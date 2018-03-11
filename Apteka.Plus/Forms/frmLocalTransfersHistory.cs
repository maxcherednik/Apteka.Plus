using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalTransfersHistory : Form
    {
        MyStore _mystoreSelected;
        List<LocalBillsTransferRow> _liLocalBillsTransferRows;
        public frmLocalTransfersHistory()
        {
            InitializeComponent();

            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
            dgvLocalTransfers.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            PerformLoadData();
        }

        private void PerformLoadData()
        {
            _mystoreSelected = cbMyStores.SelectedItem as MyStore;

            using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                _liLocalBillsTransferRows = lbta.GetRowsByDate(dtpDate.Value.Date);
                localBillsTransferRowBindingSource.DataSource = _liLocalBillsTransferRows;

                double dSum = 0;
                foreach (LocalBillsTransferRow row in _liLocalBillsTransferRows)
                {
                    dSum += row.Count * row.Price;
                }

                tsslSum.Text = string.Format("Сумма: {0}", dSum.ToString("### ##0.00"));

                dgvLocalTransfers.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
            }
        }

        public void LoadDataFor(MyStore mystore, DateTime date)
        {
            cbMyStores.SelectedItem = mystore;
            dtpDate.Value = date;

            PerformLoadData();
        }
    }
}
