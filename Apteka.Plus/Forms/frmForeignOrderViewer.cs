using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Logic.OrderConverter.BLL;
using BLToolkit.DataAccess;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Forms
{
    public partial class frmForeignOrderViewer : Form
    {
        public frmForeignOrderViewer()
        {
            InitializeComponent();
        }

        private string _supplierName;
        private string _supplierBillNumber;
        private IList<LocalOrder> _liLocalOrderRows;

        public frmForeignOrderViewer(List<LocalOrder> liLocalOrderRows)
        {
            InitializeComponent();
            _liLocalOrderRows = liLocalOrderRows;
            localOrderBindingSource.DataSource = _liLocalOrderRows;
        }

        private void frmForeignOrderViewer_Shown(object sender, EventArgs e)
        {
            var frmConvertOrder = new frmConvertOrder();

            if (frmConvertOrder.ShowDialog(this) == DialogResult.OK)
            {
                _liLocalOrderRows = frmConvertOrder.ConvertedOrder;
                localOrderBindingSource.DataSource = _liLocalOrderRows;

                _supplierName = frmConvertOrder.SupplierName;
                _supplierBillNumber = frmConvertOrder.FileName;
            }
            else
            {
                Close();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.ForeignOrder.rdlc");

            var supplierBillNumber = new ReportParameter("SupplierBillNumber", _supplierBillNumber);
            var supplierName = new ReportParameter("SupplierName", _supplierName);

            frmReportViewer.SetParameters(supplierBillNumber, supplierName);

            frmReportViewer.SetDataSource("LocalOrder", localOrderBindingSource);

            frmReportViewer.ShowDialog();
        }

        private void frmForeignOrderViewer_Load(object sender, EventArgs e)
        {
            dgvForeignOrder.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void tsbProcess_Click(object sender, EventArgs e)
        {
            var frmMainStoreInsert = new frmMainStoreInsert(_liLocalOrderRows);

            frmMainStoreInsert.Show(Owner);
            Close();
        }
    }
}
