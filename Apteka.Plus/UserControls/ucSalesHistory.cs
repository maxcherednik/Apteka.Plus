using Apteka.Helpers;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.Mapping;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLToolkit.DataAccess;

namespace Apteka.Plus.UserControls
{
    public partial class ucSalesHistory : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MyStore _mystoreSelected;

        public ucSalesHistory()
        {
            InitializeComponent();
        }

        public void ShowHistoryByName(MyStore store, string name)
        {
            _mystoreSelected = store;
            dateAcceptedDataGridViewTextBoxColumn.DefaultCellStyle.Format = "f";

            using (var dbSatelite = new DbManager(store.Name))
            {
                var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                SaleRows = sa.FindRowsByName(name);
            }

            SetResultsToGrid();
        }

        public void ShowHistoryByDate(MyStore store, DateTime date)
        {
            _mystoreSelected = store;
            using (var dbSatelite = new DbManager(store.Name))
            {
                var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                SaleRows = sa.GetRowsByDate(date);
            }

            SetResultsToGrid();

            dgvSales.Columns[2].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
        }

        private void SetResultsToGrid()
        {
            this.InvokeInGuiThread(() => salesRowBindingSource.DataSource = SaleRows);
        }

        public int NumberOfCustomers { get; private set; }

        public double Sum { get; private set; }

