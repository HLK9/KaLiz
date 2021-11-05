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
    public partial class ConnectSetting : Telerik.WinControls.UI.RadForm
    {
        public string IPAddress { get; set; }
        public string Port { get; set; }
        public ConnectSetting()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            IPAddress = txtAddress.Text;
            Port = txtPort.Text;
        }
    }
}
