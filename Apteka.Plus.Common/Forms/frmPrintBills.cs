using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using log4net;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Common.Forms
{
    public partial class frmPrintBills : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string BaseDirectory = "Apteka.Plus.Common.Reports.";

        private readonly MyStore _store;

        public frmPrintBills()
        {
            InitializeComponent();
        }

        public frmPrintBills(MyStore store)
        {
            _store = store;
            store.Name = "";
            InitializeComponent();
        }

        private void frmPrintBills_Load(object sender, EventArgs e)
        {
            dgvLocalBill.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());

            if (_store == null)
            {
                foreach (var myStore in MyStoresCollection.AllStores)
                {
                    tscbMyStores.Items.Add(myStore);
                }
            }
            else
            {
                tscbMyStores.Items.Add(_store);
                tscbMyStores.SelectedItem = _store;
            }
        }

        private void frmPrintBills_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
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
                MessageBox.Show(@"Вы не выбрали пункт!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tstbLocalBillNumber.Text.Trim() == "")
            {
                MessageBox.Show(@"Вы не ввели номер накладной!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var myStore = (MyStore)tscbMyStores.SelectedItem;
            var localBillNumber = Convert.ToInt64(tstbLocalBillNumber.Text);
            LoadLocalBill(myStore, localBillNumber);
        }

        private void LoadLocalBill(MyStore myStore, long localBillNumber)
        {
            using (var db = new DbManager(myStore.Name))
            {
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);

                var liLocalBillsRowEx = lba.GetLocalBillByNumber(localBillNumber);
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
                MessageBox.Show(@"Вы не выбрали пункт!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var myStore = (MyStore)tscbMyStores.SelectedItem;
            using (var db = new DbManager(myStore.Name))
            {
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);

                var dt = lba.GetRecentLocalBills(20);
                dgvRecentLocalBills.DataSource = dt;
            }
        }

        private void dgvRecentLocalBills_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = (DataGridView)sender;
            LoadLocalBill((MyStore)tscbMyStores.SelectedItem, Convert.ToUInt32(dgv[1, e.RowIndex].Value.ToString()));
            dgvLocalBill.Select();
        }

        private void dgvLocalBill_KeyDown(object sender, KeyEventArgs e)
        {
            Log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            var dgv = (DataGridView)sender;

            if (e.KeyCode == Keys.Delete)
            {
                dgv.CurrentRow.Cells["LabelsCount"].Value = null;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                dgv.CurrentCell = dgv.CurrentRow.Cells["LabelsCount"];
                dgv.BeginEdit(true);
                e.Handled = true;
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
            var liLocalBillsRowEx = new List<LocalBillsRowEx>();
            foreach (DataGridViewRow row in dgvLocalBill.Rows)
            {
                var dataRow = (LocalBillsRowEx)row.DataBoundItem;
                if (row.Cells["LabelsCount"].Value != null)
                {
                    int labelCount = Convert.ToInt16(row.Cells["LabelsCount"].Value);
                    for (var i = 0; i < labelCount; i++)
                    {
                        liLocalBillsRowEx.Add(dataRow);
                    }
                }
            }

            var frmReportViewer = new frmReportViewer(BaseDirectory + reportName);
            frmReportViewer.SetDataSource("Apteka_Plus_Logic_BLL_Entities_LocalBillsRowEx", liLocalBillsRowEx);
            frmReportViewer.ShowDialog();
        }

        private void PrintOrder(string reportName)
        {
            var frmReportViewer = new frmReportViewer(BaseDirectory + reportName);

            var myStore = new ReportParameter("MyStore", tscbMyStores.SelectedItem.ToString());

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
