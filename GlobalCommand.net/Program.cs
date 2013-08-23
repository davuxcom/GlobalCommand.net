using System;
using System.Windows.Forms;

namespace GlobalCommand
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            bool ok;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "GlobalCommand", out ok);
            if (!ok)
            {
                System.Windows.Forms.MessageBox.Show("GlobalCommand is already running!", "Information");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            GC.KeepAlive(m);
        }
    }
}
