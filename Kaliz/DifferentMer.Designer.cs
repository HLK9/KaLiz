namespace Kaliz
{
    partial class DifferentMer
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
            this.Miad = new Telerik.WinControls.UI.RadPanel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.textbox1 = new Telerik.WinControls.UI.RadTextBox();
            this.textbox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.Miad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Miad
            // 
            this.Miad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Miad.Location = new System.Drawing.Point(0, 72);
            this.Miad.Name = "Miad";
            this.Miad.Size = new System.Drawing.Size(1092, 339);
            this.Miad.TabIndex = 0;
            this.Miad.ThemeName = "MaterialTeal";
            this.Miad.Paint += new System.Windows.Forms.PaintEventHandler(this.Miad_Paint);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(12, 29);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(120, 36);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Select File 1";
            this.radButton1.ThemeName = "MaterialTeal";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton2.Location = new System.Drawing.Point(489, 29);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(120, 36);
            this.radButton2.TabIndex = 4;
            this.radButton2.Text = "Select File 2";
            this.radButton2.ThemeName = "MaterialTeal";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // textbox1
            // 
            this.textbox1.Location = new System.Drawing.Point(138, 29);
            this.textbox1.Name = "textbox1";
            this.textbox1.NullText = "File 1";
            this.textbox1.Size = new System.Drawing.Size(300, 36);
            this.textbox1.TabIndex = 6;
            this.textbox1.ThemeName = "MaterialTeal";
            // 
            // textbox2
            // 
            this.textbox2.Location = new System.Drawing.Point(615, 30);
            this.textbox2.Name = "textbox2";
            this.textbox2.NullText = "File 2";
            this.textbox2.Size = new System.Drawing.Size(300, 36);
            this.textbox2.TabIndex = 7;
            this.textbox2.ThemeName = "MaterialTeal";
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(970, 29);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(110, 36);
            this.radButton3.TabIndex = 8;
            this.radButton3.Text = "Compare";
            this.radButton3.ThemeName = "MaterialTeal";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // DifferentMer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 411);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.textbox2);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.Miad);
            this.Name = "DifferentMer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Different Merge";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.DifferentMer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Miad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadPanel Miad;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadTextBox textbox1;
        private Telerik.WinControls.UI.RadTextBox textbox2;
        private Telerik.WinControls.UI.RadButton radButton3;
    }
}