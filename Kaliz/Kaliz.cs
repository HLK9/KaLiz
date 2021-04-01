using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Syncfusion.Windows.Forms.Edit;
using Telerik.WinControls.UI.Docking;

namespace Kaliz
{
    public partial class Kaliz : Telerik.WinControls.UI.RadForm
    {
        private int chiso { get; set; }

        public Kaliz()
        {
            InitializeComponent();
            
        }

        private void commandBarDropDownList1_Click(object sender, EventArgs e)
        {

        }

        private void FOpen_Click(object sender, EventArgs e)
        {
            
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void DcWelcome_Click(object sender, EventArgs e)
        {

        }

        private void FNew_Click(object sender, EventArgs e)
        {
            
            DocumentWindow TaiLieu = new DocumentWindow("Document "+chiso++);
            var DanhDau = new EditControl();
            DanhDau.Dock = DockStyle.Fill;
            DanhDau.ThemeName = "Office2016Colorful";
            TaiLieu.Controls.Add(DanhDau);
            DanhDau.AllowDrop = true;
            
            DockPar.AddDocument(TaiLieu);
        }
    }
}
