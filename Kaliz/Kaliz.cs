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


using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Localization;
using Syncfusion.Windows.Forms.Edit.Implementation;
using System.Collections;
using Syncfusion.Windows.Forms.Edit.Implementation.Formatting;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using WK.Libraries.SharpClipboardNS;

namespace Kaliz
{

    public partial class Kaliz : Telerik.WinControls.UI.RadForm
    {
        private bool deBug = false;
        private bool enableContext = false;
        private bool enableTooltip = false;
        private bool enableContextPrompt = false;
        private bool showlinenum = true;
        private string TenTheme = "MaterialTeal";
        public string Pathtosendemail;
       

        private int chiso { get; set; }
       
        public Kaliz()
        {
            this.Load += Kaliz_Load;
            Thread thr = new Thread(new ThreadStart(SplashScreen));
            thr.Start();
            Thread.Sleep(5000);
            thr.Abort();
            InitializeComponent();
            TaoPhimTat();
            

        }
       
        private void Kaliz_Load(object sender, EventArgs e)
        {
            var clipBoard = new SharpClipboard();
            clipBoard.MonitorClipboard = true;
            clipBoard.ClipboardChanged += ClipBoard_ClipboardChanged; 
           


        }

        private void ClipBoard_ClipboardChanged(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            bool containd = false;
            foreach(var item in radlistclip.Items)
            {
                if (item.Text == Clipboard.GetText())
                    containd = true;
            } 

           if(containd!= true)
                    radlistclip.Items.Add(Clipboard.GetText());
             
        }

