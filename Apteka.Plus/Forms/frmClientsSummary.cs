using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmClientsSummary : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly List<ClientSummaryRow> _summaryRows = new List<ClientSummaryRow>();

        public frmClientsSummary()
        {
            InitializeComponent();
        }

        private void frmClientsSummary_Load(object sender, EventArgs e)
        {
            _summaryRows.Clear();

            foreach (var myStore in MyStoresCollection.AllStores)
            {
                using (var dbSatelite = new DbManager(myStore.Name))
                {
                    var csa = DataAccessor.CreateInstance<ClientsSummaryAccessor>(dbSatelite);
                    var summaryRowsTemp = csa.GetClientsSummary();

                    if (_summaryRows.Count == 0)
                    {
                        _summaryRows.AddRange(summaryRowsTemp);
                    }
                    else
                    {
                        foreach (var summaryRow in summaryRowsTemp)
                        {
                            var oldRow = _summaryRows.Find(p => summaryRow.ClientID == p.ClientID);

                            if (oldRow != null)
                            {
                                oldRow.Sum += summaryRow.Sum;
                                oldRow.Discount += summaryRow.Discount;
                                oldRow.BuyCount += summaryRow.BuyCount;
                                oldRow.RowCount += summaryRow.RowCount;
                                if (oldRow.DateOfRegistration < summaryRow.DateOfRegistration)
                                    oldRow.DateOfRegistration = summaryRow.DateOfRegistration;

                            }
                            else
                            {
                                _summaryRows.Add(summaryRow);
                            }
                        }
                    }
                }
            }

            var сlientAccessor = DataAccessor.CreateInstance<ClientAccessor>();
            IList<Client> liClients = сlientAccessor.Query.SelectAll();

            foreach (var client in liClients)
            {
                var oldRow = _summaryRows.Find(p => client.Id == p.ClientID);

                if (oldRow != null)
                {
                    oldRow.DiscountSize = client.Discount;
                }
            }

            tslSummary.Text = $@"Всего покупателей: {_summaryRows.Count}";
            tslPersonalDiscount.Text = $@"Персональная скидка: {liClients.Count}";
            clientSummaryRowBindingSource.DataSource = _summaryRows;
            SortBy(1, ClientSummaryRow.SumComparison, SortOrder.Descending);
        }

        private void SortBy(int columnIndex, Comparison<ClientSummaryRow> comparison, SortOrder sortOrder)
        {
            var oldColumn = dgvClientsSummary.Columns[columnIndex];

            _summaryRows.Sort(comparison);

            if (sortOrder == SortOrder.Descending)
            {
                _summaryRows.Reverse();
            }

            clientSummaryRowBindingSource.ResetBindings(false);
            oldColumn.HeaderCell.SortGlyphDirection = sortOrder;
        }

        private void dgvClientsSummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var oldColumn = dgvClientsSummary.Columns[e.ColumnIndex];

            var comparison = ClientSummaryRow.ClientIDComparison;
            switch (e.ColumnIndex)
            {
                case 0:
                    comparison = ClientSummaryRow.ClientIDComparison;
                    break;
                case 1:
                    comparison = ClientSummaryRow.SumComparison;
                    break;
                case 2:
                    comparison = ClientSummaryRow.DiscountComparison;
                    break;
                case 3:
                    comparison = ClientSummaryRow.BuyCountComparison;
                    break;
                case 4:
                    comparison = ClientSummaryRow.RowCountComparison;
                    break;
                case 5:
                    comparison = ClientSummaryRow.DateOfRegistrationComparison;
                    break;
                case 6:
                    comparison = ClientSummaryRow.DateofLastBuyComparison;
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

        private void frmClientsSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void dgvClientsSummary_KeyDown(object sender, KeyEventArgs e)
        {
            Log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                var frmClientBuysDetailed =
                    new frmClientBuysDetailed((ClientSummaryRow)clientSummaryRowBindingSource.Current);
                frmClientBuysDetailed.ShowDialog(this);
            }
        }

        private void tsbClientDiscountSettings_Click(object sender, EventArgs e)
        {
            var frmClientsDiscountSettings = new frmClientsDiscountSettings();
            frmClientsDiscountSettings.ShowDialog(this);
        }

        private void dgvClientsSummary_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "DiscountSize")
            {
                if (dgv.CurrentRow != null)
                {
                    dgv.CurrentCell = cell;
                    dgv.BeginEdit(true);
                }
            }
        }

        private void dgvClientsSummary_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "DiscountSize")
            {
                if (cell.IsInEditMode)
                {
                    if (!float.TryParse(cell.EditedFormattedValue.ToString(), out var _) &&
                        !string.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
                    {
                        MessageBox.Show(
                            @"Вы ввели некорректное значение! Допускаются только числа и пустые значения.",
                            @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvClientsSummary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "DiscountSize")
            {
                var row = (ClientSummaryRow)dgv.Rows[e.RowIndex].DataBoundItem;
                var clientAccessor = DataAccessor.CreateInstance<ClientAccessor>();
                if (row.DiscountSize.HasValue)
                {
                    var client = new Client { Id = row.ClientID, Discount = row.DiscountSize.Value };
                    var clientFromDb = clientAccessor.Query.SelectByKey(client.Id);
                    if (clientFromDb != null)
                    {
                        clientAccessor.Query.Update(client);
                    }
                    else
                    {
                        clientAccessor.Query.Insert(client);
                    }
                }
                else
                {
                    clientAccessor.Query.DeleteByKey(row.ClientID);
                }
            }
        }
    }
}
