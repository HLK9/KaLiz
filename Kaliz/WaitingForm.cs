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
        public Action Worker { get; set; }

        public WaitingForm(Action work)
        {
            InitializeComponent();
            if (work == null)
                throw new ArgumentNullException();
            Worker = work;
            radWaitingBar1.StartWaiting();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
