using System;
using System.Drawing;
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
using Syncfusion.Drawing;
using DiffPlex.WindowsForms.Controls;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Edit.Implementation;
using System.Collections;
using System.Text.RegularExpressions;
using WK.Libraries.SharpClipboardNS;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using Syncfusion.Windows.Forms.Edit.Dialogs;

namespace Kaliz
{
   
    public partial class Kaliz : Telerik.WinControls.UI.RadForm
    {
        private bool deBug = false;
        private bool enableContext = false;
        private bool enableTooltip = false;
        private bool enableContextPrompt = false;
        private bool showlinenum = true;
        private string TenTheme;
        private bool themechanged;
        public string Pathtosendemail;
        private string ConsoleUse = "Cmder";
        private string DiffOldText;
        private string DiffNewText;
        private bool highlight = true;
        private bool showClipboard = true;
        private bool showClosed = true;
        private bool showDataReceived = true;
        private bool showBookmarkList = true;
        private bool showOutput = true;
        private bool showDirectory = true;
        private bool BuildComplete = true;

        private int chiso { get; set; }
        private string Para = string.Empty;
        private string PascalOption = string.Empty;
       

        public Kaliz()
        {
            this.Load += Kaliz_Load;
            //Thread thr = new Thread(new ThreadStart(SplashScreen));
            //thr.Start();
            //Thread.Sleep(5000);
            //thr.Abort();
           
            InitializeComponent();
            Thread.Sleep(4000);
            DockPar.SelectedTabChanged += DockPar_SelectedTabChanged;
           // DockPar.SelectedTabChanging += DockPar_SelectedTabChanging;
            TaoPhimTat();
            Doutput.AutoHide();
            Dclipboard.AutoHide();
            DockPar.ShowDocumentCloseButton = true;
            ThemeResolutionService.ApplicationThemeName = "MaterialTeal";
            //them context menu
            var contextMenuData_Add = new RadMenuItem();
            contextMenuData_Add.Text = "Add to Current Tab";
            contextMenuData_Add.Click += Item_Click;
            contextMenuData.Items.Add(contextMenuData_Add);
            var contextMenuData_Merge = new RadMenuItem();
            contextMenuData_Merge.Text = "Different Merge with Current Tab";
            contextMenuData_Merge.Click += ContextMenuData_Merge_Click;
            contextMenuData.Items.Add( contextMenuData_Merge);
            var contextMenuData_Remove = new RadMenuItem();
            contextMenuData_Remove.Click += ContextMenuData_Remove_Click;
            contextMenuData_Remove.Text = "Remove";
            contextMenuData.Items.Add(contextMenuData_Remove);
            ////Directory
            //open
            var contextDirectory_Open = new RadMenuItem();
            contextDirectory_Open.Text = "Open Directory";
            contextDirectory_Open.Click += ContextDirectory_Open_Click;
            //new file
            var contextDirectory_New = new RadMenuItem();
            contextDirectory_New.Text = "New File";
            contextDirectory_New.Click += ContextDirectory_New_Click;
            //delete file
            var contextDirectory_Del = new RadMenuItem();
            contextDirectory_Del.Text = "Delete file";
            contextDirectory_Del.Click += ContextDirectory_Del_Click;
            //rename file
            var contextDirectory_Rename = new RadMenuItem();
            contextDirectory_Rename.Text = "Rename File";
            contextDirectory_Rename.Click += ContextDirectory_Rename_Click;
            //them vao menu context
            contextMenuDirectory.Items.Add(contextDirectory_New);
            contextMenuDirectory.Items.Add(contextDirectory_Rename);
            contextMenuDirectory.Items.Add(contextDirectory_Del);
            contextMenuDirectory.Items.Add(contextDirectory_Open);

            //Tooltip Mở Server
            SStartServer.ToolTipText = "Start Server with IP: " + GetLocalIP() + " Port: "+int.Parse(txtPort);
            SConnect.ToolTipText = "Connect with IP: " + GetLocalIP() + " Port: " + int.Parse(txtPort);
            //listDataReceived.ShowItemToolTips = true;
            listDataReceived.ToolTipTextNeeded += ListDataReceived_ToolTipTextNeeded;
            radlistclip.ToolTipTextNeeded += Radlistclip_ToolTipTextNeeded;
            DWorkingDirectory.AllowedDockState = ~AllowedDockState.Floating;
          




        }

