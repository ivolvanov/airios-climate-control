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
        //TODO: Include status message
        //TODO: Implement protocol checking (make sure that the message received is protocol-compliant)
        //TODO: Take values from corrupt messages (so that when only one sensor breaks the others keep giving readings)
        Thread serverThread;

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

        private void timer_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToLongDateString(); // Set date
            lbTime.Text = DateTime.Now.ToShortTimeString(); // Set time

            // TODO: once first module connected, display its values. If disconnected, display initial values (all 0's)
            // NEW: now using a DataTable for readability and easiler linking to chart
            if (Readings.Data.Rows.Count != 0)
            {
                lbCO2.Text = Readings.Data.Rows[Readings.Data.Rows.Count - 1]["CO2"].ToString() + " ppm";
                lbTemp.Text = Readings.Data.Rows[Readings.Data.Rows.Count - 1]["Temperature"].ToString() + "℃";
                lbHumid.Text = Readings.Data.Rows[Readings.Data.Rows.Count - 1]["Humidity"].ToString() + "%";
                lbTVOC.Text = Readings.Data.Rows[Readings.Data.Rows.Count - 1]["VOC"].ToString() + " ppb";
                lbIP.Text = Readings.Data.Rows[Readings.Data.Rows.Count - 1]["IP"].ToString();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Server server = new Server();
            serverThread = new Thread(server.Run);
            serverThread.Start();

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
            if(fileStream.Length != 0)
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
            if (Readings.Data.Rows.Count != 0)
            {                
                StatisticsForm statisticsForm = new StatisticsForm(); // Create new form
                statisticsForm.Show();
            }
            else
                MessageBox.Show("There are no readings taken yet!");
        }

        private void SwitchValues()
        {
            // TODO: display values of possible other connected modules
            lbTemp.Text = "clicked";
            lbHumid.Text = "clicked";
            lbTVOC.Text = "clicked";
            lbCO2.Text = "clicked";
            lbIP.Text = "clicked";
        }

        private void picTemp_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void picHumid_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void picTVOC_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void picCO2_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void picIP_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void lbTemp_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void lbHumid_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void lbTVOC_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void lbCO2_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
        }

        private void lbIP_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchValues();
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
    }
}
