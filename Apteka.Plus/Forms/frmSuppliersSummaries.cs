using System;
using System.Windows.Forms;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmSuppliersSummaries : Form
    {
        public frmSuppliersSummaries()
        {
            InitializeComponent();
        }

        private void frmSuppliersSummaries_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.SuppliersSummariesStartDate = dtpStartDate.Value;
            Properties.Settings.Default.Save();

            Owner?.Show();
        }

        private void frmSuppliersSummaries_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = Properties.Settings.Default.SuppliersSummariesStartDate;

            var liSuppliers = SuppliersCollection.AllSuppliers;

            var s = new Supplier
            {
                ID = 0,
                Name = "Все"
            };

            liSuppliers.Insert(0, s);

            supplierBindingSource.DataSource = liSuppliers;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var selectedSupplier = (Supplier)supplierBindingSource.Current;

            using (var db = new DbManager())
            {
                var msra = DataAccessor.CreateInstance<MainStoreRowsAccessor>(db);
                var liSupplierSummary = msra.GetRowsBySupplier(selectedSupplier.ID, dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                supplierSummaryBindingSource.DataSource = liSupplierSummary;

                dgvSuppliersSummaries.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Descending;

                btnReport.Enabled = true;
                dgvSuppliersSummaries.Select();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.SuppliersSummaries.rdlc");
            frmReportViewer.SetDataSource("SupplierSummary", supplierSummaryBindingSource);
            frmReportViewer.ShowDialog();
        }
    }
}
