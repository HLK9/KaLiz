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
using System.Diagnostics;
using Syncfusion.Windows.Forms.Edit.Interfaces;
using Syncfusion.Windows.Forms.Edit.Enums;
using Syncfusion.Windows.Forms.Edit.Implementation.Config;

namespace Kaliz
{
    public partial class Kaliz : Telerik.WinControls.UI.RadForm
    {
       
        private int chiso { get; set; }

        public Kaliz()
        {
            InitializeComponent();
            //Tạo sẵn để test
            TaoMoi("hal.pas", "C:\\Users\\HoangLien\\Desktop\\TeeS\\hal.pas");
            
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
            DanhDau.MarkChangedLines = true;
            DanhDau.ShowSelectionMargin = true;
            DanhDau.HighlightCurrentLine = true;
            DanhDau.CurrentLineHighlightColor = Color.Teal;
            DanhDau.ShowIndicatorMargin = true;
            DanhDau.MarkerAreaWidth = 20;
            //DanhDau.EnableSmartInBlockIndent = true;
            //DanhDau.AutoIndentMode = AutoIndentMode.Smart;
            
           
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
            TabHienTai.Close();
            DockPar.ActiveWindow.Close(); //chủ chốt
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
                if (DockPar.ActiveWindow == null) return null;
                return (DockPar.ActiveWindow.ActiveControl as EditControl);
            }
            set
            {
               DockPar.ActiveWindow.ActiveControl = (value.Parent as DocumentTabStrip);
                value.Focus();
            }
        }

        public object DanhDau { get; private set; }

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
        //Build tep
        private void Build(string ten)
        {
            if (Path.GetExtension(ten) == ".pas")
            {
                Process BienDich = new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.WorkingDirectory = @"FPC\\bin\\i386-win32\\";
                BienDich.StartInfo.UseShellExecute = false;
                BienDich.StartInfo.Arguments = "/c " + "ppc386 " + ten;

                //BienDich.StartInfo.RedirectStandardInput = true;
                BienDich.StartInfo.RedirectStandardOutput = true;
                BienDich.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                BienDich.StartInfo.CreateNoWindow = true;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                BienDich.Start();
                //BienDich.WaitForExit();
                
           }
        }
        /// <summary>
        /// Test các tính năng phụ lẻ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radMenuItem1_Click_1(object sender, EventArgs e)
        {
            
            MessageBox.Show(Path.GetExtension(TabHienTai.FileName));
        }
       
        private void BBuild_Click(object sender, EventArgs e)
        {
            Build(TabHienTai.FileName);
        }

        private void BBookmark_Click(object sender, EventArgs e)
        {
            TabHienTai.BookmarkAdd(TabHienTai.CurrentLine);
        }
    }
}
