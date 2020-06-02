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
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.radioButton3 = new System.Windows.Forms.RadioButton();
         this.radioButton4 = new System.Windows.Forms.RadioButton();
         this.updateTimer = new System.Windows.Forms.Timer(this.components);
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
         this.chartStats.Size = new System.Drawing.Size(1358, 382);
         this.chartStats.TabIndex = 0;
         this.chartStats.Text = "Measured data";
         // 
         // gbGraph
         // 
         this.gbGraph.Controls.Add(this.chartStats);
         this.gbGraph.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.gbGraph.Location = new System.Drawing.Point(12, 12);
         this.gbGraph.Name = "gbGraph";
         this.gbGraph.Size = new System.Drawing.Size(1372, 416);
         this.gbGraph.TabIndex = 1;
         this.gbGraph.TabStop = false;
         this.gbGraph.Text = "Graph";
         // 
         // gbData
         // 
         this.gbData.Controls.Add(this.dgvData);
         this.gbData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.gbData.Location = new System.Drawing.Point(7, 468);
         this.gbData.Name = "gbData";
         this.gbData.Size = new System.Drawing.Size(1377, 203);
         this.gbData.TabIndex = 2;
         this.gbData.TabStop = false;
         this.gbData.Text = "Data";
         // 
         // dgvData
         // 
         this.dgvData.AllowUserToAddRows = false;
         this.dgvData.AllowUserToDeleteRows = false;
         this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvData.Location = new System.Drawing.Point(0, 28);
         this.dgvData.Name = "dgvData";
         this.dgvData.ReadOnly = true;
         this.dgvData.Size = new System.Drawing.Size(1364, 169);
         this.dgvData.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(420, 442);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(53, 18);
         this.label1.TabIndex = 1;
         this.label1.Text = "Graph:";
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Checked = true;
         this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.radioButton1.Location = new System.Drawing.Point(514, 440);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(110, 22);
         this.radioButton1.TabIndex = 3;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "Temperature";
         this.radioButton1.UseVisualStyleBackColor = true;
         this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
         // 
         // radioButton2
         // 
         this.radioButton2.AutoSize = true;
         this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.radioButton2.Location = new System.Drawing.Point(643, 440);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(83, 22);
         this.radioButton2.TabIndex = 4;
         this.radioButton2.Text = "Humidity";
         this.radioButton2.UseVisualStyleBackColor = true;
         this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
         // 
         // radioButton3
         // 
         this.radioButton3.AutoSize = true;
         this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.radioButton3.Location = new System.Drawing.Point(826, 440);
         this.radioButton3.Name = "radioButton3";
         this.radioButton3.Size = new System.Drawing.Size(58, 22);
         this.radioButton3.TabIndex = 6;
         this.radioButton3.Text = "VOC";
         this.radioButton3.UseVisualStyleBackColor = true;
         this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
         // 
         // radioButton4
         // 
         this.radioButton4.AutoSize = true;
         this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.radioButton4.Location = new System.Drawing.Point(747, 440);
         this.radioButton4.Name = "radioButton4";
         this.radioButton4.Size = new System.Drawing.Size(57, 22);
         this.radioButton4.TabIndex = 5;
         this.radioButton4.Text = "CO2";
         this.radioButton4.UseVisualStyleBackColor = true;
         this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
         // 
         // updateTimer
         // 
         this.updateTimer.Enabled = true;
         this.updateTimer.Interval = 1000;
         this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
         // 
         // StatisticsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(1396, 683);
         this.Controls.Add(this.radioButton3);
         this.Controls.Add(this.radioButton4);
         this.Controls.Add(this.radioButton2);
         this.Controls.Add(this.radioButton1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.gbData);
         this.Controls.Add(this.gbGraph);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "StatisticsForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Timer updateTimer;
    }
}