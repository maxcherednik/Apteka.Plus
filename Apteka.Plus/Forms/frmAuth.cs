using System;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;

namespace Apteka.Plus.Forms
{
    public partial class frmAuth : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            //Employee employee = ea.Auth(tbLogin.Text, tbPassword.Text);            

            Employee employee = new Employee();
            employee.ID = 1;
            employee.Login =tbLogin.Text;
            
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