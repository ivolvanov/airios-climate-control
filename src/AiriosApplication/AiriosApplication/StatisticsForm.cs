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

            dgvData.DataSource = Readings.Data.DefaultView;
            dgvData.Font = cmbDevice.Font;
            cmbDevice.DataSource = ApplicationForm.ConnectedDevices;

            // styling
            for (short i = 0; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[i].DefaultCellStyle.BackColor = Color.FromArgb(48, 51, 107);
                dgvData.Columns[i].DefaultCellStyle.ForeColor = Color.FromArgb(223, 249, 251);
            }
            updateTimer.Start();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Stop();
            lock (Readings.readingsLock)
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
            updateTimer.Start();
        }

        private void Graph(string column)
        {
            if (!cbAllTime.Checked)
            {
                // this beauty here makes sure that if a certain day is selected we only graph the values from that day from the selected device                
                Readings.Data.DefaultView.RowFilter = "Timestamp > '" + dtpDate.Value.Date + "' and Timestamp < '" + dtpDate.Value.Date.AddDays(1)
                  + "' AND ID = '" + cmbDevice.SelectedItem.ToString() + "'";
                chartStats.Series[0].XValueType = ChartValueType.Time;
            }
            else
            {
                // if the user wants everything graphed we remove the filter and only leave the device filter                
                Readings.Data.DefaultView.RowFilter = "ID = '" + cmbDevice.SelectedItem.ToString() + "'";
                chartStats.Series[0].XValueType = ChartValueType.DateTime;
            }

            // any other way of binding the data I tried causes a threading issue because of the .DataSource property
            chartStats.DataSource = Readings.Data.DefaultView;
            chartStats.Series[0].XValueMember = "Timestamp";
            chartStats.Series[0].YValueMembers = column;
            chartStats.DataBind();

            // we make a copy of the default view for dynamic scaling - otherwise if one day has high 
            // values all of them will have a maximal Y axis value that is way too high and the graph looks ugly
            DataTable dynamicScalingTable;
            dynamicScalingTable = Readings.Data.DefaultView.ToTable();
            if (dynamicScalingTable.Rows.Count != 0)    // if a day with no readings is selected
            {
                chartStats.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(dynamicScalingTable.Compute("MIN(" + column + ")", null)) - 5;
                chartStats.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(dynamicScalingTable.Compute("MAX(" + column + ")", null)) + 5;
            }
            // temperature varies less so less scaling for it
            if (column == "Temperature")
            {
                chartStats.ChartAreas[0].AxisY.Minimum += 4;
                chartStats.ChartAreas[0].AxisY.Maximum -= 4;
            }
        }

        private void cbAllTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = !dtpDate.Enabled;
        }

        private void rbTemperature_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTemperature.Checked)
                Graph("Temperature");
        }

        private void rbHumidity_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHumidity.Checked)
                Graph("Humidity");
        }

        private void rbCO2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCO2.Checked)
                Graph("CO2");
        }

        private void rbVOC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVOC.Checked)
                Graph("VOC");
        }
    }
}

