namespace Kaliz
{
    partial class Feedback
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtAttachment = new Telerik.WinControls.UI.RadTextBox();
            this.txtSub = new Telerik.WinControls.UI.RadTextBox();
            this.richtxtContent = new Telerik.WinControls.UI.RadRichTextEditor();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            this.btnSend = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richtxtContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 27);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(60, 21);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Subject:";
            this.radLabel2.ThemeName = "MaterialTeal";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(17, 186);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(62, 21);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Content:";
            this.radLabel3.ThemeName = "MaterialTeal";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(12, 66);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(87, 21);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Attachment:";
            this.radLabel4.ThemeName = "MaterialTeal";
            // 
            // txtAttachment
            // 
            this.txtAttachment.Location = new System.Drawing.Point(105, 54);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.NullText = "Attach files";
            this.txtAttachment.Size = new System.Drawing.Size(556, 36);
            this.txtAttachment.TabIndex = 5;
            this.txtAttachment.ThemeName = "MaterialTeal";
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(105, 12);
            this.txtSub.Name = "txtSub";
            this.txtSub.NullText = "Type here";
            this.txtSub.Size = new System.Drawing.Size(686, 36);
            this.txtSub.TabIndex = 5;
            this.txtSub.ThemeName = "MaterialTeal";
            // 
            // richtxtContent
            // 
            this.richtxtContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richtxtContent.Location = new System.Drawing.Point(105, 96);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.richtxtContent.SelectionStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.richtxtContent.Size = new System.Drawing.Size(686, 223);
            this.richtxtContent.TabIndex = 6;
            this.richtxtContent.ThemeName = "MaterialTeal";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(667, 54);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(124, 36);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse File";
            this.btnBrowse.ThemeName = "MaterialTeal";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(732, 377);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(124, 36);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.ThemeName = "MaterialTeal";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeName = "MaterialTeal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 425);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.richtxtContent);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Feedback";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richtxtContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtAttachment;
        private Telerik.WinControls.UI.RadTextBox txtSub;
        private Telerik.WinControls.UI.RadRichTextEditor richtxtContent;
        private Telerik.WinControls.UI.RadButton btnBrowse;
        private Telerik.WinControls.UI.RadButton btnSend;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
