using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalTransfersHistory : Form
    {
        private MyStore _mystoreSelected;
        private List<LocalBillsTransferRow> _liLocalBillsTransferRows;

        public frmLocalTransfersHistory()
        {
            InitializeComponent();

            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
            dgvLocalTransfers.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            PerformLoadData();
        }

        private void PerformLoadData()
        {
            _mystoreSelected = (MyStore)cbMyStores.SelectedItem;

            using (var dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                _liLocalBillsTransferRows = lbta.GetRowsByDate(dtpDate.Value.Date);
                localBillsTransferRowBindingSource.DataSource = _liLocalBillsTransferRows;

                double dSum = 0;
                foreach (var row in _liLocalBillsTransferRows)
                {
                    dSum += row.Count * row.Price;
                }

                tsslSum.Text = $@"Сумма: {dSum:### ##0.00}";

                dgvLocalTransfers.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
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
