using System;

namespace Kaliz
{
    public partial class ParametDialog : Telerik.WinControls.UI.RadForm
    {
        public string ParametText { get; set; }
        public ParametDialog()
        {
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            ParametText = radTextBox1.Text;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
