using Apteka.Plus.Common.Controls;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Properties;
using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalTransfersMain : Form
    {
        List<LocalBillsTransferRow> _liLocalBillsTransferRows;
        LocalBillsTransferInfoRow _LocalBillsTransferInfoRow;
        public frmLocalTransfersMain(LocalBillsTransferInfoRow LocalBillsTransferInfoRow)
        {
            InitializeComponent();

            _LocalBillsTransferInfoRow = LocalBillsTransferInfoRow;
            lblFrom.Text = _LocalBillsTransferInfoRow.SourceStore.Name;
            lblTo.Text = _LocalBillsTransferInfoRow.DestinationStore.Name;
            using (DbManager db = new DbManager(_LocalBillsTransferInfoRow.SourceStore.Name))
            {
                LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(db);
                _liLocalBillsTransferRows = lbta.GetUnprocessedRowsByDate(_LocalBillsTransferInfoRow.DateAccepted);
                localBillsTransferRowBindingSource.DataSource = _liLocalBillsTransferRows;
            }

            dgvLocalTransfersMain.CurrentRowChanged += new EventHandler<MyDataGridView.CurrentRowChangedEventArgs>(dgvLocalTransfersMain_CurrentRowChanged);

            dgvLocalTransfersMain.Select();

        }

        void dgvLocalTransfersMain_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            LocalBillsTransferRow LocalBillsTransferRow = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsTransferRow;

            //progressBar1.Style = ProgressBarStyle.Marquee;
            int DaysForAnalysis = Convert.ToInt16(Settings.Default.DaysForAnalysis);
            int DaysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int ProductSuppliesTopRows = Convert.ToInt16(Settings.Default.ProductSuppliesTopRows);
            ucProductSupplies1.GetInfo(LocalBillsTransferRow.LocalBillsRow.MainStoreRow.FullProductInfo, ProductSuppliesTopRows, DaysOfStockRotation);

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите отпусть накладную?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DbManager dbSource = new DbManager(_LocalBillsTransferInfoRow.SourceStore.Name);
                DbManager dbDestination = new DbManager(_LocalBillsTransferInfoRow.DestinationStore.Name);
                try
                {

                    dbDestination.BeginTransaction();
                    dbSource.BeginTransaction();
                    PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>(dbDestination);
                    Property pLocalBillNumber = pa.GetByName("LocalBillNumber");
                    long LocalBillNumber = long.Parse(pLocalBillNumber.Value);

                    LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbDestination);
                    LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSource);

                    foreach (LocalBillsTransferRow row in _liLocalBillsTransferRows)
                    {
                        row.LocalBillsRow.StartPrice = row.Price;
                        row.LocalBillsRow.CurrentPrice = row.Price;
                        row.LocalBillsRow.MyStore = _LocalBillsTransferInfoRow.SourceStore;
                        row.LocalBillsRow.StartAmount = row.Count;
                        row.LocalBillsRow.Amount = row.Count;
                        row.LocalBillsRow.LocalBillNumber = LocalBillNumber;
                        row.LocalBillsRow.DateAccepted = DateTime.Today.Date;
                        if (lba.Insert(row.LocalBillsRow) <= 0)
                            throw new Exception("Не удалось вставить запись в таблицу LocalBills");

                        if (lbta.MarkAsProcessed(row.ID) == 0)
                            throw new Exception("Не удалось обновить запись в таблице LocalBillsTransfers");

                    }

                    LocalBillNumber++;
                    pLocalBillNumber.Value = LocalBillNumber.ToString();
                    pa.Update(pLocalBillNumber);

                    dbDestination.CommitTransaction();
                    dbSource.CommitTransaction();
                    MessageBox.Show("Накладная успешно сохранена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    dbDestination.RollbackTransaction();
                    dbSource.RollbackTransaction();
                    throw;
                }

                this.Close();
                frmPrintBills frmPrintBills = new frmPrintBills();

                frmPrintBills.Show();
            }
        }

        private void dgvLocalTransfersMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                switch (cell.OwningColumn.Name)
                {

                    case "Price":
                        {
                            dgv.BeginEdit(true);

                        }
                        break;

                }
            }
        }

        private void dgvLocalTransfersMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "Price":
                    {
                        if (cell.IsInEditMode)
                        {
                            string newPrice = cell.EditedFormattedValue.ToString().Replace(",", ".");

                            if (double.TryParse(newPrice, out double LocalPrice))
                            {
                                if (LocalPrice < 0)
                                {
                                    MessageBox.Show("Цена не может быть отрицательной", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            }

        }

        private void dgvLocalTransfersMain_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {

                case "Price":
                    {

                        string newPrice = e.Value.ToString().Replace(",", ".");
                        double dNewPrice = double.Parse(newPrice);
                        e.Value = dNewPrice;
                        e.ParsingApplied = true;
                    }
                    break;
            }

        }

        private void frmLocalTransfersMain_Load(object sender, EventArgs e)
        {
            dgvLocalTransfersMain.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

    }
}
