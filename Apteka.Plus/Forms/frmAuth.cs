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
            log.Info("������������ ������� �����������. ����� �� ����������");
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            log.InfoFormat("������������ ���������� �����������. �����: {0}",tbLogin.Text);

            EmployeesAccessor ea = EmployeesAccessor.CreateInstance<EmployeesAccessor>();
            //Employee employee = ea.Auth(tbLogin.Text, tbPassword.Text);            

            Employee employee = new Employee();
            employee.ID = 1;
            employee.Login =tbLogin.Text;
            
            if (employee == null)
            {
                log.Warn("����������� �� ��������");
                MessageBox.Show("������� ������ '" + tbLogin.Text + "' �� ������� ��� �������� ������!", "��������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                log.Warn("����������� ��������");
                Session.User = employee;

                frmMainMenu frmMainMenu = new frmMainMenu();
                frmMainMenu.Show();
                this.Hide();
            }

        }

        private void frmAuth_Load(object sender, EventArgs e)
        {
            log.Info("��������� ����� �����������");
        }
    }
}