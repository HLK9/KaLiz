using Kaliz.Properties;
using System.Windows.Forms;

namespace Kaliz
{
    public partial class SplashForm : Telerik.WinControls.UI.ShapedForm
    {
        public SplashForm()
        {
            //960, 540 Cỡ form 1/2 ảnh 1080
            InitializeComponent(); PictureBox spashPictureBox = new PictureBox();
            spashPictureBox.Image = Resources.Ps;
            spashPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            spashPictureBox.Dock = DockStyle.Fill;
            this.Controls.Add(spashPictureBox);

            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
