namespace Kaliz
{
    partial class SendEmail
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
            this.EmailTo = new Telerik.WinControls.UI.RadTextBox();
            this.EmailSub = new Telerik.WinControls.UI.RadTextBox();
            this.EmailAttach = new Telerik.WinControls.UI.RadTextBox();
            this.EmailSend = new Telerik.WinControls.UI.RadButton();
            this.EmailClose = new Telerik.WinControls.UI.RadButton();
            this.EmailBody = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(12, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(25, 21);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "To:";
            this.radLabel2.ThemeName = "MaterialTeal";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(12, 91);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(53, 21);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Subject:";
            this.radLabel3.ThemeName = "MaterialTeal";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(12, 174);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(37, 21);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Body";
            this.radLabel4.ThemeName = "MaterialTeal";
            // 
            // EmailTo
            // 
            this.EmailTo.BackColor = System.Drawing.Color.Honeydew;
            this.EmailTo.EnableTheming = false;
            this.EmailTo.Location = new System.Drawing.Point(71, 24);
            this.EmailTo.Name = "EmailTo";
            this.EmailTo.Size = new System.Drawing.Size(295, 36);
            this.EmailTo.TabIndex = 4;
            this.EmailTo.ThemeName = "MaterialTeal";
            // 
            // EmailSub
            // 
            this.EmailSub.BackColor = System.Drawing.Color.Honeydew;
            this.EmailSub.EnableTheming = false;
            this.EmailSub.Location = new System.Drawing.Point(71, 76);
            this.EmailSub.Name = "EmailSub";
            this.EmailSub.Size = new System.Drawing.Size(295, 36);
            this.EmailSub.TabIndex = 5;
            this.EmailSub.ThemeName = "MaterialTeal";
            // 
            // EmailAttach
            // 
            this.EmailAttach.BackColor = System.Drawing.Color.Honeydew;
            this.EmailAttach.EnableTheming = false;
            this.EmailAttach.Location = new System.Drawing.Point(470, 24);
            this.EmailAttach.Name = "EmailAttach";
            this.EmailAttach.Size = new System.Drawing.Size(295, 36);
            this.EmailAttach.TabIndex = 6;
            this.EmailAttach.ThemeName = "MaterialTeal";
            this.EmailAttach.TextChanged += new System.EventHandler(this.EmailBody_TextChanged);
            // 
            // EmailSend
            // 
            this.EmailSend.BackColor = System.Drawing.Color.Honeydew;
            this.EmailSend.EnableTheming = false;
            this.EmailSend.Location = new System.Drawing.Point(657, 274);
            this.EmailSend.Name = "EmailSend";
            this.EmailSend.Size = new System.Drawing.Size(120, 36);
            this.EmailSend.TabIndex = 10;
            this.EmailSend.Text = "Send";
            this.EmailSend.ThemeName = "MaterialTeal";
            this.EmailSend.Click += new System.EventHandler(this.EmailSend_Click);
            // 
            // EmailClose
            // 
            this.EmailClose.BackColor = System.Drawing.Color.Honeydew;
            this.EmailClose.EnableTheming = false;
            this.EmailClose.Location = new System.Drawing.Point(12, 274);
            this.EmailClose.Name = "EmailClose";
            this.EmailClose.Size = new System.Drawing.Size(120, 36);
            this.EmailClose.TabIndex = 11;
            this.EmailClose.Text = "Close";
            this.EmailClose.ThemeName = "MaterialTeal";
            this.EmailClose.Click += new System.EventHandler(this.EmailClose_Click);
            // 
            // EmailBody
            // 
            this.EmailBody.BackColor = System.Drawing.Color.Honeydew;
            this.EmailBody.EnableTheming = false;
            this.EmailBody.Location = new System.Drawing.Point(71, 129);
            this.EmailBody.Name = "EmailBody";
            this.EmailBody.Size = new System.Drawing.Size(706, 110);
            this.EmailBody.TabIndex = 12;
            this.EmailBody.Text = "Sent From Kaliz";
            this.EmailBody.ThemeName = "MaterialTeal";
            this.EmailBody.TextChanged += new System.EventHandler(this.radTextBoxControl1_TextChanged);
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.Honeydew;
            this.radButton1.EnableTheming = false;
            this.radButton1.Location = new System.Drawing.Point(378, 24);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(81, 36);
            this.radButton1.TabIndex = 12;
            this.radButton1.Text = "Attach";
            this.radButton1.ThemeName = "MaterialTeal";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.BackColor = System.Drawing.Color.Honeydew;
            this.radButton2.EnableTheming = false;
            this.radButton2.Location = new System.Drawing.Point(291, 274);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(205, 36);
            this.radButton2.TabIndex = 11;
            this.radButton2.Text = "You have problem?";
            this.radButton2.ThemeName = "MaterialTeal";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(580, 76);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(46, 21);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "No file";
            this.radLabel1.ThemeName = "MaterialTeal";
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 322);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.EmailBody);
            this.Controls.Add(this.EmailClose);
            this.Controls.Add(this.EmailSend);
            this.Controls.Add(this.EmailAttach);
            this.Controls.Add(this.EmailSub);
            this.Controls.Add(this.EmailTo);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SendEmail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Email";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.SendEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox EmailTo;
        private Telerik.WinControls.UI.RadTextBox EmailSub;
        private Telerik.WinControls.UI.RadButton EmailSend;
        private Telerik.WinControls.UI.RadButton EmailClose;
        private Telerik.WinControls.UI.RadTextBoxControl EmailBody;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        internal Telerik.WinControls.UI.RadTextBox EmailAttach;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
