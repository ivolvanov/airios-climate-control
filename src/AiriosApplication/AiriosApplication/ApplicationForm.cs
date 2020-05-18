using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace AiriosApplication
{
   public partial class ApplicationForm : Form
   {
      //TODO: Implement protocol checking (make sure that the message received is protocol-compliant)
      //TODO: Take values from corrupt messages (so that when only one sensor breaks the others keep giving readings)
      Dictionary<string, Label> labelNames = new Dictionary<string, Label>();
      Thread serverThread;
      private List<string> connectedDevices = new List<string>();
      private string selectedDevice;
      private bool once = true; // used for initialization of selectedDevice in the timer

      public ApplicationForm()
      {
         InitializeComponent();
         labelNames = new Dictionary<string, Label>();
         labelNames["CO2"] = lbCO2;
         labelNames["Temperature"] = lbTemp;
         labelNames["Humidity"] = lbHumid;
         labelNames["VOC"] = lbTVOC; ;
         labelNames["IP"] = lbIP;
         lbDate.Text = DateTime.Now.ToLongDateString(); // Set date
         lbTime.Text = DateTime.Now.ToShortTimeString(); // Set time
         ToolTip toolTip = new ToolTip // Create ToolTip and associate with the Form container
         {
            InitialDelay = 1000, // Milliseconds transpired before appearing
            ShowAlways = true // Force ToolTip text to display
         };
         // Set all necessary ToolTips
         toolTip.SetToolTip(lbDate, "Current date");
         toolTip.SetToolTip(lbTime, "Current time");
         toolTip.SetToolTip(picTemp, "Temperature in degrees Celsius");
         toolTip.SetToolTip(lbTemp, "Temperature in degrees Celsius");
         toolTip.SetToolTip(picHumid, "Relative humidity in percentages");
         toolTip.SetToolTip(lbHumid, "Relative humidity in percentages");
         toolTip.SetToolTip(picTVOC, "Total volatile organic compounds in parts-per-billion");
         toolTip.SetToolTip(lbTVOC, "Total volatile organic compounds in parts-per-billion");
         toolTip.SetToolTip(picCO2, "Carbon dioxide in parts-per-million");
         toolTip.SetToolTip(lbCO2, "Carbon dioxide in parts-per-million");
         toolTip.SetToolTip(picIP, "Current IP being displayed\nClick on any icon or value to switch between modules");
         toolTip.SetToolTip(lbIP, "Current IP being displayed\nClick on any icon or value to switch between modules");
      }

      private void dataRefreshTimer_Tick(object sender, EventArgs e)
      {
         lbDate.Text = DateTime.Now.ToLongDateString(); // Set date
         lbTime.Text = DateTime.Now.ToShortTimeString(); // Set time

         // TODO: once first module connected, display its values. If disconnected, display initial values (all 0's)            
         if (Readings.Data.Rows.Count != 0)
         {
            if (once)
            {
               selectedDevice = Readings.Data.Rows[Readings.Data.Rows.Count - 1]["IP"].ToString();
               once = false;
            }
            if (!connectedDevices.Contains(Readings.Data.Rows[Readings.Data.Rows.Count - 1]["IP"].ToString()))
               connectedDevices.Add(Readings.Data.Rows[Readings.Data.Rows.Count - 1]["IP"].ToString());
            for (int i = Readings.Data.Rows.Count - 1; i >= 0; i--)
            {
               if (Readings.Data.Rows[i]["IP"].ToString() == selectedDevice)
               {
                  lbCO2.Text = Readings.Data.Rows[i]["CO2"].ToString() + " ppm";
                  SetColor(i, "CO2");
                  lbTemp.Text = Readings.Data.Rows[i]["Temperature"].ToString() + "℃";
                  SetColor(i, "Temperature");
                  lbHumid.Text = Readings.Data.Rows[i]["Humidity"].ToString() + "%";
                  SetColor(i, "Humidity");
                  lbTVOC.Text = Readings.Data.Rows[i]["VOC"].ToString() + " ppb";
                  SetColor(i, "VOC");
                  lbIP.Text = Readings.Data.Rows[i]["IP"].ToString();
                  SetColor(i, "IP");
                  break;
               }
            }
         }
      }

      private void SetColor(int row, string column)
      {
         if (Convert.ToInt32(Readings.Data.Rows[row][column]) >= 2000) labelNames[column].ForeColor = Color.Red;
         else if (Convert.ToInt32(Readings.Data.Rows[row][column]) >= 1000 && Convert.ToInt32(Readings.Data.Rows[row][column]) < 2000) labelNames[column].ForeColor = Color.Orange;
         else if (Convert.ToInt32(Readings.Data.Rows[row][column]) < 1000) labelNames[column].ForeColor = Color.Green;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Server server = new Server();
         serverThread = new Thread(server.Run);
         serverThread.Start();

         // initializes the table
         Readings.Data.TableName = "Readings";
         Readings.Data.Columns.Add("Timestamp", typeof(DateTime));
         Readings.Data.Columns.Add("Temperature", typeof(double));
         Readings.Data.Columns.Add("Humidity", typeof(double));
         Readings.Data.Columns.Add("CO2", typeof(int));
         Readings.Data.Columns.Add("VOC", typeof(int));
         Readings.Data.Columns.Add("IP", typeof(string));

         // TODO: put in a separate method
         // takes care of loading the previous readings
         FileStream fileStream = new FileStream("Readings.xml", FileMode.OpenOrCreate);
         if (fileStream.Length != 0)
         {
            try
            {
               Readings.Data.ReadXml(fileStream);
               fileStream.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            finally
            {
               fileStream.Close();
            }
         }
         else
            fileStream.Close();

         dataRefreshTimer.Start();
         autoSaver.Start();
      }

      private void btnMore_Click(object sender, EventArgs e)
      {
         // opens a new form if there are any readings taken
         if (Readings.Data.Rows.Count != 0)
         {
            StatisticsForm statisticsForm = new StatisticsForm(); // Create new form
            statisticsForm.Show();
         }
         else
            MessageBox.Show("There are no readings taken yet!");
      }

      private void btnFan_Click(object sender, EventArgs e)
      {
         new Thread(() => new VentilationForm().ShowDialog()).Start();
      }

      private void autoSaver_Tick(object sender, EventArgs e)
      {
         // TODO: change interval
         // periodically saves the readings taken
         FileStream fileStream = new FileStream("Readings.xml", FileMode.Open);
         try
         {
            Readings.Data.WriteXml(fileStream);
            fileStream.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
         finally
         {
            fileStream.Close();
         }
      }

      private void Clicked(object sender, MouseEventArgs e)
      {
         // switches the label values if another device is connected
         if (connectedDevices.IndexOf(selectedDevice) != connectedDevices.Count - 1)
            selectedDevice = connectedDevices[connectedDevices.IndexOf(selectedDevice) + 1];
         else
            selectedDevice = connectedDevices[0];
      }
   }
}
