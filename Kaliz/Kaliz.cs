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
using System.IO;


namespace Kaliz
{
    public partial class Kaliz : Telerik.WinControls.UI.RadForm
    {
        private int chiso { get; set; }

        public Kaliz()
        {
            InitializeComponent();
            
        }
      
        /// <summary>
        /// Tao mot tep moi
        /// </summary>
        /// <param name="ten"></param>
        /// <param name="F"></param>
        private void TaoMoi(string ten,string F)
        {
            DocumentWindow TaiLieu = new DocumentWindow(ten);
            var DanhDau = new EditControl();
            DanhDau.Dock = DockStyle.Fill;
            DanhDau.ThemeName = "Office2016Colorful";
            TaiLieu.Controls.Add(DanhDau);
            DanhDau.AllowDrop = true;
            if (F!=null)
            DanhDau.LoadFile(F);
            DockPar.AddDocument(TaiLieu);
        }
      
        private void commandBarDropDownList1_Click(object sender, EventArgs e)
        {

        }

        private void FOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog Mo = new OpenFileDialog();
           
            if (Mo.ShowDialog() == DialogResult.OK)
            {
                TaoMoi(Path.GetFileName(Mo.FileName),Mo.FileName);
            }

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            DcStrp.ActiveWindow.Close();
        }

        private void DcWelcome_Click(object sender, EventArgs e)
        {

        }

        private void FNew_Click(object sender, EventArgs e)
        {

            TaoMoi("Document " + chiso++,null);
        }
        EditControl TabHienTai
        {
            get
            {
                if (DcStrp.ActiveWindow == null) return null;
                return (DcStrp.ActiveWindow.Controls[0] as EditControl);
            }
            set
            {
                DcStrp.ActiveWindow = (value.Parent as DocumentWindow);
            }
        }

        private void ECopy_Click(object sender, EventArgs e)
        {
            if (TabHienTai.CanCopy == true)
            {
                TabHienTai.Copy();
            }
            else MessageBox.Show("Loi");
          

        }

        private void ECut_Click(object sender, EventArgs e)
        {
            TabHienTai.Cut();

        }

        private void EPaste_Click(object sender, EventArgs e)
        {
            TabHienTai.Paste();
        }

        private void FPrint_Click(object sender, EventArgs e)
        {
            if (TabHienTai.ActiveControl != null) TabHienTai.Print();
        }

        private void FSaveAs_Click(object sender, EventArgs e)
        {
            TabHienTai.SaveAs();
        }

        private void FExport_Click(object sender, EventArgs e)
        {
            
        }
    }
}
