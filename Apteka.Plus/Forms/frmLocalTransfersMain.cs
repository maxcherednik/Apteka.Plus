using Apteka.Plus.Common.Controls;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Properties;
using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Common.Forms;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalTransfersMain : Form
    {
        private readonly List<LocalBillsTransferRow> _liLocalBillsTransferRows;
        private readonly LocalBillsTransferInfoRow _localBillsTransferInfoRow;

        public frmLocalTransfersMain(LocalBillsTransferInfoRow localBillsTransferInfoRow)
        {
            InitializeComponent();

            _localBillsTransferInfoRow = localBillsTransferInfoRow;
            lblFrom.Text = _localBillsTransferInfoRow.SourceStore.Name;
            lblTo.Text = _localBillsTransferInfoRow.DestinationStore.Name;
            using (var db = new DbManager(_localBillsTransferInfoRow.SourceStore.Name))
            {
                var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(db);
                _liLocalBillsTransferRows = lbta.GetUnprocessedRowsByDate(_localBillsTransferInfoRow.DateAccepted);
                localBillsTransferRowBindingSource.DataSource = _liLocalBillsTransferRows;
            }

            dgvLocalTransfersMain.CurrentRowChanged += dgvLocalTransfersMain_CurrentRowChanged;

            dgvLocalTransfersMain.Select();
        }

        private void dgvLocalTransfersMain_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var localBillsTransferRow = (LocalBillsTransferRow)dgv.Rows[e.RowIndex].DataBoundItem;

            int daysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int productSuppliesTopRows = Convert.ToInt16(Settings.Default.ProductSuppliesTopRows);
            ucProductSupplies1.GetInfo(localBillsTransferRow.LocalBillsRow.MainStoreRow.FullProductInfo, productSuppliesTopRows, daysOfStockRotation);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Вы уверены, что хотите отпусть накладную?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var dbSource = new DbManager(_localBillsTransferInfoRow.SourceStore.Name);
                var dbDestination = new DbManager(_localBillsTransferInfoRow.DestinationStore.Name);

                try
                {

                    dbDestination.BeginTransaction();
                    dbSource.BeginTransaction();
                    var pa = DataAccessor.CreateInstance<PropertyAccessor>(dbDestination);
                    var pLocalBillNumber = pa.GetByName("LocalBillNumber");
                    var localBillNumber = long.Parse(pLocalBillNumber.Value);

                    var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(dbDestination);
                    var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSource);

                    foreach (var row in _liLocalBillsTransferRows)
                    {
                        row.LocalBillsRow.StartPrice = row.Price;
                        row.LocalBillsRow.CurrentPrice = row.Price;
                        row.LocalBillsRow.MyStore = _localBillsTransferInfoRow.SourceStore;
                        row.LocalBillsRow.StartAmount = row.Count;
                        row.LocalBillsRow.Amount = row.Count;
                        row.LocalBillsRow.LocalBillNumber = localBillNumber;
                        row.LocalBillsRow.DateAccepted = DateTime.Today.Date;
                        if (lba.Insert(row.LocalBillsRow) <= 0)
                            throw new Exception("Не удалось вставить запись в таблицу LocalBills");

                        if (lbta.MarkAsProcessed(row.ID) == 0)
                            throw new Exception("Не удалось обновить запись в таблице LocalBillsTransfers");

                    }

                    localBillNumber++;
                    pLocalBillNumber.Value = localBillNumber.ToString();
                    pa.Update(pLocalBillNumber);

                    dbDestination.CommitTransaction();
                    dbSource.CommitTransaction();
                    MessageBox.Show(@"Накладная успешно сохранена.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    dbDestination.RollbackTransaction();
                    dbSource.RollbackTransaction();
                    throw;
                }

                Close();

                var frmPrintBills = new frmPrintBills();
                frmPrintBills.Show();
            }
        }

        private void dgvLocalTransfersMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dgv = (DataGridView)sender;
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.OwningColumn.Name == "Price")
                {
                    dgv.BeginEdit(true);
                }
            }
        }

        private void dgvLocalTransfersMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "Price")
            {
                if (cell.IsInEditMode)
                {
                    var newPrice = cell.EditedFormattedValue.ToString().Replace(",", ".");

                    if (double.TryParse(newPrice, out var localPrice))
                    {
                        if (localPrice < 0)
                        {
                            MessageBox.Show(@"Цена не может быть отрицательной", @"Внимание", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
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

        private void dgvLocalTransfersMain_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "Price")
            {
                var newPrice = e.Value.ToString().Replace(",", ".");
                var dNewPrice = double.Parse(newPrice);
                e.Value = dNewPrice;
                e.ParsingApplied = true;
            }
        }

        private void frmLocalTransfersMain_Load(object sender, EventArgs e)
        {
            dgvLocalTransfersMain.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }
    }
}
