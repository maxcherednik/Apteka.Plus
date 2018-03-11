using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmAuth : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmAuth()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            log.Info("Пользователь отменил авторизацию. Выход из приложения");
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            log.InfoFormat("Пользователь подтвердил авторизацию. Логин: {0}",tbLogin.Text);

            EmployeesAccessor ea = EmployeesAccessor.CreateInstance<EmployeesAccessor>();

            Employee employee = new Employee
            {
                ID = 1,
                Login = tbLogin.Text
            };

            if (employee == null)
            {
                log.Warn("Авторизация не пройдена");
                MessageBox.Show("Учетная запись '" + tbLogin.Text + "' не найдена или неверный пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                log.Warn("Авторизация пройдена");
                Session.User = employee;

                frmMainMenu frmMainMenu = new frmMainMenu();
                frmMainMenu.Show();
                this.Hide();
            }

        }

        private void frmAuth_Load(object sender, EventArgs e)
        {
            log.Info("Загружена форма авторизации");
        }
    }
}