using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Kaliz
{
    public partial class DialogASCII : Telerik.WinControls.UI.RadForm
    {
        public DialogASCII()
        {
            InitializeComponent();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtOK_Click(object sender, EventArgs e)
        {
            textResult.Clear();
            try
            {

                if (droptype.SelectedItem.Text == "Decimal")
                {
                    foreach (char c in textInput.Text)
                    {
                        if (radToggleSwitch1.Value == true)
                        {
                            textResult.Text += Convert.ToInt32(c)+" ";
                        }
                        else
                        textResult.Text += Convert.ToInt32(c);
                    }
                }
                else
                if (droptype.SelectedItem.Text == "Binary")
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (char c in textInput.Text.ToCharArray())
                    {
                        if (radToggleSwitch1.Value == true)
                        {
                            textResult.Text += sb.Append(Convert.ToString(c, 2).PadLeft(8, '0')+" ");
                        }
                        else
                            textResult.Text += sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));

                    }
                }
            }
            catch
            {
                
                    MessageBox.Show("Please select type to convert");
                
            }
           
        }
    }
}
