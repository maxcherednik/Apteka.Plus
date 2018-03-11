using System;
using System.Data;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.UserControls;
using BLToolkit.Data;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmSales : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MyStore _mystoreSelected;

        public frmSales()
        {
            InitializeComponent();

            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;

            ucSalesHistory1.LoadSettings();
            mdgvSummary.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            ucSalesHistory2.LoadSettings();
        }

        #region RowCount EventHandlers
        void ucSuppliesReturnHistory1_RowCountChanged(object sender, ucSuppliesReturnHistory.RowCountChangedEventArgs e)
        {
            tpSuppliesReturns.Text = String.Format("Возврат из поступления ({0})", ucSuppliesReturnHistory1.RowCount);
            tpSuppliesReturns.Enabled = ucSuppliesReturnHistory1.RowCount > 0;
        }

        void ucProductSuppliesHistory1_RowCountChanged(object sender, ucProductSuppliesHistory.RowCountChangedEventArgs e)
        {
            tpSupplies.Text = String.Format("Приход ({0})", ucProductSuppliesHistory1.RowCount);
            tpSupplies.Enabled = ucProductSuppliesHistory1.RowCount > 0;
        }

        void ucLocalBillsTransfersHistory1_RowCountChanged(object sender, ucLocalBillsTransfersHistory.RowCountChangedEventArgs e)
        {
            tpLocalTransfers.Text = String.Format("Передачи ({0})", ucLocalBillsTransfersHistory1.RowCount);
            tpLocalTransfers.Enabled = ucLocalBillsTransfersHistory1.RowCount > 0;
        }

        void ucSalesReturnHistory1_RowCountChanged(object sender, ucSalesReturnHistory.RowCountChangedEventArgs e)
        {
            tpReturns.Text = String.Format("Возврат из продаж ({0})", ucSalesReturnHistory1.RowCount);
            tpReturns.Enabled = ucSalesReturnHistory1.RowCount > 0;
        }

        void ucPriceChangesHistory1_RowCountChanged(object sender, Apteka.Plus.UserControls.ucPriceChangesHistory.RowCountChangedEventArgs e)
        {
            tpPriceChanges.Text = String.Format("Изменения цен ({0})", ucPriceChangesHistory1.RowCount);
            tpPriceChanges.Enabled = ucPriceChangesHistory1.RowCount > 0;
        }
        #endregion

        private void btnLoad_Click(object sender, EventArgs e)
        {
            bgwDataLoader.RunWorkerAsync();
        }

        private void PerformLoadData()
        {
            this.InvokeInGUIThread(() =>
            {
                progressIndicator1.Visible = true;
                progressIndicator1.Start();
                _mystoreSelected = cbMyStores.SelectedItem as MyStore;
            });

            #region Load data

            ucSalesHistory1.ShowHistoryByDate(_mystoreSelected, dtpDate.Value.Date);

            int maxCustomerNumber = 0;
            double dSum = 0;
            foreach (SalesRow row in ucSalesHistory1.SaleRows)
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

            tsslCustomerCounter.Text = string.Format("Кол-во покупателей: {0}", maxCustomerNumber);
            tsslSum.Text = string.Format("Сумма: {0}", dSum.ToString("### ##0.00"));

            using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);

                DataTable dt = sa.GetSummary(dtpDate.Value.Date);

                this.InvokeInGUIThread(() =>
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

            #endregion

            this.InvokeInGUIThread(() =>
            {
                progressIndicator1.Stop();
                progressIndicator1.Visible = false;
            });

        }

        private void frmSales_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void btnLoadHistory_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            if (tbSearchHistory.Text.Trim() != "")
            {
                MyStore mystore = cbMystoresHistory.SelectedItem as MyStore;

                ucSalesHistory2.ShowHistoryByName(mystore, tbSearchHistory.Text.Trim());
            }
            else
            {
                MessageBox.Show("Вы не ввели условия поиска!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbSearchHistory.Select();

            }
        }

        private void tbSearchHistory_KeyDown(object sender, KeyEventArgs e)
        {
            log.InfoFormat("Пользователь нажал клавишу {0}", e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        PerformSearch();
                        break;
                    }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.CustomersFlow.rdlc");
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

