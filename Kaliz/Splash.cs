using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Kaliz
{
    public partial class Splash : Telerik.WinControls.UI.RadForm
    {
        public Splash()
        {         
            
            InitializeComponent();
            radWaitingBar1.StartWaiting();    
            
        }
        

       
    }
}
