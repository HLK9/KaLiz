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
            this.MTools = new Telerik.WinControls.UI.RadMenuItem();
            this.TFind = new Telerik.WinControls.UI.RadMenuItem();
            this.MBuild = new Telerik.WinControls.UI.RadMenuItem();
            this.BRun = new Telerik.WinControls.UI.RadMenuItem();
            this.BBuild = new Telerik.WinControls.UI.RadMenuItem();
            this.MDebug = new Telerik.WinControls.UI.RadMenuItem();
            this.DEnable = new Telerik.WinControls.UI.RadMenuItem();
            this.DOpenGDB = new Telerik.WinControls.UI.RadMenuItem();
            this.MOptions = new Telerik.WinControls.UI.RadMenuItem();
            this.MHelp = new Telerik.WinControls.UI.RadMenuItem();
            this.DockPar = new Telerik.WinControls.UI.Docking.RadDock();
            this.DTer = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.DContainer = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.documentWindow1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.documentWindow2 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.documentWindow3 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.documentWindow4 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            ((System.ComponentModel.ISupportInitialize)(this.DockPar)).BeginInit();
            this.DockPar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DContainer)).BeginInit();
            this.DContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MFile
            // 
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
            this.FExport.Text = "Export to rtf";
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
            // 
            // MEdit
            // 
            this.MEdit.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ECopy,
            this.ECut,
            this.EPaste});
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
            // MTools
            // 
            this.MTools.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.TFind});
            this.MTools.Name = "MTools";
            this.MTools.Text = "Tools";
            // 
            // TFind
            // 
            this.TFind.Name = "TFind";
            this.TFind.Text = "Find";
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
            // 
            // BBuild
            // 
            this.BBuild.Name = "BBuild";
            this.BBuild.Text = "Build This File";
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
            this.DockPar.ActiveWindow = this.documentWindow1;
            this.DockPar.Controls.Add(this.DContainer);
            this.DockPar.Controls.Add(this.toolTabStrip1);
            this.DockPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPar.IsCleanUpTarget = true;
            this.DockPar.Location = new System.Drawing.Point(0, 37);
            this.DockPar.MainDocumentContainer = this.DContainer;
            this.DockPar.Name = "DockPar";
            this.DockPar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.DockPar.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.DockPar.Size = new System.Drawing.Size(1095, 691);
            this.DockPar.SplitterWidth = 8;
            this.DockPar.TabIndex = 2;
            this.DockPar.TabStop = false;
            this.DockPar.ThemeName = "MaterialTeal";
            // 
            // DTer
            // 
            this.DTer.Caption = null;
            this.DTer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTer.Location = new System.Drawing.Point(4, 52);
            this.DTer.Name = "DTer";
            this.DTer.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.DTer.Size = new System.Drawing.Size(1077, 83);
            this.DTer.Text = "DockTer";
            // 
            // DContainer
            // 
            this.DContainer.Controls.Add(this.documentTabStrip1);
            this.DContainer.Name = "DContainer";
            // 
            // 
            // 
            this.DContainer.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.DContainer.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 117);
            this.DContainer.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.DContainer.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 61);
            this.DContainer.SplitterWidth = 8;
            this.DContainer.ThemeName = "MaterialTeal";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.documentWindow4);
            this.documentTabStrip1.Controls.Add(this.documentWindow3);
            this.documentTabStrip1.Controls.Add(this.documentWindow2);
            this.documentTabStrip1.Controls.Add(this.documentWindow1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 3;
            this.documentTabStrip1.Size = new System.Drawing.Size(1085, 534);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "MaterialTeal";
            // 
            // documentWindow1
            // 
            this.documentWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow1.Location = new System.Drawing.Point(4, 54);
            this.documentWindow1.Name = "documentWindow1";
            this.documentWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow1.Size = new System.Drawing.Size(1077, 476);
            this.documentWindow1.Text = "documentWindow1";
            // 
            // toolTabStrip1
            // 
            this.toolTabStrip1.CanUpdateChildIndex = true;
            this.toolTabStrip1.Controls.Add(this.DTer);
            this.toolTabStrip1.Location = new System.Drawing.Point(5, 547);
            this.toolTabStrip1.Name = "toolTabStrip1";
            // 
            // 
            // 
            this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip1.SelectedIndex = 0;
            this.toolTabStrip1.Size = new System.Drawing.Size(1085, 139);
            this.toolTabStrip1.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 139);
            this.toolTabStrip1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -61);
            this.toolTabStrip1.TabIndex = 1;
            this.toolTabStrip1.TabStop = false;
            this.toolTabStrip1.ThemeName = "MaterialTeal";
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
            this.MHelp});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(1095, 37);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.ThemeName = "MaterialTeal";
            // 
            // documentWindow2
            // 
            this.documentWindow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow2.Location = new System.Drawing.Point(4, 54);
            this.documentWindow2.Name = "documentWindow2";
            this.documentWindow2.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow2.Size = new System.Drawing.Size(1087, 486);
            this.documentWindow2.Text = "documentWindow2";
            // 
            // documentWindow3
            // 
            this.documentWindow3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow3.Location = new System.Drawing.Point(4, 54);
            this.documentWindow3.Name = "documentWindow3";
            this.documentWindow3.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow3.Size = new System.Drawing.Size(1087, 486);
            this.documentWindow3.Text = "documentWindow3";
            // 
            // documentWindow4
            // 
            this.documentWindow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow4.Location = new System.Drawing.Point(4, 54);
            this.documentWindow4.Name = "documentWindow4";
            this.documentWindow4.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow4.Size = new System.Drawing.Size(1087, 486);
            this.documentWindow4.Text = "documentWindow4";
            // 
            // Kaliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 728);
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
            this.DContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
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
        private Telerik.WinControls.UI.Docking.ToolWindow DTer;
        private Telerik.WinControls.UI.RadMenuItem ECopy;
        private Telerik.WinControls.UI.RadMenuItem ECut;
        private Telerik.WinControls.UI.RadMenuItem EPaste;
        private Telerik.WinControls.UI.RadMenuItem TFind;
        private Telerik.WinControls.UI.RadMenuItem BRun;
        private Telerik.WinControls.UI.RadMenuItem BBuild;
        private Telerik.WinControls.UI.RadMenuItem DEnable;
        private Telerik.WinControls.UI.RadMenuItem DOpenGDB;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.Docking.DocumentContainer DContainer;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow4;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow3;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow2;
    }
}