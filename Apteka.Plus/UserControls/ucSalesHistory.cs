using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.Mapping;

namespace Apteka.Plus.UserControls
{
    public partial class ucSalesHistory : UserControl
    {
        #region Private fields
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<SalesRow> _liSaleRows;

        private MyStore _mystoreSelected;

        #endregion

        #region Constructor
        public ucSalesHistory()
        {
            InitializeComponent();
        }
        #endregion

        #region Public methods


        public void ShowHistoryByName(MyStore store, string name)
        {
            _mystoreSelected = store;
            this.dateAcceptedDataGridViewTextBoxColumn.DefaultCellStyle.Format = "f";

            using (DbManager dbSatelite = new DbManager(store.Name))
            {
                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                _liSaleRows = sa.FindRowsByName(name);
            }
            SetResultsToGrid();
        }

        public void ShowHistoryByDate(MyStore store, DateTime date)
        {
            _mystoreSelected = store;
            using (DbManager dbSatelite = new DbManager(store.Name))
            {
                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                _liSaleRows = sa.GetRowsByDate(date);
            }

            SetResultsToGrid();

            dgvSales.Columns[2].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
        }

        private void SetResultsToGrid()
        {
            this.InvokeInGUIThread(() => salesRowBindingSource.DataSource = _liSaleRows);
        }

        public void ShowHistoryByClient(string clientID)
        {

        }
        #endregion

        #region Properties
        public int NumberOfCustomers { get; private set; }
        public double Sum { get; private set; }

        public List<SalesRow> SaleRows
        {
            get
            {
                return _liSaleRows;
            }
        }

        #endregion

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 1)
            {

                List<SalesRow> liFiltered = _liSaleRows.FindAll(p =>
                {

                    return p.ProductName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                        || p.PackageName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0;

                });

                salesRowBindingSource.DataSource = liFiltered;

            }
            else
            {
                salesRowBindingSource.DataSource = _liSaleRows;

            }
        }

        #region Grid handlers
        private void dgvSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SalesRow row = dgv.Rows[e.RowIndex].DataBoundItem as SalesRow;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "PriceWithDiscount":
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
                    break;

                case "Discount1":
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
                    break;

                default:
                    break;
            }
        }

        private void dgvSales_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "Count":
                    {
                        frmCommentWindows frmCommentWindows = new frmCommentWindows();
                        frmCommentWindows.ShowDialog(this);

                        SalesRow row = dgv.Rows[e.RowIndex].DataBoundItem as SalesRow;

                        int amountToReturn = int.Parse(cell.EditedFormattedValue.ToString());
                        int newAmount = row.Count - amountToReturn;

                        SalesReturnHistoryRow salesReturnHistoryRow = new SalesReturnHistoryRow();

                        Map.ObjectToObject(row, salesReturnHistoryRow);
                        salesReturnHistoryRow.Comment = frmCommentWindows.Comment;
                        salesReturnHistoryRow.Amount = amountToReturn;
                        salesReturnHistoryRow.DateSold = row.DateAccepted;

                        using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
                        {
                            /////////////////////////////
                            try
                            {

                                dbSatelite.BeginTransaction();

                                /////////////////////////////
                                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                                SalesReturnHistoryAccessor srha = SalesReturnHistoryAccessor.CreateInstance<SalesReturnHistoryAccessor>(dbSatelite);
                                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                                RemoteActionAccessor raa = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);

                                srha.Insert(salesReturnHistoryRow);

                                lba.ChangeAmount(row.LocalBillsRow.ID, amountToReturn);

                                RemoteAction ra = new RemoteAction();
                                ra.LocalBillsRowID = row.LocalBillsRow.ID;
                                ra.SalesRowID = row.ID;
                                ra.AmountToReturn = amountToReturn;
                                ra.TypeOfAction = RemoteActionEnum.SalesReturn;
                                ra.Employee = Session.User;
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
                            catch (Exception exc)
                            {

                                dbSatelite.RollbackTransaction();

                                throw exc;
                            }
                        }

                    }
                    break;

            }

        }

        private void dgvSales_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            SalesRow salesRow = dgv.CurrentRow.DataBoundItem as SalesRow;

            switch (cell.OwningColumn.Name)
            {

                case "Count":
                    {
                        if (cell.IsInEditMode)
                        {
                            int Count;

                            if (int.TryParse(cell.EditedFormattedValue.ToString(), out Count))
                            {
                                if (Count > salesRow.Count)
                                {
                                    MessageBox.Show("Вы не можете вернуть число большее чем было продано", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }

                        }

                    }
                    break;

                default:
                    break;
            }
        }

        private void dgvSales_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn oldColumn = dgvSales.Columns[e.ColumnIndex];

            Comparison<SalesRow> comparison = new Comparison<SalesRow>(SalesRow.ProductNameComparison);
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

            log.InfoFormat("Пользователь нажал клавишу {0}", e.KeyCode);
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

                        if (MessageBox.Show("Вы уверены, что хотите осуществить возврат?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

        private void dgvSales_MouseUp(object sender, MouseEventArgs e)
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
                    cmsSalesGridMenu.Show(dgv, e.Location);
                }

            }
        }

        private void dgvSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar.ToString().ToUpper();
        }
        #endregion

        #region Private Methods

        private void SortBy(int columnIndex, Comparison<SalesRow> comparison, SortOrder sortOrder)
        {
            DataGridViewColumn oldColumn = dgvSales.Columns[columnIndex];

            _liSaleRows.Sort(comparison);

            if (sortOrder == SortOrder.Descending)
            {
                _liSaleRows.Reverse();
            }

            salesRowBindingSource.ResetBindings(false);
            oldColumn.HeaderCell.SortGlyphDirection = sortOrder;

        }
        #endregion

        private void cmsSalesGridMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SalesRow salesRow = dgvSales.CurrentRow.DataBoundItem as SalesRow;
            cmsSalesGridMenu.Close();

            switch (e.ClickedItem.Name)
            {
                case "showCustomerPurchases":
                    {
                        frmClientBuysDetailed frmClientBuysDetailed = new frmClientBuysDetailed(new ClientSummaryRow() { ClientID = salesRow.ClientID });
                        frmClientBuysDetailed.Show();
                        Application.DoEvents();

                    }
                    break;
                case "showWhoBuysThisItem":
                    {
                        //frmLocalTransfersHistory frmLocalTransfersHistory = new frmLocalTransfersHistory();
                        //frmLocalTransfersHistory.Show();
                        //Application.DoEvents();
                        //frmLocalTransfersHistory.LoadDataFor(_mystoreSelected, financeRow.Date);

                    }
                    break;

                default:
                    break;
            }
        }

        private void cmsSalesGridMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SalesRow salesRow = dgvSales.CurrentRow.DataBoundItem as SalesRow;

            if (String.IsNullOrEmpty(salesRow.ClientID))
            {
                cmsSalesGridMenu.Items["showCustomerPurchases"].Enabled = false;
            }
            else
            {
                cmsSalesGridMenu.Items["showCustomerPurchases"].Enabled = true;
            }
        }

        internal void LoadSettings()
        {
            dgvSales.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

    }
}
