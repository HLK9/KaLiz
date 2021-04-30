namespace Kaliz
{
    partial class TextDia
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
            this.BtClose = new Telerik.WinControls.UI.RadButton();
            this.BtOK = new Telerik.WinControls.UI.RadButton();
            this.radTextBoxControl1 = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.BtClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BtClose
            // 
            this.BtClose.Location = new System.Drawing.Point(12, 176);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(110, 45);
            this.BtClose.TabIndex = 1;
            this.BtClose.Text = "Close";
            this.BtClose.ThemeName = "MaterialTeal";
            // 
            // BtOK
            // 
            this.BtOK.Location = new System.Drawing.Point(343, 176);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(110, 45);
            this.BtOK.TabIndex = 2;
            this.BtOK.Text = "OK";
            this.BtOK.ThemeName = "MaterialTeal";
            // 
            // radTextBoxControl1
            // 
            this.radTextBoxControl1.Location = new System.Drawing.Point(12, 12);
            this.radTextBoxControl1.Name = "radTextBoxControl1";
            this.radTextBoxControl1.Size = new System.Drawing.Size(441, 158);
            this.radTextBoxControl1.TabIndex = 3;
            // 
            // TextDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 245);
            this.Controls.Add(this.radTextBoxControl1);
            this.Controls.Add(this.BtOK);
            this.Controls.Add(this.BtClose);
            this.MinimizeBox = false;
            this.Name = "TextDia";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextDialog";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.BtClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton BtClose;
        private Telerik.WinControls.UI.RadButton BtOK;
        private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl1;
    }
}
