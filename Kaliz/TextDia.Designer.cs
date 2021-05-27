namespace Kaliz
{
    partial class DialogASCII
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
            this.BtClose = new Telerik.WinControls.UI.RadButton();
            this.BtOK = new Telerik.WinControls.UI.RadButton();
            this.textInput = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.textResult = new Telerik.WinControls.UI.RadTextBox();
            this.droptype = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radToggleSwitch1 = new Telerik.WinControls.UI.RadToggleSwitch();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.BtClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.droptype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BtClose
            // 
            this.BtClose.BackColor = System.Drawing.Color.Thistle;
            this.BtClose.Location = new System.Drawing.Point(12, 176);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(110, 45);
            this.BtClose.TabIndex = 1;
            this.BtClose.Text = "Close";
            this.BtClose.ThemeName = "MaterialTeal";
            this.BtClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // BtOK
            // 
            this.BtOK.BackColor = System.Drawing.Color.Thistle;
            this.BtOK.Location = new System.Drawing.Point(343, 176);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(110, 45);
            this.BtOK.TabIndex = 2;
            this.BtOK.Text = "Convert";
            this.BtOK.ThemeName = "MaterialTeal";
            this.BtOK.Click += new System.EventHandler(this.BtOK_Click);
            // 
            // textInput
            // 
            this.textInput.BackColor = System.Drawing.Color.MintCream;
            this.textInput.Location = new System.Drawing.Point(84, 23);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(369, 36);
            this.textInput.TabIndex = 3;
            this.textInput.ThemeName = "MaterialTeal";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(15, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(63, 24);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Input:";
            this.radLabel1.ThemeName = "MaterialTeal";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(12, 125);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(72, 24);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Result:";
            this.radLabel2.ThemeName = "MaterialTeal";
            // 
            // textResult
            // 
            this.textResult.BackColor = System.Drawing.Color.MintCream;
            this.textResult.Location = new System.Drawing.Point(84, 116);
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.Size = new System.Drawing.Size(369, 36);
            this.textResult.TabIndex = 6;
            this.textResult.ThemeName = "MaterialTeal";
            // 
            // droptype
            // 
            this.droptype.BackColor = System.Drawing.Color.MintCream;
            radListDataItem1.Text = "Binary";
            radListDataItem2.Text = "Decimal";
            this.droptype.Items.Add(radListDataItem1);
            this.droptype.Items.Add(radListDataItem2);
            this.droptype.Location = new System.Drawing.Point(84, 69);
            this.droptype.Name = "droptype";
            this.droptype.Size = new System.Drawing.Size(143, 36);
            this.droptype.TabIndex = 7;
            this.droptype.ThemeName = "MaterialTeal";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(12, 72);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(54, 24);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "Type:";
            this.radLabel3.ThemeName = "MaterialTeal";
            // 
            // radToggleSwitch1
            // 
            this.radToggleSwitch1.Location = new System.Drawing.Point(373, 81);
            this.radToggleSwitch1.Name = "radToggleSwitch1";
            this.radToggleSwitch1.Size = new System.Drawing.Size(50, 20);
            this.radToggleSwitch1.TabIndex = 8;
            this.radToggleSwitch1.ThemeName = "MaterialTeal";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(246, 81);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(118, 19);
            this.radLabel4.TabIndex = 7;
            this.radLabel4.Text = "Separated by minus ";
            this.radLabel4.ThemeName = "MaterialTeal";
            // 
            // DialogASCII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 247);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radToggleSwitch1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.droptype);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.textInput);
            this.Controls.Add(this.BtOK);
            this.Controls.Add(this.BtClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogASCII";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASCII Convert";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.BtClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.droptype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadButton BtClose;
        private Telerik.WinControls.UI.RadButton BtOK;
        private Telerik.WinControls.UI.RadTextBox textInput;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox textResult;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList droptype;
        private Telerik.WinControls.UI.RadToggleSwitch radToggleSwitch1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
    }
}
