using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;

namespace Apteka.Plus.Forms
{
    public partial class frmNewBillInfo : Form
    {
        public DateTime BillDate;
        public Supplier Supplier;
        public string BillNumber;

        public frmNewBillInfo()
        {
            InitializeComponent();
        }

        public frmNewBillInfo(DateTime billDate, string billNumber, Supplier supplier)
            : this()
        {
            BillDate = billDate;
            BillNumber = billNumber;
            Supplier = supplier;

            dtpDate.Value = billDate;
            tbBillNumber.Text = billNumber;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbBillNumber.Text.Trim() != "")
            {
                BillDate = dtpDate.Value.Date;
                BillNumber = tbBillNumber.Text;
                Supplier = (Supplier)cbSuppliers.SelectedItem;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(@"Вы не ввели номер накладной или не указали поставщика!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (tbBillNumber.Text.Trim() == "")
                {
                    tbBillNumber.Focus();
                }
                else
                {
                    cbSuppliers.Focus();
                    cbSuppliers.DroppedDown = true;
                }
            }
        }

        private void frmNewBillInfo_Load(object sender, EventArgs e)
        {
            supplierBindingSource.DataSource = SuppliersCollection.AllSuppliers;
            if (Supplier != null)
                cbSuppliers.SelectedItem = Supplier;
        }
    }
}