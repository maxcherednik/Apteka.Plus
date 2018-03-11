using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.DAL.Accessors;
using Microsoft.Reporting.WinForms;
using OrderConverter;
using OrderConverter.BLL;

namespace Apteka.Plus.Forms
{
    public partial class frmForeignOrderViewer : Form
    {
        public frmForeignOrderViewer()
        {
            InitializeComponent();
        }

        string sSupplierName;
        string sSupplierBillNumber;
        List<LocalOrder> _liLocalOrderRows;

        public frmForeignOrderViewer(List<LocalOrder> liLocalOrderRows)
        {
            InitializeComponent();
            _liLocalOrderRows = liLocalOrderRows;
            localOrderBindingSource.DataSource = _liLocalOrderRows;
        }

        private void frmForeignOrderViewer_Shown(object sender, EventArgs e)
        {
            frmConvertOrder frmConvertOrder = new frmConvertOrder();

            if (frmConvertOrder.ShowDialog(this) == DialogResult.OK)
            {
                _liLocalOrderRows = frmConvertOrder.ConvertedOrder;
                localOrderBindingSource.DataSource = _liLocalOrderRows;

                sSupplierName = frmConvertOrder.SupplierName;
                sSupplierBillNumber = frmConvertOrder.FileName;
            }
            else
            {
                this.Close();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.ForeignOrder.rdlc");

            ReportParameter SupplierBillNumber = new ReportParameter("SupplierBillNumber", sSupplierBillNumber);
            ReportParameter SupplierName = new ReportParameter("SupplierName", sSupplierName);

            frmReportViewer.SetParameters(SupplierBillNumber, SupplierName);

            frmReportViewer.SetDataSource("LocalOrder", localOrderBindingSource);

            frmReportViewer.ShowDialog();
        }

        private void frmForeignOrderViewer_Load(object sender, EventArgs e)
        {
            dgvForeignOrder.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void tsbProcess_Click(object sender, EventArgs e)
        {
            frmMainStoreInsert frmMainStoreInsert = new frmMainStoreInsert(_liLocalOrderRows);

            frmMainStoreInsert.Show(Owner);
            Close();
        }
    }
}
