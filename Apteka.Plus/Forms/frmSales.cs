using System;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.UserControls;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmSales : Form
    {
        private MyStore _mystoreSelected;

        public frmSales()
        {
            InitializeComponent();

            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;

            ucSalesHistory1.LoadSettings();
            mdgvSummary.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            ucSalesHistory2.LoadSettings();
        }

        private void ucSuppliesReturnHistory1_RowCountChanged(object sender, ucSuppliesReturnHistory.RowCountChangedEventArgs e)
        {
            tpSuppliesReturns.Text = $@"Возврат из поступления ({ucSuppliesReturnHistory1.RowCount})";
            tpSuppliesReturns.Enabled = ucSuppliesReturnHistory1.RowCount > 0;
        }

        private void ucProductSuppliesHistory1_RowCountChanged(object sender, ucProductSuppliesHistory.RowCountChangedEventArgs e)
        {
            tpSupplies.Text = $@"Приход ({ucProductSuppliesHistory1.RowCount})";
            tpSupplies.Enabled = ucProductSuppliesHistory1.RowCount > 0;
        }

        private void ucLocalBillsTransfersHistory1_RowCountChanged(object sender, ucLocalBillsTransfersHistory.RowCountChangedEventArgs e)
        {
            tpLocalTransfers.Text = $@"Передачи ({ucLocalBillsTransfersHistory1.RowCount})";
            tpLocalTransfers.Enabled = ucLocalBillsTransfersHistory1.RowCount > 0;
        }

        private void ucSalesReturnHistory1_RowCountChanged(object sender, ucSalesReturnHistory.RowCountChangedEventArgs e)
        {
            tpReturns.Text = $@"Возврат из продаж ({ucSalesReturnHistory1.RowCount})";
            tpReturns.Enabled = ucSalesReturnHistory1.RowCount > 0;
        }

        private void ucPriceChangesHistory1_RowCountChanged(object sender, ucPriceChangesHistory.RowCountChangedEventArgs e)
        {
            tpPriceChanges.Text = $@"Изменения цен ({ucPriceChangesHistory1.RowCount})";
            tpPriceChanges.Enabled = ucPriceChangesHistory1.RowCount > 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            bgwDataLoader.RunWorkerAsync();
        }

        private void PerformLoadData()
        {
            this.InvokeInGuiThread(() =>
            {
                progressIndicator1.Visible = true;
                progressIndicator1.Start();
                _mystoreSelected = cbMyStores.SelectedItem as MyStore;
            });

            ucSalesHistory1.ShowHistoryByDate(_mystoreSelected, dtpDate.Value.Date);

            var maxCustomerNumber = 0;
            double dSum = 0;
            foreach (var row in ucSalesHistory1.SaleRows)
            {
                if (row.CustomerNumber > maxCustomerNumber)
                    maxCustomerNumber = row.CustomerNumber;

                if (row.PriceWithDiscount > 0)
                {
                    dSum += row.Count * row.PriceWithDiscount;
                }
                else
                {
                    dSum += row.Count * row.Price;
                }
            }

            tsslCustomerCounter.Text = $@"Кол-во покупателей: {maxCustomerNumber}";
            tsslSum.Text = $@"Сумма: {dSum:### ##0.00}";

            using (var dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);

                var dt = sa.GetSummary(dtpDate.Value.Date);

                this.InvokeInGuiThread(() =>
                {
                    mdgvSummary.DataSource = dt;
                    mdgvSummary.AutoGenerateColumns = false;
                    btnReport.Enabled = true;
                    tpSales.Select();
                });

                ucPriceChangesHistory1.LoadData(_mystoreSelected, dtpDate.Value.Date, dtpDate.Value.Date);

                ucSalesReturnHistory1.LoadData(_mystoreSelected, dtpDate.Value.Date, dtpDate.Value.Date);

                ucLocalBillsTransfersHistory1.LoadData(_mystoreSelected, dtpDate.Value.Date, dtpDate.Value.Date);

                ucProductSuppliesHistory1.LoadData(_mystoreSelected, dtpDate.Value.Date, dtpDate.Value.Date);

                ucSuppliesReturnHistory1.LoadData(_mystoreSelected, dtpDate.Value.Date, dtpDate.Value.Date);
            }

            this.InvokeInGuiThread(() =>
            {
                progressIndicator1.Stop();
                progressIndicator1.Visible = false;
            });

        }

        private void frmSales_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void btnLoadHistory_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            if (tbSearchHistory.Text.Trim() != "")
            {
                var mystore = (MyStore)cbMystoresHistory.SelectedItem;

                ucSalesHistory2.ShowHistoryByName(mystore, tbSearchHistory.Text.Trim());
            }
            else
            {
                MessageBox.Show(@"Вы не ввели условия поиска!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbSearchHistory.Select();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.CustomersFlow.rdlc");
            frmReportViewer.SetDataSource("SalesRow", ucSalesHistory1.SaleRows);
            frmReportViewer.ShowDialog();
        }

        public void LoadDataFor(MyStore mystore, DateTime date)
        {
            cbMyStores.SelectedItem = mystore;
            dtpDate.Value = date;

            bgwDataLoader.RunWorkerAsync();
        }

        private void bgwDataLoader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            PerformLoadData();
        }
    }
}

