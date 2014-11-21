using System;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.DAL;
using Apteka.Plus.Properties;

namespace Apteka.Plus
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
            DAL.InitConnectionStrings(Settings.Default.ConnectionStringSatelite);
            log.Info("Старт приложения!");
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAuth());
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