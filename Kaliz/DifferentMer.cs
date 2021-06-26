using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using DiffPlex.WindowsForms.Controls;

namespace Kaliz
{
    public partial class DifferentMer : Telerik.WinControls.UI.RadForm
    {
        public DifferentMer()
        {
            InitializeComponent();
        }

        private void radTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Fd = new OpenFileDialog();
            
            if(Fd.ShowDialog() == DialogResult.OK)
            {
                textbox1.Text = Fd.FileName;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Fd = new OpenFileDialog();

            if (Fd.ShowDialog() == DialogResult.OK)
            {
                textbox2.Text = Fd.FileName;
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if(File.Exists(textbox1.Text)&&File.Exists(textbox2.Text))
            {
                DiffViewer Has = new DiffViewer();
                Has.Dock = DockStyle.Fill;
                Has.OldText = File.ReadAllText(textbox1.Text);
                Has.OldTextHeader = "File 1";
                Has.NewText = File.ReadAllText(textbox2.Text);
                Has.NewTextHeader = "File 2";
                Has.FontSize = 16;
                Has.FontFamilyNames = "Cascadia Code";
                Miad.Controls.Add(Has);


            }


        }

        private void Miad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DifferentMer_Load(object sender, EventArgs e)
        {

        }
    }
}
