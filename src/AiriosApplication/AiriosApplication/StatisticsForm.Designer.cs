namespace AiriosApplication
{
   partial class StatisticsForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbGraph = new System.Windows.Forms.GroupBox();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTemperature = new System.Windows.Forms.RadioButton();
            this.rbHumidity = new System.Windows.Forms.RadioButton();
            this.rbVOC = new System.Windows.Forms.RadioButton();
            this.rbCO2 = new System.Windows.Forms.RadioButton();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAllTime = new System.Windows.Forms.CheckBox();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).BeginInit();
            this.gbGraph.SuspendLayout();
            this.gbData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStats
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStats.Legends.Add(legend1);
            this.chartStats.Location = new System.Drawing.Point(8, 28);
            this.chartStats.Name = "chartStats";
            this.chartStats.Size = new System.Drawing.Size(1439, 382);
            this.chartStats.TabIndex = 0;
            this.chartStats.Text = "Measured data";
            // 
            // gbGraph
            // 
            this.gbGraph.Controls.Add(this.chartStats);
            this.gbGraph.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGraph.Location = new System.Drawing.Point(12, 12);
            this.gbGraph.Name = "gbGraph";
            this.gbGraph.Size = new System.Drawing.Size(1453, 416);
            this.gbGraph.TabIndex = 1;
            this.gbGraph.TabStop = false;
            this.gbGraph.Text = "Graph";
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.dgvData);
            this.gbData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(7, 473);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(1458, 275);
            this.gbData.TabIndex = 2;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(13, 28);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(1439, 246);
            this.dgvData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Graph:";
            // 
            // rbTemperature
            // 
            this.rbTemperature.AutoSize = true;
            this.rbTemperature.Checked = true;
            this.rbTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTemperature.Location = new System.Drawing.Point(124, 440);
            this.rbTemperature.Name = "rbTemperature";
            this.rbTemperature.Size = new System.Drawing.Size(110, 22);
            this.rbTemperature.TabIndex = 3;
            this.rbTemperature.TabStop = true;
            this.rbTemperature.Text = "Temperature";
            this.rbTemperature.UseVisualStyleBackColor = true;
            // 
            // rbHumidity
            // 
            this.rbHumidity.AutoSize = true;
            this.rbHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHumidity.Location = new System.Drawing.Point(253, 440);
            this.rbHumidity.Name = "rbHumidity";
            this.rbHumidity.Size = new System.Drawing.Size(83, 22);
            this.rbHumidity.TabIndex = 4;
            this.rbHumidity.Text = "Humidity";
            this.rbHumidity.UseVisualStyleBackColor = true;
            // 
            // rbVOC
            // 
            this.rbVOC.AutoSize = true;
            this.rbVOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVOC.Location = new System.Drawing.Point(429, 440);
            this.rbVOC.Name = "rbVOC";
            this.rbVOC.Size = new System.Drawing.Size(58, 22);
            this.rbVOC.TabIndex = 6;
            this.rbVOC.Text = "VOC";
            this.rbVOC.UseVisualStyleBackColor = true;
            // 
            // rbCO2
            // 
            this.rbCO2.AutoSize = true;
            this.rbCO2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCO2.Location = new System.Drawing.Point(353, 440);
            this.rbCO2.Name = "rbCO2";
            this.rbCO2.Size = new System.Drawing.Size(57, 22);
            this.rbCO2.TabIndex = 5;
            this.rbCO2.Text = "CO2";
            this.rbCO2.UseVisualStyleBackColor = true;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(663, 440);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 24);
            this.dtpDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(505, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select date to graph";
            // 
            // cbAllTime
            // 
            this.cbAllTime.AutoSize = true;
            this.cbAllTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllTime.Location = new System.Drawing.Point(887, 441);
            this.cbAllTime.Name = "cbAllTime";
            this.cbAllTime.Size = new System.Drawing.Size(143, 22);
            this.cbAllTime.TabIndex = 9;
            this.cbAllTime.Text = "Show all readings";
            this.cbAllTime.UseVisualStyleBackColor = true;
            this.cbAllTime.CheckedChanged += new System.EventHandler(this.cbAllTime_CheckedChanged);
            // 
            // cmbDevice
            // 
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(1308, 439);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(151, 26);
            this.cmbDevice.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1036, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select which device\'s readings to graph";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1477, 760);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDevice);
            this.Controls.Add(this.cbAllTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.rbVOC);
            this.Controls.Add(this.rbCO2);
            this.Controls.Add(this.rbHumidity);
            this.Controls.Add(this.rbTemperature);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.gbGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StatisticsForm";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).EndInit();
            this.gbGraph.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStats;
        private System.Windows.Forms.GroupBox gbGraph;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbTemperature;
        private System.Windows.Forms.RadioButton rbHumidity;
        private System.Windows.Forms.RadioButton rbVOC;
        private System.Windows.Forms.RadioButton rbCO2;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAllTime;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.Label label3;
    }
}