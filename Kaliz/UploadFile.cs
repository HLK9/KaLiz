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
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        var resStr = client.UploadFile("https://file.io", txtPath.Text);
                        var jObjResult = JObject.Parse(Encoding.UTF8.GetString(resStr));
                        var linkToFile = jObjResult["link"];
                        txtLink.Text = linkToFile.ToString();
                    }
                }
                catch
                { }
            }
           
        }
    }
}
