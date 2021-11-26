using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Kaliz
{
    public partial class UploadFile : Telerik.WinControls.UI.RadForm
    {
        public UploadFile()
        {
            InitializeComponent();
            radLabel2.Text = "";
        }

        private void radTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Mo = new OpenFileDialog();
            if (Mo.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = Mo.FileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if(File.Exists(txtPath.Text))
            {
                //try
                //{
                //    using (WebClient client = new WebClient())
                //    {
                //        var resStr = client.UploadFile("https://file.io", txtPath.Text);
                //        var jObjResult = JObject.Parse(Encoding.UTF8.GetString(resStr));
                //        var linkToFile = jObjResult["link"];
                //        txtLink.Text = linkToFile.ToString();
                //        radLabel2.Text = "Copied! Link is ready to share";
                //        radLabel2.ForeColor = Color.Teal;
                //        Clipboard.SetText(linkToFile.ToString());
                //    }
                //}
                //catch
                //{
                //    radLabel2.Text = "Failed, Check your internet connection";
                //    radLabel2.ForeColor = Color.Crimson;
                //    return;
                //}
                string ReturnValue = string.Empty;
                try
                {
                    using (WebClient Client = new WebClient())
                    {
                        byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", txtPath.Text);// Thanks noobencoder for pointing out that Anonfile changed domains since when I originally wrote this 3 years ago. It's fixed now.
                        string ResponseBody = Encoding.ASCII.GetString(Response);
                        if (ResponseBody.Contains("\"error\": {"))
                        {
                            ReturnValue += "There was a erorr while uploading the file.\r\n";
                            ReturnValue += "Error message: " + ResponseBody.Split('"')[7] + "\r\n";

                        }
                        else
                        {

                            txtLink.Text= ResponseBody.Split('"')[15];
                            // ReturnValue += "File name: " + ResponseBody.Split('"')[25] + "\r\n";
                            radLabel2.Text = "Copied! Link is ready to share" +"\r\n" + ResponseBody.Split('"')[25];
                            radLabel2.ForeColor = Color.Teal;
                            Clipboard.SetText(txtLink.Text);

                        }
                    }
                }
                catch (Exception Exception)
                {
                    ReturnValue += "Exception Message:\r\n" + Exception.Message + "\r\n";
                    radLabel2.Text = "Failed";
                    radLabel2.ForeColor = Color.Crimson;
                }
            }
            else
            {
                MessageBox.Show("File not found", "Error");
            }
           
        }
        static string CreateDownloadLink(string File) // Important to note AnonFile has a 20gb file size limit (which is overkill for most applications)
        {
            string ReturnValue = string.Empty;
            try
            {
                using (WebClient Client = new WebClient())
                {
                    byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", File);// Thanks noobencoder for pointing out that Anonfile changed domains since when I originally wrote this 3 years ago. It's fixed now.
                    string ResponseBody = Encoding.ASCII.GetString(Response);
                    if (ResponseBody.Contains("\"error\": {"))
                    {
                        ReturnValue += "There was a erorr while uploading the file.\r\n";
                        ReturnValue += "Error message: " + ResponseBody.Split('"')[7] + "\r\n";
                    }
                    else
                    {
                        ReturnValue += "Download link: " + ResponseBody.Split('"')[15] + "\r\n";
                       // ReturnValue += "File name: " + ResponseBody.Split('"')[25] + "\r\n";
                       
                       
                    }
                }
            }
            catch (Exception Exception)
            {
                ReturnValue += "Exception Message:\r\n" + Exception.Message + "\r\n";
            }
            return ReturnValue;
        }
    }
}
