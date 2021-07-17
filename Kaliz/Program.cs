using System;
using System.Threading;
using System.Windows.Forms;

namespace Kaliz
{
    static class Program
    {
        public static SplashForm splashForm = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //
            //show splash
            Thread splashThread = new Thread(new ThreadStart(
                delegate
                {
                    splashForm = new SplashForm();
                    Application.Run(splashForm);
                }
                ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            //run form - time taking operation
            //MainForm mainForm = new MainForm();
            //mainForm.Load += new EventHandler(mainForm_Load);
            Kaliz Ka = new Kaliz();
            Ka.Load += Ka_Load;
            //
            Application.Run(Ka);
        }

        private static void Ka_Load(object sender, EventArgs e)
        {
            if (splashForm == null)
            {
                return;
            }

            splashForm.Invoke(new Action(splashForm.Close));
            splashForm.Dispose();
            splashForm = null;
        }
    }
}