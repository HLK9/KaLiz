namespace Kaliz
{
    partial class SearchDocs
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.content = new Telerik.WinControls.UI.RadTextBox();
            this.searchEng = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.content)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchEng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(166, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(389, 41);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Search Documents On Internet";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(605, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 36);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.ThemeName = "MaterialTeal";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(192, 80);
            this.content.Name = "content";
            this.content.NullText = "Type here  to search";
            this.content.Size = new System.Drawing.Size(407, 36);
            this.content.TabIndex = 2;
            this.content.ThemeName = "MaterialTeal";
            // 
            // searchEng
            // 
            radListDataItem1.Text = "Stack OverFlow";
            radListDataItem2.Text = "DayNhauHoc";
            radListDataItem3.Text = "Google";
            this.searchEng.Items.Add(radListDataItem1);
            this.searchEng.Items.Add(radListDataItem2);
            this.searchEng.Items.Add(radListDataItem3);
            this.searchEng.Location = new System.Drawing.Point(8, 80);
            this.searchEng.Name = "searchEng";
            this.searchEng.Size = new System.Drawing.Size(178, 36);
            this.searchEng.TabIndex = 3;
            this.searchEng.Text = "Search Engine";
            this.searchEng.ThemeName = "MaterialTeal";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(145, 145);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(382, 18);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "Any trademarks used on this dialog are property of their respective owners.";
            // 
            // SearchDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 175);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.searchEng);
            this.Controls.Add(this.content);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchDocs";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchDocs";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.SearchDocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.content)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchEng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadTextBox content;
        private Telerik.WinControls.UI.RadDropDownList searchEng;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