        private void ContextDirectory_Rename_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeDirectory.SelectedNode.Selected == true && treeDirectory.SelectedNode.Parent.Text != null)
                {
                    using (ParametDialog fd = new ParametDialog())
                    {
                        fd.Text = "Input Dialog";
                        fd.radLabel1.Text = "Type file name below";
                        fd.radLabel2.Text = "Note: You can set file extention";
                        fd.radButton3.Enabled = false;
                        if (fd.ShowDialog() == DialogResult.OK)
                        {

                            filenameDir = fd.ParametText;
                            if (filenameDir == string.Empty || filenameDir == "") return;
                        }
                    }
                    try
                    {
                        File.Move(PathDirectory + "\\" + Path.GetFileName(treeDirectory.SelectedNode.FullPath), PathDirectory + "\\" + filenameDir);
                        File.Delete(PathDirectory + "\\" + Path.GetFileName(treeDirectory.SelectedNode.FullPath));
                        treeDirectory.SelectedNode.Text = filenameDir;
                        if (Path.GetExtension(treeDirectory.SelectedNode.Text) == ".cpp")
                            treeDirectory.SelectedNode.ImageIndex = 1;
                        else if (Path.GetExtension(treeDirectory.SelectedNode.Text) == ".c")
                            treeDirectory.SelectedNode.ImageIndex = 0;
                        else if (Path.GetExtension(treeDirectory.SelectedNode.Text) == ".pas")
                            treeDirectory.SelectedNode.ImageIndex = 5;
                        else if (Path.GetExtension(treeDirectory.SelectedNode.Text) == ".py")
                            treeDirectory.SelectedNode.ImageIndex = 6;
                        else if (Path.GetExtension(treeDirectory.SelectedNode.Text) == ".java")
                            treeDirectory.SelectedNode.ImageIndex = 4;
                        else if (Path.GetExtension(treeDirectory.SelectedNode.Text) == ".exe")
                            treeDirectory.SelectedNode.ImageIndex = 7;
                        else treeDirectory.SelectedNode.ImageIndex = 2;


                    }
                    catch
                    {
                        MessageBox.Show("Can't rename this file");
                    }
                }
                else
                { MessageBox.Show("Can't apply with this file"); }
            }
            catch
            {
                MessageBox.Show("This cannot be applied");
            }
           
        }

        private void ContextDirectory_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeDirectory.SelectedNode.Selected == true && treeDirectory.SelectedNode.Parent.Text != null)
                {
                    //MessageBox.Show(treeDirectory.SelectedNode.FullPath);
                    try
                    {

                        File.Delete(PathDirectory + "\\" + Path.GetFileName(treeDirectory.SelectedNode.FullPath));
                        treeDirectory.SelectedNode.Remove();
                    }
                    catch { MessageBox.Show("Can't delete this file"); }

                }
                else
                { MessageBox.Show("Can't apply with this file"); }
            }
            catch
            {
                MessageBox.Show("This cannot be applied");
            }
            
        }

        string filenameDir;
        private void ContextDirectory_New_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeDirectory.SelectedNode != null && treeDirectory.SelectedNode.Parent.Text != null)
                {

                    using (ParametDialog fd = new ParametDialog())
                    {
                        fd.Text = "Input Dialog";
                        fd.radLabel1.Text = "Type file name below";
                        fd.radLabel2.Text = "Note: You can set file extention";
                        fd.radButton3.Enabled = false;
                        if (fd.ShowDialog() == DialogResult.OK)
                        {

                            filenameDir = fd.ParametText;
                            if (filenameDir == string.Empty || filenameDir == "") return;
                        }
                    }

                    MessageBox.Show(treeDirectory.SelectedNode.Parent.Text);
                    var nd = new RadTreeNode();
                    treeDirectory.SelectedNode.Parent.Nodes.Add(nd);
                    treeDirectory.SelectedNode = nd;
                    nd.Text = filenameDir;
                    if (Path.GetExtension(nd.Text) == ".cpp")
                        nd.ImageIndex = 1;
                    else if (Path.GetExtension(nd.Text) == ".c")
                        nd.ImageIndex = 0;
                    else if (Path.GetExtension(nd.Text) == ".pas")
                        nd.ImageIndex = 5;
                    else if (Path.GetExtension(nd.Text) == ".py")
                        nd.ImageIndex = 6;
                    else if (Path.GetExtension(nd.Text) == ".java")
                        nd.ImageIndex = 4;
                    else if (Path.GetExtension(nd.Text) == ".exe")
                        nd.ImageIndex = 7;
                    else nd.ImageIndex = 2;
                    nd.Tag = nd.Text;

                    try
                    {
                        File.Create(PathDirectory + "\\" + nd.Text);
                        MessageBox.Show(PathDirectory + "\\" + treeDirectory.SelectedNode.Parent + "\\" + nd.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Can't create file!");
                        treeDirectory.SelectedNode.Remove();
                    }




                }
                else
                { MessageBox.Show("Can't apply with this file"); }
            }
            catch
            {
                MessageBox.Show("This cannot be applied");
            }
           
           
        }

        private void ContextDirectory_Open_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                PathDirectory = dialog.FileName;
                LoadDirectory(dialog.FileName);
            }
        }

        private void Radlistclip_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            try
            {
                e.ToolTipText = radlistclip.SelectedItem.Text;
            }
            catch
            {
                return;
            }
           
        }

        private void ListDataReceived_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            try
            {
                e.ToolTipText = listDataReceived.SelectedItem.Text;
            }
            catch
            {
                return;
            }
            
        }

        private void ContextMenuData_Remove_Click(object sender, EventArgs e)
        {
            listDataReceived.Items.Remove(listDataReceived.SelectedItem);
        }

        private void ContextMenuData_Merge_Click(object sender, EventArgs e)
        {
            if (TabHienTai != null)
            {
                DiffNewText = TabHienTai.Text;
                DiffViewer Diff = new DiffViewer();
                Diff.OldText = TabHienTai.Text;
                Diff.NewText = listDataReceived.SelectedItem.Text;
                Diff.FontFamilyNames = "Cascadia Code";
                Diff.FontSize = 16;
                Diff.ShowSideBySide();
                Diff.NewTextHeader = "Data Received";
                Diff.OldTextHeader = "Current Tab";
                Diff.IgnoreWhiteSpace = true;

                Diff.Dock = DockStyle.Fill;
                DocumentWindow Do = new DocumentWindow("Different Merge");
                Do.Controls.Add(Diff);
                DockPar.AddDocument(Do);
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            if (TabHienTai != null) 
            {
                
                TabHienTai.InsertText(TabHienTai.CurrentLine,TabHienTai.CurrentColumn, "\n" + listDataReceived.SelectedItem.Text + "\n");
            }
           
        }

        private void DockPar_SelectedTabChanging(object sender, SelectedTabChangingEventArgs e)
        {
            //UpdateTheme();
          
        }

        private void Kaliz_Load(object sender, EventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, @"Kaliz\");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var clipBoard = new SharpClipboard();
            clipBoard.MonitorClipboard = true;
            clipBoard.ClipboardChanged += ClipBoard_ClipboardChanged;



            try
            {

                using (StreamReader Doc = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz\\Histo.txt"))
                {
                    string dong;
                    while ((dong = Doc.ReadLine()) != null)
                    {

                        recentList.Items.Add(dong);



                    }
                }
                if (recentList.Items.Count >= 10)
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz\\Histo.txt", string.Empty);

            }
            catch { }






        }

        private void MenuZoom_TextChanged(object sender, EventArgs e)
        {
           
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
            SwitchNext.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.PageUp));
            SwitchPrevious.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.PageDown));
            EDupli.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Shift, Keys.D));
            //Tools
            FFindSelected.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.Enter));
            TTermi.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Alt, Keys.T));
            //Build
            BBuild.Shortcuts.Add(new RadShortcut(Keys.Control | Keys.Shift, Keys.B));
            BRun.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.B));
            BBuildaRun.Shortcuts.Add(new RadShortcut(Keys.Control|Keys.Alt,Keys.B));
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
        /// <param name="DuongDanTep"></param>
        private void TaoMoi(string ten, string DuongDanTep)
        {
            DocumentWindow TaiLieu = new DocumentWindow(ten);
            var DanhDau = new EditControl();
            DanhDau.Dock = DockStyle.Fill;
            DanhDau.Style = EditControlStyle.Office2016Colorful;
            DanhDau.LineNumbersFont = new Font("Consolas", 13);
            TaiLieu.Controls.Add(DanhDau);
            DanhDau.AllowDrop = true;
            
            DanhDau.FileExtensions = new string[] { ".pas", ".c", ".cpp", ".cs", ".py",".java" };
            DockPar.AddDocument(TaiLieu);
            //Theme
            //TaiLieu.TabStrip.SelectedIndexChanged += TabStrip_SelectedIndexChanged;
            DanhDau.DragDrop += DanhDau_DragDrop;
            
            DockPar.DockWindowClosing += DockPar_DockWindowClosing;
            DanhDau.ContextChoiceBorderColor = Color.FromArgb(64, 224, 208);
            //DanhDau.WhiteSpaceIndicators.NewLineString = "\n";
            //DanhDau.contextchoice


            if (DuongDanTep != null)
            {
                LuuHisto(DuongDanTep);
                
                if (Path.GetExtension(DuongDanTep) == ".c" || Path.GetExtension(DuongDanTep) == ".cpp")
                {
                    //DanhDau.WhiteSpaceIndicators.NewLineString = "\r\n";
                    DanhDau.SetNewLineStyle(Syncfusion.IO.NewLineStyle.Unix);
                    //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                   DanhDau.LoadFile(DuongDanTep, Encoding.UTF8);
                    string ConfigF = @"Lex\CppF.xml";
                    
                    DanhDau.Configurator.Open(ConfigF);
                    DanhDau.ApplyConfiguration("C++");
                    // DanhDau.ApplyConfiguration(KnownLanguages.C);
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";
                    DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen_C;
                    DanhDau.ContextPromptOpen += DanhDau_ContextPromptOpen_ForC;
                    DanhDau.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForC;
                    DanhDau.UpdateContextToolTip += DanhDau_UpdateContextToolTip_ForC;
                    



                }
                if (Path.GetExtension(DuongDanTep) == ".pas")
                {
                    DanhDau.LoadFile(DuongDanTep, Encoding.UTF8);
                    string ConfigF = @"Lex\Pascal.xml";
                    DanhDau.Configurator.Open(ConfigF);

                    DanhDau.ApplyConfiguration("Pascal");
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
                    DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen;
                    DanhDau.ContextPromptOpen += DanhDau_ContextPromptOpen_ForPascal;
                    DanhDau.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForPascal;
                    DanhDau.UpdateContextToolTip += DanhDau_UpdateContextToolTip_ForPascal;
                   // DanhDau.AddCodeSnippet("Block code", "begin\nend");

                }
                if (Path.GetExtension(DuongDanTep) == ".py")
                {
                    DanhDau.LoadFile(DuongDanTep, Encoding.UTF8);
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
                    string ConfigF = @"Lex\Python.xml";
                    DanhDau.Configurator.Open(ConfigF);
                    DanhDau.ApplyConfiguration("Python");
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
                    DanhDau.ContextChoiceOpen += DanhDau_ContextChoiceOpen_ForPython;
                    DanhDau.UpdateContextToolTip += DanhDau_UpdateContextToolTip_ForPython;

                }
                if(Path.GetExtension(DuongDanTep)==".java")
                {
                    
                    DanhDau.LoadFile(DuongDanTep, Encoding.ASCII);

                   // DanhDau.SetNewLineStyle(Syncfusion.IO.NewLineStyle.Unix);
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Java";
                    string ConfigF = @"Lex\Java.xml";
                    DanhDau.Configurator.Open(ConfigF);
                    DanhDau.ApplyConfiguration("Java");
                    DanhDau.StatusBarSettings.FileNamePanel.Panel.Text = "Java";
                    DanhDau.UpdateContextToolTip += DanhDau_UpdateContextToolTip_ForJava;
                    
                }
              

            }



            DanhDau.MarkChangedLines = true;
            DanhDau.ShowSelectionMargin = true;
            DanhDau.HighlightCurrentLine = true;
            //DanhDau.AutoSave = true;
            DanhDau.Closing += DanhDau_Closing;
            DanhDau.CurrentLineHighlightColor = Color.Teal;
            DanhDau.ShowIndicatorMargin = true;
            //DanhDau.MarkerAreaWidth = 20;
            DanhDau.ShowIndentationGuidelines = true;
            DanhDau.ShowOutliningCollapsers = true;
            DanhDau.ShowColumnGuides = true;          
            DanhDau.UpdateBookmarkToolTip += DanhDau_UpdateBookmarkToolTip;
            DanhDau.AllowZoom = true;
            // DanhDau.OnlyHighlightMatchingBraces = true;
            DanhDau.EnableSmartInBlockIndent = true ;
            DanhDau.IndentBlockHighlightingColor = Color.Orange;
            DanhDau.AutoIndentMode  = AutoIndentMode.Smart;
            // if (Path.GetExtension(F) == ".cpp") DanhDau.ApplyConfiguration(KnownLanguages.C);
            //hien khoag trang DanhDau.ShowWhitespaces = true;
            DanhDau.OnlyHighlightMatchingBraces = true;
            DanhDau.StatusBarSettings.VisualStyle = Syncfusion.Windows.Forms.Tools.Controls.StatusBar.VisualStyle.Office2016Colorful;
            DanhDau.StatusBarSettings.Visible = true;
            DanhDau.StatusBarSettings.GripVisibility = Syncfusion.Windows.Forms.Edit.Enums.SizingGripVisibility.Hidden;
            DanhDau.StatusBarSettings.TextPanel.Panel.Text = DuongDanTep;
            DanhDau.StatusBarSettings.StatusPanel.Panel.Text = "Saved";
            DanhDau.StatusBarSettings.StatusPanel.Panel.BackColor = Color.Teal;
            DanhDau.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;
            //Các sự kiện
            DanhDau.TextChanged += DanhDau_TextChanged;
           // DanhDau.UpdateContextToolTip += DanhDau_UpdateContextToolTip_ForPascal;
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
            //Auto
            DanhDau.KeyDown += DanhDau_KeyDown;

        }

        private void DanhDau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemOpenBrackets && e.Modifiers == Keys.Shift)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "}");
                TabHienTai.MoveLeft();
            }
            else
             if (e.KeyCode == Keys.OemOpenBrackets && e.Modifiers == Keys.None)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "]");
                TabHienTai.MoveLeft();
            }

            else
                 if (e.KeyCode == Keys.OemQuotes && e.Modifiers == Keys.None)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "'");
                TabHienTai.MoveLeft();
            }
            else
                 if (e.KeyCode == Keys.OemQuotes && e.Modifiers == Keys.Shift)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "\"");
                TabHienTai.MoveLeft();
            }
            else
                 if (e.KeyCode == Keys.D9 && e.Modifiers == Keys.Shift)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, ")");
                TabHienTai.MoveLeft();
            }
        }

        private void DanhDau_UpdateContextToolTip_ForJava(object sender, UpdateTooltipEventArgs e)
        {
            //https://www.w3schools.com/java/java_ref_keywords.asp
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
                                case "abstract":
                                    e.Text = lexem.Text + ": A non-access modifier. Used for classes and methods: An abstract class cannot be used to create objects (to access it, it must be inherited from another class). An abstract method can only be used in an abstract class, and it does not have a body. The body is provided by the subclass (inherited from)";
                                    break;
                                case "byte":
                                    e.Text = lexem.Text + ": A data type that can store whole numbers from -128 and 127";
                                    break;
                                case "assert":
                                    e.Text = lexem.Text + ": For debugging";
                                    break;
                                case "break":
                                    e.Text = lexem.Text + ": Breaks out of a loop or a switch block";
                                    break;
                                case "class":
                                    e.Text = lexem.Text + ": Defines a class";
                                    break;
                                case "continue":
                                    e.Text = lexem.Text + ": Continues to the next iteration of a loop";
                                    break;
                                case "const":
                                    e.Text = lexem.Text + ": Defines a constant. Not in use - use final instead";
                                    break;
                                case "default":
                                    e.Text = lexem.Text + ": Specifies the default block of code in a switch statement";
                                    break;
                                case "do":
                                    e.Text = lexem.Text + ": Used together with while to create a do-while loop";
                                    break;
                                case "double":
                                    e.Text = lexem.Text + ": A data type that can store whole numbers from 1.7e−308 to 1.7e+308";
                                    break;
                                case "else":
                                    e.Text = lexem.Text + ": Used in conditional statements";
                                    break;
                                case "enum":
                                    e.Text = lexem.Text + ": Declares an enumerated (unchangeable) type";
                                    break;
                                case "exports":
                                    e.Text = lexem.Text + ": Exports a package with a module. New in Java 9";
                                    break;
                                case "extends":
                                    e.Text = lexem.Text + ": Extends a class (indicates that a class is inherited from another class)";
                                    break;
                                case "final":
                                    e.Text = lexem.Text + ": A non-access modifier used for classes, attributes and methods, which makes them non-changeable (impossible to inherit or override)";
                                    break;
                                case "finally":
                                    e.Text = lexem.Text + ": Used with exceptions, a block of code that will be executed no matter if there is an exception or not";
                                    break;
                                case "float":
                                    e.Text = lexem.Text + ": A data type that can store whole numbers from 3.4e−038 to 3.4e+038";
                                    break;
                                case "for":
                                    e.Text = lexem.Text + ": Create a for loop";
                                    break;
                                case "goto":
                                    e.Text = lexem.Text + ": Not in use, and has no function";
                                    break;
                                case "if":
                                    e.Text = lexem.Text + ": Makes a conditional statement";
                                    break;
                                case "implements":
                                    e.Text = lexem.Text + ": Implements an interface";
                                    break;
                                case "import":
                                    e.Text = lexem.Text + ": Used to import a package, class or interface";
                                    break;
                                case "instanceof":
                                    e.Text = lexem.Text + ": Checks whether an object is an instance of a specific class or an interface";
                                    break;
                                case "int":
                                    e.Text = lexem.Text + ": A data type that can store whole numbers from -2147483648 to 2147483647";
                                    break;
                                case "interface":
                                    e.Text = lexem.Text + ": Used to declare a special type of class that only contains abstract methods";
                                    break;
                                case "long":
                                    e.Text = lexem.Text + ": A data type that can store whole numbers from -9223372036854775808 to 9223372036854775808";
                                    break;
                                case "module":
                                    e.Text = lexem.Text + ": Declares a module. New in Java 9";
                                    break;
                                case "native":
                                    e.Text = lexem.Text + ": Specifies that a method is not implemented in the same Java source file (but in another language)";
                                    break;
                                case "new":
                                    e.Text = lexem.Text + ": Create new objects";
                                    break;
                                case "package":
                                    e.Text = lexem.Text + ": Declares a package";
                                    break;
                                case "private":
                                    e.Text = lexem.Text + ": An access modifier used for attributes, methods and constructors, making them only accessible within the declared class";
                                    break;
                                case "protected":
                                    e.Text = lexem.Text + ": An access modifier used for attributes, methods and constructors, making them accessible in the same package and subclasses";
                                    break;
                                case "public":
                                    e.Text = lexem.Text + ": An access modifier used for classes, attributes, methods and constructors, making them accessible by any other class";
                                    break;
                                case "requires":
                                    e.Text = lexem.Text + ": Specifies required libraries inside a module. New in Java 9";
                                    break;
                                case "return":
                                    e.Text = lexem.Text + ": Finished the execution of a method, and can be used to return a value from a method";
                                    break;
                                case "short":
                                    e.Text = lexem.Text + ": A data type that can store whole numbers from -32768 to 32767";
                                    break;
                                case "static":
                                    e.Text = lexem.Text + ": A non-access modifier used for methods and attributes. Static methods/attributes can be accessed without creating an object of a class";
                                    break;
                                case "strictfp":
                                    e.Text = lexem.Text + ": Restrict the precision and rounding of floating point calculations";
                                    break;
                                case "super":
                                    e.Text = lexem.Text + ": Refers to superclass (parent) objects";
                                    break;
                                case "switch":
                                    e.Text = lexem.Text + ": Selects one of many code blocks to be executed";
                                    break;
                                case "synchronized":
                                    e.Text = lexem.Text + ": A non-access modifier, which specifies that methods can only be accessed by one thread at a time";
                                    break;
                                case "this":
                                    e.Text = lexem.Text + ": Refers to the current object in a method or constructor";
                                    break;
                                case "throw":
                                    e.Text = lexem.Text + ": Creates a custom error";
                                    break;
                                case "throws":
                                    e.Text = lexem.Text + ": Indicates what exceptions may be thrown by a method";
                                    break;
                                case "transient":
                                    e.Text = lexem.Text + ": A non-accesss modifier, which specifies that an attribute is not part of an object's persistent state";
                                    break;
                                case "try":
                                    e.Text = lexem.Text + ": Creates a try...catch statement";
                                    break;
                                case "var":
                                    e.Text = lexem.Text + ": Declares a variable. New in Java 10";
                                    break;
                                case "void":
                                    e.Text = lexem.Text + ": Specifies that a method should not have a return value";
                                    break;
                                case "volatile":
                                    e.Text = lexem.Text + ": Indicates that an attribute is not cached thread-locally, and is always read from the \"main memory\"";
                                    break;
                                case "while":
                                    e.Text = lexem.Text + ": Creates a while loop";
                                    break;
                                
                                default:
                                    break;
                            }
                        }
                        else return;
                    }
                }

            }
        }

        private void DanhDau_UpdateContextToolTip_ForC(object sender, UpdateTooltipEventArgs e)
        {
            //https://doc.bccnsoft.com/docs/cppreference_en/keywords/index.html
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
                                case "asm":
                                    e.Text = lexem.Text + ": insert an assembly instruction";
                                    break;
                                case "auto":
                                    e.Text = lexem.Text + ": declare a local variable";
                                    break;
                                case "bool":
                                    e.Text = lexem.Text + ": declare a boolean variable";
                                    break;
                                case "break":
                                    e.Text = lexem.Text + ": break out of a loop";
                                    break;
                                case "case":
                                    e.Text = lexem.Text + ": a block of code in a switch statement";
                                    break;
                                case "catch":
                                    e.Text = lexem.Text + ": handles exceptions from throw";
                                    break;
                                default:
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
                        else return;
                    }
                }

            }
        }

        private void DanhDau_UpdateContextToolTip_ForPython(object sender, UpdateTooltipEventArgs e)
        {
            //https://www.w3schools.com/python/python_ref_keywords.asp
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
                                case "and":
                                    e.Text = lexem.Text + ": A logical operator";
                                    break;
                                case "as":
                                    e.Text = lexem.Text + ": To create an alias";
                                    break;
                                case "assert":
                                    e.Text = lexem.Text + ": For debugging";
                                    break;
                                case "break":
                                    e.Text = lexem.Text + ": To break out of a loop";
                                    break;
                                case "class":
                                    e.Text = lexem.Text + ": To define a class";
                                    break;
                                case "continue":
                                    e.Text = lexem.Text + ": To continue to the next iteration of a loop";
                                    break;
                                case "def":
                                    e.Text= lexem.Text+": To define a function";
                                    break;
                                case "del":
                                e.Text = lexem.Text+": To delete an object";
                                break;
                                case "elif":
                                    e.Text = lexem.Text + ": Used in conditional statements, same as else if";
                                    break;
                                case "else":
                                    e.Text = lexem.Text + ": 	Used in conditional statements";
                                    break;
                                case "except":
                                    e.Text = lexem.Text + ": Used with exceptions, what to do when an exception occurs";
                                    break;
                                case "false":
                                    e.Text = lexem.Text + ": Boolean value, result of comparison operations";
                                    break;
                                case "finally":
                                    e.Text = lexem.Text + ": Used with exceptions, a block of code that will be executed no matter if there is an exception or not";
                                    break;
                                case "for":
                                    e.Text = lexem.Text + ": To create a for loop";
                                    break;
                                case "from":
                                    e.Text = lexem.Text + ": To import specific parts of a module";
                                    break;
                                case "global":
                                    e.Text = lexem.Text + ": To declare a global variable";
                                    break;
                                case "if":
                                    e.Text = lexem.Text + ": To make a conditional statement";
                                    break;
                                case "import":
                                    e.Text = lexem.Text + ": To import a module";
                                    break;
                                case "in":
                                    e.Text = lexem.Text + ": To check if a value is present in a list, tuple, etc.";
                                    break;
                                case "is":
                                    e.Text = lexem.Text + ": To test if two variables are equal";
                                    break;
                                case "lambda":
                                    e.Text = lexem.Text + ": To create an anonymous function";
                                    break;
                                case "None":
                                    e.Text = lexem.Text + ": Represents a null value";
                                    break;
                                case "nonlocal":
                                    e.Text = lexem.Text + ": To declare a non-local variable";
                                    break;
                                case "not":
                                    e.Text = lexem.Text + ": A logical operator";
                                    break;
                                case "or":
                                    e.Text = lexem.Text + ": A logical operator";
                                    break;
                                case "pass":
                                    e.Text = lexem.Text + ": A null statement, a statement that will do nothing";
                                    break;
                                case "raise":
                                    e.Text = lexem.Text + ": To raise an exception";
                                    break;
                                case "return":
                                    e.Text = lexem.Text + ": To exit a function and return a value";
                                    break;
                                case "True":
                                    e.Text = lexem.Text + ": Boolean value, result of comparison operations";
                                    break;
                                case "try":
                                    e.Text = lexem.Text + ": To make a try...except statement";
                                    break;
                                case "while":
                                    e.Text = lexem.Text + ": To create a while loop";
                                    break;
                                case "with":
                                    e.Text = lexem.Text + ": Used to simplify exception handling";
                                    break;
                                case "yield":
                                    e.Text = lexem.Text + ": To end a function, returns a generator";
                                    break;
                                default:
                                    break;
                            }
                         }
                        else return;
                    }
                }

            }
        }

        private void DanhDau_DragDrop(object sender, DragEventArgs e)

        {
            string dropfile = TabHienTai.FileName;
            TabHienTai.Close();
            DockPar.ActiveWindow.Close();
            TaoMoi(Path.GetFileName(dropfile), dropfile);
        
           
                   
        }

        private void DockPar_DockWindowClosing(object sender, DockWindowCancelEventArgs e)
        {
            try
            {
                if(Path.GetFileName(TabHienTai.FileName)==DockPar.DocumentManager.ActiveDocument.Text)
                {
                    foreach (var item in listClosedFiles.Items)
                    {
                        if (item.Text == TabHienTai.FileName) listClosedFiles.Items.Remove(item);
                    }
                    listClosedFiles.Items.Add(TabHienTai.FileName);

                    TabHienTai.Close();
                }else
                {
                    DockPar.DocumentManager.ActiveDocument.Close();
                }
              

                
            }
            catch { }
              
           
            
            
        }

        private void UpdateTheme()
        {
           if (themechanged == true)
            {

                switch (TenTheme)
                {
                    case "Fluent":
                        ThemeResolutionService.ApplicationThemeName = "Fluent";
                        try
                        {
                            //ThemeResolutionService.ApplicationThemeName = "Fluent";
                            //TabHienTai.Style = EditControlStyle.Office2016Colorful;
                            //TabHienTai.IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
                            //TabHienTai.LineNumbersColor = Color.Teal;
                            //TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                            //TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                            //this.WindowState = FormWindowState.Normal;
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

                            //thử cách 2  áp dùng hàng loạt các tab
                            foreach (var item in DockPar.DocumentManager.DocumentArray)
                            {
                                try
                                {
                                   
                                    (item.Controls[0] as EditControl).Style = EditControlStyle.Office2016DarkGray;
                                    (item.Controls[0] as EditControl).Style = EditControlStyle.Office2016Colorful;
                                    (item.Controls[0] as EditControl).IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
                                    (item.Controls[0] as EditControl).LineNumbersColor = Color.Teal;
                                    (item.Controls[0] as EditControl).ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                                    (item.Controls[0] as EditControl).BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                                    
                                    if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".pas")
                                    {
                                        string ConfigF = @"Lex\Pascal.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Pascal");
                                    }
                                    else
                                        if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".c" || Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".cpp")
                                    {
                                        string ConfigF = @"Lex\CppF.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("C++");
                                    }
                                    else if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".py")
                                    {
                                        string ConfigF = @"Lex\Python.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Python");
                                    }
                                    else if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".java")
                                    {
                                        string ConfigF = @"Lex\Java.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Java");
                                    }
                                }
                                catch
                                {

                                }
                                

                            }


                        }
                        catch { }
                        break;
                    case "FluentDark":
                        ThemeResolutionService.ApplicationThemeName = "FluentDark";
                        try
                        {

                            //TabHienTai.IndicatorMarginBackColor = Color.FromArgb(40, 42, 54);
                            //TabHienTai.LineNumbersColor = Color.FromArgb(98, 114, 164);
                            //TabHienTai.Style = EditControlStyle.Office2016DarkGray;
                            //TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
                            //TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
                            //ThemeResolutionService.ApplicationThemeName = "FluentDark";
                            //this.WindowState = FormWindowState.Normal;
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
                            //thử cách 2 áp dùng hàng loạt các tab
                            foreach (var item in DockPar.DocumentManager.DocumentArray)
                            {
                                try
                                {
                                    (item.Controls[0] as EditControl).IndicatorMarginBackColor = Color.FromArgb(40, 42, 54);
                                    (item.Controls[0] as EditControl).LineNumbersColor = Color.FromArgb(98, 114, 164);
                                    (item.Controls[0] as EditControl).Style = EditControlStyle.Office2016DarkGray;
                                    (item.Controls[0] as EditControl).ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
                                    (item.Controls[0] as EditControl).BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(40, 42, 54) });
                                    
                                    //this.WindowState = FormWindowState.Normal;
                                    if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".pas")
                                    {
                                        string ConfigF = @"Lex\Pascal_D.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Pascal");
                                    }
                                    else
                                        if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".c" || Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".cpp")
                                    {
                                        string ConfigF = @"Lex\CppF_D.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("C++");
                                    }
                                    else if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".py")
                                    {
                                        string ConfigF = @"Lex\Python_D.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Python");
                                    }
                                    else if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".java")
                                    {
                                        string ConfigF = @"Lex\Java_D.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Java");
                                    }
                                    
                                }
                                catch
                                {

                                }
                               
                            }
                        }
                        catch { }
                        break;
                    default:
                        ThemeResolutionService.ApplicationThemeName = "MaterialTeal";
                        try
                        {
                            /////Cách này chỉ hiệu quả cho từng tab
                            //ThemeResolutionService.ApplicationThemeName = "MaterialTeal";
                            //TabHienTai.Style = EditControlStyle.Office2016Colorful;
                            //TabHienTai.IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
                            //TabHienTai.LineNumbersColor = Color.Teal;
                            //TabHienTai.ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                            //TabHienTai.BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                            //this.WindowState = FormWindowState.Normal;
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

                            //thử cách 2. áp dùng hàng loạt các tab
                            foreach (var item in DockPar.DocumentManager.DocumentArray)
                            {
                                try
                                {
                                   
                                    (item.Controls[0] as EditControl).Style = EditControlStyle.Office2016Colorful;
                                    (item.Controls[0] as EditControl).IndicatorMarginBackColor = Color.FromArgb(249, 249, 249);
                                    (item.Controls[0] as EditControl).LineNumbersColor = Color.Teal;
                                    (item.Controls[0] as EditControl).ContextPromptBackgroundBrush = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                                    (item.Controls[0] as EditControl).BackgroundColor = new BrushInfo(GradientStyle.None, new Color[] { Color.FromArgb(249, 249, 249) });
                                    //this.WindowState = FormWindowState.Normal;
                                    if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".pas")
                                    {
                                        string ConfigF = @"Lex\Pascal.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Pascal");
                                    }
                                    else
                                        if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".c" || Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".cpp")
                                    {
                                        string ConfigF = @"Lex\CppF.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("C++");
                                    }
                                    else if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".py")
                                    {
                                        string ConfigF = @"Lex\Python.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Python");
                                    }
                                    else if (Path.GetExtension((item.Controls[0] as EditControl).FileName) == ".java")
                                    {
                                        string ConfigF = @"Lex\Java.xml";
                                        (item.Controls[0] as EditControl).Configurator.Open(ConfigF);
                                        (item.Controls[0] as EditControl).ApplyConfiguration("Java");
                                    }

                                }
                                catch
                                {

                                }
                               
                            }
                        }
                        catch { }
                        break;
               }
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
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

            Menu.ContextMenuProvider.SetVisualStyle(VisualStyle.Office2016DarkGray);




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
            if (ConsoleUse=="PowerShell")
            {
                string dan = Path.GetDirectoryName(TabHienTai.FileName);
                Process pw = new Process();
                pw.StartInfo.FileName = "powershell.exe";
                pw.StartInfo.WorkingDirectory = dan;
                pw.Start();
            }
            else
            {
                string dan = Path.GetDirectoryName(TabHienTai.FileName);
                Process pw = new Process();
                pw.StartInfo.FileName = @"Cmder\Cmder.exe";
                pw.StartInfo.Arguments ="/start "+ dan;
                pw.Start();
            }
          
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

        private void DanhDau_UpdateContextToolTip_ForPascal(object sender, UpdateTooltipEventArgs e)
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
                                    e.Text = lexem.Text + ": Defines start of an application. This keyword is usually optional.";
                                    break;
                                case "var":
                                    e.Text = lexem.Text + ": Used to declare variables";
                                    break;
                                case "and":
                                    e.Text = lexem.Text + ": Boolean operator requiring both conditions are true for the result to be true";
                                    break;
                                case "array":
                                    e.Text = lexem.Text + ": multiple elements with the same name";
                                    break;
                                case "asm":
                                    e.Text =lexem.Text+ ": start of code written in assembly language";
                                    break;
                                case "begin":
                                    e.Text = lexem.Text + ": start of a block of code ";
                                    break;
                                default:                                   
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
                        else return;
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
            //  https://doc.bccnsoft.com/docs/cppreference_en/keywords/index.html
            controller.Items.Add("auto", "	Declare a local variable");
            controller.Items.Add("double", "Declare a double precision floating-point variable");
            controller.Items.Add("int", "Declare a integer variable");
            controller.Items.Add("struct", "Define a new structure");
            controller.Items.Add("break", "Break out of a loop");
            controller.Items.Add("else", "Alternate case for an 'if' statement");
            controller.Items.Add("enum", "Create enumeration types");
            controller.Items.Add("register", "Request that a variable be optimized for speed");
            controller.Items.Add("typedef","Create a new type name from an existing type");
            controller.Items.Add("char","Declare a character variable");
            controller.Items.Add("extern","Tell the compiler about variables defined elsewhere");
            controller.Items.Add("return", "Return from a function");
            controller.Items.Add("union","A structure that assigns multiple variables to the same memory location");
            controller.Items.Add("const","Declare immutable data or functions that do not change data");
            controller.Items.Add("float","Declare a floating-point variable");
            controller.Items.Add("short","Declare a short integer variable");
            controller.Items.Add("unsigned","Declare an unsigned integer variable");
            controller.Items.Add("continue","Bypass iterations of a loop");
            controller.Items.Add("for","Looping construct");
            controller.Items.Add("signed","Modify variable type declarations");
            controller.Items.Add("void","Declare functions or data with no associated data type");
            controller.Items.Add("default","Default handler in a case statement");
            controller.Items.Add("goto","Jump to a different part of the program");
            controller.Items.Add("sizeof","Return the size of a variable or type");
            controller.Items.Add("volatile","Warn the compiler about variables that can be modified unexpectedly");
            controller.Items.Add("do","Looping construct");
            controller.Items.Add("if","Execute code based off of the result of a test");
            controller.Items.Add("static","Create permanent storage for a variable");
            controller.Items.Add("while","Looping construct");
            controller.Items.Add("true","The boolean value of true");
            controller.Items.Add("false","The boolean value of true");
            controller.Items.Add("private","Declare private members of a class");
            controller.Items.Add("protected","Declare protected members of a class");
            controller.Items.Add("public","Declare public members of a class");
            controller.Items.Add("try","Execute code that can throw an exception");
            controller.Items.Add("catch","Handles exceptions from throw");
            controller.Items.Add("dyamic_cash","Perform runtime casts");
            controller.Items.Add("reinterpret_cast","Change the type of a variable");
            controller.Items.Add("static_cast","Perform a nonpolymorphic cast");
            controller.Items.Add("const_cast","Cast from const variables");
            controller.Items.Add("throw","Throws an exception");
            controller.Items.Add("explicit","Only use constructors when they exactly match");
            controller.Items.Add("new","Allocate dynamic memory for a new variable");
            controller.Items.Add("this","A pointer to the current object");
            controller.Items.Add("asm","Insert an assembly instruction");
            controller.Items.Add("operator","Create overloaded operator functions");
            controller.Items.Add("namespace","Partition the global namespace by defining a scope");
            controller.Items.Add("typeid","Describes an object");
            controller.Items.Add("typename","Declare a class or undefined type");
            controller.Items.Add("class","Declare a class");
            controller.Items.Add("friend","Grant non-member function access to private data");
            controller.Items.Add("template","Create generic functions");
            controller.Items.Add("using","Import complete or partial namespaces into the current scope");
            controller.Items.Add("virtual","Create a function that can be overridden by a derived class");
            controller.Items.Add("delete","Make memory available");
            controller.Items.Add("inline","Optimize calls to short functions");
            controller.Items.Add("mutable","Override a const variable");
            controller.Items.Add("wchar_t","Declare a wide-character variable");
            controller.Items.Add("bool","Declare a boolean variable");
            controller.Items.Add("and","As an alternative for &&");
            controller.Items.Add("bitor","As an alternative for |");
            controller.Items.Add("not_eq","As an alternative for !=");
            controller.Items.Add("xor","As an alternative for ^");
            controller.Items.Add("and_eq","As an alternative for &=");
            controller.Items.Add("compl","As an alternative for ~");
            controller.Items.Add("or","As an alternative for ||");
            controller.Items.Add("not","As an alternative for !");
            controller.Items.Add("xor_eq","As an alternative for ^=");
            controller.Items.Add("bitand","As an alternative for &");
            controller.Items.Add("or_eq","As an alternative for |=");
            controller.Items.Add("export","Used to mark a template definition exported, which allows the same template to be declared, but not defined, in other translation units. ");
            controller.Items.Add("explicit");


        }

        private void DanhDau_ContextChoiceOpen(IContextChoiceController controller)
        {

            controller.Items.Add("begin", "Start of a block of code");
            controller.Items.Add("break", "	Exit a 'case' statement");
            controller.Items.Add("case", "Select a particular segement of code to execute based on a value");
            controller.Items.Add("const", "Declare an identifier with a fixed value, or a variable with an initialized value");
            controller.Items.Add("absolute", "");
            controller.Items.Add("and", "Boolean operator requiring both conditions are true for the result to be true");
            controller.Items.Add("array", "Multiple elements with the same name");
            controller.Items.Add("asm", "Start of code written in assembly language");
            controller.Items.Add("do", "	Used to indicate start of a loop");
            controller.Items.Add("downto", "Used in a for loop to indicate the index variable is decremented");
            controller.Items.Add("else", "Used in if statement to provide an execution path when the if test fails");
            controller.Items.Add("end", "End of a block of code, a record or certain other constructs");
            controller.Items.Add("constructor", "Routine used to create an object");
            controller.Items.Add("continue", "Skips an iteration in a for-loop and restart execution at the beginning of the loop");
            controller.Items.Add("destructor", "Routine used to deallocate an object");
            controller.Items.Add("div", "	Integer divide operator");
            controller.Items.Add("file", "External data structure, typically stored on disc");
            controller.Items.Add("for", "Loop used to increment or decrement a control variable");
            controller.Items.Add("function", "Define start of a routine that returns a result value");
            controller.Items.Add("goto", "	Used to exit a segment of code and jump to another point");
            controller.Items.Add("if", "Test a condition and perform a set of instructions based on the result");
            controller.Items.Add("implementation", "Define the internal routines in unit");
            controller.Items.Add("in", "	Identifies elements in a collection");
            controller.Items.Add("inherited", "Calls function/procedure from ancestor class");
            controller.Items.Add("inline", "Machine code inserted directly into a routine");
            controller.Items.Add("interface", "Public declarations of routines in a unit");
            controller.Items.Add("label", "Defines the target jump point for a goto");
            controller.Items.Add("mod", "Operator used to return the remainder of an integer division");
            controller.Items.Add("nil", "Pointer value indicating the pointer does not contain a value");
            controller.Items.Add("not", "	Boolean operator that negates the result of a test");
            controller.Items.Add("object", "	Defines an object construct");
            controller.Items.Add("of", "Defines the characteristics of a variable");
            controller.Items.Add("on", "Defines an exception handling statement in the Except part of a Try statement");
            controller.Items.Add("packed", "Indicates the elements of an array are to use less space (this keyword is primarily for compatibility with older programs as packing of array elements is generally automatic)");
            controller.Items.Add("operator", "Defines a routine used to implement an operator");
            controller.Items.Add("or", " Boolean operator which allows either of two choices to be used");
            controller.Items.Add("procedure", "Define start of a routine that does not return a result value");
            controller.Items.Add("program", "Defines start of an application. This keyword is usually optional.");
            controller.Items.Add("record", "Group a series of variables under a single name");
            controller.Items.Add("reintroduce");
            controller.Items.Add("repeat", "Loop through a section of code through an 'until' statement as long as the result of the test is true");
            controller.Items.Add("self", "Reference to an instance of a class");
            controller.Items.Add("set", "Group a collection");
            controller.Items.Add("shl", "Operator to shift a value to the left; equivalent to multiplying by a power of 2");
            controller.Items.Add("shr", "Operator to shift a value to the right; equivalent to dividing by a power of 2");
            controller.Items.Add("string", "Declares a variable that contains multiple characters");
            controller.Items.Add("then", "	Indicates start of code in an 'if' test");
            controller.Items.Add("to", "	indicates a 'for' variable is to be incremented");
            controller.Items.Add("type", "Declares kinds of records or new classes of variables");
            controller.Items.Add("unit", "Separately compiled module");
            controller.Items.Add("until", "	Indicates end test of a 'repeat' statement");
            controller.Items.Add("uses", "Names units this program or 'unit' refers to");
            controller.Items.Add("var", "Declare variables");
            controller.Items.Add("while", "Test a value and if true, loop through a section of code");
            controller.Items.Add("with", "Reference the internal variables within a record without having to refer to the record itself");
            controller.Items.Add("xor", "	Boolean operator used to invert and or test");
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
            Mo.Multiselect = true;

            if (Mo.ShowDialog() == DialogResult.OK)
            {
                foreach(var item in Mo.FileNames)
                {
                    try
                    {
                        TaoMoi(Path.GetFileName(item), item);
                        UpdateTheme();
                       
                    }

                   catch
                    { }
                }
               
            }

        }
        private void LuuHisto(string duongdantep )
        {
            try
            {
                //using (StreamWriter Viet = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz\\Histo.txt"))
                //{
                //    Viet.WriteLine(duongdantep);
                //}
                //foreach (var item in File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz\\Histo.txt"))
                //{
                //    if (item.ToString() != duongdantep||item==null)
                //        File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz\\Histo.txt", duongdantep + Environment.NewLine);
                //}
                File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz\\Histo.txt", duongdantep + Environment.NewLine);



            }
            catch { }
           
        }


        private void DcWelcome_Click(object sender, EventArgs e)
        {
            
        }

        private void FNew_Click(object sender, EventArgs e)
        {

            TaoMoi("Document " + chiso++, null);
            UpdateTheme();
        }
        void asd()
        {
            foreach(var isd in DockPar.DocumentManager.DocumentArray)
            {
               
            }
        }
        //TabStripItem StripHienTai
        //{
        //    get { return DockPar.DocumentManager.ActiveDocument.TabStripItem.n}
        //}
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
                //TabHienTai = value;
                DockPar.DocumentManager.ActiveDocument.ActiveControl = (value.Parent as EditControl);
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
        private string DuongDanTepExe(string ten)
        {
            return Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
        }
        private string TepEXE(string ten)
        {
            return Path.GetFileNameWithoutExtension(ten) + ".exe";
        }
        //Build tep
        void WatingLoad()
        {
            for(int i =0;i<500;i++)
            Thread.Sleep(10);
        }
        private void Build(string ten, bool enabledebug, ref RadListView outp)
        {
            //using (WaitingForm wait = new WaitingForm(WatingLoad))
            //{
            //    wait.ShowDialog(this);
            //}

            
            TabHienTai.Save();
            ListOutput.Items.Clear();
                ListOutput.Items.Add("Processing");
                if (Path.GetExtension(ten) == ".pas")
                {

                    Process BienDich = new Process();
                    BienDich.StartInfo.FileName = "cmd";
                    //BienDich.StartInfo.WorkingDirectory = @"Cmder\vendor\FPC\bin\i386-win32";
                    BienDich.StartInfo.UseShellExecute = false;
                    if (enabledebug == false)
                        BienDich.StartInfo.Arguments = "/c " + "fpc " + ten + PascalOption +Para;
                    else BienDich.StartInfo.Arguments = "/c " + "fpc " + ten + " -g" + PascalOption +Para;

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

                        if (ad.Contains("lines compiled"))
                    {
                        break;
                        

                    }
                      
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
                {
                    ShowAlert_Light("<html><color=LightSalmon>Build Failed", "Check output to view more",false);
                    BuildComplete = false;
                }
                       
                    else
                
            ShowAlert_Light("<html><color=Teal>Build Completed", "Ready to run", false);
                  
                
                       






                    //BienDich.WaitForExit();

                }

                else if (Path.GetExtension(ten) == ".c" || Path.GetExtension(ten) == ".cpp")
                {

                    Process BienDich = new Process();
                    BienDich.StartInfo.FileName = "cmd";
                    BienDich.StartInfo.UseShellExecute = false;
                    BienDich.StartInfo.RedirectStandardOutput = true;
                    BienDich.StartInfo.RedirectStandardError = true;
                    BienDich.StartInfo.RedirectStandardInput = true;
                //BienDich.StartInfo.WorkingDirectory = @"Cmder\vendor\occ60451e\orangec\bin";

             if (enabledebug == false)
                    BienDich.StartInfo.Arguments = "/c " + "g++ " +Para+" "+ ten + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
                    else BienDich.StartInfo.Arguments = "/c " + "g++ " + Para + " " + " -g " + ten + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";


                // if (enabledebug == false)
                //BienDich.StartInfo.Arguments = "/c " + "occ " + "/o" + Path.GetDirectoryName(ten) + "\\" + TepEXE(ten) + " " + ten;// + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";
                //  else BienDich.StartInfo.Arguments = "/c " + "occ " + " /g " + " /o" + Path.GetDirectoryName(ten) + "\\" + TepEXE(ten) + " " + ten;// + " -o " + Path.GetDirectoryName(ten) + "\\" + Path.GetFileNameWithoutExtension(ten) + ".exe";


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
                    if (ListOutput.Items.Count < 2)
                
                    ListOutput.Items.Add("Compile: " + Path.GetFileName(ten) + " - Completed, Ready to run");
                    

                
                   
                    else
                {
                    ListOutput.Items.Add("Build: " + Path.GetFileName(ten) + " - Fail");
                    BuildComplete = false;
                }

                  

                    foreach (var item in ListOutput.Items)
                    {
                        if (item.Text.ToLower().Contains("error")) item.BackColor = Color.LightSalmon;
                        if (item.Text.Contains("Completed")) item.BackColor = Color.LightGreen;
                        if (item.Text.Contains("- Fail")) item.BackColor = Color.LightSalmon;

                    }

                }
                else if(Path.GetExtension(ten)==".java")
            {
                Process BienDich = new Process();
                BienDich.StartInfo.FileName = "cmd";
                BienDich.StartInfo.UseShellExecute = false;
                BienDich.StartInfo.RedirectStandardOutput = true;
                BienDich.StartInfo.RedirectStandardError = true;
                BienDich.StartInfo.RedirectStandardInput = true;
               // BienDich.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\jdk\bin";
                if (enabledebug == false)
                    BienDich.StartInfo.Arguments = " /c " + "javac " + Para + " " + ten;
               else BienDich.StartInfo.Arguments = "/c " + "javac " + Para + " " + " -g " + ten;


                BienDich.StartInfo.CreateNoWindow = true;
                BienDich.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                BienDich.Start();

                string ad;

                ListOutput.AllowEdit = false;
                ListOutput.AllowRemove = false;
                while ((ad = BienDich.StandardError.ReadLine()) != null)
                {
                    ListOutput.Items.Add(ad);

                    // if (ad.Contains("lines compiled")) break;
                }
                if (ad==null)
                {
                    ListOutput.Items.Add("Completed");
                }
                foreach (var item in ListOutput.Items)
                {
                    if (item.Text.Contains("error")) item.BackColor = Color.LightSalmon;
                    if (item.Text.Contains("Completed")) item.BackColor = Color.LightGreen;
                    if (item.Text.Contains("- Fail")) item.BackColor = Color.LightSalmon;

                }
            }
            
            
          if(Directory.Exists(PathDirectory))
            {
                LoadDirectory(PathDirectory);
            }
        }





        private void GDB(string ten)
        {
            if(ConsoleUse == "PowerShell")
            {
                if (Path.GetExtension(ten) == ".pas")
                {
                    Process BienDich = new Process();
                    //Cho ListGDB


                    //
                    BienDich.StartInfo.FileName = "cmd";
                   // BienDich.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"Cmder\vendor\conemu-maximus5\ConEmu.exe";
                    BienDich.StartInfo.Arguments = " /c " + "gdb32 " + DuongDanTepExe(ten);
                    BienDich.Start();
                    //BienDich.BeginOutputReadLine();

                   
                    //  string output;

                    //while ((output = BienDich.StandardOutput.ReadLine()) != null)
                    //    list.Items.Add(output);

                }
                if (Path.GetExtension(ten) == ".c" || Path.GetExtension(ten) == ".cpp")
                {
                    Process BienDich = new Process();
                    BienDich.StartInfo.FileName = "cmd";
                    //BienDich.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"Cmder\vendor\conemu-maximus5\ConEmu.exe";
                    BienDich.StartInfo.Arguments = "/c " + "gdb32 " + DuongDanTepExe(ten);
                    BienDich.Start();
                   
                }

            }
            else
            {
                if (Path.GetExtension(ten) == ".pas")
                {
                    Process BienDich = new Process();
                    //Cho ListGDB

                  //  BienDich.StartInfo.Verb = "runas";
                    //
                    BienDich.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                  
                    BienDich.StartInfo.Arguments = "  -run gdb32 " + DuongDanTepExe(ten);
                    BienDich.Start();
                    //BienDich.BeginOutputReadLine();

                   
                    //  string output;

                    //while ((output = BienDich.StandardOutput.ReadLine()) != null)
                    //    list.Items.Add(output);

                }
                if (Path.GetExtension(ten) == ".c" || Path.GetExtension(ten) == ".cpp")
                {
                    
                    Process BienDich = new Process();
                   // BienDich.StartInfo.Verb = "runas";
                    BienDich.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                    BienDich.StartInfo.Arguments = "  -run gdb32 " + DuongDanTepExe(ten);
                    BienDich.Start();
                              
                    
                }

            }



        }



        private void Run(string file)
        {
            if (!File.Exists(DuongDanTepExe(TabHienTai.FileName)) && Path.GetExtension(file) != ".py" && Path.GetExtension(file) != ".java")
            {
                RadTaskDialogPage Tas = new RadTaskDialogPage();
                Tas.ShouldApplyTheme = true;
                
               
                Tas.Caption = "Warning!";
                Tas.Heading = "File not Found!";
                Tas.Text = "This file has not been compiled. Do you want to compile it?";
                Tas.Icon = RadTaskDialogIcon.Error;
                RadTaskDialogButton BuBuild = new RadTaskDialogButton();
                BuBuild.Text = "Build this file";
                BuBuild.Click += new EventHandler(delegate (object sender, EventArgs e)
                 {
                     Build(TabHienTai.FileName, deBug, ref ListOutput);
                 });
                Tas.CommandAreaButtons.Add(BuBuild);
                RadTaskDialogButton BuCant = new RadTaskDialogButton();
                BuCant.Text = "Cancel";
                BuCant.Click += new EventHandler(delegate (object sender, EventArgs e)
                {
                    this.Close();
                    return;
                });
                Tas.CommandAreaButtons.Add(BuCant);
                RadTaskDialog.ShowDialog(Tas);
            }
            else if( Path.GetExtension(file)==".py"||Path.GetExtension(file)==".java"|| Path.GetExtension(file) == ".pas"|| Path.GetExtension(file) == ".c"|| Path.GetExtension(file) == ".cpp" && BuildComplete==true)
            {

                if (ConsoleUse == "PowerShell")
                {
                    //


                    if (Path.GetExtension(file) == ".pas")
                    {
                        Process Chay = new Process();

                        Chay.StartInfo.WorkingDirectory = Path.GetDirectoryName(file);
                        //Path.GetFileNameWithoutExtension(file) + ".exe"
                        Chay.StartInfo.FileName = DuongDanTepExe(file);
                        Chay.StartInfo.UseShellExecute = true;

                        //Chay.WaitForExit();
                        Chay.Start();
                    }
                    if (Path.GetExtension(file) == ".c" || Path.GetExtension(file) == ".cpp")
                    {

                        Process Chay = new Process();
                        Chay.StartInfo.UseShellExecute = false;
                        Chay.StartInfo.FileName = "cmd.exe";
                        //Chay.StartInfo.WorkingDirectory = Application.ExecutablePath + @"\Cmder\vendor\TDM-GCC-32\bin";
                        Chay.StartInfo.Arguments = "/c " + DuongDanTepExe(file) + "  -static-libgcc -static-libstdc++";
                        //MessageBox.Show(DuongDanTepExe(file) + " -static-libgcc -static-libstdc++");

                        Chay.Start();
                    }
                    if (Path.GetExtension(file) == ".py")
                    {
                        Process Chay = new Process();
                        Chay.StartInfo.FileName = "cmd";
                        //Chay.StartInfo.WorkingDirectory = @"Cmder\vendor\Python\Python38-32";
                        Chay.StartInfo.Arguments = "/c" + " python " + file;
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
                    if(Path.GetExtension(file)==".java")
                    {
                        Process Chay = new Process();
                        Chay.StartInfo.FileName = "cmd";                        
                        Chay.StartInfo.Arguments = "/c" + "java " + file;
                        Chay.Start();
                        Chay.WaitForExit();
                    }

                    //
                }
                else
                {

                    if (Path.GetExtension(file) == ".pas")
                    {
                        Process Chay = new Process();
                        Chay.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                        //Lấy path ở Roaming
                        //Chay.StartInfo.Verb = "runas";
                        Chay.StartInfo.Arguments = "-run  " + DuongDanTepExe(file);
                        Chay.Start();

                    }
                    if (Path.GetExtension(file) == ".c" || Path.GetExtension(file) == ".cpp")
                    {

                        Process Chay = new Process();

                        //Chay.StartInfo.Verb = "runas";
                        // Chay.StartInfo.FileName = @"Cmder\Cmder.exe";
                        Chay.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                        //Chay.StartInfo.WorkingDirectory = @"Cmder\vendor\TDM-GCC-32\bin";
                        Chay.StartInfo.Arguments = "-run " + DuongDanTepExe(file);// + "  -static-libgcc -static-libstdc++";
                        //Fixed, Khi chạy từ process mới thì path không được set, phải sẽ manual :b               
                        Chay.Start();

                        Chay.WaitForExit();

                    }
                    if (Path.GetExtension(file) == ".py")
                    {

                        Process Chay = new Process();
                        
                        Chay.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                        Chay.StartInfo.Arguments = " -run python " + file;
                        //Để ý dấu - phải sát với lệnh
                        Chay.Start();
                        Chay.WaitForExit();
                        //Fixed!

                    }
                    if(Path.GetExtension(file)==".java")
                    {
                        Process Chay = new Process();

                        Chay.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                        Chay.StartInfo.Arguments = "-dir "+ Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\jdk-11.0.11\bin  " + " -run java " + file;
                        Chay.Start();
                       // Chay.WaitForExit();
                    }
                }
            }
          

           


        }
        /// <summary>
        /// Test các tính năng phụ lẻ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dark_Click(object sender, EventArgs e)
        {
            if (TenTheme != "FluentDark")
            {
                TenTheme = "FluentDark";
                themechanged = true;
                UpdateTheme();
            }
            else themechanged = false;
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
            //Tạo waitting form
            

            //
           
           //fixed 20/6
            

            try
            {
                
                if (File.Exists(TabHienTai.FileName))
                    DockPar.DocumentManager.ActiveDocument.Text = Path.GetFileName(TabHienTai.FileName);

                if (Path.GetExtension(TabHienTai.FileName) == ".py")
                    ShowAlert_Light("<html><color=LightSalmon>Build Failed", "<html><color=Teal>Python can only be <b>RUN</b> directly", false);
                else
                {
                   // var thread = new Thread(ThreadStart);

                    //thread.TrySetApartmentState(ApartmentState.STA);
                    //thread.Start();
                    Build(TabHienTai.FileName, deBug, ref ListOutput);
                    //thread.Abort();
                }
                
            }
            catch { }
           

        }
       
       
        private void BBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                
                BrushInfo brushInfo = new BrushInfo(Color.Turquoise);
                TabHienTai.BookmarkAdd(TabHienTai.CurrentLine, brushInfo,Color.Transparent);
                if(File.Exists(TabHienTai.FileName))
                bookmarkList.Items.Add(TabHienTai.CurrentLine, Path.GetFileName(TabHienTai.FileName), TabHienTai.FileName);
                else
                    bookmarkList.Items.Add(TabHienTai.CurrentLine, DockPar.DocumentManager.ActiveDocument.TabStripItem.Text, "None");


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
                if(File.Exists(TabHienTai.FileName))
                {
                    foreach (var item in bookmarkList.Items)
                    {
                        if (item[0].ToString() == TabHienTai.CurrentLine.ToString() && Path.GetFileName(TabHienTai.FileName) == item[1].ToString())
                            bookmarkList.Items.Remove(item);
                    }
                }
                else
                {
                    foreach (var item in bookmarkList.Items)
                    {
                        if (item[0].ToString() == TabHienTai.CurrentLine.ToString() && DockPar.DocumentManager.ActiveDocument.TabStripItem.Text == item[1].ToString())
                            bookmarkList.Items.Remove(item);
                    }
                }
                
              
            }
            catch { }


        }

        private void BRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.BookmarkClear();
               
                    if (File.Exists(TabHienTai.FileName))
                    {
                    foreach (ListViewDataItem item in bookmarkList.Items.ToList())
                    {

                        if (item[1].ToString().Contains(Path.GetFileName(TabHienTai.FileName)))
                            bookmarkList.Items.Remove(item);
                     }      
                        
                    }

                    else
                    {
                    foreach (ListViewDataItem item in bookmarkList.Items.ToList())
                    {
                        if (item[1].ToString().Contains(DockPar.DocumentManager.ActiveDocument.TabStripItem.Text))
                            bookmarkList.Items.Remove(item);
                    }
                }
                
                   
            }
            catch { }
            
        }

        private void TFind_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ShowFindDialog();
                
            }
            catch
            {

            }
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
                ShowAlert_Light("<html><color=Teal><b>You have enabled debugging mode</b> ", "<html><i><span><color=Teal>Please compile again to initialize</span></i>", false);
                deBug = true;
                DEnable.Text = "Disable Debug";

            }
            else
            {
                ShowAlert_Light("<html><color=Crimson><b> You have disabled debugging mode </b> ", "<html><i><span><color=Teal>Compiler will not initialize debug information</span></i>", false);
                deBug = false;
                DEnable.Text = "Enable Debug";

            }


        }

        private void FSave_Click(object sender, EventArgs e)
        {



            try
            {

            //if (TabHienTai.GetNewLineStyle() != Syncfusion.IO.NewLineStyle.Windows||TabHienTai.GetEncoding() != Encoding.ASCII && Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
            //{
            //    TabHienTai.SaveFile(TabHienTai.FileName,Encoding.ASCII, Syncfusion.IO.NewLineStyle.Unix);

            //}
            //else
            //try {if (TabHienTai.GetNewLineStyle() != Syncfusion.IO.NewLineStyle.Windows || TabHienTai.GetEncoding() != Encoding.ASCII && Path.GetExtension(TabHienTai.FileName) == ".java")
            //    {
            //        TabHienTai.SaveFile(TabHienTai.FileName, Encoding.ASCII, Syncfusion.IO.NewLineStyle.Unix);
            //    } }
            //catch { }
                    

                //TabHienTai.SetEncoding(Encoding.UTF8);

                TabHienTai.Save();

                if (Path.GetExtension(TabHienTai.FileName) == ".py")
                    TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
                if (Path.GetExtension(TabHienTai.FileName) == ".pas")
                    TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
                if (Path.GetExtension(TabHienTai.FileName) == ".c" || Path.GetExtension(TabHienTai.FileName) == ".cpp")
                    TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";
                if (Path.GetExtension(TabHienTai.FileName) == ".java")
                    TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Java";
                TabHienTai.StatusBarSettings.StatusPanel.Panel.Text = "Saved";
                TabHienTai.StatusBarSettings.StatusPanel.Panel.BackColor = Color.DarkCyan;
                TabHienTai.StatusBarSettings.StatusPanel.Panel.ForeColor = Color.White;

                if (Path.GetFileName(TabHienTai.FileName) != DockPar.DocumentManager.ActiveDocument.Text)
                {
                    DockPar.DocumentManager.ActiveDocument.Text = Path.GetFileName(TabHienTai.FileName);
                }

            }
            catch { MessageBox.Show("Có lỗi xảy ra!"); }
            
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
                    ShowAlert_Light("<html><color=Blue>Bạn chưa bật GDB Debug", "<html><i>Nếu chưa biết sử dụng, hay tham khảo ở<span><color=Teal> Mục</span></i>", false);
                }
            }
            catch { }
        }
        private void ShowAlert_Light(string cap, string content,bool pin)
        {
            RadDesktopAlert al = new RadDesktopAlert();
            
            al.CaptionText = cap;
            al.Opacity = 0.8f;
            al.PopupAnimationDirection = RadDirection.Up;
            al.ScreenPosition = AlertScreenPosition.BottomRight;
            al.ContentText = content;
            if (pin == false)
                al.AutoCloseDelay = 5;
            else
                al.IsPinned = true;
            
            al.AutoSize = true;
            al.ThemeName = "Windows8";
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
                ShowAlert_Light("<html><color=Teal>Context Intellisense Enabled", null, false);
            }
            else
            {
                ShowAlert_Light("<html><color=Crimson>Context Intellisense Disabled", null, false);
                enableContext = false;
                OEnableContext.Text = "Enable Context Intellisense";
            }
        }

        private void PerReadonly_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ReadOnly = true;
                ShowAlert_Light("<html><color=Crimson>Readonly Enabled", null, false);
            }
            catch { };

        }

        private void PerDisable_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ReadOnly = false;
                ShowAlert_Light("<html><color=Teal>Readonly Disabled", null, false);
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
                ShowAlert_Light("<html><color=Teal>Context Tooltip Enabled", null, false);
                OCTooltip.Text = "Disable Context Tooltip";
            }
            else
            {
                enableTooltip = false;
                ShowAlert_Light("<html><color=Crimson>Context Tooltip Disabled", null, false);
                OCTooltip.Text = "Enable Context Tooltip";

            }
        }

        private void OEnaPrompt_Click(object sender, EventArgs e)
        {
            if (enableContextPrompt == false)
            {
                enableContextPrompt = true;
                ShowAlert_Light("<html><color=Teal>Context Prompt Enabled", null, false);
                OEnaPrompt.Text = "Disable Context Prompt";

            }
            else
            {
                enableContextPrompt = false;
                ShowAlert_Light("<html><color=Crimson>Context Prompt Disabled", null, false);
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
            pd.ThumbnailListWidth = 0;
            pd.ThumbnailsScaleFactor = 0;
            pd.EnableThumbnails = false;
            pd.Dock = DockStyle.Fill;
            pd.LoadDocument(@"Documents\ASCII_Table.pdf");
           
        }

        private void HAbout_Click(object sender, EventArgs e)
        {
            About_Z ab = new About_Z();
            ab.ShowDialog();
        }

        private void MPcurrentline_Click(object sender, EventArgs e)
        {
            RadColorDialog Col = new RadColorDialog( );
            Col.Icon = null;
            

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
                    ShowAlert_Light("<html>Show line number <color=Teal>ON", null, false);
                }

                else
                {
                    TabHienTai.ShowLineNumbers = false;
                    showlinenum = false;
                    ShowAlert_Light("<html>Show line number <color=Crimson>OFF", null, false);
                }
            }
            catch { }
        }

        private void ELight_Click(object sender, EventArgs e)
        {
            if (TenTheme != "Fluent")
            {
                TenTheme = "Fluent";
                themechanged = true;
                UpdateTheme();
            }
            
            else themechanged = false;

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
           
          //  radPdfViewer1.LoadDocument(@"C:\Users\HLK9\Desktop\TraCuu.pdf");
            
        }

        private void DockPar_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
           // UpdateTheme();
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

            if(ConsoleUse =="PowerShell")
            {
                Process pw = new Process();
                pw.StartInfo.FileName = "powershell.exe";

                pw.Start();
            }
            else
            {
                Process pw = new Process();

                pw.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz"+@"\Cmder\Cmder.exe";
               // pw.StartInfo.Arguments = "/start " + Application.StartupPath;
                pw.Start();
            }
           
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
           
            string Phantich = @"\(\d+\,\d+\)|\:\d+\:\d+\:|\:\d+\:|\(\d+\)";
            
            string chuoi = ListOutput.SelectedItem.Text;
            int a = ListOutput.SelectedIndex;
            string sda = ListOutput.Items[a + 1].Text;
            //string ret;
            MatchCollection df = Regex.Matches(chuoi, Phantich);
            
                foreach (Match sd in df)
            {

                string phan2 = @"\d+";
                MatchCollection df2 = Regex.Matches(sd.ToString(), phan2);

                if (Path.GetExtension(TabHienTai.FileName) == ".java")
                {

                    TabHienTai.FindText(sda, false);
                }else                   
               TabHienTai.GoTo(int.Parse(df2[0].ToString()));
               
            }
               
            
        }

        private void TEmail_Click(object sender, EventArgs e)
        {
           // Pathtosendemail = TabHienTai.FileName;
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
            DockPar.DocumentManager.ActivateNextDocument();
            DockPar.ShowDocumentCloseButton = true;
                   
                
        }
        private void Uo()
        {
          
        }

        private void EMatiral_Click(object sender, EventArgs e)
        {
            if (TenTheme != "MaterialTeal")
            {
                TenTheme = "MaterialTeal";
                themechanged = true;
                UpdateTheme();
            }
            else themechanged = false;
           
            
            
          

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

        private void TCmder_Click(object sender, EventArgs e)
        {
            Process.Start(@"Cmder\Cmder.exe");
        }

        private void ConC_Click(object sender, EventArgs e)
        {
            ConsoleUse = "PowerShell";
            ShowAlert_Light("<html><color=Teal>Terminal Has Been Changed", "<html>Current: <span><color=Crimson>PowerShell</span>", false);
        }

        private void ConCmder_Click(object sender, EventArgs e)
        {
            ConsoleUse = "Cmder";
            ShowAlert_Light("<html><color=Teal>Terminal Has Been Changed", "<html>Current: <span><color=Crimson>Cmder</span>", false);
        }

        private void DGui_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 0.5F;
            }
            catch
            {

            }
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 0.75F;
            }
            catch
            {

            }
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 1F;
            }
            catch
            {

            }
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 1.25F;
            }
            catch
            {

            }
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 1.5F;
            }
            catch
            {

            }
        }

        private void radMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 2F;
            }
            catch
            {

            }
        }

        private void radMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 2.5F;
            }
            catch
            {

            }
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.ZoomFactor = 3.5F;
            }
            catch
            {

            }
        }

        private void BBuildaRun_Click(object sender, EventArgs e)
        {
            TabHienTai.Save();
            try
            {
                Build(TabHienTai.FileName, deBug, ref ListOutput);
                Run(TabHienTai.FileName);
            }
            catch { }
           
        }

        private void documentWindow1_Click(object sender, EventArgs e)
        {
           
        }

        

        private void ScreatPas_Click(object sender, EventArgs e)
        {
            TaoMoi("Document " + chiso++, null);

            string ConfigF = @"Lex\Pascal.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("Pascal");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen;
            TabHienTai.ContextPromptOpen += DanhDau_ContextPromptOpen_ForPascal;
            TabHienTai.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForPascal;

            UpdateTheme();
        }

        private void ScreatePython_Click(object sender, EventArgs e)
        {
            TaoMoi("Document " + chiso++, null);

            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
            string ConfigF = @"Lex\Python.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("Python");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen_ForPython;

            UpdateTheme();
        }

        private void radLabel5_Click(object sender, EventArgs e)
        {
            TaoMoi("Document " + chiso++, null);

            string ConfigF = @"Lex\CppF.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("C++");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen_C;
            TabHienTai.ContextPromptOpen += DanhDau_ContextPromptOpen_ForC;
            TabHienTai.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForC;

            UpdateTheme();
        }

        //private void recentList_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        //{
        //    try
        //    {
        //        TaoMoi(Path.GetFileName(recentList.SelectedItem.Text), recentList.SelectedItem.Text);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error", "This file not exist", MessageBoxButtons.OK,MessageBoxIcon.Error);
        //    }
            
        //}

        private void radRichTextEditor1_Click(object sender, EventArgs e)
        {

        }

        private void HLookUp_Click(object sender, EventArgs e)
        {
            DocumentWindow Las = new DocumentWindow("Look Up");
            DockPar.AddDocument(Las);
            RadPdfViewer Lok = new RadPdfViewer();
            Las.Controls.Add(Lok);
            Lok.Dock = DockStyle.Fill;
            Lok.ThemeName = "MaterialTeal";
            Lok.ThumbnailListWidth = 0;
            Lok.ThumbnailsScaleFactor = 0;
            Lok.EnableThumbnails = false;
            
            
        }

      

        private void radMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.PrintPreview();

            }
            catch { }
        }

        private void radMenuItem14_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.PrintSelection();
            }
            catch { }
        }

        private void radMenuItem15_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabHienTai.ActiveControl != null) TabHienTai.Print();
            }
            catch { }
        }

        private void DSetDiff_Click(object sender, EventArgs e)
        {
            try
            {
                DiffOldText = TabHienTai.Text;
                ShowAlert_Light("<html><Color=Teal><b>Different has been set!</b>", "<html><Color=Crimson>You can Compare code after changes", false);
            }
            catch {
                ShowAlert_Light("<html><Color=Teal><b>Couldn't set Different</b>", "<html><Color=Crimson>Code not Found!", false);
            }
           
            //try
            //{
               
            //    if (!File.Exists(TabHienTai.FileName))
            //    {
            //        DiffOldText = TabHienTai.Text;
            //    }
            //    else
            //        DiffOldText = File.ReadAllText(TabHienTai.FileName);

            //}
            //catch { }
            
        }

        private void DOpenDiff_Click(object sender, EventArgs e)
        {
            if (DiffOldText != null)
            {
                DiffNewText = TabHienTai.Text;
                DiffViewer Diff = new DiffViewer();
                Diff.OldText = DiffOldText;
                Diff.NewText = DiffNewText;
                Diff.FontFamilyNames = "Cascadia Code";
                Diff.FontSize = 16;
                Diff.ShowSideBySide();
                Diff.NewTextHeader = "New";
                Diff.OldTextHeader = "Old";
                Diff.IgnoreWhiteSpace = true;

                Diff.Dock = DockStyle.Fill;
                DocumentWindow Do = new DocumentWindow("Different Merge");
                Do.Controls.Add(Diff);
                DockPar.AddDocument(Do);
                
            }
            else
                ShowAlert_Light("<html><Color=Teal><b>Couldn't find code to compare</b>", "<html><Color=Crimson>You need set Different to Compare", false);

         
        }

        private void DDiffDialog_Click(object sender, EventArgs e)
        {
            DifferentMer df = new DifferentMer();
            df.ShowDialog();
        }

        private void radLabel11_Click(object sender, EventArgs e)
        {
           
        }

        private void radMenuItem16_Click(object sender, EventArgs e)
        {
            DockPar.DocumentManager.ActivatePreviousDocument();
        }

        private void SwitchNext_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DocumentManager.ActivateNextDocument();
            }
            catch
            {
                
            }
        }

        private void SwitchPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DocumentManager.ActivatePreviousDocument();
            }
            catch { }
        }

        private void OHightlight_Click(object sender, EventArgs e)
        {
            if (highlight == true)
            {
                TabHienTai.HighlightCurrentLine = false;
                OHightlight.Text = "Show Hightlight Current Line";
                highlight = false;
            }
            else
            {
                TabHienTai.HighlightCurrentLine = true;
                OHightlight.Text = "Hide Hightlight Current Line";
                highlight = true;

            }
        }

        private void listClosedFiles_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {

            try
            {
                TaoMoi(Path.GetFileName(listClosedFiles.SelectedItem.Text), listClosedFiles.SelectedItem.Text);
            }
            catch
            {
                MessageBox.Show("Error", "This file not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wclPascal_Click(object sender, EventArgs e)
        {
            TaoMoi("Document " + chiso++, null);

            string ConfigF = @"Lex\Pascal.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("Pascal");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Pascal";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen;
            TabHienTai.ContextPromptOpen += DanhDau_ContextPromptOpen_ForPascal;
            TabHienTai.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForPascal;

            UpdateTheme();
        

      
    }

        private void wclPython_Click(object sender, EventArgs e)
        {
            
            TaoMoi("Document " + chiso++, null);

            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
            string ConfigF = @"Lex\Python.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("Python");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Python";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen_ForPython;

            UpdateTheme();
        

     
    }

        private void wclCc_Click(object sender, EventArgs e)
        {
             
            TaoMoi("Document " + chiso++, null);

            string ConfigF = @"Lex\CppF.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("C++");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "C/C++";
            TabHienTai.ContextChoiceOpen += DanhDau_ContextChoiceOpen_C;
            TabHienTai.ContextPromptOpen += DanhDau_ContextPromptOpen_ForC;
            TabHienTai.ContextPromptUpdate += DanhDau_ContextPromptUpdate_ForC;

            UpdateTheme();
        
    }

        private void wclOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog Mo = new OpenFileDialog();
            Mo.Multiselect = true;

            if (Mo.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in Mo.FileNames)
                {
                    try
                    {
                        TaoMoi(Path.GetFileName(item), item);
                        UpdateTheme();

                    }

                    catch
                    { }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void recentList_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            try
            {
                TaoMoi(Path.GetFileName(recentList.SelectedItem.Text), recentList.SelectedItem.Text);
            }
            catch
            {
                MessageBox.Show("Can't load this file", "Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void PCustom_Click(object sender, EventArgs e)
        {
            
        }

        private void MOptions_Click(object sender, EventArgs e)
        {

        }

        private void OutputShow_Click(object sender, EventArgs e)
        {
            Doutput.Show();
        }

        private void OutputHide_Click(object sender, EventArgs e)
        {
            Doutput.Hide();
        }

        private void VOutput_Click(object sender, EventArgs e)
        {
            if (showOutput==true)
            {
                showOutput = false;
                Doutput.Hide();
                VOutput.Text = "Show Output";
            }
            else
            {
                showOutput = true;
                Doutput.Show();
                VOutput.Text = "Hide Output";
            }
        }

        private void VClosedList_Click(object sender, EventArgs e)
        {
            if(showClosed == true)
            {
                DClosedFiles.Hide();
                showClosed = false;
                VClosedList.Text = "Show Closed List";
            }
            else
            {
                DClosedFiles.Show();
                showClosed = true;
                VClosedList.Text = "Hide Closed List";
            }
        }

        private void VClipboardList_Click(object sender, EventArgs e)
        {
            if(showClipboard == true)
            {
                Dclipboard.Hide();
                showClipboard = false;
                VClipboardList.Text = "Show Clipboard List";
            }
            else
            {
                Dclipboard.Show();
                showClipboard = true;
                VClipboardList.Text = "Hide Clipboard";
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.SplitHorizontally();
            }
            catch
            {

            }
            
        }

        private void VSplitVertical_Click(object sender, EventArgs e)
        {
            try
            {
                TabHienTai.SplitVertically();
            }
            catch
            { }
        }

        private void radMenuItem3_Click_2(object sender, EventArgs e)
        {
            TabHienTai.VScrollMode = ScrollMode.Immediate;
            TabHienTai.LikeVisualStudioSearch = true;
        }

        private void radMenuItem16_Click_1(object sender, EventArgs e)
        {
            TabHienTai.VScrollMode = ScrollMode.Deferred;
        }

        private void radMenuItem17_Click(object sender, EventArgs e)
        {
            TabHienTai.VScrollMode = ScrollMode.Pixel;
        }

        private void radMenuItem18_Click(object sender, EventArgs e)
        {
            //DockPar.DockWindow(DockPar.DocumentManager.ActiveDocument, DockPosition.Fill);
           
            //DockPar.DockControl(DockPar.DocumentManager.ActiveDocument, DockPosition.Fill, DockType.Document);
            //DockPar.FloatWindow(DockPar.DocumentManager.ActiveDocument);

            

        }

        private void DeJDB_Click(object sender, EventArgs e)
        {
            if(deBug == true)
            {
                if (File.Exists(TabHienTai.FileName))
                {
                    if (Path.GetExtension(TabHienTai.FileName) == ".java")
                    {
                        if (ConsoleUse == "PowerShell")
                        {
                            Process JDB = new Process();
                            JDB.StartInfo.FileName = "cmd";
                            JDB.StartInfo.Arguments = "/c " + " jdb " + TabHienTai.FileName;
                            JDB.Start();
                            JDB.WaitForExit();

                        }
                        else
                        {
                            Process JDB = new Process();
                            JDB.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                            JDB.StartInfo.Arguments = "-run " + " jdb " + TabHienTai.FileName;
                            JDB.Start();
                            JDB.WaitForExit();

                        }
                    }
                }
                else
                    MessageBox.Show("Couldn't load this file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ShowAlert_Light("<html><color=Crimson><b>You have not enabled debug mode </b>", null, false);
            }
           
          
        }

        private void wlcJava_Click(object sender, EventArgs e)
        {
            TaoMoi("Document " + chiso++, null);

            string ConfigF = @"Lex\Java.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("Java");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Java";
            UpdateTheme();
        }

        private void SynJava_Click(object sender, EventArgs e)
        {
            string ConfigF = @"Lex\Java.xml";
            TabHienTai.Configurator.Open(ConfigF);
            TabHienTai.ApplyConfiguration("Java");
            TabHienTai.StatusBarSettings.FileNamePanel.Panel.Text = "Java";
        }

        private void EncodeUTF8_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(TabHienTai.FileName))
                {
                    TabHienTai.LoadFile(TabHienTai.FileName, Encoding.UTF8);

                }
                else
                {
                    MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            { }
        }

        private void EncodeUS_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(TabHienTai.FileName))
                {
                    TabHienTai.LoadFile(TabHienTai.FileName, Encoding.ASCII);

                }
                else
                {
                    MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            { }
           
        }

        private void Encode1252_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (File.Exists(TabHienTai.FileName))
                {
                    TabHienTai.LoadFile(TabHienTai.FileName, Encoding.GetEncoding("windows-1252"));

                }
                else
                {
                    MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void WFloat_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.FloatWindow(DockPar.DocumentManager.ActiveDocument);
            }
            catch
            {}
          
        }

        private void WFloatAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in DockPar.DocumentManager.DocumentArray)
                {
                    DockPar.FloatWindow(item);
                }
            }
            catch { }
           
        }

        private void WResetWindows_Click(object sender, EventArgs e)
        {
            foreach (var item in DockPar.ActiveFloatingWindows)
            {
                item.Activate();
                DockPar.DockWindow(DockPar.ActiveWindow, DockPosition.Fill);

           }
        }

        private void WCloseAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in DockPar.DocumentManager.DocumentArray)
                {
                    item.Close();
                }
            }
            catch
            {

            }
            
        }

        private void WCloseCur_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DocumentManager.ActiveDocument.Close();
            }
            catch { }
        }

        private void DockLeft_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DockWindow(DockPar.DocumentManager.ActiveDocument, DockPosition.Left);
            }
            catch
            { }
        }

        private void DockRight_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DockWindow(DockPar.DocumentManager.ActiveDocument, DockPosition.Right);
            }
            catch
            { }
        }

        private void DockFill_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DockWindow(DockPar.ActiveWindow, DockPosition.Fill);
            }
            catch
            { }
        }

        private void DockTop_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DockWindow(DockPar.DocumentManager.ActiveDocument, DockPosition.Top);
            }
            catch
            { }
        }

        private void DockBottom_Click(object sender, EventArgs e)
        {
            try
            {
                DockPar.DockWindow(DockPar.DocumentManager.ActiveDocument, DockPosition.Bottom);
            }
            catch
            { }
        }

        private void radMenuItem3_Click_3(object sender, EventArgs e)
        {
            
        }

        private void radMenuItem16_Click_2(object sender, EventArgs e)
        {
            TabHienTai.SaveFile(TabHienTai.FileName, TabHienTai.GetEncoding(), Syncfusion.IO.NewLineStyle.Windows);
        }

        private void radMenuItem17_Click_1(object sender, EventArgs e)
        {
            //  TabHienTai.SetUnderline(new Point())
            TabHienTai.ShowCodeSnippets();
        }

        private void DebugPython_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(TabHienTai.FileName))
                {
                    if (Path.GetExtension(TabHienTai.FileName) == ".py" && deBug == true)
                    {
                        Process PythonDebugger = new Process();
                        if (ConsoleUse == "PowerShell")
                        {
                            PythonDebugger.StartInfo.FileName = "cmd";
                            PythonDebugger.StartInfo.Arguments = "/c python -m pdb " + TabHienTai.FileName;
                            PythonDebugger.Start();
                            PythonDebugger.WaitForExit();
                        }
                        else
                        {
                            PythonDebugger.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";
                            PythonDebugger.StartInfo.Arguments = "/run python -m pdb " + TabHienTai.FileName;
                            PythonDebugger.Start();
                            PythonDebugger.WaitForExit();

                        }
                    }
                    else
                    {
                        ShowAlert_Light("<html><color=Crimson><b>This Debugger Support for Python Only and Debug Mode Enable</b>", null, false);
                    }
                }
                else
                {
                    MessageBox.Show("File not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }

          
        }

        private void BPara_Click(object sender, EventArgs e)
        {
            using (ParametDialog fd = new ParametDialog())
            {
                
                if (fd.ShowDialog()== DialogResult.OK)
                {
                    
                    Para = fd.ParametText;
                }
            }
           // MessageBox.Show(Para);
        }

        private void BConfig_Click(object sender, EventArgs e)
        {
            using (BuildConfig bl = new BuildConfig())
            {
                if(bl.ShowDialog() == DialogResult.OK)
                {
                    PascalOption = bl.PascalOp;
                }
            }
            
        }

       

        private void EDupli_Click(object sender, EventArgs e)
        {

            try
            {
                TabHienTai.MoveToLineEnd();
                int a = TabHienTai.CurrentColumn;
                TabHienTai.InsertText(TabHienTai.CurrentLine, a, Environment.NewLine + TabHienTai.CurrentLineText);
            }
            catch
            { }
        }
        private bool isServer = false;
        private void SStartServer_Click(object sender, EventArgs e)
        {
            var args = e as MouseEventArgs;
            if(args.Button == MouseButtons.Right)
            {
                using (ParametDialog fd = new ParametDialog())
                {
                    fd.Text = "Connection Setting";
                    fd.radLabel1.Text = "Change Port Address (Number)";
                    fd.radLabel2.Text = "Note: You can't change IP Address. Can only change Port";
                    fd.radButton3.Enabled = false;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {

                        txtPort = fd.ParametText;
                    }
                }
                bool isIntString = txtPort.All(char.IsDigit);
                if (!isIntString||txtPort=="")
                {
                    MessageBox.Show("Port invalid! Reset to 4444", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPort = "4444";
                    SStartServer.ToolTipText = "Start Server with IP: " + GetLocalIP() + " Port: "+txtPort;
                }
                    
                else
                    SStartServer.ToolTipText = "Start Server with IP: " + GetLocalIP() + " Port: " + txtPort;
                return;
            }
           
            if(!isConnected)
            Connect_Ser();
        }
        private string txtPort= "4444";
        

        ///Server///////////////////////////////////////////////
        IPEndPoint IPServer;
        Socket server;
        private bool isConnected = false;
        List<Socket> clientlist = new List<Socket>();
        void Connect_Ser()
        {
            //bool isIntString = txtPort.All(char.IsDigit);
            //if(isIntString)
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                IPServer = new IPEndPoint(IPAddress.Parse(GetLocalIP()), int.Parse(txtPort));
                isServer = true;
                SConnect.Enabled = false;
                SPush.Text = "Push Code in Current Tab to Clients";
                //<html><span style="color: #ff8080"><strong>S</strong><strong>tatus: Not Connected</strong></span></html>

                
            }
            catch
            {
                MessageBox.Show("Port address ivalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                 
           // else
           //IPServer = new IPEndPoint(IPAddress.Parse(GetLocalIP()), 4444);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            if(!isConnected)
            server.Bind(IPServer);
            isConnected = true;
            SStartServer.Enabled = false;
            //if(isIntString)
            SStatus.Text = "Server has been initialized with IP: "+ GetLocalIP()+" Port: "+txtPort;
            //else
            //    SStatus.Text = SStatus.Text = "Server has been initialized with IP: " + GetLocalIP() + " Port: 4444";
            ShowAlert_Light("<html><color=Teal><b>Server has been initialized</b>", "<html>IP:<span><color=Teal>"+GetLocalIP()+"</span>",true);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        ShowAlert_Light("<html><color=Teal><b>New Client Connected!</b>","Client: "+client.RemoteEndPoint,false);
                        clientlist.Add(client);
                        SStatus.Text = "Connected: " + clientlist.Count;
                        Thread recevie = new Thread(Receive_Ser);
                        recevie.IsBackground = true;
                        recevie.Start(client);
                    }
                }
                catch
                {
                    //if (!isIntString)
                    //    IPServer = new IPEndPoint(IPAddress.Parse(GetLocalIP()), 4444);
                    //else
                        IPServer = new IPEndPoint(IPAddress.Parse(GetLocalIP()), int.Parse(txtPort));
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }


            });
            Listen.IsBackground = true;
            Listen.Start();


        }
        void Close_Ser()
        {
            
            server.Close();
            
            SConnect.Enabled = true;
            SStatus.Text = "Not Connected";
        }
        void Send_Ser(Socket client)
        {
            if (TabHienTai.Text != string.Empty && TabHienTai != null)
                client.Send(Serialize(TabHienTai.Text));
        }
        void Receive_Ser(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    AddMessage_Ser(message);
                }
            }
            catch
            {
                ShowAlert_Light("<html><color=Crimson><b>Client Disconnect</b>", client.RemoteEndPoint+" Disconnected",false);
                clientlist.Remove(client);
                if (clientlist.Count != 0)
                    SStatus.Text = "Connected: " + clientlist.Count;
                else
                    SStatus.Text = "Waitting for connection";

                client.Close();
            }


        }
        //Tạo 1 biến để lưu dữ liệu gửi về cuối cùng
        string dataReceived = string.Empty;
        void AddMessage_Ser(string s)
        {
            dataReceived = s;
            listDataReceived.Items.Add(s);
            //lsvMessage.Items.Add(new ListViewItem() { Text = s });

        }
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);

        }

        private void SPush_Click(object sender, EventArgs e)
        {
            if (isServer)
            {
                foreach (Socket item in clientlist)
                {
                    Send_Ser(item);
                }
            }
            else
            {
                Send();
            }

        }
        private bool isConnectedCli = false;
        private void SConnect_Click(object sender, EventArgs e)
        {
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            {
                using (ParametDialog fd = new ParametDialog())
                {
                    fd.Text = "Connection Setting";
                    fd.radLabel1.Text = "Change Port Address (Number)";
                    fd.radLabel2.Text = "Note: You can't change IP Address. Can only change Port";
                    fd.radButton3.Enabled = false;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {

                        txtPort = fd.ParametText;
                    }
                }
                bool isIntString = txtPort.All(char.IsDigit);
                if (!isIntString||txtPort=="")
                {
                    MessageBox.Show("Port invalid! Reset to 4444", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPort = "4444";
                    SConnect.ToolTipText = "Connect with IP: " + GetLocalIP() + " Port: "+txtPort;
                }
                else
                    SConnect.ToolTipText = "Connect with IP: " + GetLocalIP() + " Port: " + txtPort;
                return;
            }
           
            if(!isConnectedCli)
            Connect();
        }

        ///Server///////////////////////////////////////////////
        /// ----------------------------------------------------
        ///Clients//////////////////////////////////////////////
        IPEndPoint IP;
        Socket client;
        void Connect()
        {
            //bool isIntString = txtPort.All(char.IsDigit);
            //if(!isIntString)
            //IP = new IPEndPoint(IPAddress.Parse(GetLocalIP()), 4444);
            //else
            try
            {
            IP = new IPEndPoint(IPAddress.Parse(GetLocalIP()), int.Parse(txtPort));
                isServer = false;
                SStartServer.Enabled = false;
                SPush.Text = "Push Code in Current Tab to Server";

                CheckForIllegalCrossThreadCalls = false;
            }
            catch
            {
                MessageBox.Show("Port address invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
                isConnectedCli = true;
                SStatus.Text = "Connected to " + GetLocalIP();
                ShowAlert_Light("<html><color=Teal><b>You are connected to Server</b>",null, false);
            }
            catch
            {
                MessageBox.Show("Error!"); return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }
        void Close()
        {
          
               
                try
                {
                client.Close();
                SStatus.Text = "Not Connected";
                if (client.Connected)
                    {
                        client.Shutdown(SocketShutdown.Both);
                        client.Close(10);
                        ShowAlert_Light("<html><b>Disconnected to Server</b>", null, false);
                        SStartServer.Enabled = true;
                        
                        isServer = false;
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.ToString());
                }
            
           
            
        }
        void Send()
        {
            if (client.Connected)
            {
                if (TabHienTai.Text != string.Empty && TabHienTai != null)
                    client.Send(Serialize(TabHienTai.Text));
            }
            else
            {
                MessageBox.Show("Server not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SStatus.Text = "Not Connected";
            }
           
           
        }
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }


        }
        void AddMessage(string s)
        {
            dataReceived = s;
            listDataReceived.Items.Add(s);
        }

        private void SDisconnect_Click(object sender, EventArgs e)
        {
            if(isServer)
            {
                Close_Ser();
                isConnected = false;
                SConnect.Enabled = true;
                SStartServer.Enabled = true;
            }
            else
            {
                Close();
                isConnectedCli = false;
                SConnect.Enabled = true;
                SStartServer.Enabled = true;
            }
        }
        ///Clients////////////////////////////////////////////// 
        
        public string GetLocalIP() ///Lấy địa chỉ IP Hiện tại
        {
            try
            {
                string HostName = Dns.GetHostName(); //ger the name of localhost
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //Filter out IPv4 type IP addresses from the IP address list
                    //AddressFamily.InterNetwork represents IPv4,
                    //AddressFamily.InterNetworkV6 represents IPv6
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting local IP:" + ex.Message);
                return "";
            }
        }

        private void radMenuItem1_Click_2(object sender, EventArgs e)
        {
            TabHienTai.KeyDown += TabHienTai_Down;

        }

       

        private void TabHienTai_Down(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.OemOpenBrackets && e.Modifiers == Keys.Shift)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "}");
                TabHienTai.MoveLeft();
            }
            else
            if(e.KeyCode == Keys.OemOpenBrackets&& e.Modifiers == Keys.None)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "]");
                TabHienTai.MoveLeft();
            }
           
            else
                if(e.KeyCode == Keys.OemQuotes&&e.Modifiers==Keys.None)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "'");
                TabHienTai.MoveLeft();
            }
            else
                if(e.KeyCode==Keys.OemQuotes&&e.Modifiers==Keys.Shift)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, "\"");
                TabHienTai.MoveLeft();
            }else
                if(e.KeyCode == Keys.D9&&e.Modifiers==Keys.Shift)
            {
                TabHienTai.InsertText(TabHienTai.CurrentLine, TabHienTai.CurrentColumn, ")");
                TabHienTai.MoveLeft();
            }
            
            
        }



        private void DataDiff_Click(object sender, EventArgs e)
        {
            if(TabHienTai!=null)
            {
                DiffNewText = TabHienTai.Text;
                DiffViewer Diff = new DiffViewer();
                Diff.OldText = TabHienTai.Text;
                Diff.NewText = dataReceived;
                Diff.FontFamilyNames = "Cascadia Code";
                Diff.FontSize = 16;
                Diff.ShowSideBySide();
                Diff.NewTextHeader = "Current Tab";
                Diff.OldTextHeader = "Data Received";
                Diff.IgnoreWhiteSpace = true;

                Diff.Dock = DockStyle.Fill;
                DocumentWindow Do = new DocumentWindow("Different Merge");
                Do.Controls.Add(Diff);
                DockPar.AddDocument(Do);
            }
            else
            {
                ShowAlert_Light("<html><color=Teal><b>Please Set Active Tab Document to Compare</b>", null, false);
            }
           
        }

        private void Kaliz_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isServer)
                Close_Ser();
            else
                Close();
        }

        private void DataAdd_Click(object sender, EventArgs e)
        {
            if (TabHienTai != null)
            {
                TabHienTai.MoveToLineEnd();
                TabHienTai.Text.Insert(0, "\n" + dataReceived + "\n");

            }
            else
                MessageBox.Show("Active Document not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
        }

        private void listDataReceived_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {

        }

        private void listDataReceived_MouseClick(object sender, MouseEventArgs e)
        {
            var args = e as MouseEventArgs;
            if(args.Button == MouseButtons.Right&&listDataReceived.SelectedItem!=null)
            {
                contextMenuData.Show(listDataReceived, args.Location);
            }
        }

        private void VDataReceived_Click(object sender, EventArgs e)
        {
            if(showDataReceived == false)
            {
                DDataReceived.Show();
                VDataReceived.Text = "Hide Data Received List";
                showDataReceived = true;
            }else
            {
                DDataReceived.Hide();
                VDataReceived.Text = "Show Data Received List";
                showDataReceived = false;
            }
        }

        private void OVitrualSpace_Click(object sender, EventArgs e)
        {
            try

            {
                if (TabHienTai.VirtualSpaceMode == false)
                {
                    TabHienTai.VirtualSpaceMode = true;
                    OVitrualSpace.Text = "Disable Vitrual Space Mode";
                }
                else
                {
                    TabHienTai.VirtualSpaceMode = true;
                    OVitrualSpace.Text = "Enable Vitrual Space Mode";
                }
            }
            catch
            {
                
            }
           
               
        }

        private void bookmarkList_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            foreach( var item in bookmarkList.Items)
            {
                if(item.Selected)
                {
                    try
                    {
                        if (item[2].ToString() == TabHienTai.FileName.ToString())
                        {
                            TabHienTai.GoTo(int.Parse(item[0].ToString()));
                        }
                        else 
                        {
                            foreach (var tabs in DockPar.DocumentManager.DocumentArray)
                            {
                                if (tabs.TabStripItem.Text == item[1].ToString())
                                {
                                    DockPar.ActivateWindow(tabs);
                                    TabHienTai.GoTo(int.Parse(item[0].ToString()));
                                }
                            }

                        }
                        //else
                        //{
                        //    foreach (var bmlist in bookmarkList.Items)
                        //    {
                        //        foreach (var tabs in DockPar.DocumentManager.DocumentArray)
                        //        {
                        //            if (tabs.TabStripItem.Text == bmlist[1].ToString())
                        //            {
                        //                DockPar.ActivateWindow(tabs);
                        //                TabHienTai.GoTo(int.Parse(bmlist[0].ToString()));
                        //            }
                        //        }
                        //    }
                        //}
                        //TabHienTai.GoTo(int.Parse(item[0].ToString()));
                    }

                    //else
                    catch
                    {
                        foreach (var tabs in DockPar.DocumentManager.DocumentArray)
                        {
                            if (tabs.TabStripItem.Text == item[1].ToString())
                            {
                                DockPar.ActivateWindow(tabs);
                                TabHienTai.GoTo(int.Parse(item[0].ToString()));
                            }
                        }

                    }
                }
            }
        }

        private void VBookmarkList_Click(object sender, EventArgs e)
        {
            if(showBookmarkList == true)
            {                
                DBookmarksList.Hide();
                VBookmarkList.Text = "Show Bookmarks List";
                showBookmarkList = false;
            }
            else
            {
                DBookmarksList.Show();
                VBookmarkList.Text = "Hide Bookmarks List";
                showBookmarkList = true;
            }
        }
        //////////////Directory//////////////
        public string PathDirectory;
        public void LoadDirectory(string Dir)
        {
            
            treeDirectory.Nodes.Clear();
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value  

            RadTreeNode tds = treeDirectory.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.ImageIndex = 3;
            LoadFiles(Dir, tds);
            LoadSubDirectories(Dir, tds);
            treeDirectory.ExpandAll();
        }
        private void LoadSubDirectories(string dir, RadTreeNode td)
        {
            // Get all subdirectories  
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories  
            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo di = new DirectoryInfo(subdirectory);
                RadTreeNode tds = td.Nodes.Add(di.Name);
                tds.ImageIndex = 3;
                tds.Tag = di.FullName;
                LoadFiles(subdirectory, tds);
                LoadSubDirectories(subdirectory, tds);
                //UpdateProgress();

            }
        }
        private void LoadFiles(string dir, RadTreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            // Loop through them to see files  
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);

                RadTreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                if (Path.GetExtension(fi.ToString()) == ".cpp")
                    tds.ImageIndex = 1;
                else if (Path.GetExtension(fi.ToString()) == ".c")
                    tds.ImageIndex = 0;
                else if (Path.GetExtension(fi.ToString()) == ".pas")
                    tds.ImageIndex = 5;
                else if (Path.GetExtension(fi.ToString()) == ".py")
                    tds.ImageIndex = 6;
                else if (Path.GetExtension(fi.ToString()) == ".java")
                    tds.ImageIndex = 4;
                else if (Path.GetExtension(fi.ToString()) == ".exe") 
                tds.ImageIndex = 7;
                else tds.ImageIndex = 2;
                // UpdateProgress();

            }
        }

        private void FDirectory_Click(object sender, EventArgs e)
        {

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                PathDirectory = dialog.FileName;
                LoadDirectory(dialog.FileName);
            }
        }

        private void treeDirectory_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            
            try
            {
                string path = Path.GetDirectoryName(PathDirectory) + "\\" + e.Node.FullPath;
                if (Path.GetExtension(path) == ".exe")
                {
                    Process Chay = new Process();
                    Chay.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Kaliz" + @"\Cmder\vendor\conemu-maximus5\ConEmu.exe";                  
                    Chay.StartInfo.Arguments = "-run  " + DuongDanTepExe(path);
                    Chay.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    Chay.Start();
                    return;
                }
                
                if(Path.GetExtension(path)==".pas"|| Path.GetExtension(path) == ".c" || Path.GetExtension(path) == ".cpp" || Path.GetExtension(path) == ".py" || Path.GetExtension(path) == ".java"&&File.Exists(path))
                TaoMoi(Path.GetFileName(path), path);
            }
            catch { }
        }

        private void treeDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            {
                contextMenuDirectory.Show(treeDirectory, args.Location);
            }
        }


        //////////////End Directory///////////
        private void FReopenLineBreak_Click(object sender, EventArgs e)
        {
            if(TabHienTai!=null && File.Exists(TabHienTai.FileName))
            {
                try
                {
                    string[] a = File.ReadAllLines(TabHienTai.FileName);
                    TabHienTai.Text = string.Empty;
                    foreach (string line in a)
                    {

                        TabHienTai.Text += line + "\r\n";
                    }
                }
                catch
                {
                    List<string> ls = new List<string>();
                    for (int i = 1; i <= TabHienTai.PhysicalLineCount; i++)
                    {
                        ls.Add(TabHienTai.GetLineText(i) + "\r\n");
                    }
                    TabHienTai.Text = "";
                    foreach (var i in ls)
                    {
                        TabHienTai.Text += i.ToString() + "\r\n";
                    }

                }

            }
            else if (TabHienTai != null && !File.Exists(TabHienTai.FileName))
            {
               
                List<string> ls = new List<string>();
                for(int i=1;i<=TabHienTai.PhysicalLineCount;i++)
                {
                    ls.Add(TabHienTai.GetLineText(i)+"\r\n");
                }
                TabHienTai.Text = "";
                foreach(var i in ls)
                {
                    TabHienTai.Text += i.ToString()+"\r\n";
                }
            }
        }

        private void VHideDir_Click(object sender, EventArgs e)
        {
            if(showDirectory == false)
            {
                VHideDir.Text = "Hide Working Directory";
                DWorkingDirectory.Show();
                showDirectory = true;
            }
            else
            {

                VHideDir.Text = "Show Working Directory";
                DWorkingDirectory.Hide();
                showDirectory = false;
            }
        }
    }
}

