using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmFinanceCollection : Form
    {
        private MyStore _mystoreSelected;

        public frmFinanceCollection()
        {
            InitializeComponent();
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;

            dgvFinanceCollection.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void frmFinanceCollection_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _mystoreSelected = cbMyStores.SelectedItem as MyStore;

            using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
            {

                FinanceCollectionAccessor fca = FinanceCollectionAccessor.CreateInstance<FinanceCollectionAccessor>(dbSatelite);

                List<FinanceCollectionRow> liFinanceCollectionRows = fca.SelectByMonth(dtpDate.Value.Date);

                financeCollectionRowBindingSource.DataSource = liFinanceCollectionRows;
            }

            btnReport.Enabled = true;
        }

        private void dgvFinanceCollection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            FinanceCollectionRow row = dgv.Rows[e.RowIndex].DataBoundItem as FinanceCollectionRow;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "AmountCollected":
                    {
                        if (row.AmountCollected == 0)
                        {
                            e.Value = "";

                        }

                    }
                    break;

                case "Difference":
                    {
                        if (row.AmountCollected != 0)
                        {
                            double dif = row.AmountCollected - row.AmountComputer;
                            e.Value = dif;
                            if (dif < 0)
                            {
                                e.CellStyle.BackColor = Color.Salmon;
                            }
                        }
                        else
                        {
                            e.Value = "";
                        }

                    }
                    break;

                default:
                    break;
            }
        }

        private void dgvFinanceCollection_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "AmountCollected" || cell.OwningColumn.Name == "Comment")
                {
                    dgv.CurrentCell = cell;
                    dgv.BeginEdit(true);
                }
            }
        }

        private void dgvFinanceCollection_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            FinanceCollectionRow row = dgv.Rows[e.RowIndex].DataBoundItem as FinanceCollectionRow;

            switch (cell.OwningColumn.Name)
            {

                case "AmountCollected":
                    {
                        using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
                        {

                            FinanceCollectionAccessor fca =
                                FinanceCollectionAccessor.CreateInstance<FinanceCollectionAccessor>(dbSatelite);

                            double amount = double.Parse(cell.EditedFormattedValue.ToString());
                            row.AmountCollected = amount;
                            if (row.ID == 0)
                            {
                                row.ID = fca.Insert(row);
                            }
                            else
                            {
                                fca.Update(row);
                            }
                        }

                    }
                    break;

                case "Comment":
                    {
                        using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
                        {

                            FinanceCollectionAccessor fca =
                                FinanceCollectionAccessor.CreateInstance<FinanceCollectionAccessor>(dbSatelite);

                            row.Comment = e.Value.ToString();
                            if (row.ID == 0)
                            {
                                row.ID = fca.Insert(row);
                            }
                            else
                            {
                                fca.Update(row);
                            }
                        }

                    }
                    break;

            }
        }

        private void dgvFinanceCollection_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {

                case "AmountCollected":
                    {
                        if (cell.IsInEditMode)
                        {
                            if (double.TryParse(cell.EditedFormattedValue.ToString(), out double Amount))
                            {
                                if (Amount < 0)
                                {
                                    MessageBox.Show("Вы не можете вести отрицательное число.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.Finances.FinanceCollectionDetailed.rdlc");

            frmReportViewer.SetDataSource("FinanceCollectionRow", financeCollectionRowBindingSource);

            frmReportViewer.ShowDialog();
        }
    }
}
