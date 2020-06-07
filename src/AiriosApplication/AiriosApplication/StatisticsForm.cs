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

            // the default view of the dataTable has the data that is needed for graphing filtered (as in it's in the selected by the user timeframe)
            chartStats.DataSource = Readings.Data.DefaultView;
            chartStats.DataBind();

            dgvData.DataSource = Readings.Data;
            for (short i = 0; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            cmbDevice.DataSource = ApplicationForm.ConnectedDevices;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (rbTemperature.Checked)
                Graph("Temperature");
            else if (rbHumidity.Checked)
                Graph("Humidity");
            else if (rbVOC.Checked)
                Graph("VOC");
            else if (rbCO2.Checked)
                Graph("CO2");
        }

        private void Graph(string column)
        {
            chartStats.Series.Clear();
            chartStats.Series.Add(column);

            if (!cbAllTime.Checked)
            { 
                // this beauty here makes sure that if a certain day is selected we only graph the values from that day from the selected device
                Readings.Data.DefaultView.RowFilter = "Timestamp > '" + dtpDate.Value.Date + "' and Timestamp < '" + dtpDate.Value.Date.AddDays(1) 
                    + "' AND IP = '" + cmbDevice.SelectedItem.ToString() + "'";
                chartStats.Series[0].XValueType = ChartValueType.Time;
            }
            else
            { 
                // if the user wants everything graphed we remove the filter and only leave the device filter
                Readings.Data.DefaultView.RowFilter = "IP = '" + cmbDevice.SelectedItem.ToString() + "'"; 
                chartStats.Series[0].XValueType = ChartValueType.DateTime;
            }

            chartStats.Series[0].XValueMember = "Timestamp";
            chartStats.Series[0].YValueMembers = column;
            chartStats.Series[0].ChartType = SeriesChartType.Line;

            try
            {
                // we make a copy of the default view for dynamic scaling - otherwise if one day has high 
                // values all of them will have a maximal Y axis value that is way too high and the graph looks ugly
                DataTable dynamicScalingTable = Readings.Data.DefaultView.ToTable();
                chartStats.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(dynamicScalingTable.Compute("MIN(" + column + ")", null)) - 5;
                chartStats.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(dynamicScalingTable.Compute("MAX(" + column + ")", null)) + 5;

                // temperature varies less so less scaling for it
                if (column == "Temperature")
                {
                    chartStats.ChartAreas[0].AxisY.Minimum += 4;
                    chartStats.ChartAreas[0].AxisY.Maximum -= 4;
                }
            }
            catch (Exception) { }
            // The compute function causes some problems            

            chartStats.Series[0].LegendText = column;
            chartStats.Series[0].YValueType = ChartValueType.Int32;
            chartStats.Series[0].BorderWidth = 6;
        }
       
        private void cbAllTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = !dtpDate.Enabled;
        }
    }
}