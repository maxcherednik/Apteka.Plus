using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmFinance : Form
    {
        private MyStore _mystoreSelected;
        private DateTime _selectedDate;
        private readonly DataLoader<List<FinanceRow>> _dataLoader;

        public frmFinance()
        {
            InitializeComponent();
            _dataLoader = new DataLoader<List<FinanceRow>>(LoadData, 0);
            _dataLoader.RequestCompleted += _dataLoader_RequestCompleted;
            _dataLoader.ItsGonnaTakeAWhile += _dataLoader_ItsGonnaTakeAWhile;

            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;

            dgvFinanceDaily.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            dgvFinanceMonthly.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void _dataLoader_ItsGonnaTakeAWhile(object sender, DataLoader<List<FinanceRow>>.ItsGonnaTakeAWhileEventArgs e)
        {
            progressIndicatorEx1.Show();
        }

        private void _dataLoader_RequestCompleted(object sender, DataLoader<List<FinanceRow>>.RequestCompletedEventArgs e)
        {
            btnLoad.Enabled = true;
            progressIndicatorEx1.Hide();
            var liFinanceRows = e.Results;

            double stockInTradeSum;

            using (var dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                stockInTradeSum = lba.GetStockInTradeSumByDate(new DateTime(dtpDate.Value.Date.Year, dtpDate.Value.Date.Month, 1));
                tbStockInTradeSumBefore.Text = stockInTradeSum.ToString("0.00");
            }

            financeRowBindingSource.DataSource = liFinanceRows;

            double revenueSum = 0;

            double receiptSum = 0;

            double netProfitSum = 0;

            double costsSum = 0;

            double discountSum = 0;

            double priceChangesSum = 0;

            double localTransfersSum = 0;

            var lastStockInTradeSum = stockInTradeSum;

            foreach (var row in liFinanceRows)
            {
                revenueSum += row.Revenue;
                receiptSum += row.Receipt;
                netProfitSum += row.NetProfit;
                costsSum += row.Costs;
                discountSum += row.Discount;
                priceChangesSum += row.PriceChangesSum;
                localTransfersSum += row.LocalTransferSum;

                row.StockInTradeSum = lastStockInTradeSum - row.Revenue + row.Receipt + row.PriceChangesSum - row.LocalTransferSum;
                lastStockInTradeSum = row.StockInTradeSum;
            }

            tbStockInTradeSumAfter.Text = lastStockInTradeSum.ToString("0.00");
            var revenueAvg = revenueSum / liFinanceRows.Count;
            var receiptAvg = receiptSum / liFinanceRows.Count;
            var netProfitAvg = netProfitSum / liFinanceRows.Count;
            var costsAvg = costsSum / liFinanceRows.Count;
            var discountAvg = discountSum / liFinanceRows.Count;
            var priceChangesAvg = priceChangesSum / liFinanceRows.Count;
            var localTransfersAvg = localTransfersSum / liFinanceRows.Count;

            tbRevenueAvg.Text = revenueAvg.ToString("0.00");
            tbRevenueSum.Text = revenueSum.ToString("0.00");

            tbRecieptAvg.Text = receiptAvg.ToString("0.00");
            tbRecieptSum.Text = receiptSum.ToString("0.00");

            tbNetProfitAvg.Text = netProfitAvg.ToString("0.00");
            tbNetProfitSum.Text = netProfitSum.ToString("0.00");

            tbCostsAvg.Text = costsAvg.ToString("0.00");
            tbCostsSum.Text = costsSum.ToString("0.00");

            tbDiscountAvg.Text = discountAvg.ToString("0.00");
            tbDiscountSum.Text = discountSum.ToString("0.00");

            tbPriceChangesAvg.Text = priceChangesAvg.ToString("0.00");
            tbPriceChangesSum.Text = priceChangesSum.ToString("0.00");

            tbLocalTransfersAvg.Text = localTransfersAvg.ToString("0.00");
            tbLocalTransfersSum.Text = localTransfersSum.ToString("0.00");

            button1.Enabled = true;

            PerformDailyTextBoxPositionin(dgvFinanceDaily);
        }

        private List<FinanceRow> LoadData()
        {
            using (var dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                var fa = DataAccessor.CreateInstance<FinanceAccessor>(dbSatelite);
                return fa.GetFinanceDaily(_selectedDate);
            }
        }

        private void frmFinance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;

            _mystoreSelected = (MyStore)cbMyStores.SelectedItem;
            _selectedDate = dtpDate.Value.Date;
            _dataLoader.MakeRequest();
        }

        private void frmFinance_Load(object sender, EventArgs e)
        {
            tbYear.Text = DateTime.Now.Year.ToString();
        }

        private void dgvFinanceDaily_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (FinanceRow)dgv.Rows[e.RowIndex].DataBoundItem;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "Date":
                    {
                        if (row.Date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

                        }
                        e.Value = row.Date.Day + " - " + row.Date.ToString("ddd");
                        e.FormattingApplied = true;

                    }
                    break;
                case "NetProfit":
                    {
                        var percent = row.NetProfit * 100.0 / row.Revenue;
                        e.Value = $"{row.NetProfit:0.00}     ({percent:0.00}%)";
                        e.FormattingApplied = true;

                    }
                    break;

                default:
                    {
                        if (e.Value != null)
                        {
                            if (double.TryParse(e.Value.ToString(), out var sum))
                            {
                                if (sum == 0)
                                {
                                    e.Value = "";
                                    e.FormattingApplied = true;
                                }
                            }
                        }

                    }
                    break;
            }
        }

        private void dgvFinanceDaily_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Rows.Count > 0)
            {
                PerformDailyTextBoxPositionin(dgv);
            }
        }

        private void PerformDailyTextBoxPositionin(DataGridView dgv)
        {
            var rect = dgv.GetCellDisplayRectangle(2, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbRevenueAvg.Left = rect.X;
            tbRevenueAvg.Width = rect.Width;
            tbRevenueSum.Left = rect.X;
            tbRevenueSum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(3, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbRecieptAvg.Left = rect.X;
            tbRecieptAvg.Width = rect.Width;
            tbRecieptSum.Left = rect.X;
            tbRecieptSum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(4, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbCostsAvg.Left = rect.X;
            tbCostsAvg.Width = rect.Width;
            tbCostsSum.Left = rect.X;
            tbCostsSum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(5, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbNetProfitAvg.Left = rect.X;
            tbNetProfitAvg.Width = rect.Width;
            tbNetProfitSum.Left = rect.X;
            tbNetProfitSum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(6, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbDiscountAvg.Left = rect.X;
            tbDiscountAvg.Width = rect.Width;
            tbDiscountSum.Left = rect.X;
            tbDiscountSum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(7, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbLocalTransfersAvg.Left = rect.X;
            tbLocalTransfersAvg.Width = rect.Width;
            tbLocalTransfersSum.Left = rect.X;
            tbLocalTransfersSum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(8, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbPriceChangesAvg.Left = rect.X;
            tbPriceChangesAvg.Width = rect.Width;
            tbPriceChangesSum.Left = rect.X;
            tbPriceChangesSum.Width = rect.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.Finances.FinanceDaily.rdlc");
            frmReportViewer.SetDataSource("FinanceRow", financeRowBindingSource);
            frmReportViewer.ShowDialog();
        }

        private void btnLoadMonthlyFinance_Click(object sender, EventArgs e)
        {
            _mystoreSelected = (MyStore)cbMyStores.SelectedItem;
            List<FinanceRow> liFinanceRows;

            double stockInTradeMonthlySum;

            var iYear = int.Parse(tbYear.Text);

            using (var dbSatelite = new DbManager(_mystoreSelected.Name))
            {   
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                stockInTradeMonthlySum = lba.GetStockInTradeSumByDate(new DateTime(iYear, 1, 1));
                tbStockInTradeMonthlySumBefore.Text = stockInTradeMonthlySum.ToString("0.00");

                var fa = DataAccessor.CreateInstance<FinanceAccessor>(dbSatelite);
                dbSatelite.Command.CommandTimeout = 360;

                liFinanceRows = fa.GetFinanceMonthlyPeriod(new DateTime(iYear, 1, 1), DateTime.Now);

                financeRowBindingSource1.DataSource = liFinanceRows;
            }

            double revenueSum = 0;

            double receiptSum = 0;

            double netProfitSum = 0;

            double costsSum = 0;

            var lastStockInTradeSum = stockInTradeMonthlySum;

            foreach (var row in liFinanceRows)
            {
                revenueSum += row.Revenue;
                receiptSum += row.Receipt;
                netProfitSum += row.NetProfit;
                costsSum += row.Costs;

                row.StockInTradeSum = lastStockInTradeSum - row.Revenue + row.Receipt + row.PriceChangesSum - row.LocalTransferSum;
                lastStockInTradeSum = row.StockInTradeSum;
            }

            tbStockInTradeMonthlySumAfter.Text = lastStockInTradeSum.ToString("0.00");
            var revenueAvg = revenueSum / liFinanceRows.Count;
            var receiptAvg = receiptSum / liFinanceRows.Count;
            var netProfitAvg = netProfitSum / liFinanceRows.Count;
            var costsAvg = costsSum / liFinanceRows.Count;

            tbRevenueMonthlyAvg.Text = revenueAvg.ToString("0.00");
            tbRevenueMonthlySum.Text = revenueSum.ToString("0.00");

            tbRecieptMonthlyAvg.Text = receiptAvg.ToString("0.00");
            tbRecieptMonthlySum.Text = receiptSum.ToString("0.00");

            tbNetProfitMonthlyAvg.Text = netProfitAvg.ToString("0.00");
            tbNetProfitMonthlySum.Text = netProfitSum.ToString("0.00");

            tbCostsMonthlyAvg.Text = costsAvg.ToString("0.00");
            tbCostsMonthlySum.Text = costsSum.ToString("0.00");

            button2.Enabled = true;

            PerformMonthlyTextBoxPositionin(dgvFinanceMonthly);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.Finances.FinanceMonthly.rdlc");

            frmReportViewer.SetDataSource("FinanceRow", financeRowBindingSource1);

            frmReportViewer.ShowDialog();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1 && e.Action == TabControlAction.Selecting)
            {
                if (Session.User.Login != "igor")
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgvFinanceMonthly_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Rows.Count > 0)
            {
                PerformMonthlyTextBoxPositionin(dgv);
            }
        }

        private void PerformMonthlyTextBoxPositionin(DataGridView dgv)
        {
            var rect = dgv.GetCellDisplayRectangle(2, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbRevenueMonthlyAvg.Left = rect.X;
            tbRevenueMonthlyAvg.Width = rect.Width;
            tbRevenueMonthlySum.Left = rect.X;
            tbRevenueMonthlySum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(3, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbRecieptMonthlyAvg.Left = rect.X;
            tbRecieptMonthlyAvg.Width = rect.Width;
            tbRecieptMonthlySum.Left = rect.X;
            tbRecieptMonthlySum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(4, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbCostsMonthlyAvg.Left = rect.X;
            tbCostsMonthlyAvg.Width = rect.Width;
            tbCostsMonthlySum.Left = rect.X;
            tbCostsMonthlySum.Width = rect.Width;

            rect = dgv.GetCellDisplayRectangle(5, 0, false);
            rect.Location = dgv.PointToScreen(rect.Location);
            tbNetProfitMonthlyAvg.Left = rect.X;
            tbNetProfitMonthlyAvg.Width = rect.Width;
            tbNetProfitMonthlySum.Left = rect.X;
            tbNetProfitMonthlySum.Width = rect.Width;
        }

        private void dgvFinanceMonthly_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (FinanceRow)dgv.Rows[e.RowIndex].DataBoundItem;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "DateMonthly":
                    {
                        e.Value = row.Date.Year + " " + row.Date.ToString("MMMM");
                        e.FormattingApplied = true;
                    }
                    break;
                case "NetProfit":
                    {
                        var percent = row.NetProfit * 100.0 / row.Revenue;
                        e.Value = $"{row.NetProfit:0.00}     ({percent:0.00}%)";
                        e.FormattingApplied = true;
                    }
                    break;

                default:
                    {
                        if (e.Value != null)
                        {
                            if (double.TryParse(e.Value.ToString(), out var sum))
                            {
                                if (sum == 0)
                                {
                                    e.Value = "";
                                    e.FormattingApplied = true;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void dgvFinanceDaily_MouseDown(object sender, MouseEventArgs e)
        {
            var dgv = (DataGridView)sender;

            // Load context menu on right mouse click
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgv.HitTest(e.X, e.Y);
                // If column is first column
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.RowIndex >= 0)
                {
                    dgv.ClearSelection();

                    dgv.Rows[hitTestInfo.RowIndex].Selected = true;
                    //setting active cell (black arrow)
                    dgv.CurrentCell = dgv.Rows[hitTestInfo.RowIndex].Cells[0];
                }
            }
        }

        private void dgvFinanceDaily_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // Load context menu on right mouse click
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgv.HitTest(e.X, e.Y);
                // If column is first column
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell
                    && hitTestInfo.RowIndex >= 0)
                {
                    cmsFinance.Show(dgv, e.Location);
                }
            }
        }

        private void cmsFinance_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var financeRow = (FinanceRow)dgvFinanceDaily.CurrentRow.DataBoundItem;

            cmsFinance.Close();

            switch (e.ClickedItem.Name)
            {
                case "sales":
                    {
                        var frmSales = new frmSales();
                        frmSales.Show();
                        Application.DoEvents();
                        frmSales.LoadDataFor(_mystoreSelected, financeRow.Date);

                    }
                    break;
                case "transfers":
                    {
                        var frmLocalTransfersHistory = new frmLocalTransfersHistory();
                        frmLocalTransfersHistory.Show();
                        Application.DoEvents();
                        frmLocalTransfersHistory.LoadDataFor(_mystoreSelected, financeRow.Date);

                    }
                    break;
                case "price_changes":
                    {
                        var frmPriceChangesHistory = new frmPriceChangesHistory();
                        frmPriceChangesHistory.Show();
                        Application.DoEvents();
                        frmPriceChangesHistory.LoadDataFor(_mystoreSelected, financeRow.Date);
                    }
                    break;
            }

        }

        private void cmsFinance_Opening(object sender, CancelEventArgs e)
        {
            var financeRow = (FinanceRow)dgvFinanceDaily.CurrentRow.DataBoundItem;

            cmsFinance.Items["transfers"].Enabled = financeRow.LocalTransferSum != 0;

            cmsFinance.Items["price_changes"].Enabled = financeRow.PriceChangesSum != 0;

            cmsFinance.Items["supplies"].Enabled = false;
        }
    }
}
