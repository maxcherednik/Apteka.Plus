using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

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

            if (this.Owner != null)
                this.Owner.Show();
        }

        private void frmSuppliersSummaries_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = Properties.Settings.Default.SuppliersSummariesStartDate;

            List<Supplier> liSuppliers = SuppliersCollection.AllSuppliers;

            Supplier s = new Supplier
            {
                ID = 0,
                Name = "Все"
            };

            liSuppliers.Insert(0, s);

            supplierBindingSource.DataSource = liSuppliers;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Supplier selectedSupplier = supplierBindingSource.Current as Supplier;
            using (DbManager db = new DbManager())
            {
                MainStoreRowsAccessor msra = MainStoreRowsAccessor.CreateInstance<MainStoreRowsAccessor>(db);
                List<SupplierSummary> liSupplierSummary = msra.GetRowsBySupplier(selectedSupplier.ID, dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                supplierSummaryBindingSource.DataSource = liSupplierSummary;

                dgvSuppliersSummaries.Columns[0].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;

                btnReport.Enabled = true;
                dgvSuppliersSummaries.Select();

            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.SuppliersSummaries.rdlc");
            frmReportViewer.SetDataSource("SupplierSummary", supplierSummaryBindingSource);
            frmReportViewer.ShowDialog();
        }
    }
}
