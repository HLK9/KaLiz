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
    public partial class Share_Email : Telerik.WinControls.UI.RadForm
    {
        public Share_Email()
        {
            InitializeComponent();
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private List<string> Attach { get; set; }
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendSimpleMessage(txtTo.Text, txtSub.Text, richtxtContent.Text,null,txtAttachment.Text);
        }
        public static IRestResponse SendSimpleMessage(string to,string sub,string content, List<string> att,string file)
        {               
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");

            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "097a85cb85a494579c1ae43faf64e457-30b9cd6d-8193fcd0");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox23413c86ba314991baa2cb3f2bec72aa.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Kaliz Porter <kaliz@sandbox23413c86ba314991baa2cb3f2bec72aa.mailgun.org>");
            request.AddParameter("to", "<games.hoanglong@gmail.com>");
           // request.AddParameter("to", "hoanglong@sandbox23413c86ba314991baa2cb3f2bec72aa.mailgun.org");
            request.AddParameter("subject", sub);
            request.AddParameter("text", content+"\nSent From Kaliz!");
            //for (int i = 0; i < att.Count; i++)
                request.AddFile("attachment",file);
           // request.AddFile("attachment", Path.Combine(path, filename));
            request.Method = Method.POST;
            return client.Execute(request);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            List<string> att = new List<string>();
            OpenFileDialog Mo = new OpenFileDialog();
            Mo.Multiselect = true;

            if (Mo.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in Mo.FileNames)
                {
                    try
                    {
                        //att.Add(item);
                        txtAttachment.Text += item;

                    }

                    catch
                    { }
                }

            }
            Attach = att;
            
        }
    }
}
