using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmClientsSummary : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        List<ClientSummaryRow> _summaryRows = new List<ClientSummaryRow>();
        public frmClientsSummary()
        {
            InitializeComponent();
        }

        private void frmClientsSummary_Load(object sender, EventArgs e)
        {
            _summaryRows.Clear();

            foreach (MyStore myStore in MyStoresCollection.AllStores)
            {
                using (DbManager dbSatelite = new DbManager(myStore.Name))
                {

                    ClientsSummaryAccessor csa = ClientsSummaryAccessor.CreateInstance<ClientsSummaryAccessor>(dbSatelite);
                    List<ClientSummaryRow> summaryRowsTemp = csa.GetClientsSummary();

                    if (_summaryRows.Count == 0)
                    {
                        _summaryRows.AddRange(summaryRowsTemp);
                    }
                    else
                    {
                        foreach (ClientSummaryRow summaryRow in summaryRowsTemp)
                        {
                            ClientSummaryRow oldRow = _summaryRows.Find(p => summaryRow.ClientID == p.ClientID);

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

            ClientAccessor сlientAccessor = ClientAccessor.CreateInstance<ClientAccessor>();
            IList<Client> liClients = сlientAccessor.Query.SelectAll();

            foreach (Client client in liClients)
            {
                ClientSummaryRow oldRow = _summaryRows.Find(p => client.Id == p.ClientID);

                if (oldRow != null)
                {
                    oldRow.DiscountSize = client.Discount;

                }
            }

            tslSummary.Text = string.Format("Всего покупателей: {0}", _summaryRows.Count);
            tslPersonalDiscount.Text = string.Format("Персональная скидка: {0}", liClients.Count);
            clientSummaryRowBindingSource.DataSource = _summaryRows;
            SortBy(1, ClientSummaryRow.SumComparison, SortOrder.Descending);
        }

        private void SortBy(int columnIndex, Comparison<ClientSummaryRow> comparison, SortOrder SortOrder)
        {
            DataGridViewColumn oldColumn = dgvClientsSummary.Columns[columnIndex];

            _summaryRows.Sort(comparison);

            if (SortOrder == SortOrder.Descending)
            {
                _summaryRows.Reverse();
            }

            clientSummaryRowBindingSource.ResetBindings(false);
            oldColumn.HeaderCell.SortGlyphDirection = SortOrder;

        }

        private void dgvClientsSummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn oldColumn = dgvClientsSummary.Columns[e.ColumnIndex];

            Comparison<ClientSummaryRow> comparison = new Comparison<ClientSummaryRow>(ClientSummaryRow.ClientIDComparison);
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
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void dgvClientsSummary_KeyDown(object sender, KeyEventArgs e)
        {
            log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {

                case Keys.Enter:
                    {

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        ClientSummaryRow selectedClientSummaryRow = clientSummaryRowBindingSource.Current as ClientSummaryRow;
                        frmClientBuysDetailed frmClientBuysDetailed = new frmClientBuysDetailed(selectedClientSummaryRow);
                        frmClientBuysDetailed.ShowDialog(this);

                    }
                    break;

            }
        }

        private void tsbClientDiscountSettings_Click(object sender, EventArgs e)
        {
            frmClientsDiscountSettings frmClientsDiscountSettings = new frmClientsDiscountSettings();
            frmClientsDiscountSettings.ShowDialog(this);
        }

        private void dgvClientsSummary_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "DiscountSize":
                    {
                        if (dgv.CurrentRow != null)
                        {
                            dgv.CurrentCell = cell;
                            dgv.BeginEdit(true);
                        }
                    }
                    break;
            }
        }

        private void dgvClientsSummary_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "DiscountSize":
                    {
                        if (cell.IsInEditMode)
                        {
                            if (!float.TryParse(cell.EditedFormattedValue.ToString(), out float newValue) && !string.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
                            {
                                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа и пустые значения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void dgvClientsSummary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "DiscountSize":
                    {
                        ClientSummaryRow row = dgv.Rows[e.RowIndex].DataBoundItem as ClientSummaryRow;
                        ClientAccessor clientAccessor = ClientAccessor.CreateInstance<ClientAccessor>();
                        if (row.DiscountSize.HasValue)
                        {
                            Client client = new Client() { Id = row.ClientID, Discount = row.DiscountSize.Value };
                            Client clientFromDB = clientAccessor.Query.SelectByKey(client.Id);
                            if (clientFromDB != null)
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
                    break;

                default:
                    break;
            }
        }
    }
}
