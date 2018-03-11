using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmFinance : Form
    {
        private MyStore _mystoreSelected;
        private DateTime _selectedDate;
        private DataLoader<List<FinanceRow>> _dataLoader;

        public frmFinance()
        {
            InitializeComponent();
            _dataLoader = new DataLoader<List<FinanceRow>>(() => LoadData(), 0);
            _dataLoader.RequestCompleted += new EventHandler<DataLoader<List<FinanceRow>>.RequestCompletedEventArgs>(_dataLoader_RequestCompleted);
            _dataLoader.ItsGonnaTakeAWhile += new EventHandler<DataLoader<List<FinanceRow>>.ItsGonnaTakeAWhileEventArgs>(_dataLoader_ItsGonnaTakeAWhile);

            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;

            dgvFinanceDaily.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            dgvFinanceMonthly.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        void _dataLoader_ItsGonnaTakeAWhile(object sender, DataLoader<List<FinanceRow>>.ItsGonnaTakeAWhileEventArgs e)
        {
            progressIndicatorEx1.Show();
        }

        void _dataLoader_RequestCompleted(object sender, DataLoader<List<FinanceRow>>.RequestCompletedEventArgs e)
        {
            btnLoad.Enabled = true;
            progressIndicatorEx1.Hide();
            List<FinanceRow> liFinanceRows = e.Results;

            double StockInTradeSum = 0;

            using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                StockInTradeSum = lba.GetStockInTradeSumByDate(new DateTime(dtpDate.Value.Date.Year, dtpDate.Value.Date.Month, 1));
                tbStockInTradeSumBefore.Text = StockInTradeSum.ToString("0.00");
            }

            financeRowBindingSource.DataSource = liFinanceRows;

            double RevenueSum = 0;
            double RevenueAvg = 0;

            double ReceiptSum = 0;
            double ReceiptAvg = 0;

            double NetProfitSum = 0;
            double NetProfitAvg = 0;

            double CostsSum = 0;
            double CostsAvg = 0;

            double DiscountSum = 0;
            double DiscountAvg = 0;

            double PriceChangesSum = 0;
            double PriceChangesAvg = 0;

            double LocalTransfersSum = 0;
            double LocalTransfersAvg = 0;

            double lastStockInTradeSum = StockInTradeSum;
            foreach (FinanceRow row in liFinanceRows)
            {
                RevenueSum += row.Revenue;
                ReceiptSum += row.Receipt;
                NetProfitSum += row.NetProfit;
                CostsSum += row.Costs;
                DiscountSum += row.Discount;
                PriceChangesSum += row.PriceChangesSum;
                LocalTransfersSum += row.LocalTransferSum;

                row.StockInTradeSum = lastStockInTradeSum - row.Revenue + row.Receipt + row.PriceChangesSum - row.LocalTransferSum;
                lastStockInTradeSum = row.StockInTradeSum;
            }
            tbStockInTradeSumAfter.Text = lastStockInTradeSum.ToString("0.00");
            RevenueAvg = RevenueSum / liFinanceRows.Count;
            ReceiptAvg = ReceiptSum / liFinanceRows.Count;
            NetProfitAvg = NetProfitSum / liFinanceRows.Count;
            CostsAvg = CostsSum / liFinanceRows.Count;
            DiscountAvg = DiscountSum / liFinanceRows.Count;
            PriceChangesAvg = PriceChangesSum / liFinanceRows.Count;
            LocalTransfersAvg = LocalTransfersSum / liFinanceRows.Count;

            tbRevenueAvg.Text = RevenueAvg.ToString("0.00");
            tbRevenueSum.Text = RevenueSum.ToString("0.00");

            tbRecieptAvg.Text = ReceiptAvg.ToString("0.00");
            tbRecieptSum.Text = ReceiptSum.ToString("0.00");

            tbNetProfitAvg.Text = NetProfitAvg.ToString("0.00");
            tbNetProfitSum.Text = NetProfitSum.ToString("0.00");

            tbCostsAvg.Text = CostsAvg.ToString("0.00");
            tbCostsSum.Text = CostsSum.ToString("0.00");

            tbDiscountAvg.Text = DiscountAvg.ToString("0.00");
            tbDiscountSum.Text = DiscountSum.ToString("0.00");

            tbPriceChangesAvg.Text = PriceChangesAvg.ToString("0.00");
            tbPriceChangesSum.Text = PriceChangesSum.ToString("0.00");

            tbLocalTransfersAvg.Text = LocalTransfersAvg.ToString("0.00");
            tbLocalTransfersSum.Text = LocalTransfersSum.ToString("0.00");

            button1.Enabled = true;

            PerformDailyTextBoxPositionin(dgvFinanceDaily);
        }

        private List<FinanceRow> LoadData()
        {
            using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                FinanceAccessor fa = FinanceAccessor.CreateInstance<FinanceAccessor>(dbSatelite);
                return fa.GetFinanceDaily(_selectedDate);
            }
        }

        private void frmFinance_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner != null)
                Owner.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;

            _mystoreSelected = cbMyStores.SelectedItem as MyStore;
            _selectedDate = dtpDate.Value.Date;
            _dataLoader.MakeRequest();
        }

        private void frmFinance_Load(object sender, EventArgs e)
        {
            tbYear.Text = DateTime.Now.Year.ToString();
        }

        private void dgvFinanceDaily_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            FinanceRow row = dgv.Rows[e.RowIndex].DataBoundItem as FinanceRow;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "Date":
                    {
                        if (row.Date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            e.CellStyle.BackColor = Color.LightGreen;
                            Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                            e.CellStyle.Font = f;

                        }
                        e.Value = row.Date.Day + " - " + row.Date.ToString("ddd");
                        e.FormattingApplied = true;

                    }
                    break;
                case "NetProfit":
                    {
                        double Percent = 0;
                        Percent = row.NetProfit * 100.0 / row.Revenue;
                        e.Value = string.Format("{0}     ({1}%)", row.NetProfit.ToString("0.00"), Percent.ToString("0.00"));
                        e.FormattingApplied = true;

                    }
                    break;

                default:
                    {
                        if (e.Value != null)
                        {
                            if (double.TryParse(e.Value.ToString(), out double sum))
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
            DataGridView dgv = sender as DataGridView;
            if (dgv.Rows.Count > 0)
            {
                PerformDailyTextBoxPositionin(dgv);
            }
        }

        private void PerformDailyTextBoxPositionin(DataGridView dgv)
        {
            Rectangle rect = dgv.GetCellDisplayRectangle(2, 0, false);
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
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.Finances.FinanceDaily.rdlc");
            frmReportViewer.SetDataSource("FinanceRow", financeRowBindingSource);
            frmReportViewer.ShowDialog();
        }

        private void btnLoadMonthlyFinance_Click(object sender, EventArgs e)
        {
            _mystoreSelected = cbMyStores.SelectedItem as MyStore;
            List<FinanceRow> liFinanceRows;

            double StockInTradeMonthlySum = 0;

            using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
            {

                int iYear = int.Parse(tbYear.Text);
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                StockInTradeMonthlySum = lba.GetStockInTradeSumByDate(new DateTime(iYear, 1, 1));
                tbStockInTradeMonthlySumBefore.Text = StockInTradeMonthlySum.ToString("0.00");

                FinanceAccessor fa = FinanceAccessor.CreateInstance<FinanceAccessor>(dbSatelite);
                dbSatelite.Command.CommandTimeout = 360;

                liFinanceRows = fa.GetFinanceMonthlyPeriod(new DateTime(iYear, 1, 1), DateTime.Now);

                financeRowBindingSource1.DataSource = liFinanceRows;
            }

            double RevenueSum = 0;
            double RevenueAvg = 0;

            double ReceiptSum = 0;
            double ReceiptAvg = 0;

            double NetProfitSum = 0;
            double NetProfitAvg = 0;

            double CostsSum = 0;
            double CostsAvg = 0;

            double lastStockInTradeSum = StockInTradeMonthlySum;
            foreach (FinanceRow row in liFinanceRows)
            {
                RevenueSum += row.Revenue;
                ReceiptSum += row.Receipt;
                NetProfitSum += row.NetProfit;
                CostsSum += row.Costs;

                row.StockInTradeSum = lastStockInTradeSum - row.Revenue + row.Receipt + row.PriceChangesSum - row.LocalTransferSum;
                lastStockInTradeSum = row.StockInTradeSum;
            }

            tbStockInTradeMonthlySumAfter.Text = lastStockInTradeSum.ToString("0.00");
            RevenueAvg = RevenueSum / liFinanceRows.Count;
            ReceiptAvg = ReceiptSum / liFinanceRows.Count;
            NetProfitAvg = NetProfitSum / liFinanceRows.Count;
            CostsAvg = CostsSum / liFinanceRows.Count;

            tbRevenueMonthlyAvg.Text = RevenueAvg.ToString("0.00");
            tbRevenueMonthlySum.Text = RevenueSum.ToString("0.00");

            tbRecieptMonthlyAvg.Text = ReceiptAvg.ToString("0.00");
            tbRecieptMonthlySum.Text = ReceiptSum.ToString("0.00");

            tbNetProfitMonthlyAvg.Text = NetProfitAvg.ToString("0.00");
            tbNetProfitMonthlySum.Text = NetProfitSum.ToString("0.00");

            tbCostsMonthlyAvg.Text = CostsAvg.ToString("0.00");
            tbCostsMonthlySum.Text = CostsSum.ToString("0.00");

            button2.Enabled = true;

            PerformMonthlyTextBoxPositionin(dgvFinanceMonthly);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.Finances.FinanceMonthly.rdlc");

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
            DataGridView dgv = sender as DataGridView;
            if (dgv.Rows.Count > 0)
            {
                PerformMonthlyTextBoxPositionin(dgv);
            }
        }

        private void PerformMonthlyTextBoxPositionin(DataGridView dgv)
        {
            Rectangle rect = dgv.GetCellDisplayRectangle(2, 0, false);
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
            DataGridView dgv = sender as DataGridView;
            FinanceRow row = dgv.Rows[e.RowIndex].DataBoundItem as FinanceRow;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "DateMonthly":
                    {

                        e.Value = row.Date.Year.ToString() + " " + row.Date.ToString("MMMM");
                        e.FormattingApplied = true;

                    }
                    break;
                case "NetProfit":
                    {
                        double Percent = 0;
                        Percent = row.NetProfit * 100.0 / row.Revenue;
                        e.Value = string.Format("{0}     ({1}%)", row.NetProfit.ToString("0.00"), Percent.ToString("0.00"));
                        e.FormattingApplied = true;

                    }
                    break;

                default:
                    {
                        if (e.Value != null)
                        {
                            if (double.TryParse(e.Value.ToString(), out double sum))
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
            DataGridView dgv = sender as DataGridView;

            // Load context menu on right mouse click
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {

                hitTestInfo = dgv.HitTest(e.X, e.Y);
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
            DataGridView dgv = sender as DataGridView;
            // Load context menu on right mouse click
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dgv.HitTest(e.X, e.Y);
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
            FinanceRow financeRow = dgvFinanceDaily.CurrentRow.DataBoundItem as FinanceRow;

            cmsFinance.Close();

            switch (e.ClickedItem.Name)
            {
                case "sales":
                    {
                        frmSales frmSales = new frmSales();
                        frmSales.Show();
                        Application.DoEvents();
                        frmSales.LoadDataFor(_mystoreSelected, financeRow.Date);

                    }
                    break;
                case "transfers":
                    {
                        frmLocalTransfersHistory frmLocalTransfersHistory = new frmLocalTransfersHistory();
                        frmLocalTransfersHistory.Show();
                        Application.DoEvents();
                        frmLocalTransfersHistory.LoadDataFor(_mystoreSelected, financeRow.Date);

                    }
                    break;
                case "price_changes":
                    {
                        frmPriceChangesHistory frmPriceChangesHistory = new frmPriceChangesHistory();
                        frmPriceChangesHistory.Show();
                        Application.DoEvents();
                        frmPriceChangesHistory.LoadDataFor(_mystoreSelected, financeRow.Date);

                    }
                    break;

                default:
                    break;
            }

        }

        private void cmsFinance_Opening(object sender, CancelEventArgs e)
        {
            FinanceRow financeRow = dgvFinanceDaily.CurrentRow.DataBoundItem as FinanceRow;

            if (financeRow.LocalTransferSum == 0)
            {
                cmsFinance.Items["transfers"].Enabled = false;
            }
            else
            {
                cmsFinance.Items["transfers"].Enabled = true;
            }

            if (financeRow.PriceChangesSum == 0)
            {
                cmsFinance.Items["price_changes"].Enabled = false;
            }
            else
            {
                cmsFinance.Items["price_changes"].Enabled = true;
            }

            cmsFinance.Items["supplies"].Enabled = false;
        }
    }
}
