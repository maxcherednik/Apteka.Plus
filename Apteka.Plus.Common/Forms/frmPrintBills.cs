using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Forms
{
    public partial class frmPrintBills : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string BaseDirectory = "Apteka.Plus.Common.Reports.";

        private MyStore store;

        public frmPrintBills()
        {
            InitializeComponent();
        }

        public frmPrintBills(MyStore store)
        {
            this.store = store;
            store.Name = "";
            InitializeComponent();
        }

        private void frmPrintBills_Load(object sender, EventArgs e)
        {
            dgvLocalBill.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());

            if (store == null)
            {
                foreach (MyStore myStore in MyStoresCollection.AllStores)
                {
                    tscbMyStores.Items.Add(myStore);
                }
            }
            else
            {
                tscbMyStores.Items.Add(store);
                tscbMyStores.SelectedItem = store;
            }
        }

        private void frmPrintBills_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void накладнаяФармацевтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintOrder("LocalOrders.LocalBillByNumberShort.rdlc");
        }

        private void накладнаяПровизораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintOrder("LocalOrders.LocalBillRowsByNumber.rdlc");
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (tscbMyStores.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали пункт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tstbLocalBillNumber.Text.Trim() == "")
            {
                MessageBox.Show("Вы не ввели номер накладной!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MyStore myStore = tscbMyStores.SelectedItem as MyStore;
            long localBillNumber = Convert.ToInt64(tstbLocalBillNumber.Text);
            LoadLocalBill(myStore, localBillNumber);
        }

        private void LoadLocalBill(MyStore myStore, long localBillNumber)
        {
            using (DbManager db = new DbManager(myStore.Name))
            {
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);

                List<LocalBillsRowEx> liLocalBillsRowEx = lba.GetLocalBillByNumber(localBillNumber);
                localBillsRowExBindingSource.DataSource = liLocalBillsRowEx;
            }

            foreach (DataGridViewRow row in dgvLocalBill.Rows)
            {
                row.Cells["LabelsCount"].Value = 1;
            }
        }

        private void tscbMyStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbMyStores.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали пункт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MyStore myStore = tscbMyStores.SelectedItem as MyStore;
            using (DbManager db = new DbManager(myStore.Name))
            {
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);

                DataTable dt = lba.GetRecentLocalBills(20);
                dgvRecentLocalBills.DataSource = dt;
            }
        }

        private void dgvRecentLocalBills_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            LoadLocalBill(tscbMyStores.SelectedItem as MyStore, Convert.ToUInt32(dgv[1, e.RowIndex].Value.ToString()));
            dgvLocalBill.Select();

        }

        private void dgvLocalBill_KeyDown(object sender, KeyEventArgs e)
        {
            log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        dgv.CurrentRow.Cells["LabelsCount"].Value = null;
                    }
                    break;

                case Keys.Enter:
                    {
                        dgv.CurrentCell = dgv.CurrentRow.Cells["LabelsCount"];
                        dgv.BeginEdit(true);
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void большиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLabels("Labels.LocalBillLabels.rdlc");
        }

        private void маленькиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLabels("Labels.LocalBillLabelsSmall.rdlc");
        }

        private void средниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLabels("Labels.LocalBillLabelsMed.rdlc");
        }

        private void PrintLabels(string reportName)
        {
            List<LocalBillsRowEx> liLocalBillsRowEx = new List<LocalBillsRowEx>();
            foreach (DataGridViewRow row in dgvLocalBill.Rows)
            {
                LocalBillsRowEx dataRow = row.DataBoundItem as LocalBillsRowEx;
                if (row.Cells["LabelsCount"].Value != null)
                {
                    int labelCount = Convert.ToInt16(row.Cells["LabelsCount"].Value);
                    for (int i = 0; i < labelCount; i++)
                    {
                        liLocalBillsRowEx.Add(dataRow);
                    }
                }
            }

            frmReportViewer frmReportViewer = new frmReportViewer(BaseDirectory + reportName);
            frmReportViewer.SetDataSource("Apteka_Plus_Logic_BLL_Entities_LocalBillsRowEx", liLocalBillsRowEx);
            frmReportViewer.ShowDialog();
        }

        private void PrintOrder(string reportName)
        {
            frmReportViewer frmReportViewer = new frmReportViewer(BaseDirectory + reportName);

            ReportParameter myStore = new ReportParameter("MyStore", tscbMyStores.SelectedItem.ToString());

            frmReportViewer.SetParameters(myStore);
            frmReportViewer.SetDataSource("LocalBillsRowEx", localBillsRowExBindingSource);

            frmReportViewer.ShowDialog();
        }

        private void tsmiPrintWarehouseLabels_Click(object sender, EventArgs e)
        {
            PrintLabels("Labels.LocalBillLabelsWarehouse.rdlc");
        }
    }
}
