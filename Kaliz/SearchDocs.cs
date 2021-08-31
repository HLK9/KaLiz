using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kaliz
{
    public partial class SearchDocs : Telerik.WinControls.UI.RadForm
    {
        public SearchDocs()
        {
            InitializeComponent();
        }

        private void SearchDocs_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(content.Text!=null|| content.Text != "")
            switch(searchEng.Text)
            {
                case "Google":
                    {
                            string con = "https://www.google.com/search?q=" + content.Text;
                            Process.Start(con);
                        break;
                    }
                    case "DayNhauHoc":
                        {
                            string con = "https://daynhauhoc.com/search?q=" + content.Text;
                            Process.Start(con);
                            break;
                        }
                    case "Stack OverFlow":
                        {
                            string con = "https://stackoverflow.com/search?q=" + content.Text;
                            Process.Start(con);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Select Search Engine");
                            break;
                        }
                       
            }
        }
    }
}
