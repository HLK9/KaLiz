using System.Windows.Forms;
using Telerik.WinControls;
namespace Kaliz
{
    partial class Kaliz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.MFile = new Telerik.WinControls.UI.RadMenuItem();
            this.FNew = new Telerik.WinControls.UI.RadMenuItem();
            this.FOpen = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.FClose = new Telerik.WinControls.UI.RadMenuItem();
            this.FPrint = new Telerik.WinControls.UI.RadMenuItem();
            this.FSave = new Telerik.WinControls.UI.RadMenuItem();
            this.FSaveAs = new Telerik.WinControls.UI.RadMenuItem();
            this.FExport = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.FExit = new Telerik.WinControls.UI.RadMenuItem();
            this.MEdit = new Telerik.WinControls.UI.RadMenuItem();
            this.ECopy = new Telerik.WinControls.UI.RadMenuItem();
            this.ECut = new Telerik.WinControls.UI.RadMenuItem();
            this.EPaste = new Telerik.WinControls.UI.RadMenuItem();
            this.ESave = new Telerik.WinControls.UI.RadMenuItem();
            this.ESelect = new Telerik.WinControls.UI.RadMenuItem();
            this.MTools = new Telerik.WinControls.UI.RadMenuItem();
            this.TFind = new Telerik.WinControls.UI.RadMenuItem();
            this.TReplace = new Telerik.WinControls.UI.RadMenuItem();
            this.TGoToLine = new Telerik.WinControls.UI.RadMenuItem();
            this.MBuild = new Telerik.WinControls.UI.RadMenuItem();
            this.BRun = new Telerik.WinControls.UI.RadMenuItem();
            this.BBuild = new Telerik.WinControls.UI.RadMenuItem();
            this.MDebug = new Telerik.WinControls.UI.RadMenuItem();
            this.DEnable = new Telerik.WinControls.UI.RadMenuItem();
            this.DOpenGDB = new Telerik.WinControls.UI.RadMenuItem();
            this.MOptions = new Telerik.WinControls.UI.RadMenuItem();
            this.MHelp = new Telerik.WinControls.UI.RadMenuItem();
            this.DockPar = new Telerik.WinControls.UI.Docking.RadDock();
            this.Doutput = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.DContainer = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.MBookmark = new Telerik.WinControls.UI.RadMenuItem();
            this.BBookmark = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.BRemoveAll = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem3 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.BBookmarkPre = new Telerik.WinControls.UI.RadMenuItem();
            this.BBookmarkNext = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.BMList = new Telerik.WinControls.UI.Docking.ToolWindow();
            ((System.ComponentModel.ISupportInitialize)(this.DockPar)).BeginInit();
            this.DockPar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MFile
            // 
            this.MFile.BackColor = System.Drawing.Color.White;
            this.MFile.BorderHighlightColor = System.Drawing.Color.White;
            this.MFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.FNew,
            this.FOpen,
            this.radMenuSeparatorItem1,
            this.FClose,
            this.FPrint,
            this.FSave,
            this.FSaveAs,
            this.FExport,
            this.radMenuSeparatorItem2,
            this.FExit});
            this.MFile.Name = "MFile";
            this.MFile.Text = "File";
            // 
            // FNew
            // 
            this.FNew.Name = "FNew";
            this.FNew.Text = "New File";
            this.FNew.ToolTipText = "Tệp Mới";
            this.FNew.Click += new System.EventHandler(this.FNew_Click);
            // 
            // FOpen
            // 
            this.FOpen.Name = "FOpen";
            this.FOpen.Text = "Open File";
            this.FOpen.Click += new System.EventHandler(this.FOpen_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FClose
            // 
            this.FClose.Name = "FClose";
            this.FClose.Text = "Close";
            this.FClose.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // FPrint
            // 
            this.FPrint.Name = "FPrint";
            this.FPrint.Text = "Print";
            this.FPrint.Click += new System.EventHandler(this.FPrint_Click);
            // 
            // FSave
            // 
            this.FSave.Name = "FSave";
            this.FSave.Text = "Save";
            // 
            // FSaveAs
            // 
            this.FSaveAs.Name = "FSaveAs";
            this.FSaveAs.Text = "Save As";
            this.FSaveAs.Click += new System.EventHandler(this.FSaveAs_Click);
            // 
            // FExport
            // 
            this.FExport.Name = "FExport";
            this.FExport.Text = "Export to RTF";
            this.FExport.Click += new System.EventHandler(this.FExport_Click);
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FExit
            // 
            this.FExit.Name = "FExit";
            this.FExit.Text = "Exit";
            this.FExit.Click += new System.EventHandler(this.FExit_Click);
            // 
            // MEdit
            // 
            this.MEdit.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ECopy,
            this.ECut,
            this.EPaste,
            this.ESave,
            this.ESelect});
            this.MEdit.Name = "MEdit";
            this.MEdit.Text = "Edit";
            // 
            // ECopy
            // 
            this.ECopy.Name = "ECopy";
            this.ECopy.Text = "Copy";
            this.ECopy.Click += new System.EventHandler(this.ECopy_Click);
            // 
            // ECut
            // 
            this.ECut.Name = "ECut";
            this.ECut.Text = "Cut";
            this.ECut.Click += new System.EventHandler(this.ECut_Click);
            // 
            // EPaste
            // 
            this.EPaste.Name = "EPaste";
            this.EPaste.Text = "Paste";
            this.EPaste.Click += new System.EventHandler(this.EPaste_Click);
            // 
            // ESave
            // 
            this.ESave.Name = "ESave";
            this.ESave.Text = "Save";
            this.ESave.Click += new System.EventHandler(this.ESave_Click);
            // 
            // ESelect
            // 
            this.ESelect.Name = "ESelect";
            this.ESelect.Text = "Select Mode: Block";
            this.ESelect.Click += new System.EventHandler(this.ESelect_Click);
            // 
            // MTools
            // 
            this.MTools.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.TFind,
            this.TReplace,
            this.TGoToLine});
            this.MTools.Name = "MTools";
            this.MTools.Text = "Tools";
            // 
            // TFind
            // 
            this.TFind.Name = "TFind";
            this.TFind.Text = "Find";
            this.TFind.Click += new System.EventHandler(this.TFind_Click);
            // 
            // TReplace
            // 
            this.TReplace.Name = "TReplace";
            this.TReplace.Text = "Replace";
            this.TReplace.Click += new System.EventHandler(this.TReplace_Click);
            // 
            // TGoToLine
            // 
            this.TGoToLine.Name = "TGoToLine";
            this.TGoToLine.Text = "Go To Line";
            this.TGoToLine.Click += new System.EventHandler(this.TGoToLine_Click);
            // 
            // MBuild
            // 
            this.MBuild.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.BRun,
            this.BBuild});
            this.MBuild.Name = "MBuild";
            this.MBuild.Text = "Buid";
            // 
            // BRun
            // 
            this.BRun.Name = "BRun";
            this.BRun.Text = "Run";
            this.BRun.Click += new System.EventHandler(this.BRun_Click);
            // 
            // BBuild
            // 
            this.BBuild.Name = "BBuild";
            this.BBuild.Text = "Build This File";
            this.BBuild.Click += new System.EventHandler(this.BBuild_Click);
            // 
            // MDebug
            // 
            this.MDebug.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.DEnable,
            this.DOpenGDB});
            this.MDebug.Name = "MDebug";
            this.MDebug.Text = "Debug";
            // 
            // DEnable
            // 
            this.DEnable.Name = "DEnable";
            this.DEnable.Text = "Enable Debug";
            // 
            // DOpenGDB
            // 
            this.DOpenGDB.Name = "DOpenGDB";
            this.DOpenGDB.Text = "Open GDB Debug";
            // 
            // MOptions
            // 
            this.MOptions.Name = "MOptions";
            this.MOptions.Text = "Options";
            // 
            // MHelp
            // 
            this.MHelp.Name = "MHelp";
            this.MHelp.Text = "Help";
            // 
            // DockPar
            // 
            this.DockPar.ActiveWindow = this.BMList;
            this.DockPar.CausesValidation = false;
            this.DockPar.Controls.Add(this.DContainer);
            this.DockPar.Controls.Add(this.toolTabStrip1);
            this.DockPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPar.IsCleanUpTarget = true;
            this.DockPar.Location = new System.Drawing.Point(0, 37);
            this.DockPar.MainDocumentContainer = this.DContainer;
            this.DockPar.Name = "DockPar";
            this.DockPar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.DockPar.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.DockPar.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.DockPar.Size = new System.Drawing.Size(1093, 689);
            this.DockPar.SplitterWidth = 8;
            this.DockPar.TabIndex = 2;
            this.DockPar.TabStop = false;
            this.DockPar.ThemeName = "MaterialTeal";
            // 
            // Doutput
            // 
            this.Doutput.Caption = null;
            this.Doutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Doutput.Location = new System.Drawing.Point(4, 52);
            this.Doutput.Name = "Doutput";
            this.Doutput.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.Doutput.Size = new System.Drawing.Size(1085, 99);
            this.Doutput.Text = "Output";
            this.Doutput.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
            // 
            // DContainer
            // 
            this.DContainer.Name = "DContainer";
            // 
            // 
            // 
            this.DContainer.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.DContainer.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 456);
            this.DContainer.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.DContainer.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -25);
            this.DContainer.SplitterWidth = 8;
            this.DContainer.ThemeName = "MaterialTeal";
            // 
            // toolTabStrip1
            // 
            this.toolTabStrip1.CanUpdateChildIndex = true;
            this.toolTabStrip1.CausesValidation = false;
            this.toolTabStrip1.Controls.Add(this.Doutput);
            this.toolTabStrip1.Controls.Add(this.BMList);
            this.toolTabStrip1.Location = new System.Drawing.Point(0, 464);
            this.toolTabStrip1.Name = "toolTabStrip1";
            // 
            // 
            // 
            this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip1.SelectedIndex = 1;
            this.toolTabStrip1.Size = new System.Drawing.Size(1093, 225);
            this.toolTabStrip1.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 225);
            this.toolTabStrip1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 25);
            this.toolTabStrip1.TabIndex = 1;
            this.toolTabStrip1.TabStop = false;
            this.toolTabStrip1.ThemeName = "MaterialTeal";
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Test";
            this.radMenuItem1.Click += new System.EventHandler(this.radMenuItem1_Click_1);
            // 
            // MBookmark
            // 
            this.MBookmark.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.BBookmark,
            this.radMenuItem2,
            this.BRemoveAll,
            this.radMenuSeparatorItem3,
            this.BBookmarkPre,
            this.BBookmarkNext});
            this.MBookmark.Name = "MBookmark";
            this.MBookmark.Text = "Bookmark";
            // 
            // BBookmark
            // 
            this.BBookmark.Name = "BBookmark";
            this.BBookmark.Text = "Add to current line";
            this.BBookmark.Click += new System.EventHandler(this.BBookmark_Click);
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Remove in current line";
            this.radMenuItem2.Click += new System.EventHandler(this.BRemoveBookmark_Click);
            // 
            // BRemoveAll
            // 
            this.BRemoveAll.Name = "BRemoveAll";
            this.BRemoveAll.Text = "Remove All";
            this.BRemoveAll.Click += new System.EventHandler(this.BRemoveAll_Click);
            // 
            // radMenuSeparatorItem3
            // 
            this.radMenuSeparatorItem3.Name = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.Text = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BBookmarkPre
            // 
            this.BBookmarkPre.Name = "BBookmarkPre";
            this.BBookmarkPre.Text = "BookmarkPrevious";
            this.BBookmarkPre.Click += new System.EventHandler(this.BBookmarkPre_Click);
            // 
            // BBookmarkNext
            // 
            this.BBookmarkNext.Name = "BBookmarkNext";
            this.BBookmarkNext.Text = "BookmarkNext";
            this.BBookmarkNext.Click += new System.EventHandler(this.BBookmarkNext_Click);
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MFile,
            this.MEdit,
            this.MTools,
            this.MBuild,
            this.MDebug,
            this.MOptions,
            this.MHelp,
            this.MBookmark,
            this.radMenuItem1});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(1093, 37);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.ThemeName = "MaterialTeal";
            // 
            // BMList
            // 
            this.BMList.Caption = null;
            this.BMList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BMList.Location = new System.Drawing.Point(4, 52);
            this.BMList.Name = "BMList";
            this.BMList.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.BMList.Size = new System.Drawing.Size(1085, 143);
            this.BMList.Text = "Bookmark List";
            this.BMList.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
            // 
            // Kaliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 726);
            this.Controls.Add(this.DockPar);
            this.Controls.Add(this.radMenu1);
            this.Name = "Kaliz";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Kaliz-CMB";
            this.ThemeName = "MaterialTeal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DockPar)).EndInit();
            this.DockPar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
            this.toolTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadMenuItem MFile;
        private Telerik.WinControls.UI.RadMenuItem MEdit;
        private Telerik.WinControls.UI.RadMenuItem MTools;
        private Telerik.WinControls.UI.RadMenuItem MBuild;
        private Telerik.WinControls.UI.RadMenuItem MDebug;
        private Telerik.WinControls.UI.RadMenuItem MOptions;
        private Telerik.WinControls.UI.RadMenuItem MHelp;
        private Telerik.WinControls.UI.RadMenuItem FNew;
        private Telerik.WinControls.UI.RadMenuItem FOpen;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem FClose;
        private Telerik.WinControls.UI.RadMenuItem FPrint;
        private Telerik.WinControls.UI.RadMenuItem FSave;
        private Telerik.WinControls.UI.RadMenuItem FSaveAs;
        private Telerik.WinControls.UI.RadMenuItem FExport;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem FExit;
        private Telerik.WinControls.UI.Docking.RadDock DockPar;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private Telerik.WinControls.UI.Docking.ToolWindow Doutput;
        private Telerik.WinControls.UI.RadMenuItem ECopy;
        private Telerik.WinControls.UI.RadMenuItem ECut;
        private Telerik.WinControls.UI.RadMenuItem EPaste;
        private Telerik.WinControls.UI.RadMenuItem TFind;
        private Telerik.WinControls.UI.RadMenuItem BRun;
        private Telerik.WinControls.UI.RadMenuItem BBuild;
        private Telerik.WinControls.UI.RadMenuItem DEnable;
        private Telerik.WinControls.UI.RadMenuItem DOpenGDB;
        private Telerik.WinControls.UI.Docking.DocumentContainer DContainer;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem MBookmark;
        private Telerik.WinControls.UI.RadMenuItem BBookmark;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem BRemoveAll;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem3;
        private Telerik.WinControls.UI.RadMenuItem TReplace;
        private Telerik.WinControls.UI.RadMenuItem TGoToLine;
        private Telerik.WinControls.UI.RadMenuItem ESave;
        private Telerik.WinControls.UI.RadMenuItem BBookmarkPre;
        private Telerik.WinControls.UI.RadMenuItem BBookmarkNext;
        private Telerik.WinControls.UI.RadMenuItem ESelect;
        private Telerik.WinControls.UI.Docking.ToolWindow BMList;
    }
}