namespace Kaliz
{
    partial class TerControl
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
            this.components = new System.ComponentModel.Container();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.radRichTextEditor1 = new Telerik.WinControls.UI.RadRichTextEditor();
            this.btnEcho = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.btnPush = new Telerik.WinControls.UI.RadButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEcho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPush)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radRichTextEditor1
            // 
            this.radRichTextEditor1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radRichTextEditor1.Location = new System.Drawing.Point(12, 98);
            this.radRichTextEditor1.Name = "radRichTextEditor1";
            this.radRichTextEditor1.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.radRichTextEditor1.SelectionStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.radRichTextEditor1.Size = new System.Drawing.Size(995, 440);
            this.radRichTextEditor1.TabIndex = 0;
            this.radRichTextEditor1.ThemeName = "MaterialTeal";
            // 
            // btnEcho
            // 
            this.btnEcho.Location = new System.Drawing.Point(12, 56);
            this.btnEcho.Name = "btnEcho";
            this.btnEcho.Size = new System.Drawing.Size(120, 36);
            this.btnEcho.TabIndex = 1;
            this.btnEcho.Text = "Echo";
            this.btnEcho.ThemeName = "MaterialTeal";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(887, 56);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 36);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.ThemeName = "MaterialTeal";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(12, 14);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(489, 36);
            this.radTextBox1.TabIndex = 3;
            this.radTextBox1.ThemeName = "MaterialTeal";
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(507, 14);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(160, 36);
            this.btnPush.TabIndex = 3;
            this.btnPush.Text = "Push Command";
            this.btnPush.ThemeName = "MaterialTeal";
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // TerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 550);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEcho);
            this.Controls.Add(this.radRichTextEditor1);
            this.Name = "TerControl";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "TerControl";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEcho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPush)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;
        private Telerik.WinControls.UI.RadButton btnEcho;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadButton btnPush;
        private System.Windows.Forms.Timer timer1;
    }
}
