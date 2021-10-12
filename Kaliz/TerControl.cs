using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Kaliz
{
    public partial class TerControl : Telerik.WinControls.UI.RadForm
    {
        private static StringBuilder cmdOut = null;
       private static Process Ter = new Process();
        StreamWriter cmdWriter;
        public TerControl()
        {
            InitializeComponent();
            this.Load += TerControl_Load;
        }

        private void TerControl_Load(object sender, EventArgs e)
        {
            cmdOut = new StringBuilder("");
           // Process Ter = new Process();
            Ter.StartInfo.FileName = "cmd.exe";
            Ter.StartInfo.UseShellExecute = false;
            Ter.StartInfo.RedirectStandardOutput = true;
            Ter.OutputDataReceived += new DataReceivedEventHandler(SortData);
            Ter.StartInfo.CreateNoWindow = true;
            Ter.StartInfo.RedirectStandardInput = true;
            Ter.Start();
            cmdWriter = Ter.StandardInput;
            Ter.BeginOutputReadLine();
        }

        private void SortData(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                cmdOut.Append(Environment.NewLine + e.Data);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Ter.Close();
            Application.Exit();

        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            cmdWriter.WriteLine(radTextBox1.Text);
            timer1.Start();
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            radRichTextEditor1.Text = cmdOut.ToString();
            timer1.Stop();
        }
    }
}
