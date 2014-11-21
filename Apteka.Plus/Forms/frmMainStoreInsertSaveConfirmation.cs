using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;

namespace Apteka.Plus.Forms
{
    public partial class frmMainStoreInsertSaveConfirmation : Form
    {
        public bool DelayLocalBills = false;

        public frmMainStoreInsertSaveConfirmation()
        {
            InitializeComponent();
        }

        public frmMainStoreInsertSaveConfirmation(Supplier Supplier, DateTime BillDate, string SupplierBillNumber, double Sum)
        {
            InitializeComponent();

            tbDate.Text = BillDate.ToShortDateString();
            tbSupplier.Text = Supplier.Name;
            tbSupplierBillNumber.Text = SupplierBillNumber;
            tbSum.Text = Sum.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DelayLocalBills = cbDelayLocalBills.Checked;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
