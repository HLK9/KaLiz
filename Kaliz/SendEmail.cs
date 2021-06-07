using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Net.Mail;
using System.Net;

namespace Kaliz
{
    public partial class SendEmail : Telerik.WinControls.UI.RadForm
    {
        public SendEmail()
        {
            InitializeComponent();
            
        }

        private void SendEmail_Load(object sender, EventArgs e)
        {

        }

        private void EmailSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage Ma = new MailMessage();
                Ma.From = new MailAddress(EmailFrom.Text);
                Ma.To.Add(EmailTo.Text);
                Ma.Subject = EmailSub.Text;
                Ma.Body = EmailBody.Text;
                Ma.Attachments.Add(new Attachment(EmailAttach.Text));
                SmtpClient sm = new SmtpClient();
                sm.Host = EmailSeever.SelectedItem.Text;
                NetworkCredential net = new NetworkCredential();
                net.UserName = EmailFrom.Text;
                net.Password = EmailPass.Text;
                sm.Credentials = net;
                sm.EnableSsl = true;
                sm.Port = 587;
                sm.Send(Ma);
                MessageBox.Show("Completed!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void radTextBoxControl1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Mo = new OpenFileDialog();

            if (Mo.ShowDialog() == DialogResult.OK)
            {
                EmailAttach.Text = Mo.FileName;
            }
        }

        private void EmailClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
