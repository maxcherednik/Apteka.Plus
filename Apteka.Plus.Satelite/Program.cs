using System;
using System.Threading;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.DAL;
using Apteka.Plus.Satelite.Forms;
using Apteka.Plus.Satelite.Properties;

namespace Apteka.Plus.Satelite
{
    static class Program
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log.Info("Старт приложения!");
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CheckAndInitConnectionStrings();

            Application.Run(new frmEmployeeLogin());
        }

        private static void CheckAndInitConnectionStrings()
        {
            while (!DAL.IsConnectionFine(Settings.Default.ConnectionString))
            {
                using (var dlg = new frmDBConnectionFailure(Settings.Default.ConnectionString))
                {
                    if (DialogResult.Retry == dlg.ShowDialog())
                    {
                        Settings.Default.ConnectionString = dlg.ConnectionString;
                        Settings.Default.Save();
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                }
            }
            DAL.InitConnectionString(Settings.Default.ConnectionString);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            log.Error("Произошла ошибка!", e.Exception);
            MessageBox.Show("Произошла ошибка: " + e.Exception.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exc = (Exception)e.ExceptionObject;
            log.Error("Произошла ошибка!", exc);
            MessageBox.Show("Произошла ошибка: " + exc.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}