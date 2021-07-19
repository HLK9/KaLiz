using System;
using System.Diagnostics;


namespace Kaliz
{
    public partial class About_Z : Telerik.WinControls.UI.RadForm
    {
        public About_Z()
        {
            InitializeComponent();
        }

        private void radLabel8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radLabel7_Click(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://cmbst.wordpress.com/aboutkaliz/");
        }
    }
}
