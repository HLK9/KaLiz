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
            this.MEdit = new Telerik.WinControls.UI.RadMenuItem();
            this.MTools = new Telerik.WinControls.UI.RadMenuItem();
            this.MBuild = new Telerik.WinControls.UI.RadMenuItem();
            this.MDebug = new Telerik.WinControls.UI.RadMenuItem();
            this.MOptions = new Telerik.WinControls.UI.RadMenuItem();
            this.MHelp = new Telerik.WinControls.UI.RadMenuItem();
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
            this.POpen = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.DTer = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.DcWelcome = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.PNew = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            ((System.ComponentModel.ISupportInitialize)(this.POpen)).BeginInit();
            this.POpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
            this.DcWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
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
            // MEdit
            // 
            this.MEdit.Name = "MEdit";
            this.MEdit.Text = "Edit";
            // 
            // MTools
            // 
            this.MTools.Name = "MTools";
            this.MTools.Text = "Tools";
            // 
            // MBuild
            // 
            this.MBuild.Name = "MBuild";
            this.MBuild.Text = "Buid";
            // 
            // MDebug
            // 
            this.MDebug.Name = "MDebug";
            this.MDebug.Text = "Debug";
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
            // FNew
            // 
            this.FNew.Name = "FNew";
            this.FNew.Text = "New File";
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
            // 
            // FExport
            // 
            this.FExport.Name = "FExport";
            this.FExport.Text = "Export to rtf";
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
            // POpen
            // 
            this.POpen.ActiveWindow = this.DTer;
            this.POpen.Controls.Add(this.documentContainer1);
            this.POpen.Controls.Add(this.toolTabStrip1);
            this.POpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POpen.Location = new System.Drawing.Point(0, 37);
            this.POpen.MainDocumentContainer = this.documentContainer1;
            this.POpen.Name = "POpen";
            this.POpen.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.POpen.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.POpen.Size = new System.Drawing.Size(1095, 691);
            this.POpen.SplitterWidth = 8;
            this.POpen.TabIndex = 2;
            this.POpen.TabStop = false;
            this.POpen.ThemeName = "MaterialTeal";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 117);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 61);
            this.documentContainer1.SplitterWidth = 8;
            this.documentContainer1.ThemeName = "MaterialTeal";
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
            // DcWelcome
            // 
            this.DcWelcome.Controls.Add(this.radButton1);
            this.DcWelcome.Controls.Add(this.PNew);
            this.DcWelcome.Controls.Add(this.radLabel1);
            this.DcWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DcWelcome.Location = new System.Drawing.Point(4, 54);
            this.DcWelcome.Name = "DcWelcome";
            this.DcWelcome.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.DcWelcome.Size = new System.Drawing.Size(1077, 476);
            this.DcWelcome.Text = "Giới thiệu";
            this.DcWelcome.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
            this.DcWelcome.Click += new System.EventHandler(this.DcWelcome_Click);
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.Controls.Add(this.DcWelcome);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(1085, 534);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "MaterialTeal";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.Teal;
            this.radLabel1.Location = new System.Drawing.Point(257, 16);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(516, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Chào mừng tới với Kaliz:Phần mềm lập trình đa dụng";
            this.radLabel1.ThemeName = "MaterialTeal";
            // 
            // PNew
            // 
            this.PNew.Location = new System.Drawing.Point(3, 59);
            this.PNew.Name = "PNew";
            this.PNew.Size = new System.Drawing.Size(120, 25);
            this.PNew.TabIndex = 1;
            this.PNew.Text = "New File";
            this.PNew.ThemeName = "MaterialTeal";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(3, 90);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(120, 26);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Open File";
            this.radButton1.ThemeName = "MaterialTeal";
            // 
            // Kaliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 728);
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
            this.Controls.Add(this.POpen);
            this.Controls.Add(this.radMenu1);
            this.Name = "Kaliz";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Kaliz-CMB";
            this.ThemeName = "MaterialTeal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.POpen)).EndInit();
            this.POpen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
            this.toolTabStrip1.ResumeLayout(false);
            this.DcWelcome.ResumeLayout(false);
            this.DcWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
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
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem FOpen;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem FClose;
        private Telerik.WinControls.UI.RadMenuItem FPrint;
        private Telerik.WinControls.UI.RadMenuItem FSave;
        private Telerik.WinControls.UI.RadMenuItem FSaveAs;
        private Telerik.WinControls.UI.RadMenuItem FExport;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem FExit;
        private Telerik.WinControls.UI.Docking.RadDock POpen;
        private Telerik.WinControls.UI.Docking.DocumentWindow DcWelcome;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private Telerik.WinControls.UI.Docking.ToolWindow DTer;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton PNew;
    }
}