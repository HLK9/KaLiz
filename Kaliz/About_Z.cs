using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

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
    }
}
