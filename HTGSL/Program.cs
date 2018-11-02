using Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
namespace HTGSL
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            try
            {
                string[] commandLineArgs = Environment.GetCommandLineArgs();
                if (commandLineArgs.Length == 1 || commandLineArgs[1] != "/new")
                {
                    if (SingleInstanceApplication.NotifyExistingInstance(Process.GetCurrentProcess().Id))
                    {
                        return;
                    }
                }

                System.Threading.Thread.CurrentThread.CurrentUICulture =
               new System.Globalization.CultureInfo(Settings.Default.Language);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SingleInstanceApplication.Initialize();
                Application.Run(new FMAIN());
                //  Application.Run(new FrmMain());
                SingleInstanceApplication.Close(); 
            }
            catch (Exception)
            {
            }

        }
    }
}
