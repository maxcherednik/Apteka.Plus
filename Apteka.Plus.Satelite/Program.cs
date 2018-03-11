using System;
using System.Threading;
using System.Windows.Forms;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.DAL;
using Apteka.Plus.Satelite.Forms;
using Apteka.Plus.Satelite.Properties;
using log4net;

namespace Apteka.Plus.Satelite
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            var connectionString = string.Format(Settings.Default.ConnectionStringTemplate, Settings.Default.DbHost, Settings.Default.DbUser, Settings.Default.DbPassword);

            while (!DAL.IsConnectionFine(connectionString))
            {
                using (var dlg = new frmDBConnectionFailure(Settings.Default.DbHost, Settings.Default.DbUser, Settings.Default.DbPassword))
                {
                    if (DialogResult.Retry == dlg.ShowDialog())
                    {
                        Settings.Default.DbHost = dlg.DbHost;
                        Settings.Default.DbUser = dlg.DbUser;
                        Settings.Default.DbPassword = dlg.DbPassword;
                        Settings.Default.Save();

                        connectionString = string.Format(Settings.Default.ConnectionStringTemplate, Settings.Default.DbHost, Settings.Default.DbUser, Settings.Default.DbPassword);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                }
            }

            DAL.InitConnectionString(connectionString);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
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