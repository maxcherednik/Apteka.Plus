using System;
using System.Windows.Forms;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.DAL;
using Apteka.Plus.Properties;
using Apteka.Plus.Common.Forms;
using log4net;

namespace Apteka.Plus
{
    static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        static void Main()
        {
            Log.Info("Старт приложения!");
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CheckAndInitConnectionStrings();

            Application.Run(new frmAuth());
        }

        private static void CheckAndInitConnectionStrings()
        {
            var connectionString = string.Format(Settings.Default.ConnectionStringTemplate, Settings.Default.DbHost, Settings.Default.DbUser, Settings.Default.DbPassword);

            while (!Dal.IsConnectionFine(connectionString))
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

            Dal.InitConnectionString(connectionString);
            Dal.InitStoresConnectionStrings(Settings.Default.ConnectionStringStoreTemplate, Settings.Default.DbHost, Settings.Default.DbUser, Settings.Default.DbPassword);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log.Error("Произошла ошибка!", e.Exception);

            MessageBox.Show($@"Произошла ошибка: {e.Exception.Message}", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exc = (Exception)e.ExceptionObject;

            Log.Error("Произошла ошибка!", exc);

            MessageBox.Show($@"Произошла ошибка: {exc.Message}", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}