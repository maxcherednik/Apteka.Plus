using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;

namespace Apteka.Plus.Forms
{
    public partial class frmMainStoreInsertSaveConfirmation : Form
    {
        public bool DelayLocalBills;

        public frmMainStoreInsertSaveConfirmation()
        {
            InitializeComponent();
        }

        public frmMainStoreInsertSaveConfirmation(Supplier supplier, DateTime billDate, string supplierBillNumber, double sum)
        {
            InitializeComponent();

            tbDate.Text = billDate.ToShortDateString();
            tbSupplier.Text = supplier.Name;
            tbSupplierBillNumber.Text = supplierBillNumber;
            tbSum.Text = sum.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DelayLocalBills = cbDelayLocalBills.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
