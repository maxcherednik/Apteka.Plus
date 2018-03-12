using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmEmployeeLogin : Form
    {
        public frmEmployeeLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var empl = (Employee)dgvEmployeeList.CurrentRow.DataBoundItem;
            Session.User = empl;
            var frmMainSalesWindow = new frmMainSalesWindow(empl);
            frmMainSalesWindow.Show();
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmEmployeeLogin_Load(object sender, EventArgs e)
        {
            var ea = DataAccessor.CreateInstance<EmployeesAccessor>();
            employeeBindingSource.DataSource = ea.GetAllActiveEmployees();
        }

        private void dgvEmployeeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}
