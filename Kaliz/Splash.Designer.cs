namespace Kaliz
{
    partial class Splash
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsLineWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("OCR A Extended", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel1.Location = new System.Drawing.Point(65, 50);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(223, 76);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Kaliz";
            this.radLabel1.ThemeName = "MaterialTeal";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel2.Location = new System.Drawing.Point(80, 125);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(233, 27);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "<html><span style=\"font-size: 14pt\"><em>With Python, Pascal, C/C++</em></span></h" +
    "tml>";
            this.radLabel2.ThemeName = "MaterialTeal";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel3.Location = new System.Drawing.Point(12, 255);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(163, 21);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "© 2020-2021  CMB Studio";
            this.radLabel3.ThemeName = "MaterialTeal";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel4.Location = new System.Drawing.Point(357, 255);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(200, 21);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Powered by Telerik && Syncfusion";
            this.radLabel4.ThemeName = "MaterialTeal";
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Location = new System.Drawing.Point(186, 185);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(194, 24);
            this.radWaitingBar1.TabIndex = 4;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.WaitingIndicators.Add(this.dotsLineWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingSpeed = 80;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine;
            // 
            // dotsLineWaitingBarIndicatorElement1
            // 
            this.dotsLineWaitingBarIndicatorElement1.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dotsLineWaitingBarIndicatorElement1.Name = "dotsLineWaitingBarIndicatorElement1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(569, 297);
            this.Controls.Add(this.radWaitingBar1);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Splash";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement dotsLineWaitingBarIndicatorElement1;
        private System.Windows.Forms.Timer timer1;
    }
}
