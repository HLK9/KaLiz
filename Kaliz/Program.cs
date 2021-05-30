using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Kaliz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Splash ht = new Splash();
            Thread thr = new Thread(new ThreadStart(SplashScreen));
            thr.Start();
            Thread.Sleep(5000);
            thr.Abort();
            
            Application.Run(new Kaliz());
        }
        static void SplashScreen()
        {
            Application.Run(new Splash());
        }
    }
}