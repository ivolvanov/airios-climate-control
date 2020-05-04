using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace smtpProtocol
{
   public partial class Gmail : Form
   {
      public Gmail()
      {
         InitializeComponent();
         MessageBox.Show("Only works with Gmail. You have to turn on 'accessibility for less secure apps' in your Gmail settings in order for this to work!", "Disclaimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
         try
         {
            SmtpClient server = new SmtpClient("smtp.gmail.com");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(tbFrom.Text);
            mail.To.Add(tbTo.Text);
            mail.Subject = tbSubject.Text;
            mail.Body = tbBody.Text;
            server.Port = 587;
            server.UseDefaultCredentials = false;
            server.Credentials = new System.Net.NetworkCredential(tbUsername.Text, tbPassword.Text);
            server.EnableSsl = true;
            server.Send(mail);
            MessageBox.Show("Mail has been sent!");
         }
         catch (Exception exc)
         {
            MessageBox.Show(exc.ToString());
         }
      }
   }
}
