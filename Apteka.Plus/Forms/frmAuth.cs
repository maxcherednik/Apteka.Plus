using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmAuth : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmAuth()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Log.Info("Пользователь отменил авторизацию. Выход из приложения");
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Log.InfoFormat("Пользователь подтвердил авторизацию. Логин: {0}", tbLogin.Text);

            var employee = new Employee
            {
                ID = 1,
                Login = tbLogin.Text
            };

            Session.User = employee;

            var frmMainMenu = new frmMainMenu();
            frmMainMenu.Show();
            Hide();
        }

        private void frmAuth_Load(object sender, EventArgs e)
        {
            Log.Info("Загружена форма авторизации");
        }
    }
}