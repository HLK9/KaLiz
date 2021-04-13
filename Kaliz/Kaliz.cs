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
using Syncfusion.Drawing;
//using Syncfusion.Windows.Forms.Localization.Localizer.EditResourceIdentifiers;
//using Syncfusion.Windows.Forms.ResourceIdentifiers;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Localization;

namespace Kaliz
{

    public partial class Kaliz : Telerik.WinControls.UI.RadForm
    {
      private  bool deBug = false;
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
            DanhDau.DropAllFiles = true;
            DanhDau.CurrentLineHighlightColor = Color.Teal;
            DanhDau.ShowIndicatorMargin = true;
            DanhDau.MarkerAreaWidth = 20;
            DanhDau.ShowIndentationGuidelines = true;
            DanhDau.UpdateBookmarkToolTip += DanhDau_UpdateBookmarkToolTip;
           // DanhDau.OnlyHighlightMatchingBraces = true;
            DanhDau.EnableSmartInBlockIndent = true;
            DanhDau.AutoIndentMode = AutoIndentMode.Block;
            //hien hoag trang DanhDau.ShowWhitespaces = true;
            DanhDau.OnlyHighlightMatchingBraces = true;
            DanhDau.StatusBarSettings.VisualStyle = Syncfusion.Windows.Forms.Tools.Controls.StatusBar.VisualStyle.Office2016Colorful;
            DanhDau.StatusBarSettings.Visible = true;
            DanhDau.StatusBarSettings.GripVisibility = Syncfusion.Windows.Forms.Edit.Enums.SizingGripVisibility.Hidden;




        }

        private void DanhDau_UpdateBookmarkToolTip(object sender, UpdateBookmarkTooltipEventArgs e)
        {
            e.Text = TabHienTai.SelectedText;
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
            SaveFileDialog LuuVoiRTF = new SaveFileDialog();
            LuuVoiRTF.FileName = Path.GetFileNameWithoutExtension(TabHienTai.FileName) + ".rtf";
            LuuVoiRTF.Filter = "RitchTextDocuments (*.rtf)|*.rtf";
            if (LuuVoiRTF.ShowDialog() == DialogResult.OK)
            {
                this.TabHienTai.SaveAsRTF(LuuVoiRTF.FileName);
            }
            //this.TabHienTai.SaveAsRTF("Document.rtf");
        }
        //Build tep
        private void Build(string ten,bool enabledebug)
        {
            if (Path.GetExtension(ten) == ".pas")
            {
                Process BienDich = new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.WorkingDirectory = @"FPC\\bin\\i386-win32\\";
                BienDich.StartInfo.UseShellExecute = false;
                if (enabledebug ==false)
                BienDich.StartInfo.Arguments = "/c " + "fpc " + ten;
                else BienDich.StartInfo.Arguments = "/c " + "fpc " + ten+" -g";

                //BienDich.StartInfo.RedirectStandardInput = true;
                BienDich.StartInfo.RedirectStandardOutput = true;
                BienDich.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                BienDich.StartInfo.CreateNoWindow = true;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                BienDich.Start();
                //BienDich.WaitForExit();
                
           }

            if(Path.GetExtension(ten)==".c"|| Path.GetExtension(ten)==".cpp")
            {
                Process BienDich =new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.UseShellExecute = false;
                string Duong = Path.GetDirectoryName(ten);
                //BienDich.StartInfo.Arguments = "/c " + "g++ " + ten + " -o " + Duong+"\\"+Path.GetFileName(ten)+".exe";
                BienDich.StartInfo.Arguments = "/c " + "g++ " + ten + " -o " + Path.GetFullPath(ten) + ".exe";
                BienDich.StartInfo.RedirectStandardOutput = true;
                BienDich.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                BienDich.StartInfo.CreateNoWindow = true;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                BienDich.Start();

            }
        }
        private void Run(string file)
        {
            if (Path.GetExtension(file)==".pas")
            {
                    Process Chay = new Process();
                
                Chay.StartInfo.WorkingDirectory = Path.GetDirectoryName(file);
                Chay.StartInfo.FileName =Path.GetFileNameWithoutExtension(file) + ".exe";
                Chay.StartInfo.UseShellExecute = true;
                
                //Chay.WaitForExit();
                Chay.Start();
            }
            if(Path.GetExtension(file) == ".c"|| Path.GetExtension(file) == ".cpp")
            {

                Process Chay = new Process();

                Chay.StartInfo.WorkingDirectory = Path.GetDirectoryName(file);
                Chay.StartInfo.FileName = Path.GetFullPath(file) + ".exe";
                Chay.StartInfo.UseShellExecute = true;
                Chay.Start();
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
            Build(TabHienTai.FileName,deBug);
        }

        private void BBookmark_Click(object sender, EventArgs e)
        {
            BrushInfo brushInfo = new BrushInfo(Color.DarkViolet);
            TabHienTai.BookmarkAdd(TabHienTai.CurrentLine,brushInfo);
            
        }

        private void BRemoveBookmark_Click(object sender, EventArgs e)
        {
            TabHienTai.BookmarkRemove(TabHienTai.CurrentLine);
        }

        private void BRemoveAll_Click(object sender, EventArgs e)
        {
            TabHienTai.BookmarkClear();
        }

        private void TFind_Click(object sender, EventArgs e)
        {
            TabHienTai.FindDialog();
        }

        private void TReplace_Click(object sender, EventArgs e)
        {
            TabHienTai.ReplaceDialog();
        }
        
        private void TGoToLine_Click(object sender, EventArgs e)
        {
            TabHienTai.GoToDialog();
        }

        private void ESave_Click(object sender, EventArgs e)
        {
            TabHienTai.Save();
        }

        private void BBookmarkPre_Click(object sender, EventArgs e)
        {
            TabHienTai.BookmarkPrevious();
        }

        private void BBookmarkNext_Click(object sender, EventArgs e)
        {
            TabHienTai.BookmarkNext();
        }

        private void ESelect_Click(object sender, EventArgs e)
        {
            if (TabHienTai.SelectionMode == SelectionModes.Default)
            {
                 TabHienTai.SelectionMode = SelectionModes.Block;
                ESelect.Text = "Select Mode: Default";
            }
            else
            {
                TabHienTai.SelectionMode = SelectionModes.Default;
                ESelect.Text = "Select Mode: Block";
            }
           
        }
       

        private void BRun_Click(object sender, EventArgs e)
        {
            Run(TabHienTai.FileName);
        }

        private void FExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