        public List<SalesRow> SaleRows { get; private set; }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 1)
            {
                var liFiltered = SaleRows.FindAll(p => p.ProductName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                                                       || p.PackageName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0);

                salesRowBindingSource.DataSource = liFiltered;
            }
            else
            {
                salesRowBindingSource.DataSource = SaleRows;
            }
        }

        #region Grid handlers
        private void dgvSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (SalesRow)dgv.Rows[e.RowIndex].DataBoundItem;

            if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "PriceWithDiscount")
            {
                if (row.PriceWithDiscount == 0)
                {
                    e.Value = "";
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
            }
            else if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Discount1")
            {
                if (row.Discount == 0)
                {
                    e.Value = "";
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void dgvSales_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "Count":
                    {
                        var frmCommentWindows = new frmCommentWindows();
                        frmCommentWindows.ShowDialog(this);

                        var row = (SalesRow)dgv.Rows[e.RowIndex].DataBoundItem;

                        var amountToReturn = int.Parse(cell.EditedFormattedValue.ToString());
                        var newAmount = row.Count - amountToReturn;

                        var salesReturnHistoryRow = new SalesReturnHistoryRow();

                        Map.ObjectToObject(row, salesReturnHistoryRow);
                        salesReturnHistoryRow.Comment = frmCommentWindows.Comment;
                        salesReturnHistoryRow.Amount = amountToReturn;
                        salesReturnHistoryRow.DateSold = row.DateAccepted;

                        using (var dbSatelite = new DbManager(_mystoreSelected.Name))
                        {
                            try
                            {
                                dbSatelite.BeginTransaction();

                                var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                                var srha = DataAccessor.CreateInstance<SalesReturnHistoryAccessor>(dbSatelite);
                                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                                var raa = DataAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);

                                srha.Insert(salesReturnHistoryRow);

                                lba.ChangeAmount(row.LocalBillsRow.ID, amountToReturn);

                                var ra = new RemoteAction
                                {
                                    LocalBillsRowID = row.LocalBillsRow.ID,
                                    SalesRowID = row.ID,
                                    AmountToReturn = amountToReturn,
                                    TypeOfAction = RemoteActionEnum.SalesReturn,
                                    Employee = Session.User
                                };

                                raa.Insert(ra);

                                row.Count = newAmount;
                                e.Value = newAmount;
                                e.ParsingApplied = true;

                                if (row.Count == 0)
                                {
                                    sa.DeleteByKey(row.ID);
                                }
                                else
                                {
                                    sa.ChangeAmount(row.ID, -1 * amountToReturn);
                                }

                                dbSatelite.CommitTransaction();
                            }
                            catch
                            {
                                dbSatelite.RollbackTransaction();

                                throw;
                            }
                        }
                    }
                    break;
            }
        }

        private void dgvSales_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            var salesRow = (SalesRow)dgv.CurrentRow.DataBoundItem;

            if (cell.OwningColumn.Name == "Count")
            {
                if (cell.IsInEditMode)
                {
                    if (int.TryParse(cell.EditedFormattedValue.ToString(), out var count))
                    {
                        if (count > salesRow.Count)
                        {
                            MessageBox.Show(@"Вы не можете вернуть число большее чем было продано", @"Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Вы ввели некорректное значение! Допускаются только числа.", @"Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvSales_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var oldColumn = dgvSales.Columns[e.ColumnIndex];

            var comparison = SalesRow.ProductNameComparison;
            switch (e.ColumnIndex)
            {
                case 0:
                    comparison = SalesRow.CustomerNumberComparison;
                    break;
                case 1:
                    comparison = SalesRow.CustomerNumberComparison;
                    break;
                case 2:
                    comparison = SalesRow.ProductNameComparison;
                    break;

                case 9:
                    comparison = SalesRow.ClientIDComparison;
                    break;
                case 8:
                    comparison = SalesRow.EmployeeComparison;
                    break;
            }

            if (oldColumn.HeaderCell.SortGlyphDirection == SortOrder.Descending
                        || oldColumn.HeaderCell.SortGlyphDirection == SortOrder.None)
            {
                SortBy(e.ColumnIndex, comparison, SortOrder.Ascending);
            }
            else
            {
                SortBy(e.ColumnIndex, comparison, SortOrder.Descending);
            }
        }

        private void dgvSales_KeyDown(object sender, KeyEventArgs e)
        {
            Log.InfoFormat("Пользователь нажал клавишу {0}", e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Back:
                    {
                        if (tbSearch.Text.Length != 0)
                        {
                            tbSearch.Text = tbSearch.Text.Substring(0, tbSearch.Text.Length - 1);
                        }

                        e.SuppressKeyPress = true;
                    }

                    break;

                case Keys.Escape:
                    {
                        tbSearch.Text = "";
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.Delete:
                    {
                        if (MessageBox.Show(@"Вы уверены, что хотите осуществить возврат?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            dgvSales.CurrentCell = dgvSales.CurrentRow.Cells["Count"];
                            dgvSales.BeginEdit(true);
                            e.Handled = true;
                        }
                        break;
                    }
            }
        }

        private void dgvSales_MouseDown(object sender, MouseEventArgs e)
        {
            var dgv = (DataGridView) sender;

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

        private void dgvSales_MouseUp(object sender, MouseEventArgs e)
        {
            var dgv = (DataGridView) sender;
            // Load context menu on right mouse click
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgv.HitTest(e.X, e.Y);
                // If column is first column
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell
                    && hitTestInfo.RowIndex >= 0)
                {
                    cmsSalesGridMenu.Show(dgv, e.Location);
                }
            }
        }

        private void dgvSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar.ToString().ToUpper();
        }
        #endregion

        private void SortBy(int columnIndex, Comparison<SalesRow> comparison, SortOrder sortOrder)
        {
            var oldColumn = dgvSales.Columns[columnIndex];

            SaleRows.Sort(comparison);

            if (sortOrder == SortOrder.Descending)
            {
                SaleRows.Reverse();
            }

            salesRowBindingSource.ResetBindings(false);
            oldColumn.HeaderCell.SortGlyphDirection = sortOrder;
        }

        private void cmsSalesGridMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var salesRow = (SalesRow)dgvSales.CurrentRow.DataBoundItem;
            cmsSalesGridMenu.Close();

            if (e.ClickedItem.Name == "showCustomerPurchases")
            {
                var frmClientBuysDetailed = new frmClientBuysDetailed(new ClientSummaryRow { ClientID = salesRow.ClientID });
                frmClientBuysDetailed.Show();
                Application.DoEvents();
            }
        }

        private void cmsSalesGridMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var salesRow = (SalesRow)dgvSales.CurrentRow.DataBoundItem;

            cmsSalesGridMenu.Items["showCustomerPurchases"].Enabled = !string.IsNullOrEmpty(salesRow.ClientID);
        }

        internal void LoadSettings()
        {
            dgvSales.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }
    }
}
