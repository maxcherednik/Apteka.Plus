using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using log4net;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmEmployeeLogin : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmEmployeeLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Employee empl = dgvEmployeeList.CurrentRow.DataBoundItem as Employee;
            Session.User = empl;
            frmMainSalesWindow frmMainSalesWindow = new frmMainSalesWindow(empl);
            frmMainSalesWindow.Show();
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmEmployeeLogin_Load(object sender, EventArgs e)
        {
            EmployeesAccessor ea = EmployeesAccessor.CreateInstance<EmployeesAccessor>();
            employeeBindingSource.DataSource = ea.GetAllActiveEmployees();
        }

        private void dgvEmployeeList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        btnOk.PerformClick();
                    }
                    break;
            }
        }
    }
}
