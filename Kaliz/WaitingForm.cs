using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaliz
{
    public partial class WaitingForm : Telerik.WinControls.UI.ShapedForm
    {
    {
        public WaitingForm()
        {
            InitializeComponent();
            radWaitingBar1.StartWaiting();
        }
    }
}
