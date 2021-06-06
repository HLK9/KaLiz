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
    public partial class BWai : Telerik.WinControls.UI.RadForm
    {
        public BWai()
        {
            InitializeComponent();
            this.Load += BWai_Load;
        }

        private void BWai_Load(object sender, EventArgs e)
        {
            radWaitingBar1.StartWaiting();
        }
    }
}
