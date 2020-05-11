namespace AiriosApplication
{
   partial class VentilationForm
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
         this.picFan = new System.Windows.Forms.PictureBox();
         this.btnIncrease = new System.Windows.Forms.Button();
         this.btnDecrease = new System.Windows.Forms.Button();
         this.gbFanSpeed = new System.Windows.Forms.GroupBox();
         this.lbFanSpeed = new System.Windows.Forms.Label();
         this.btnConnect = new System.Windows.Forms.Button();
         this.cmbConnected = new System.Windows.Forms.ComboBox();
         this.serialPort = new System.IO.Ports.SerialPort(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.picFan)).BeginInit();
         this.gbFanSpeed.SuspendLayout();
         this.SuspendLayout();
         // 
         // picFan
         // 
         this.picFan.Image = global::AiriosApplication.Properties.Resources.fan;
         this.picFan.Location = new System.Drawing.Point(12, 8);
         this.picFan.Name = "picFan";
         this.picFan.Size = new System.Drawing.Size(91, 90);
         this.picFan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.picFan.TabIndex = 0;
         this.picFan.TabStop = false;
         // 
         // btnIncrease
         // 
         this.btnIncrease.BackColor = System.Drawing.Color.DodgerBlue;
         this.btnIncrease.Location = new System.Drawing.Point(109, 12);
         this.btnIncrease.Name = "btnIncrease";
         this.btnIncrease.Size = new System.Drawing.Size(40, 40);
         this.btnIncrease.TabIndex = 1;
         this.btnIncrease.Text = "^";
         this.btnIncrease.UseVisualStyleBackColor = false;
         this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
         // 
         // btnDecrease
         // 
         this.btnDecrease.BackColor = System.Drawing.Color.Red;
         this.btnDecrease.Location = new System.Drawing.Point(109, 58);
         this.btnDecrease.Name = "btnDecrease";
         this.btnDecrease.Size = new System.Drawing.Size(40, 40);
         this.btnDecrease.TabIndex = 2;
         this.btnDecrease.Text = "˅";
         this.btnDecrease.UseVisualStyleBackColor = false;
         this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
         // 
         // gbFanSpeed
         // 
         this.gbFanSpeed.Controls.Add(this.lbFanSpeed);
         this.gbFanSpeed.Font = new System.Drawing.Font("Segoe UI", 16F);
         this.gbFanSpeed.Location = new System.Drawing.Point(155, -1);
         this.gbFanSpeed.Name = "gbFanSpeed";
         this.gbFanSpeed.Size = new System.Drawing.Size(86, 99);
         this.gbFanSpeed.TabIndex = 3;
         this.gbFanSpeed.TabStop = false;
         this.gbFanSpeed.Text = "%";
         // 
         // lbFanSpeed
         // 
         this.lbFanSpeed.AutoSize = true;
         this.lbFanSpeed.Font = new System.Drawing.Font("Segoe UI", 25F);
         this.lbFanSpeed.Location = new System.Drawing.Point(6, 32);
         this.lbFanSpeed.Name = "lbFanSpeed";
         this.lbFanSpeed.Size = new System.Drawing.Size(38, 46);
         this.lbFanSpeed.TabIndex = 0;
         this.lbFanSpeed.Text = "0";
         this.lbFanSpeed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbFanSpeed_MouseClick);
         // 
         // btnConnect
         // 
         this.btnConnect.Enabled = false;
         this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 10F);
         this.btnConnect.Location = new System.Drawing.Point(12, 104);
         this.btnConnect.Name = "btnConnect";
         this.btnConnect.Size = new System.Drawing.Size(91, 28);
         this.btnConnect.TabIndex = 4;
         this.btnConnect.Text = "Connect";
         this.btnConnect.UseVisualStyleBackColor = true;
         this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
         // 
         // cmbConnected
         // 
         this.cmbConnected.Enabled = false;
         this.cmbConnected.Font = new System.Drawing.Font("Segoe UI", 10F);
         this.cmbConnected.FormattingEnabled = true;
         this.cmbConnected.Location = new System.Drawing.Point(109, 107);
         this.cmbConnected.Name = "cmbConnected";
         this.cmbConnected.Size = new System.Drawing.Size(76, 25);
         this.cmbConnected.TabIndex = 5;
         this.cmbConnected.DropDown += new System.EventHandler(this.cmbConnected_DropDown);
         // 
         // VentilationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(254, 146);
         this.Controls.Add(this.cmbConnected);
         this.Controls.Add(this.btnConnect);
         this.Controls.Add(this.gbFanSpeed);
         this.Controls.Add(this.btnDecrease);
         this.Controls.Add(this.btnIncrease);
         this.Controls.Add(this.picFan);
         this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.Name = "VentilationForm";
         this.Text = "Ventilation Box";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VentilationForm_FormClosing);
         this.Load += new System.EventHandler(this.VentilationForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.picFan)).EndInit();
         this.gbFanSpeed.ResumeLayout(false);
         this.gbFanSpeed.PerformLayout();
         this.ResumeLayout(false);

      }

        #endregion

        private System.Windows.Forms.PictureBox picFan;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.GroupBox gbFanSpeed;
        private System.Windows.Forms.Label lbFanSpeed;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbConnected;
      private System.IO.Ports.SerialPort serialPort;
   }
}