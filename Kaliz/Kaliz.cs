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
            DanhDau.Style = EditControlStyle.Office2016Colorful;
            TaiLieu.Controls.Add(DanhDau);
            DanhDau.AllowDrop = true;
            DanhDau.FileExtensions = new string[] { ".pas", ".c", ".cpp", ".cs" };
            DockPar.AddDocument(TaiLieu);

            if (F != null)
            {
                DanhDau.LoadFile(F);
                if (Path.GetExtension(F) == ".c" || Path.GetExtension(F) == ".cpp")
                {
                    string ConfigF = @"Lex\CppF.xml";
                    DanhDau.Configurator.Open(ConfigF);
                    DanhDau.ApplyConfiguration("C++");
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";
                    DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen_C;
                    DanhDau.ContextPromptOpen += DanhDau_ContextPromptOpen;


                }
                if (Path.GetExtension(F) == ".pas")
                {
                    string ConfigF = @"Lex\Pascal.xml";
                    DanhDau.Configurator.Open(ConfigF);

                    DanhDau.ApplyConfiguration("Pascal");
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
                   DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen;
                   DanhDau.ContextPromptOpen += DanhDau_ContextPromptOpen;
                   
                }
             
            }
                
          
            
            DanhDau.MarkChangedLines = true;
            DanhDau.ShowSelectionMargin = true;
            DanhDau.HighlightCurrentLine = true;
            
            DanhDau.CurrentLineHighlightColor = Color.Teal;
            DanhDau.ShowIndicatorMargin = true;
            DanhDau.MarkerAreaWidth = 20;
            DanhDau.ShowIndentationGuidelines = true;
            DanhDau.UpdateBookmarkToolTip += DanhDau_UpdateBookmarkToolTip;
            DanhDau.AllowZoom = true;
           DanhDau.OnlyHighlightMatchingBraces = true;
            DanhDau.EnableSmartInBlockIndent = true;
            DanhDau.IndentBlockHighlightingColor = Color.Orange;
            DanhDau.AutoIndentMode = AutoIndentMode.Smart;
           // if (Path.GetExtension(F) == ".cpp") DanhDau.ApplyConfiguration(KnownLanguages.C);
            //hien khoag trang DanhDau.ShowWhitespaces = true;
            DanhDau.OnlyHighlightMatchingBraces = true;
            DanhDau.StatusBarSettings.VisualStyle = Syncfusion.Windows.Forms.Tools.Controls.StatusBar.VisualStyle.Office2016White;
            DanhDau.StatusBarSettings.Visible = true;
            DanhDau.StatusBarSettings.GripVisibility = Syncfusion.Windows.Forms.Edit.Enums.SizingGripVisibility.Hidden;
            DanhDau.StatusBarSettings.TextPanel.Panel.Text = F;
            DanhDau.StatusBarSettings.StatusPanel.Panel.Text = "Saved";
            DanhDau.StatusBarSettings.StatusPanel.Panel.BackColor = Color.DarkMagenta;
            DanhDau.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;
            DanhDau.TextChanged += DanhDau_TextChanged;
            // DanhDau.BackgroundColor  = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, new System.Drawing.Color[] { System.Drawing.Color.LavenderBlush, System.Drawing.Color.AliceBlue, System.Drawing.Color.BlanchedAlmond });
            //DanhDau.TextChanging += DanhDau_TextChanging;
            // DanhDau.FilterAutoCompleteItems = true;

            //In
            DanhDau.PrintHeader += DanhDau_PrintHeader;

            //



        }

        private void DanhDau_PrintHeader(object sender, PrintHeadlineEventArgs e)
        {
            e.Text = Path.GetFileName(TabHienTai.FileName);
        }

        private void DanhDau_ContextPromptOpen(object sender, ContextPromptUpdateEventArgs e)
        {
            e.AddPrompt("Control.Items.Add(string text, string tooltipText, int imageIndex, int selectedImageIndex)", "Specify the text of the item, its tooltip text, image index and selected image index");

            e.AddPrompt("Control.Items.Add(string text, string tooltipText, int imageIndex)", "Specify the text of the item, its tooltip text, and image index");

            e.AddPrompt("Control.Items.Add(string text, string tooltipText)", "Specify the text of the item, and its tooltip text");
        }

       

        private void DanhDau_ContextChoiceOpen_C(IContextChoiceController controller)
        {

            controller.Items.Add("auto");
            controller.Items.Add("double");
            controller.Items.Add("int");
            controller.Items.Add("struct");
            controller.Items.Add("break");
            controller.Items.Add("else");
            controller.Items.Add("enum");
            controller.Items.Add("register");
            controller.Items.Add("typedef");
            controller.Items.Add("char");
            controller.Items.Add("extern");
            controller.Items.Add("return");
            controller.Items.Add("union");
            controller.Items.Add("const");
            controller.Items.Add("float");
            controller.Items.Add("short");
            controller.Items.Add("unsigned");
            controller.Items.Add("continue");
            controller.Items.Add("for");
            controller.Items.Add("signed");
            controller.Items.Add("void");
            controller.Items.Add("default");
            controller.Items.Add("goto");
            controller.Items.Add("sizeof");
            controller.Items.Add("volatile");
            controller.Items.Add("do");
            controller.Items.Add("if");
            controller.Items.Add("static");
            controller.Items.Add("while");
            controller.Items.Add("true");
            controller.Items.Add("false");
            controller.Items.Add("private");
            controller.Items.Add("protected");
            controller.Items.Add("public");
            controller.Items.Add("try");
            controller.Items.Add("catch");
            controller.Items.Add("dyamic_cash");
            controller.Items.Add("reinterpret_cast");
            controller.Items.Add("static_cast");
            controller.Items.Add("const_cast");
            controller.Items.Add("throw");
            controller.Items.Add("explicit");
            controller.Items.Add("new");
            controller.Items.Add("this");
            controller.Items.Add("asm");
            controller.Items.Add("operator");
            controller.Items.Add("namespace");
            controller.Items.Add("typeid");
            controller.Items.Add("typename");
            controller.Items.Add("class");
            controller.Items.Add("friend");
            controller.Items.Add("template");
            controller.Items.Add("using");
            controller.Items.Add("virtual");
            controller.Items.Add("delete");
            controller.Items.Add("inline");
            controller.Items.Add("mutable");
            controller.Items.Add("wchar_t");
            controller.Items.Add("bool");
            controller.Items.Add("And");
            controller.Items.Add("bitor");
            controller.Items.Add("not_eq");
            controller.Items.Add("xor");
            controller.Items.Add("and_eq");
            controller.Items.Add("compl");
            controller.Items.Add("or");
            controller.Items.Add("not");
            controller.Items.Add("xor_eq");
            controller.Items.Add("bitand");
            controller.Items.Add("or_eq");
            controller.Items.Add("export");
            controller.Items.Add("explicit");


        }

        private void DanhDau_ContextChoiceOpen(IContextChoiceController controller)
        {
           
                controller.Items.Add("begin", "Activate the form and give it focus");
                controller.Items.Add("break", "Gets or sets the Active Control");
                controller.Items.Add("case", "Activates the MDIChild of form");
                controller.Items.Add("const", "Gets or sets the value indicating Autoscroll");
                controller.Items.Add("absolute","");
            controller.Items.Add("and");
            controller.Items.Add("array");
            controller.Items.Add("asm");
            controller.Items.Add("do");
            controller.Items.Add("downto");
            controller.Items.Add("else");
            controller.Items.Add("end");
            controller.Items.Add("constructor");
            controller.Items.Add("continue");
            controller.Items.Add("destructor");
            controller.Items.Add("div");
            controller.Items.Add("file");
            controller.Items.Add("for");
            controller.Items.Add("function");
            controller.Items.Add("goto");
            controller.Items.Add("if");
            controller.Items.Add("implementation");
            controller.Items.Add("in");
            controller.Items.Add("inherited");
            controller.Items.Add("inline");
            controller.Items.Add("interface");
            controller.Items.Add("label");
            controller.Items.Add("mod");
            controller.Items.Add("nil");
            controller.Items.Add("not");
            controller.Items.Add("object");
            controller.Items.Add("of");
            controller.Items.Add("on");
            controller.Items.Add("packaed");
            controller.Items.Add("operator");
            controller.Items.Add("or");
            controller.Items.Add("procedure");
            controller.Items.Add("program");
            controller.Items.Add("record");
            controller.Items.Add("reintroduce");
            controller.Items.Add("repeat");
            controller.Items.Add("self");
            controller.Items.Add("set");
            controller.Items.Add("shl");
            controller.Items.Add("shr");
            controller.Items.Add("string");
            controller.Items.Add("then");
            controller.Items.Add("to");
            controller.Items.Add("type");
            controller.Items.Add("unit");
            controller.Items.Add("until");
            controller.Items.Add("uses");
            controller.Items.Add("var");
            controller.Items.Add("while");
            controller.Items.Add("with");
            controller.Items.Add("xor");
        }

        private void DanhDau_TextChanged(object sender, EventArgs e)
        {
            TabHienTai.ShowContextChoice();

            TabHienTai.FilterAutoCompleteItems = true;

            TabHienTai.StatusBarSettings.StatusPanel.Panel.Text = "Unsaved";
            TabHienTai.StatusBarSettings.StatusPanel.Panel.BackColor = Color.DarkMagenta;
            TabHienTai.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;
           
        }

        private void DanhDau_UpdateBookmarkToolTip(object sender, UpdateBookmarkTooltipEventArgs e)
        {
            try
            {
                e.Text = TabHienTai.SelectedText;
            }
            catch
            {

            }
           
            
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
            try { TabHienTai.Close();
            DockPar.ActiveWindow.Close(); //chủ chốt 
            } catch { }
            
           
           
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
        private string TepExe (string ten)
        {
            return Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
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
                BienDich.StartInfo.CreateNoWindow = true ;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
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
                if (enabledebug == false)
                    BienDich.StartInfo.Arguments = "/c " + "g++ " + ten + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
                else BienDich.StartInfo.Arguments = "/c " + "g++ " +" -g "+ ten + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
                BienDich.StartInfo.RedirectStandardOutput = true;
                BienDich.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                BienDich.StartInfo.CreateNoWindow = true;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                BienDich.Start();

            }
        }

        private void GDB(string ten)
        {
            if (Path.GetExtension(ten) == ".pas")
            {
                Process BienDich = new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.WorkingDirectory = @"FPC\bin\i386-win32\";           
                BienDich.StartInfo.Arguments = "/c " + "gdb " + TepExe(ten);
                BienDich.Start();
                BienDich.WaitForExit();

            }
            if (Path.GetExtension(ten)==".c"|| Path.GetExtension(ten) == ".cpp")
            {
                Process BienDich = new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.WorkingDirectory = @"FPC\bin\i386-win32\";
                BienDich.StartInfo.Arguments = "/c " + "gdb " + TepExe(ten);
                BienDich.Start();
                BienDich.WaitForExit();
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
                Chay.StartInfo.FileName = Path.GetFileNameWithoutExtension(file) + ".exe";
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

            //  MessageBox.Show(Path.GetExtension(TabHienTai.FileName));
            //radListView1.Items.Add(new ListViewItem (new string[] { "hee","of"}));
           
            
        }
       
        private void BBuild_Click(object sender, EventArgs e)
        {
            Build(TabHienTai.FileName,deBug);
        }

        private void BBookmark_Click(object sender, EventArgs e)
        {
            BrushInfo brushInfo = new BrushInfo(Color.DarkViolet);
            TabHienTai.BookmarkAdd(TabHienTai.CurrentLine,brushInfo);
            string sd = "Bookmark : " + TabHienTai.CurrentLine;
            
            for (int i = ListBm.Items.Count - 1;i>= 0;i--)
            {
                if  (ListBm.Items[i].Text.Contains(sd)) return;
               
                   

            }
            ListBm.Items.Add(sd);



        }

        private void BRemoveBookmark_Click(object sender, EventArgs e)
        {
            TabHienTai.BookmarkRemove(TabHienTai.CurrentLine);
            string sd = TabHienTai.CurrentLine.ToString();
           for  (int i=ListBm.Items.Count-1;i>=0;i--)
            {
                if (ListBm.Items[i].Text.Contains(sd))
                { ListBm.Items.RemoveAt(i); }
            }
            
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
            TabHienTai.StatusBarSettings.StatusPanel.Panel.Text = "Saved";
            TabHienTai.StatusBarSettings.StatusPanel.Panel.BackColor = Color.DarkCyan;
            TabHienTai.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;


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

        private void DEnable_Click(object sender, EventArgs e)
        {
            if (deBug == false)
            {
                deBug = true;
                DEnable.Text = "Disable Debug";
                TabHienTai.CurrentLineHighlightColor = Color.DarkMagenta;
            }
            else
            {
                deBug = false;
                DEnable.Text = "Enable Debug";
                TabHienTai.CurrentLineHighlightColor = Color.Teal;
            }


        }

        private void FSave_Click(object sender, EventArgs e)
        {
            try
            {TabHienTai.Save(); } catch { }
            
        }

        private void DOpenGDB_Click(object sender, EventArgs e)
        {
            if (deBug == true)
                GDB(TabHienTai.FileName);
            else MessageBox.Show("Error");
        }

        /// <summary>
        /// thử chuyển dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ListBm_SelectedItemChanged(object sender, EventArgs e)
        //{
        //    TabHienTai.GoTo(int.Parse(ListBm.SelectedItem.Text.Remove(0, 12)));

        //}
    }
}
