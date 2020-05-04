namespace smtpProtocol
{
   partial class Gmail
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
         this.btnSend = new System.Windows.Forms.Button();
         this.tbFrom = new System.Windows.Forms.TextBox();
         this.tbTo = new System.Windows.Forms.TextBox();
         this.tbSubject = new System.Windows.Forms.TextBox();
         this.tbBody = new System.Windows.Forms.TextBox();
         this.tbUsername = new System.Windows.Forms.TextBox();
         this.tbPassword = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.gbMail = new System.Windows.Forms.GroupBox();
         this.gbCredentials = new System.Windows.Forms.GroupBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.gbMail.SuspendLayout();
         this.gbCredentials.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnSend
         // 
         this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnSend.Location = new System.Drawing.Point(6, 392);
         this.btnSend.Name = "btnSend";
         this.btnSend.Size = new System.Drawing.Size(93, 28);
         this.btnSend.TabIndex = 0;
         this.btnSend.Text = "Send email";
         this.btnSend.UseVisualStyleBackColor = true;
         this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
         // 
         // tbFrom
         // 
         this.tbFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbFrom.Location = new System.Drawing.Point(72, 32);
         this.tbFrom.Name = "tbFrom";
         this.tbFrom.Size = new System.Drawing.Size(170, 25);
         this.tbFrom.TabIndex = 1;
         // 
         // tbTo
         // 
         this.tbTo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbTo.Location = new System.Drawing.Point(72, 61);
         this.tbTo.Name = "tbTo";
         this.tbTo.Size = new System.Drawing.Size(170, 25);
         this.tbTo.TabIndex = 2;
         // 
         // tbSubject
         // 
         this.tbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbSubject.Location = new System.Drawing.Point(72, 92);
         this.tbSubject.Name = "tbSubject";
         this.tbSubject.Size = new System.Drawing.Size(92, 22);
         this.tbSubject.TabIndex = 3;
         // 
         // tbBody
         // 
         this.tbBody.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbBody.Location = new System.Drawing.Point(6, 117);
         this.tbBody.Multiline = true;
         this.tbBody.Name = "tbBody";
         this.tbBody.Size = new System.Drawing.Size(288, 268);
         this.tbBody.TabIndex = 4;
         // 
         // tbUsername
         // 
         this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbUsername.Location = new System.Drawing.Point(6, 55);
         this.tbUsername.Name = "tbUsername";
         this.tbUsername.Size = new System.Drawing.Size(170, 25);
         this.tbUsername.TabIndex = 5;
         // 
         // tbPassword
         // 
         this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbPassword.Location = new System.Drawing.Point(6, 115);
         this.tbPassword.Name = "tbPassword";
         this.tbPassword.PasswordChar = '*';
         this.tbPassword.Size = new System.Drawing.Size(100, 27);
         this.tbPassword.TabIndex = 6;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(20, 33);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(46, 20);
         this.label1.TabIndex = 7;
         this.label1.Text = "From:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(5, 94);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(61, 20);
         this.label2.TabIndex = 8;
         this.label2.Text = "Subject:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(38, 66);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(28, 20);
         this.label3.TabIndex = 9;
         this.label3.Text = "To:";
         // 
         // gbMail
         // 
         this.gbMail.Controls.Add(this.tbBody);
         this.gbMail.Controls.Add(this.label3);
         this.gbMail.Controls.Add(this.btnSend);
         this.gbMail.Controls.Add(this.label2);
         this.gbMail.Controls.Add(this.tbFrom);
         this.gbMail.Controls.Add(this.label1);
         this.gbMail.Controls.Add(this.tbTo);
         this.gbMail.Controls.Add(this.tbSubject);
         this.gbMail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.gbMail.Location = new System.Drawing.Point(12, 12);
         this.gbMail.Name = "gbMail";
         this.gbMail.Size = new System.Drawing.Size(300, 426);
         this.gbMail.TabIndex = 10;
         this.gbMail.TabStop = false;
         this.gbMail.Text = "Send mail";
         // 
         // gbCredentials
         // 
         this.gbCredentials.Controls.Add(this.label5);
         this.gbCredentials.Controls.Add(this.label4);
         this.gbCredentials.Controls.Add(this.tbUsername);
         this.gbCredentials.Controls.Add(this.tbPassword);
         this.gbCredentials.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.gbCredentials.Location = new System.Drawing.Point(318, 12);
         this.gbCredentials.Name = "gbCredentials";
         this.gbCredentials.Size = new System.Drawing.Size(200, 170);
         this.gbCredentials.TabIndex = 11;
         this.gbCredentials.TabStop = false;
         this.gbCredentials.Text = "Credentials";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(6, 92);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(70, 20);
         this.label5.TabIndex = 11;
         this.label5.Text = "Password";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(6, 32);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(101, 20);
         this.label4.TabIndex = 10;
         this.label4.Text = "Email address";
         // 
         // Gmail
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(526, 450);
         this.Controls.Add(this.gbCredentials);
         this.Controls.Add(this.gbMail);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "Gmail";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Gmail";
         this.gbMail.ResumeLayout(false);
         this.gbMail.PerformLayout();
         this.gbCredentials.ResumeLayout(false);
         this.gbCredentials.PerformLayout();
         this.ResumeLayout(false);

      }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.TextBox tbBody;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.GroupBox gbMail;
      private System.Windows.Forms.GroupBox gbCredentials;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
   }
}