        private void TaoPhimTat()
        {
           
            FNew.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.N));
            FOpen.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.O));
            FSave.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.S));
            FSaveAs.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Shift, Keys.S));
            //Edit
            ERedo.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Shift, Keys.Z));
            EStart.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.Up));
            EEnd.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.Down));
            EIndent.Shortcuts.Add(new RadShortcut(Keys.Control,Keys.OemCloseBrackets));
            EOutdent.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.OemOpenBrackets));
            //Tools
            FFindSelected.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.Enter));
            TPowerShell.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Alt, Keys.T));
            //Build
            BBuild.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Shift, Keys.B));
            BRun.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.B));
            //Bookmark
            BBookmark.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.M));
            radMenuItem2.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Shift, Keys.M));
            BBookmarkPre.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.Oemcomma));
            BBookmarkNext.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.OemPeriod));
        }
        /// <summary>
        /// Tao mot tep moi
        /// </summary>
        /// <param name="ten"></param>
        /// <param name="F"></param>
        private void TaoMoi(string ten, string F)
        {
            DocumentWindow TaiLieu = new DocumentWindow(ten);
            var DanhDau = new EditControl();
            DanhDau.Dock = DockStyle.Fill;
            DanhDau.Style = EditControlStyle.Office2016Colorful;
           
            TaiLieu.Controls.Add(DanhDau);
            DanhDau.AllowDrop = true;
            DanhDau.FileExtensions = new string[] { ".pas", ".c", ".cpp", ".cs", ".py" };
            DockPar.AddDocument(TaiLieu);
            //Theme
            TaiLieu.TabStrip.SelectedIndexChanged += TabStrip_SelectedIndexChanged;
            
            DanhDau.ContextChoiceBorderColor = Color.FromArgb(64, 224, 208);

            //DanhDau.contextchoice


            if (F != null)
            {
                DanhDau.LoadFile(F, Encoding.UTF8);
                if (Path.GetExtension(F) == ".c" || Path.GetExtension(F) == ".cpp")
                {
                    string ConfigF = @"Lex\CppF.xml";
                    DanhDau.Configurator.Open(ConfigF);
                    DanhDau.ApplyConfiguration("C++");
                    // DanhDau.ApplyConfiguration(KnownLanguages.C);
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";
                    DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen_C;
                    DanhDau.ContextPromptOpen += DanhDau_ContextPromptOpen_ForC;
                    DanhDau.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForC;
                    // DanhDau.ContextPromptOpen += DanhDau_ContextPromptOpen;


                }
                if (Path.GetExtension(F) == ".pas")
                {
                    string ConfigF = @"Lex\Pascal.xml";
                    DanhDau.Configurator.Open(ConfigF);

                    DanhDau.ApplyConfiguration("Pascal");
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
                    DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen;
                    DanhDau.ContextPromptOpen += DanhDau_ContextPromptOpen_ForPascal;
                    DanhDau.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForPascal;

                }
                if (Path.GetExtension(F) == ".py")
                {
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
                    string ConfigF = @"Lex\Python.xml";
                    DanhDau.Configurator.Open(ConfigF);
                    DanhDau.ApplyConfiguration("Python");
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
                    DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen_ForPython;




                }

            }



            DanhDau.MarkChangedLines = true;
            DanhDau.ShowSelectionMargin = true;
            DanhDau.HighlightCurrentLine = true;
            //DanhDau.AutoSave = true;
            DanhDau.Closing += DanhDau_Closing;
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
            DanhDau.StatusBarSettings.VisualStyle = Syncfusion.Windows.Forms.Tools.Controls.StatusBar.VisualStyle.Office2016Colorful;
            DanhDau.StatusBarSettings.Visible = true;
            DanhDau.StatusBarSettings.GripVisibility = Syncfusion.Windows.Forms.Edit.Enums.SizingGripVisibility.Hidden;
            DanhDau.StatusBarSettings.TextPanel.Panel.Text = F;
            DanhDau.StatusBarSettings.StatusPanel.Panel.Text = "Saved";
            DanhDau.StatusBarSettings.StatusPanel.Panel.BackColor = Color.Teal;
            DanhDau.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;
            //Các sự kiện
            DanhDau.TextChanged += DanhDau_TextChanged;
            DanhDau.UpdateContextToolTip += DanhDau_UpdateContextToolTip;
            DanhDau.MenuFill += DanhDau_MenuFill;
            
            DanhDau.ContextPromptBorderColor = Color.Pink;
            DanhDau.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
            DanhDau.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
            // DanhDau.BackgroundColor  = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, new System.Drawing.Color[] { System.Drawing.Color.LavenderBlush, System.Drawing.Color.AliceBlue, System.Drawing.Color.BlanchedAlmond });
            //DanhDau.TextChanging += DanhDau_TextChanging;
            // DanhDau.FilterAutoCompleteItems = true;

            //In
            DanhDau.PrintHeader += DanhDau_PrintHeader;
            //DanhDau.ShowContextTooltip = true; 

            //


        }

        private void TabStrip_SelectedIndexChanged(object sender, EventArgs e)
        {
           UpdateTheme();
           
        }
        private void UpdateTheme()
        {
            if (TenTheme != radMenu.ThemeName)
            {
                if (TenTheme == "Fluent")
                {
                    try
                    {
                        ThemeResolutionService.ApplicationThemeName = "Fluent";
                        TabHienTai.Style = EditControlStyle.Office2016Colorful;
                        TabHienTai.IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
                        TabHienTai.LineNumbersColor = Color.Teal;
                        TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                        TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });

                        if (Path.GetExtension(TabHienTai.FileName) == ".pas")
                        {
                            string ConfigF = @"Lex\Pascal.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("Pascal");
                        }
                        else
                            if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
                        {
                            string ConfigF = @"Lex\CppF.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("C++");
                        }
                        else if (Path.GetExtension(TabHienTai.FileName) == ".py")
                        {
                            string ConfigF = @"Lex\Python.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("Python");
                        }
                    }
                    catch { }
                }
                else if (TenTheme == "MaterialTeal")
                {
                    try
                    {
                        ThemeResolutionService.ApplicationThemeName = "MaterialTeal";
                        TabHienTai.Style = EditControlStyle.Office2016Colorful;
                        TabHienTai.IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
                        TabHienTai.LineNumbersColor = Color.Teal;
                        TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                        TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });

                        if (Path.GetExtension(TabHienTai.FileName) == ".pas")
                        {
                            string ConfigF = @"Lex\Pascal.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("Pascal");
                        }
                        else
                            if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
                        {
                            string ConfigF = @"Lex\CppF.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("C++");
                        }
                        else if (Path.GetExtension(TabHienTai.FileName) == ".py")
                        {
                            string ConfigF = @"Lex\Python.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("Python");
                        }
                    }
                    catch { }

                }
                else
                {
                    try
                    {

                        TabHienTai.IndicatorMarginBackColor = Color.FromArgb(40, 42, 54);
                        TabHienTai.LineNumbersColor = Color.FromArgb(98, 114, 164);
                        TabHienTai.Style = EditControlStyle.Office2016DarkGray;
                        TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
                        TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
                        ThemeResolutionService.ApplicationThemeName = "FluentDark";
                        if (Path.GetExtension(TabHienTai.FileName) == ".pas")
                        {
                            string ConfigF = @"Lex\Pascal_D.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("Pascal");
                        }
                        else
                            if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
                        {
                            string ConfigF = @"Lex\CppF_D.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("C++");
                        }
                        else if (Path.GetExtension(TabHienTai.FileName) == ".py")
                        {
                            string ConfigF = @"Lex\Python_D.xml";
                            TabHienTai.Configurator.Open(ConfigF);
                            TabHienTai.ApplyConfiguration("Python");
                        }
                    }
                    catch { }
                }
            }
                
        }

        private void DanhDau_Closing(object sender, StreamCloseEventArgs e)
        {
            e.Action = SaveChangesAction.ShowDialog;
        }

        private void DanhDau_ContextChoiceOpen_ForPython(IContextChoiceController controller)
        {
            controller.Items.Add("and");
            controller.Items.Add("as");
            controller.Items.Add("assert");
            controller.Items.Add("break");
            controller.Items.Add("class");
            controller.Items.Add("continue");
            controller.Items.Add("def");
            controller.Items.Add("del");
            controller.Items.Add("elif");
            controller.Items.Add("else");
            controller.Items.Add("except");
            controller.Items.Add("False");
            controller.Items.Add("finally");
            controller.Items.Add("for");
            controller.Items.Add("from");
            controller.Items.Add("global");
            controller.Items.Add("if");
            controller.Items.Add("import");
            controller.Items.Add("in");
            controller.Items.Add("is");
            controller.Items.Add("lambda");
            controller.Items.Add("None");
            controller.Items.Add("nonlocal");
            controller.Items.Add("not");
            controller.Items.Add("or");
            controller.Items.Add("pass");
            controller.Items.Add("raise");
            controller.Items.Add("return");
            controller.Items.Add("True");
            controller.Items.Add("try");
            controller.Items.Add("while");
            controller.Items.Add("with");
            controller.Items.Add("yield");
            controller.Items.Add("input");


        }

        private void DanhDau_ContextPromptUpdate_ForPascal(object sender, ContextPromptUpdateEventArgs e)
        {
            if (e.List.SelectedItem != null)
            {

                // Get list of the lexems that are inside the current stack.

                IList list = TabHienTai.GetLexemsInsideCurrentStack(false);

                if (list == null) return;



                int iBoldedIndex = 0;

                foreach (ILexem lexem in list)

                {

                    if (lexem.Text == "to" || lexem.Text == "do")

                        iBoldedIndex++;

                }

                if (iBoldedIndex >= e.List.SelectedItem.BoldedItems.Count)

                    e.List.SelectedItem.BoldedItems.SelectedItem = null;

                else

                    // Gets or sets selected item.

                    e.List.SelectedItem.BoldedItems.SelectedItem = e.List.SelectedItem.BoldedItems[iBoldedIndex];

            }
        }

        private void DanhDau_ContextPromptOpen_ForPascal(object sender, ContextPromptUpdateEventArgs e)
        {
            if (enableContextPrompt == true)
            {
                //ContextPromptItem item = null;
                if (TabHienTai.GetCurrentWord().ToLower() == "for")
                {
                    e.AddPrompt("Vòng Lặp for", " for <Giá trị đầu> to <Giá trị cuối> do <Câu lệnh>");
                    e.AddPrompt("Ví dụ về vòng lặp for", " for i:=1 to 10 do write('xin chao')");
                    e.AddPrompt("Ví dụ về vòng lặp for đảo ngược", null).BoldedItems.Add(0, 31, " for i:=10 downto 1 do write('xin chao')");
                    //item = e.AddPrompt("Vòng Lặp for", "<Giá trị đầu> to <Giá trị cuối> do <Câu lệnh>");
                    //item.BoldedItems.Add(0, 12, "Giá trị đầu");
                    //item.BoldedItems.
                    //item.BoldedItems.Add(0, 12, "Giá trị cuối");
                    //item.BoldedItems.Add(0, 12, "Câu lệnh");

                }
                else
            if (TabHienTai.GetCurrentWord().ToLower() == "while")
                {
                    e.AddPrompt("Vòng Lặp while", null).BoldedItems.Add(0, 14, "while <Điều kiện> do <Câu lệnh>");
                    //item = e.AddPrompt("Vòng Lặp while", "<Điều kiện> do <Câu lệnh>");
                    //item.BoldedItems.Add(0, 14, "Điều kiện");
                    //item.BoldedItems.Add(0, 14, "Câu lệnh");

                }
            }
            if (TabHienTai.GetCurrentWord().ToLower() == "if")
            {
                e.AddPrompt("Câu lệnh rẽ nhánh", "if <Các điều kiện > then <Các câu lệnh>");
            }
            if (TabHienTai.GetCurrentWord().ToLower() == "case")
            {
                e.AddPrompt("Lệnh Case-Of", "Case <Giá trị> Of" + @"
    <Trường hợp 1> : <Công việc 1>;
    <Trường hợp 2> : <Công việc 2>;
    ...
    <Trường hợp n> : <Công việc n>;
End;
");
            }
        }

        private void DanhDau_ContextPromptUpdate_ForC(object sender, ContextPromptUpdateEventArgs e)
        {
            if (e.List.SelectedItem != null)
            {

                // Get list of the lexems that are inside the current stack.

                IList list = TabHienTai.GetLexemsInsideCurrentStack(false);

                if (list == null) return;



                int iBoldedIndex = 0;

                foreach (ILexem lexem in list)

                {

                    if (lexem.Text == "," || lexem.Text == ";")

                        iBoldedIndex++;

                }

                if (iBoldedIndex >= e.List.SelectedItem.BoldedItems.Count)

                    e.List.SelectedItem.BoldedItems.SelectedItem = null;

                else

                    // Gets or sets selected item.

                    e.List.SelectedItem.BoldedItems.SelectedItem = e.List.SelectedItem.BoldedItems[iBoldedIndex];

            }
        }

        private void DanhDau_ContextPromptOpen_ForC(object sender, ContextPromptUpdateEventArgs e)
        {
            if (enableContextPrompt == true)
            {
                ContextPromptItem item = null;
                if (TabHienTai.GetCurrentWord().ToLower() == "for")
                {
                    item = e.AddPrompt("Vòng Lặp for", "<Khởi tạo biến> ; <Biểu thức điều kiện> ; <Cập nhật biến lặp>");
                    item.BoldedItems.Add(0, 12, "Khởi tạo biến");
                    item.BoldedItems.Add(0, 12, "Biểu thức điều kiện");
                    item.BoldedItems.Add(0, 12, "Cập nhật biến lặp");

                }
                if (TabHienTai.GetCurrentWord().ToLower() == "while")
                {
                    item = e.AddPrompt("Vòng Lặp while", "<Điều kiện>");
                    item.BoldedItems.Add(0, 14, "Điều kiện");

                }
                if (TabHienTai.GetCurrentWord().ToLower() == "if")
                {
                    item = e.AddPrompt("Câu lệnh rẽ nhánh", "<Điều kiện>");
                    item.BoldedItems.Add(0, 1, "Điều kiện");
                }
                if (TabHienTai.GetCurrentWord().ToLower() == "switch")
                {
                    item = e.AddPrompt("Switch-Case", "<Biểu thức điều kiện>");
                    item.BoldedItems.Add(0, 11, "Điều kiện");
                }
            }



        }

        private void DanhDau_MenuFill(object sender, EventArgs e)
        {
            ContextMenuManager Menu = (ContextMenuManager)sender;
           
            
            Menu.ClearMenu();
            
            Menu.AddMenuItem("&Copy                   Ctrl+C", new EventHandler(MenuCopy));
            Menu.AddMenuItem("&Cut                      Ctrl+X", new EventHandler(MenuCut));
            Menu.AddMenuItem("&Paste                   Ctrl+V", new EventHandler(MenuPaste));
            Menu.AddSeparator();
            Menu.AddMenuItem("&Select All", new EventHandler(MenuSelectAll));
            Menu.AddMenuItem("&Comment selection", new EventHandler(MenuComment));
            Menu.AddMenuItem("&Uncomment selection", new EventHandler(MenuUncomment));
            Menu.AddMenuItem("&Undo                   Ctrl+Z", new EventHandler(MenuUndo));

            Menu.AddMenuItem("&Redo                    Ctrl+Shift+Z", new EventHandler(MenuRedo));
            Menu.AddMenuItem("&Save                     Ctrl+S", new EventHandler(MenuSave));
            Menu.AddSeparator();
            Menu.AddMenuItem("&Copy File Path", new EventHandler(MenuCopyPath));
            Menu.AddMenuItem("&Open Containing Folder", new EventHandler(MenuOpenContaining));
            Menu.AddMenuItem("&Open Terminal Here", new EventHandler(MenuOpenTerHere));

            Menu.ContextMenuProvider.SetVisualStyle(VisualStyle.Office2016Colorful);




            // Syncfusion.Windows.Forms.IContextMenuProvider contextMenuProvider = this.TabHienTai.ContextMenuManager.ContextMenuProvider;
        }

        private void MenuCopyPath(object sender, EventArgs e)
        {
            Clipboard.SetText(TabHienTai.FileName);
        }

        private void MenuSelectAll(object sender, EventArgs e)
        {
            TabHienTai.SelectAll();
        }

        private void MenuOpenContaining(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(TabHienTai.FileName));
        }

        private void MenuOpenTerHere(object sender, EventArgs e)
        {
            string dan = Path.GetDirectoryName(TabHienTai.FileName);
            Process pw = new Process();
            pw.StartInfo.FileName = "powershell.exe";
            pw.StartInfo.WorkingDirectory = dan;
            pw.Start();
        }

        private void MenuSave(object sender, EventArgs e)
        {

            TabHienTai.Save();
        }

        private void MenuRedo(object sender, EventArgs e)
        {
            TabHienTai.Redo();
        }

        private void MenuUndo(object sender, EventArgs e)
        {
            TabHienTai.Undo();
        }

        private void MenuUncomment(object sender, EventArgs e)
        {
            TabHienTai.UncommentSelection();
        }

        private void MenuComment(object sender, EventArgs e)
        {
            TabHienTai.CommentSelection();
        }

        private void MenuPaste(object sender, EventArgs e)
        {

            TabHienTai.Paste();
        }

        private void MenuCut(object sender, EventArgs e)
        {
            TabHienTai.Cut();
        }

        private void MenuCopy(object sender, EventArgs e)
        {
            TabHienTai.Copy();
        }

        private void DanhDau_UpdateContextToolTip(object sender, UpdateTooltipEventArgs e)
        {
            if (e.Text == string.Empty)
            {

                Point pointVirtual = TabHienTai.PointToVirtualPosition(new Point(e.X, e.Y));

                if (pointVirtual.Y > 0)
                {
                    // Get the current line
                    ILexemLine line = TabHienTai.GetLine(pointVirtual.Y);

                    if (line != null)
                    {
                        // Get tokens from the current line
                        ILexem lexem = line.FindLexemByColumn(pointVirtual.X);

                        if (lexem != null && enableTooltip == true)
                        {
                            // Set the desired information tooltip
                            switch (lexem.Text.ToLower())
                            {
                                case "program":
                                    e.Text = lexem.Text + " |Từ khóa\n Xác định bắt đầu của một ứng dụng, thường là tùy chọn";
                                    break;
                                case "var":
                                    e.Text = lexem.Text + " |Từ khóa\n Sử dụng để khai báo biến";
                                    break;
                                case "byte":
                                    e.Text = lexem.Text + " |Kiểu dữ liệu\n Kiểu nguyên, có phạm vi từ 0->255 ";
                                    break;
                                default:
                                    e.Text = "";
                                    break;
                            }
                            //if (lexem.Text == "program")
                            //e.Text = "Từ khóa :v:v :V " + lexem.Text;
                            //if (lexem.Text == "var")
                            //    e.Text = "Từ khóaádasd :v:v :V " + lexem.Text;
                            //if (lexem.Text == "write")
                            //    e.Text = "in" + lexem.Text;
                            //if (lexem.Text == "readln")
                            //    e.Text = "dừng " + lexem.Text;


                        }
                        else e.Text = "";
                    }
                }

            }
        }

        private void DanhDau_PrintHeader(object sender, PrintHeadlineEventArgs e)
        {
            e.Text = Path.GetFileName(TabHienTai.FileName);
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
            controller.Items.Add("return", "cái ày là của C/C++");
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

            controller.Items.Add("begin", "Bắt đầu một chương trình hoặc khối mã");
            controller.Items.Add("break", "con mèo đen");
            controller.Items.Add("case", "bùm");
            controller.Items.Add("const", "lờ mao");
            controller.Items.Add("absolute", "");
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
            controller.Items.Add("readln");
            controller.Items.Add("write");
            controller.Items.Add("readkey");
        }

        private void DanhDau_TextChanged(object sender, EventArgs e)
        {
            if (enableContext == true)
            {
                TabHienTai.ShowContextChoice();

                TabHienTai.FilterAutoCompleteItems = true;
            }

            TabHienTai.StatusBarSettings.StatusPanel.Panel.Text = "Unsaved";
            TabHienTai.StatusBarSettings.StatusPanel.Panel.BackColor = Color.DarkMagenta;
            TabHienTai.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;

        }

        private void DanhDau_UpdateBookmarkToolTip(object sender, UpdateBookmarkTooltipEventArgs e)
        {
            try
            {
                e.Text = "BookMark";
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
                TaoMoi(Path.GetFileName(Mo.FileName), Mo.FileName);
            }

        }


        private void DcWelcome_Click(object sender, EventArgs e)
        {
            
        }

        private void FNew_Click(object sender, EventArgs e)
        {

            TaoMoi("Document " + chiso++, null);
        }
        EditControl TabHienTai
        {
            get
            {

                if (DockPar.ActiveWindow == null) return null;
                return (DockPar.DocumentManager.ActiveDocument.Controls[0] as EditControl);

                //Fixed... :v            .Controls[0]


            }
            set
            {
                DockPar.DocumentManager.ActiveDocument.ActiveControl = (value.Parent as DocumentTabStrip);
                value.Focus();

            }
        }

        

        private void ECopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabHienTai.CanCopy == true)
                {
                    TabHienTai.Copy();
                }
            }
            catch { }




        }

        private void ECut_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.Cut();
            }
            catch { }


        }

        private void EPaste_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.Paste();
            }
            catch { }

        }

        private void FPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabHienTai.ActiveControl != null) TabHienTai.Print();
            }
            catch { }

        }

        private void FSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.SaveAs();
            }
            catch { }

        }

        private void FExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog LuuVoiRTF = new SaveFileDialog();
                LuuVoiRTF.FileName = Path.GetFileNameWithoutExtension(TabHienTai.FileName) + ".rtf";
                LuuVoiRTF.Filter = "RitchTextDocuments (*.rtf)|*.rtf";
                if (LuuVoiRTF.ShowDialog() == DialogResult.OK)
                {
                    this.TabHienTai.SaveAsRTF(LuuVoiRTF.FileName);
                }
            }
            catch { }

            //this.TabHienTai.SaveAsRTF("Document.rtf");
        }
        private string TepExe(string ten)
        {
            return Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
        }
        //Build tep
        private void Build(string ten, bool enabledebug, ref RadListView outp)
        {
            if (Path.GetExtension(ten) == ".pas")
            {
                ListOutput.Items.Clear();
                Process BienDich = new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.WorkingDirectory = @"FPC\bin\i386-win32";
                BienDich.StartInfo.UseShellExecute = false;
                if (enabledebug == false)
                    BienDich.StartInfo.Arguments = "/c " + "fpc " + ten;
                else BienDich.StartInfo.Arguments = "/c " + "fpc " + ten + " -g";

                //BienDich.StartInfo.RedirectStandardInput = true;
                BienDich.StartInfo.RedirectStandardOutput = true;
                BienDich.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                BienDich.StartInfo.CreateNoWindow = true;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                BienDich.Start();
                ListOutput.AllowEdit = false;
                ListOutput.AllowRemove = false;
                bool issuccess = true;
                string ad;
                while ((ad = BienDich.StandardOutput.ReadLine()) != null)
                {
                    ListOutput.Items.Add(ad);

                    if (ad.Contains("lines compiled")) break;
                }
                foreach (var item in ListOutput.Items)
                {
                    if (item.Text.Contains("Fatal"))
                    {
                        item.BackColor = Color.LightSalmon;
                        issuccess = false;
                    }

                    if (item.Text.Contains("lines compiled")) item.BackColor = Color.LightGreen;
                }
                if (issuccess == false)
                    ShowAlert_Light("<html><color=LightSalmon>Build Failed", "Check output to view more");
                else
                    ShowAlert_Light("<html><color=Teal>Build Completed", "Ready to run");






                //BienDich.WaitForExit();

            }

            else if (Path.GetExtension(ten) == ".c" || Path.GetExtension(ten) == ".cpp")
            {
                ListOutput.Items.Clear();
                Process BienDich = new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.UseShellExecute = false;
                BienDich.StartInfo.RedirectStandardOutput = true;
                BienDich.StartInfo.RedirectStandardError = true;
                BienDich.StartInfo.RedirectStandardInput = true;

                if (enabledebug == false)
                    BienDich.StartInfo.Arguments = "/c " + "g++ " + ten + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
                else BienDich.StartInfo.Arguments = "/c " + "g++ " + " -g " + ten + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";


                BienDich.StartInfo.CreateNoWindow = true;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                BienDich.Start();

                string ad;

                ListOutput.AllowEdit = false;
                ListOutput.AllowRemove = false;


                //Lấy thông tin Error chứ k phải Output :))
                while ((ad = BienDich.StandardError.ReadLine()) != null)
                {
                    ListOutput.Items.Add(ad);

                    // if (ad.Contains("lines compiled")) break;
                }
                if (ListOutput.Items.Count < 2) ListOutput.Items.Add("Compile: " + Path.GetFileName(ten) + " - Completed, Ready to run");
                else ListOutput.Items.Add("Build: " + Path.GetFileName(ten) + " - Fail");

                foreach (var item in ListOutput.Items)
                {
                    if (item.Text.Contains("error")) item.BackColor = Color.LightSalmon;
                    if (item.Text.Contains("Completed")) item.BackColor = Color.LightGreen;
                    if (item.Text.Contains("- Fail")) item.BackColor = Color.LightSalmon;

                }

            }
        }





        private void GDB(string ten)
        {
            if (Path.GetExtension(ten) == ".pas")
            {
                Process BienDich = new Process();
                //Cho ListGDB


                //
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.WorkingDirectory = @"FPC\bin\i386-win32\";
                BienDich.StartInfo.Arguments = "/c " + "gdb " + TepExe(ten);
                BienDich.Start();
                //BienDich.BeginOutputReadLine();

                BienDich.WaitForExit();
                //  string output;

                //while ((output = BienDich.StandardOutput.ReadLine()) != null)
                //    list.Items.Add(output);

            }
            if (Path.GetExtension(ten) == ".c" || Path.GetExtension(ten) == ".cpp")
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
            if (Path.GetExtension(file) == ".pas")
            {
                Process Chay = new Process();

                Chay.StartInfo.WorkingDirectory = Path.GetDirectoryName(file);
                //Path.GetFileNameWithoutExtension(file) + ".exe"
                Chay.StartInfo.FileName = TepExe(file);
                Chay.StartInfo.UseShellExecute = true;

                //Chay.WaitForExit();
                Chay.Start();
            }
            if (Path.GetExtension(file) == ".c" || Path.GetExtension(file) == ".cpp")
            {

                Process Chay = new Process();

                Chay.StartInfo.WorkingDirectory = Path.GetDirectoryName(file);
                //Path.GetFileNameWithoutExtension(file) + ".exe"
                Chay.StartInfo.FileName = TepExe(file);
                Chay.StartInfo.UseShellExecute = true;
                Chay.Start();
            }
            if (Path.GetExtension(file) == ".py")
            {
                Process Chay = new Process();
                Chay.StartInfo.FileName = "cmd";
                //Chay.StartInfo.UseShellExecute = true;
                Chay.StartInfo.Arguments = "/c" + " python " + file;
                //Lấy thông tin nhưng phải để UseExeCutale là false :))
                //Chay.StartInfo.RedirectStandardError = true;
                //Chay.StartInfo.RedirectStandardOutput = true;

                Chay.Start();
                Chay.WaitForExit();
                /*       
                 *   Đoạn này đẩy thông tin vào trong Output        string ad;

                           ListOutput.AllowEdit = false;
                           ListOutput.AllowRemove = false;


                           //Lấy thông tin Error chứ k phải Output :))
                           while ((ad = Chay.StandardError.ReadLine()) != null)
                           {
                               ListOutput.Items.Add(ad);

                               // if (ad.Contains("lines compiled")) break;
                           }
                           while ((ad = Chay.StandardOutput.ReadLine()) != null)
                           {
                               ListOutput.Items.Add(ad);

                               // if (ad.Contains("lines compiled")) break;
                           }
               */
            }


        }
        /// <summary>
        /// Test các tính năng phụ lẻ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dark_Click(object sender, EventArgs e)
        {
            TenTheme = "FluentDark";
            UpdateTheme();
            //TabHienTai.IndicatorMarginBackColor = Color.FromArgb(40, 42, 54);
            //TabHienTai.LineNumbersColor = Color.FromArgb(98, 114, 164);
            //TabHienTai.Style = EditControlStyle.Office2016DarkGray;
            //TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
            //TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
            //ThemeResolutionService.ApplicationThemeName = "FluentDark";
            //if (Path.GetExtension(TabHienTai.FileName) == ".pas")
            //{
            //    string ConfigF = @"Lex\Pascal_D.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("Pascal");
            //}
            //else
            //    if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
            //{
            //    string ConfigF = @"Lex\CppF_D.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("C++");
            //}
            //else if (Path.GetExtension(TabHienTai.FileName) == ".py")
            //{
            //    string ConfigF = @"Lex\Python_D.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("Python");
            //}


        }



        private void BBuild_Click(object sender, EventArgs e)
        {
           

            try
            {
               
                if (Path.GetExtension(TabHienTai.FileName) == ".py")
                    ShowAlert_Light("<html><color=LightSalmon>Build Failed", "<html><color=Teal>Python can only be <b>RUN</b> directly");
                else
                {
                    var thread = new Thread(ThreadStart);

                    thread.TrySetApartmentState(ApartmentState.STA);
                    thread.Start();
                    Build(TabHienTai.FileName, deBug, ref ListOutput);
                    thread.Abort();
                }
                
            }
            catch { }
           

        }
        private static void ThreadStart()
        {
            try
            {
                BWai f = new BWai();
                Application.Run(f); // <-- other form started on its own UI thread
            }
            catch { }
           
        }
        // DataTable databm = new DataTable();

        private void BBookmark_Click(object sender, EventArgs e)
        {
            try
            {


                //databm.Columns.Add("Line", typeof(int));
                //databm.Columns.Add("File", typeof(string));
                //databm.Rows.Add(TabHienTai.CurrentLine, TabHienTai.FileName);
                //ListBm.DataSource = databm;

                BrushInfo brushInfo = new BrushInfo(Color.DarkViolet);
                TabHienTai.BookmarkAdd(TabHienTai.CurrentLine, brushInfo);
            }
            catch
            { }



            //try
            //{
            //        BrushInfo brushInfo = new BrushInfo(Color.DarkViolet);
            //TabHienTai.BookmarkAdd(TabHienTai.CurrentLine,brushInfo);

            //string sd = "Bookmark : " + TabHienTai.CurrentLine;

            //for (int i = ListBm.Items.Count - 1;i>= 0;i--)
            //{
            //    if  (ListBm.Items[i].Text.Contains(sd)) return;



            //}
            //ListBm.Items.Add(sd);        
            //}
            //catch { }




        }

        private void BRemoveBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.BookmarkRemove(TabHienTai.CurrentLine);
              
            }
            catch { }


        }

        private void BRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.BookmarkClear();
            }
            catch { }

        }

        private void TFind_Click(object sender, EventArgs e)
        {

        }

        private void TReplace_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ReplaceDialog();
            }
            catch { }

        }

        private void TGoToLine_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.GoToDialog();
            }
            catch { }

        }

        private void EUndo_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.Undo();
            }
            catch { }



        }

        private void BBookmarkPre_Click(object sender, EventArgs e)
        {

            try
            {
                TabHienTai.BookmarkPrevious();
            }
            catch { }

        }

        private void BBookmarkNext_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.BookmarkNext();
            }
            catch { }
        }

        private void ESelect_Click(object sender, EventArgs e)
        {
            try

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
            catch { }

        }


        private void BRun_Click(object sender, EventArgs e)
        {
            try
            {
                Run(TabHienTai.FileName);

            }
            catch { }

        }

        private void FExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DEnable_Click(object sender, EventArgs e)
        {

            if (deBug == false)
            {
                ShowAlert_Light("<html><color=Teal><b>Bạn đã Bật GDB Debug </b> ", "<html><i><span><color=Teal>Hãy biên dịch lại để khởi tạo</span></i>");
                deBug = true;
                DEnable.Text = "Disable Debug";

            }
            else
            {
                ShowAlert_Light("<html><color = Crimson><b> Bạn đã Tắt GDB Debug </b> ", "<html><i><span><color=Teal>Trình biên dịch sẽ không khởi tạo thông tin Debug</span></i>");
                deBug = false;
                DEnable.Text = "Enable Debug";

            }


        }

        private void FSave_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.Save();
                
                if (Path.GetExtension(TabHienTai.FileName) == ".py")
                    TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
                if (Path.GetExtension(TabHienTai.FileName) == ".pas")
                    TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
                if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
                    TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";

                TabHienTai.StatusBarSettings.StatusPanel.Panel.Text = "Saved";
                TabHienTai.StatusBarSettings.StatusPanel.Panel.BackColor = Color.DarkCyan;
                TabHienTai.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;
            }
            catch { }

        }

        private void DOpenGDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (deBug == true)
                {
                    GDB(TabHienTai.FileName);

                }
                else
                {
                    ShowAlert_Light("<html><color=Blue>Bạn chưa bật GDB Debug", "<html><i>Nếu chưa biết sử dụng, hay tham khảo ở<span><color=Teal> Mục</span></i>");
                }
            }
            catch { }
        }
        private void ShowAlert_Light(string cap, string content)
        {
            RadDesktopAlert al = new RadDesktopAlert();
            al.ThemeName = "Windows8";
            al.CaptionText = cap;
            al.Opacity = 0.8f;
            al.PopupAnimationDirection = RadDirection.Up;
            al.ScreenPosition = AlertScreenPosition.BottomRight;
            al.ContentText = content;
            al.AutoCloseDelay = 5;
            al.AutoSize = true;
            al.Show();
        }
        private void MDebug_Click(object sender, EventArgs e)
        {

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







        public void Compile(ref RadListView list)
        {
            //ShowCompiling mess= new ShowCompiling();
            Process compiler = new Process();
            list.Items.Clear();

            list.Items.Add("Compiling");
            compiler.StartInfo.FileName = "cmd";
            compiler.StartInfo.Arguments = "/c " + " dir";
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.Start();
            compiler.WaitForExit();
            string ass = compiler.StandardOutput.ReadToEnd();
            list.Items.Add(ass);
        }

        private void OEnableContext_Click(object sender, EventArgs e)
        {
            if (enableContext == false)
            {
                enableContext = true;
                OEnableContext.Text = "Disable Context Intellisense";
                ShowAlert_Light("<html><color=Teal>Context Intellisense Enabled", null);
            }
            else
            {
                ShowAlert_Light("<html><color=Crimson>Context Intellisense Disabled", null);
                enableContext = false;
                OEnableContext.Text = "Enable Context Intellisense";
            }
        }

        private void PerReadonly_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ReadOnly = true;
                ShowAlert_Light("<html><color=Crimson>Readonly Enabled", null);
            }
            catch { };

        }

        private void PerDisable_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ReadOnly = false;
                ShowAlert_Light("<html><color=Teal>Readonly Disabled", null);
                TabHienTai.StatusBarSettings.StatusPanel.Panel.Text = "Unsaved";
                TabHienTai.StatusBarSettings.StatusPanel.Panel.BackColor = Color.DarkMagenta;
                TabHienTai.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;
            }
            catch { };

        }

        private void OCTooltip_Click(object sender, EventArgs e)
        {
            if (enableTooltip == false)
            {

                enableTooltip = true;
                ShowAlert_Light("<html><color=Teal>Context Tooltip Enabled", null);
                OCTooltip.Text = "Disable Context Tooltip";
            }
            else
            {
                enableTooltip = false;
                ShowAlert_Light("<html><color=Crimson>Context Tooltip Disabled", null);
                OCTooltip.Text = "Enable Context Tooltip";

            }
        }

        private void OEnaPrompt_Click(object sender, EventArgs e)
        {
            if (enableContextPrompt == false)
            {
                enableContextPrompt = true;
                ShowAlert_Light("<html><color=Teal>Context Prompt Enabled", null);
                OEnaPrompt.Text = "Disable Context Prompt";

            }
            else
            {
                enableContextPrompt = false;
                ShowAlert_Light("<html><color=Crimson>Context Prompt Disabled", null);
                OEnaPrompt.Text = "Enable Context Prompt";
            }
        }

        private void HLearn_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.w3schools.com/cpp/");
        }

        private void LPascal_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tutorialspoint.com/pascal/index.htm");
        }

        private void LPython_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.w3schools.com/python/default.asp");
        }

        private void TCalc_Click(object sender, EventArgs e)
        {
            Process clc = new Process();
            clc.StartInfo.FileName = "calc.exe";
            clc.Start();
        }

        private void Tcmd_Click(object sender, EventArgs e)
        {
            Process cm = new Process();
            cm.StartInfo.FileName = "cmd.exe";
            cm.Start();

        }

        private void AConvert_Click(object sender, EventArgs e)
        {
            DialogASCII dia = new DialogASCII();
            dia.ShowDialog();
        }

        private void ATable_Click(object sender, EventArgs e)
        {
            DocumentWindow ascii_table = new DocumentWindow("ASCII-Table");
            DockPar.AddDocument(ascii_table);

            RadPdfViewer pd = new RadPdfViewer();

            ascii_table.Controls.Add(pd);
            pd.ViewerMode = FixedDocumentViewerMode.TextSelection;
            pd.FitToWidth = true;
            pd.ThemeName = "MaterialTeal";
            pd.Dock = DockStyle.Fill;
            pd.LoadDocument(@"Lex\ASCII_Table.pdf");
        }

        private void HAbout_Click(object sender, EventArgs e)
        {
            About_Z ab = new About_Z();
            ab.ShowDialog();
        }

        private void MPcurrentline_Click(object sender, EventArgs e)
        {
            RadColorDialog Col = new RadColorDialog();

            try
            {
                if (Col.ShowDialog() == DialogResult.OK)
                {
                    
                    TabHienTai.CurrentLineHighlightColor = Col.SelectedColor;
                }
            }
            catch
            { }
        }



        private void PSelection_Click(object sender, EventArgs e)
        {


            RadColorDialog Col = new RadColorDialog();


            try
            {
                if (Col.ShowDialog() == DialogResult.OK)
                {
                    TabHienTai.SelectionTextColor = Col.SelectedColor;
                }
            }
            catch
            { }
        }

        private void OLineNum_Click(object sender, EventArgs e)
        {
            try
            {
                if (showlinenum == false)
                {
                    TabHienTai.ShowLineNumbers = true;
                    showlinenum = true;
                    ShowAlert_Light("<html>Show line number <color=Teal>ON", null);
                }

                else
                {
                    TabHienTai.ShowLineNumbers = false;
                    showlinenum = false;
                    ShowAlert_Light("<html>Show line number <color=Crimson>OFF", null);
                }
            }
            catch { }
        }

        private void ELight_Click(object sender, EventArgs e)
        {
            TenTheme = "Fluent";
            UpdateTheme();
            //ThemeResolutionService.ApplicationThemeName = "Fluent";
            //TabHienTai.Style = EditControlStyle.Office2016Colorful;
            //TabHienTai.IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
            //TabHienTai.LineNumbersColor = Color.Teal;
            //TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
            //TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });

            //if (Path.GetExtension(TabHienTai.FileName) == ".pas")
            //{
            //    string ConfigF = @"Lex\Pascal.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("Pascal");
            //}
            //else
            //    if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
            //{
            //    string ConfigF = @"Lex\CppF.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("C++");
            //}
            //else if (Path.GetExtension(TabHienTai.FileName) == ".py")
            //{
            //    string ConfigF = @"Lex\Python.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("Python");
            //}
        }
       
        private void radMenuItem1_Click_1(object sender, EventArgs e)
        {
          
        }

       

        public void SplashScreen()
        {
            Splash sd = new Splash();
            Application.Run(sd);
        }

        private void SynC_Click(object sender, EventArgs e)
        {
            string ConfigF = @"Lex\CppF.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("C++");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen_C;
            TabHienTai.ContextPromptOpen += DanhDau_ContextPromptOpen_ForC;
            TabHienTai.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForC;
        }

        private void SPascal_Click(object sender, EventArgs e)
        {

            string ConfigF = @"Lex\Pascal.xml";
            TabHienTai.Configurator.Open(ConfigF);

            TabHienTai.ApplyConfiguration("Pascal");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen;
            TabHienTai.ContextPromptOpen += DanhDau_ContextPromptOpen_ForPascal;
            TabHienTai.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForPascal;

        }

        private void SynPython_Click(object sender, EventArgs e)
        {
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
            string ConfigF = @"Lex\Python.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("Python");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen_ForPython;
            
        }

        private void EStart_Click(object sender, EventArgs e)
        {
            TabHienTai.JumpToIndentBlockStart();
        }

        private void EEnd_Click(object sender, EventArgs e)
        {
            TabHienTai.JumpToIndentBlockEnd();
            
        }

        private void EIndent_Click(object sender, EventArgs e)
        {
            TabHienTai.IndentSelection();
            
        }

        private void FFindSelected_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.FindText(TabHienTai.SelectedText);
                
            }
            catch { }
        }

        private void EOutdent_Click(object sender, EventArgs e)
        {
            TabHienTai.OutdentSelection();
        }

        private void TPowerShell_Click(object sender, EventArgs e)
        {
            Process pw = new Process();
            pw.StartInfo.FileName = "powershell.exe";
            
            pw.Start();
        }

        private void ERedo_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.Redo();
                
            }
            catch { }
        }

        private void FFold_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.Collapse();
            }
            catch { }
        }

        private void FUnfold_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.Expand();
            }
            catch { }
           
        }

        private void FFoldAll_Click(object sender, EventArgs e)
        {
            try { TabHienTai.CollapseAll(); }
            catch { }
        }

        private void FFUnfoldAll_Click(object sender, EventArgs e)
        {
            try { TabHienTai.ExpandAll(); }
            catch { }
        }

        private void ListOutput_SelectedItemChanged(object sender, EventArgs e)
        {
           


        }

        private void ListOutput_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            string Phantich = @"\(\d+\,\d+\)|\:\d+\:\d+\:";
            
            string chuoi = ListOutput.SelectedItem.Text;
            string ret;

            MatchCollection df = Regex.Matches(chuoi, Phantich);
            
                foreach (Match sd in df)
            {
                string phan2 = @"\d+";
                MatchCollection df2 = Regex.Matches(sd.ToString(), phan2);
             
               TabHienTai.GoTo(int.Parse(df2[0].ToString()));
               
            }
               
            
        }

        private void TEmail_Click(object sender, EventArgs e)
        {
            Pathtosendemail = TabHienTai.FileName;
            SendEmail Sa = new SendEmail();
            Sa.ShowDialog();
            
        }
       
       
        private void radlistclip_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            try
            {
TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, radlistclip.SelectedItem.Text);
            }
            catch {  }
            
        }

        private void OClearClip_Click(object sender, EventArgs e)
        {
            radlistclip.Items.Clear();
           
        }

        private void radMenuItem3_Click_1(object sender, EventArgs e)
        {
            Dclipboard.Show();
           
        }

        private void EMatiral_Click(object sender, EventArgs e)
        {
            TenTheme = "MaterialTeal";
            UpdateTheme();

            //ThemeResolutionService.ApplicationThemeName = "MaterialTeal";
            //TabHienTai.Style = EditControlStyle.Office2016Colorful;
            //TabHienTai.IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
            //TabHienTai.LineNumbersColor = Color.Teal;
            //TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
            //TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });

            //if (Path.GetExtension(TabHienTai.FileName) == ".pas")
            //{
            //    string ConfigF = @"Lex\Pascal.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("Pascal");
            //}
            //else
            //    if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
            //{
            //    string ConfigF = @"Lex\CppF.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("C++");
            //}
            //else if (Path.GetExtension(TabHienTai.FileName) == ".py")
            //{
            //    string ConfigF = @"Lex\Python.xml";
            //    TabHienTai.Configurator.Open(ConfigF);
            //    TabHienTai.ApplyConfiguration("Python");
            //}
        }
    }
}

