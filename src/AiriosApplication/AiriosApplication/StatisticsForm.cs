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
        private delegate void GraphHandler();
        private GraphHandler grapher;
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
            
            // TODO: Make a combobox with all the readings, plot the selected reading
            // TODO: Update the chart once the Form is open (timer)            

            chartStats.DataSource = Readings.Data;
            chartStats.DataBind();
            grapher = GraphTemperature;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            grapher = GraphTemperature;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            grapher = GraphHumidity;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            grapher = GraphCO2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            grapher = GraphVOC;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            grapher();
        }

        private void GraphTemperature()
        {
            chartStats.Series.Clear();
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
            chartStats.Series[0].BorderWidth = 6;            
        }

        private void GraphHumidity()
        {
            chartStats.Series.Clear();
            chartStats.Series.Add("Humidity");
            chartStats.Series[0].XValueMember = "Timestamp";
            chartStats.Series[0].YValueMembers = "Humidity";
            chartStats.Series[0].ChartType = SeriesChartType.Line;
            
            chartStats.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(Readings.Data.Compute("MIN(Humidity)", null)) - 5;
            chartStats.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Readings.Data.Compute("MAX(Humidity)", null)) + 5;

            chartStats.Series[0].LegendText = "Humidity";
            chartStats.Series[0].XValueType = ChartValueType.Time;
            chartStats.Series[0].YValueType = ChartValueType.Int32;
            chartStats.Series[0].BorderWidth = 6;            
        }

        private void GraphCO2()
        {
            chartStats.Series.Clear();
            chartStats.Series.Add("CO2");
            chartStats.Series[0].XValueMember = "Timestamp";
            chartStats.Series[0].YValueMembers = "CO2";
            chartStats.Series[0].ChartType = SeriesChartType.Line;

            chartStats.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(Readings.Data.Compute("MIN(CO2)", null)) - 5;
            chartStats.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Readings.Data.Compute("MAX(CO2)", null)) + 5;

            chartStats.Series[0].LegendText = "CO2";
            chartStats.Series[0].XValueType = ChartValueType.Time;
            chartStats.Series[0].YValueType = ChartValueType.Int32;
            chartStats.Series[0].BorderWidth = 6;
        }

        private void GraphVOC()
        {
            chartStats.Series.Clear();
            chartStats.Series.Add("VOC");
            chartStats.Series[0].XValueMember = "Timestamp";
            chartStats.Series[0].YValueMembers = "VOC";
            chartStats.Series[0].ChartType = SeriesChartType.Line;
            
            chartStats.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(Readings.Data.Compute("MIN(VOC)", null)) - 5;
            chartStats.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Readings.Data.Compute("MAX(VOC)", null)) + 5;

            chartStats.Series[0].LegendText = "VOC";
            chartStats.Series[0].XValueType = ChartValueType.Time;
            chartStats.Series[0].YValueType = ChartValueType.Int32;
            chartStats.Series[0].BorderWidth = 6;
        }
        
    }
}

