using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AiriosApplication
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip // Create ToolTip and associate with the Form container
            {
                InitialDelay = 1000, // Milliseconds transpired before appearing
                ShowAlways = true // Force ToolTip text to display
            };

            // Set all necessary ToolTips
            toolTip.SetToolTip(gbGraph, "Data from sensor visualized");
            toolTip.SetToolTip(chartStats, "Data from sensor visualized");
            toolTip.SetToolTip(gbData, "Collected data from sensors");
            //MessageBox.Show(Readings.Data.Rows[0][0].ToString()); for debugging

            // Prototype plotting of temperature data (with active scaling)
            // TODO: Make a combobox with all the readings, plot the selected reading
            // TODO: Update the chart once the Form is open (timer)
            // TODO: Code cleanup, make methods for charting

            chartStats.DataSource = Readings.Data;
            chartStats.Series.Add("Temperature");
            chartStats.Series[0].XValueMember = "Timestamp";
            chartStats.Series[0].YValueMembers = "Temperature";
            chartStats.Series[0].ChartType = SeriesChartType.Line;

            // Takes care of scaling - calculates the MIN and MAX values of the column
            chartStats.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(Readings.Data.Compute("MIN(Temperature)", null)) - 1;
            chartStats.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Readings.Data.Compute("MAX(Temperature)", null)) + 1;

            chartStats.Series[0].LegendText = "Temperature";
            chartStats.Series[0].XValueType = ChartValueType.Time;
            chartStats.Series[0].YValueType = ChartValueType.Int32;
            chartStats.Series[0].BorderWidth = 8;
            chartStats.DataBind();
        }
    }
}

