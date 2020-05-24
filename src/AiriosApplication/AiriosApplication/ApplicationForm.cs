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
        Thread serverThread;
        private List<string> connectedDevices = new List<string>();
        private string selectedDevice;
        private bool once = true; // used for initialization of selectedDevice in the timer

        public ApplicationForm()
        {
            InitializeComponent();
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
                        SetColor(lbCO2, i, "CO2", 0, 1000, 2000, 1000, 2000);

                        lbTemp.Text = Readings.Data.Rows[i]["Temperature"].ToString() + "℃";
                        SetColor(lbTemp, i, "Temperature", 15, 25, 35, 5, 15);

                        lbHumid.Text = Readings.Data.Rows[i]["Humidity"].ToString() + "%";
                        SetColor(lbHumid, i, "Humidity", 35, 65, 85, 25, 35);

                        lbTVOC.Text = Readings.Data.Rows[i]["VOC"].ToString() + " ppb";
                        SetColor(lbTVOC, i, "VOC", 0, 350, 500, 350, 500);                        

                        lbIP.Text = Readings.Data.Rows[i]["IP"].ToString();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the color to the given label using the given parameters
        /// </summary>
        /// <param name="label">Which label's color to change</param>
        /// <param name="row">Which row of DataTable to take the readings from</param>
        /// <param name="column">Which column of DataTable to take the readings from</param>
        /// <param name="greenLower">The lower threshold for the label to be green</param>
        /// <param name="greenUpper">The upper threshold for the label to be green</param>
        /// <param name="orangeUpper">The upper threshold for the label to be orange</param>
        /// <param name="orangeLower1">Another lower threshold for the label to be orange, in case there's 2 regions where the reading could be orange</param>
        /// <param name="orangeUpper1">Another upper threshold for the label to be orange, in case there's 2 regions where the reading could be orange</param>
        private void SetColor(Label label, int row, string column, int greenLower, int greenUpper,
            int orangeUpper, int orangeLower1, int orangeUpper1)
        {
            if (Convert.ToDouble(Readings.Data.Rows[row][column]) > greenLower && Convert.ToDouble(Readings.Data.Rows[row][column]) < greenUpper)
                label.ForeColor = Color.Green;
            else if ((Convert.ToDouble(Readings.Data.Rows[row][column]) >= greenUpper && Convert.ToDouble(Readings.Data.Rows[row][column]) <= orangeUpper) ||
                (Convert.ToDouble(Readings.Data.Rows[row][column]) >= orangeLower1 && Convert.ToDouble(Readings.Data.Rows[row][column]) <= orangeUpper1))
                label.ForeColor = Color.Orange;
            else
                label.ForeColor = Color.Red;
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
            new VentilationForm().Show();
        }

        private void autoSaver_Tick(object sender, EventArgs e)
        {
            // periodically saves the readings taken (currently once every 10 mins)
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

        private void panelSwitch_MouseClick(object sender, MouseEventArgs e)
        {
            // switches the label values if another device is connected 
            if (connectedDevices.Count != 0)
            {
                if (connectedDevices.IndexOf(selectedDevice) != connectedDevices.Count - 1)
                    selectedDevice = connectedDevices[connectedDevices.IndexOf(selectedDevice) + 1];
                else
                    selectedDevice = connectedDevices[0];
            }
        }

        private void ApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
    }
}
