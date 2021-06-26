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
using System.Security.Cryptography;

namespace Kaliz
{
    public partial class SendEmail : Telerik.WinControls.UI.RadForm
    {
        public SendEmail()
        {
            InitializeComponent();
            
            
        }
        string hashs = "WelcomeToK@liz";
        private string EncryptString(string inp)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(inp);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashs));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return  Convert.ToBase64String(result, 0, result.Length);
                }

            }
        }
        private string DecryptString( string inp)
        {
            byte[] data = Convert.FromBase64String(inp);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashs));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                   return UTF8Encoding.UTF8.GetString(result);
                }

            }
        }

        private void SendEmail_Load(object sender, EventArgs e)
        {

        }

        private void EmailSend_Click(object sender, EventArgs e)
        {
            string UsrN = DecryptString(EmailFrom.Text);
            string PasN = DecryptString(EmailPass.Text);
           
            try
            {
                MailMessage Ma = new MailMessage();
                Ma.From = new MailAddress(UsrN);
                Ma.To.Add(EmailTo.Text);
                Ma.Subject = EmailSub.Text;
                Ma.Body = EmailBody.Text;
                
                Ma.Attachments.Add(new Attachment(EmailAttach.Text));
                SmtpClient sm = new SmtpClient();
                sm.Host = EmailSeever.SelectedItem.Text;
                NetworkCredential net = new NetworkCredential();
                net.UserName = UsrN;
                net.Password = PasN; 
                sm.Credentials = net;
                sm.EnableSsl = true;
                sm.Port = 587;
                sm.Send(Ma);
                MessageBox.Show("This mail has been sent", "Kaliz", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        string[] att;
        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Mo = new OpenFileDialog();
           
                EmailAttach.Text = Mo.FileName;
               
           
        }

        private void EmailClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //DecryptString();
            
            

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            //EmailFrom.Text = "KyHXr0HfMu8APuN3/GhYSa8vCAxH4gde";
            //EmailPass.Text = "qrzlf1TaFvNUHIqCVMVSXA==";
        }
    }
}
