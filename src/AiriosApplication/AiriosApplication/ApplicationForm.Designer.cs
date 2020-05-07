namespace AiriosApplication
{
   partial class ApplicationForm
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
         this.lbTime = new System.Windows.Forms.Label();
         this.timer = new System.Windows.Forms.Timer(this.components);
         this.lbDate = new System.Windows.Forms.Label();
         this.lbHumid = new System.Windows.Forms.Label();
         this.lbTemp = new System.Windows.Forms.Label();
         this.lbTVOC = new System.Windows.Forms.Label();
         this.lbCO2 = new System.Windows.Forms.Label();
         this.btnIncrease = new System.Windows.Forms.Button();
         this.btnDecrease = new System.Windows.Forms.Button();
         this.lbFan = new System.Windows.Forms.Label();
         this.lbUnderscore = new System.Windows.Forms.Label();
         this.btnMore = new System.Windows.Forms.Button();
         this.picFan = new System.Windows.Forms.PictureBox();
         this.picCO2 = new System.Windows.Forms.PictureBox();
         this.picTVOC = new System.Windows.Forms.PictureBox();
         this.picTemp = new System.Windows.Forms.PictureBox();
         this.picHumid = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.picFan)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.picCO2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.picTVOC)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.picTemp)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.picHumid)).BeginInit();
         this.SuspendLayout();
         // 
         // lbTime
         // 
         this.lbTime.AutoSize = true;
         this.lbTime.BackColor = System.Drawing.Color.White;
         this.lbTime.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
         this.lbTime.ForeColor = System.Drawing.Color.Black;
         this.lbTime.Location = new System.Drawing.Point(11, 41);
         this.lbTime.Name = "lbTime";
         this.lbTime.Size = new System.Drawing.Size(86, 41);
         this.lbTime.TabIndex = 0;
         this.lbTime.Text = "Time";
         // 
         // timer
         // 
         this.timer.Enabled = true;
         this.timer.Interval = 500;
         this.timer.Tick += new System.EventHandler(this.timer_Tick);
         // 
         // lbDate
         // 
         this.lbDate.AutoSize = true;
         this.lbDate.BackColor = System.Drawing.Color.White;
         this.lbDate.Font = new System.Drawing.Font("Segoe UI", 18F);
         this.lbDate.ForeColor = System.Drawing.Color.Black;
         this.lbDate.Location = new System.Drawing.Point(12, 9);
         this.lbDate.Name = "lbDate";
         this.lbDate.Size = new System.Drawing.Size(65, 32);
         this.lbDate.TabIndex = 1;
         this.lbDate.Text = "Date";
         // 
         // lbHumid
         // 
         this.lbHumid.AutoSize = true;
         this.lbHumid.BackColor = System.Drawing.Color.White;
         this.lbHumid.Font = new System.Drawing.Font("Segoe UI", 14F);
         this.lbHumid.ForeColor = System.Drawing.Color.Black;
         this.lbHumid.Location = new System.Drawing.Point(48, 144);
         this.lbHumid.Name = "lbHumid";
         this.lbHumid.Size = new System.Drawing.Size(38, 25);
         this.lbHumid.TabIndex = 2;
         this.lbHumid.Text = "0%";
         // 
         // lbTemp
         // 
         this.lbTemp.AutoSize = true;
         this.lbTemp.BackColor = System.Drawing.Color.White;
         this.lbTemp.Font = new System.Drawing.Font("Segoe UI", 14F);
         this.lbTemp.ForeColor = System.Drawing.Color.Black;
         this.lbTemp.Location = new System.Drawing.Point(48, 113);
         this.lbTemp.Name = "lbTemp";
         this.lbTemp.Size = new System.Drawing.Size(41, 25);
         this.lbTemp.TabIndex = 6;
         this.lbTemp.Text = "0°C";
         // 
         // lbTVOC
         // 
         this.lbTVOC.AutoSize = true;
         this.lbTVOC.BackColor = System.Drawing.Color.White;
         this.lbTVOC.Font = new System.Drawing.Font("Segoe UI", 14F);
         this.lbTVOC.ForeColor = System.Drawing.Color.Black;
         this.lbTVOC.Location = new System.Drawing.Point(48, 174);
         this.lbTVOC.Name = "lbTVOC";
         this.lbTVOC.Size = new System.Drawing.Size(60, 25);
         this.lbTVOC.TabIndex = 7;
         this.lbTVOC.Text = "0 ppb";
         // 
         // lbCO2
         // 
         this.lbCO2.AutoSize = true;
         this.lbCO2.BackColor = System.Drawing.Color.White;
         this.lbCO2.Font = new System.Drawing.Font("Segoe UI", 14F);
         this.lbCO2.ForeColor = System.Drawing.Color.Black;
         this.lbCO2.Location = new System.Drawing.Point(48, 205);
         this.lbCO2.Name = "lbCO2";
         this.lbCO2.Size = new System.Drawing.Size(65, 25);
         this.lbCO2.TabIndex = 8;
         this.lbCO2.Text = "0 ppm";
         // 
         // btnIncrease
         // 
         this.btnIncrease.BackColor = System.Drawing.Color.DodgerBlue;
         this.btnIncrease.ForeColor = System.Drawing.Color.White;
         this.btnIncrease.Location = new System.Drawing.Point(231, 129);
         this.btnIncrease.Name = "btnIncrease";
         this.btnIncrease.Size = new System.Drawing.Size(25, 25);
         this.btnIncrease.TabIndex = 10;
         this.btnIncrease.Text = "^";
         this.btnIncrease.UseVisualStyleBackColor = false;
         // 
         // btnDecrease
         // 
         this.btnDecrease.BackColor = System.Drawing.Color.Red;
         this.btnDecrease.ForeColor = System.Drawing.Color.White;
         this.btnDecrease.Location = new System.Drawing.Point(231, 194);
         this.btnDecrease.Name = "btnDecrease";
         this.btnDecrease.Size = new System.Drawing.Size(25, 25);
         this.btnDecrease.TabIndex = 11;
         this.btnDecrease.Text = "˅";
         this.btnDecrease.UseVisualStyleBackColor = false;
         // 
         // lbFan
         // 
         this.lbFan.AutoSize = true;
         this.lbFan.Font = new System.Drawing.Font("Segoe UI", 18F);
         this.lbFan.ForeColor = System.Drawing.Color.Black;
         this.lbFan.Location = new System.Drawing.Point(225, 157);
         this.lbFan.Name = "lbFan";
         this.lbFan.Size = new System.Drawing.Size(48, 32);
         this.lbFan.TabIndex = 12;
         this.lbFan.Text = "0%";
         // 
         // lbUnderscore
         // 
         this.lbUnderscore.Location = new System.Drawing.Point(12, 82);
         this.lbUnderscore.Name = "lbUnderscore";
         this.lbUnderscore.Size = new System.Drawing.Size(161, 21);
         this.lbUnderscore.TabIndex = 14;
         this.lbUnderscore.Text = "_____________________";
         // 
         // btnMore
         // 
         this.btnMore.BackColor = System.Drawing.Color.Transparent;
         this.btnMore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnMore.ForeColor = System.Drawing.Color.Black;
         this.btnMore.Location = new System.Drawing.Point(287, 226);
         this.btnMore.Name = "btnMore";
         this.btnMore.Size = new System.Drawing.Size(43, 21);
         this.btnMore.TabIndex = 15;
         this.btnMore.Text = "More";
         this.btnMore.UseVisualStyleBackColor = false;
         this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
         // 
         // picFan
         // 
         this.picFan.Image = global::AiriosApplication.Properties.Resources.fan;
         this.picFan.Location = new System.Drawing.Point(154, 128);
         this.picFan.Name = "picFan";
         this.picFan.Size = new System.Drawing.Size(71, 91);
         this.picFan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.picFan.TabIndex = 13;
         this.picFan.TabStop = false;
         // 
         // picCO2
         // 
         this.picCO2.BackColor = System.Drawing.Color.White;
         this.picCO2.Image = global::AiriosApplication.Properties.Resources.co2;
         this.picCO2.Location = new System.Drawing.Point(18, 206);
         this.picCO2.Name = "picCO2";
         this.picCO2.Size = new System.Drawing.Size(24, 24);
         this.picCO2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.picCO2.TabIndex = 9;
         this.picCO2.TabStop = false;
         // 
         // picTVOC
         // 
         this.picTVOC.BackColor = System.Drawing.Color.White;
         this.picTVOC.Image = global::AiriosApplication.Properties.Resources.voc;
         this.picTVOC.Location = new System.Drawing.Point(18, 175);
         this.picTVOC.Name = "picTVOC";
         this.picTVOC.Size = new System.Drawing.Size(24, 24);
         this.picTVOC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.picTVOC.TabIndex = 5;
         this.picTVOC.TabStop = false;
         // 
         // picTemp
         // 
         this.picTemp.BackColor = System.Drawing.Color.White;
         this.picTemp.Image = global::AiriosApplication.Properties.Resources.temperature;
         this.picTemp.Location = new System.Drawing.Point(18, 113);
         this.picTemp.Name = "picTemp";
         this.picTemp.Size = new System.Drawing.Size(24, 24);
         this.picTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.picTemp.TabIndex = 4;
         this.picTemp.TabStop = false;
         // 
         // picHumid
         // 
         this.picHumid.BackColor = System.Drawing.Color.White;
         this.picHumid.Image = global::AiriosApplication.Properties.Resources.humidity;
         this.picHumid.Location = new System.Drawing.Point(18, 143);
         this.picHumid.Name = "picHumid";
         this.picHumid.Size = new System.Drawing.Size(26, 26);
         this.picHumid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.picHumid.TabIndex = 3;
         this.picHumid.TabStop = false;
         // 
         // ApplicationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(342, 259);
         this.Controls.Add(this.btnMore);
         this.Controls.Add(this.lbUnderscore);
         this.Controls.Add(this.picFan);
         this.Controls.Add(this.lbFan);
         this.Controls.Add(this.btnDecrease);
         this.Controls.Add(this.btnIncrease);
         this.Controls.Add(this.picCO2);
         this.Controls.Add(this.lbCO2);
         this.Controls.Add(this.lbTVOC);
         this.Controls.Add(this.lbTemp);
         this.Controls.Add(this.picTVOC);
         this.Controls.Add(this.picTemp);
         this.Controls.Add(this.picHumid);
         this.Controls.Add(this.lbHumid);
         this.Controls.Add(this.lbDate);
         this.Controls.Add(this.lbTime);
         this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ForeColor = System.Drawing.Color.Black;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.Name = "ApplicationForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Application";
         this.Load += new System.EventHandler(this.MainForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.picFan)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.picCO2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.picTVOC)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.picTemp)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.picHumid)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

        #endregion

        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbHumid;
        private System.Windows.Forms.PictureBox picHumid;
        private System.Windows.Forms.PictureBox picTemp;
        private System.Windows.Forms.PictureBox picTVOC;
        private System.Windows.Forms.Label lbTemp;
        private System.Windows.Forms.Label lbTVOC;
        private System.Windows.Forms.Label lbCO2;
        private System.Windows.Forms.PictureBox picCO2;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Label lbFan;
        private System.Windows.Forms.PictureBox picFan;
      private System.Windows.Forms.Label lbUnderscore;
      private System.Windows.Forms.Button btnMore;
   }
}

