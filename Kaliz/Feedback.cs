using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;

namespace Kaliz
{
    public partial class Feedback : Telerik.WinControls.UI.RadForm
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private string Attach { get; set; }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(richtxtContent.Text!=null&&richtxtContent.Text!="")
            {
                SendSimpleMessage(txtSub.Text, richtxtContent.Text, Attach);
            }
            
        }
        public static IRestResponse SendSimpleMessage(string sub,string content, string file)
        {               
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");

            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "097a85cb85a494579c1ae43faf64e457-30b9cd6d-8193fcd0");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox23413c86ba314991baa2cb3f2bec72aa.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Feedback User<kaliz@sandbox23413c86ba314991baa2cb3f2bec72aa.mailgun.org>");
            request.AddParameter("to", "<void.kaliz@gmail.com>");           
            request.AddParameter("subject", sub);          
                request.AddParameter("text", content + "\nSent From Kaliz!");
          
            if(File.Exists(file))
                request.AddFile("attachment",file);
           
            request.Method = Method.POST;
            return client.Execute(request);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {          
            OpenFileDialog Mo = new OpenFileDialog();
            Mo.Multiselect = false;

            if (Mo.ShowDialog() == DialogResult.OK)
            {
                Attach = Mo.FileName;

            }         
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
