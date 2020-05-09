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
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToLongDateString(); // Set date
            lbTime.Text = DateTime.Now.ToShortTimeString(); // Set time
            
            if(Readings.Co2.Count != 0 && Readings.Humidity.Count != 0 && Readings.Voc.Count != 0 && Readings.Temperature.Count != 0)
            {
                lbCO2.Text = Readings.Co2[Readings.Co2.Count - 1].ToString() + " ppm";
                lbTemp.Text = Readings.Temperature[Readings.Temperature.Count - 1].ToString() + "℃";
                lbHumid.Text = Readings.Humidity[Readings.Humidity.Count - 1].ToString() + "%";
                lbTVOC.Text = Readings.Voc[Readings.Voc.Count - 1].ToString() + " ppb";
            }            
        }        

        private void MainForm_Load(object sender, EventArgs e)
        {
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
            toolTip.SetToolTip(picFan, "Fan speed in percentage of maximum attainable speed");
            toolTip.SetToolTip(lbFan, "Fan speed in percentage of maximum attainable speed");
            toolTip.SetToolTip(btnIncrease, "Increase fan speed");
            toolTip.SetToolTip(btnDecrease, "Decrease fan speed");
            Server server = new Server();
            serverThread = new Thread(server.Run);
            serverThread.Start();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(); // Create new form
            statisticsForm.ShowDialog(); // Show form            
        }

        private void ApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Readings.ShouldStop = true;
            serverThread.Abort();
        }
    }
}
