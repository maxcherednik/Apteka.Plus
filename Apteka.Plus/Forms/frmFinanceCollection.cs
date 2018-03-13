using System;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmFinanceCollection : Form
    {
        private MyStore _mystoreSelected;

        public frmFinanceCollection()
        {
            InitializeComponent();
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;

            dgvFinanceCollection.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void frmFinanceCollection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _mystoreSelected = (MyStore)cbMyStores.SelectedItem;

            using (var dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                var fca = DataAccessor.CreateInstance<FinanceCollectionAccessor>(dbSatelite);

                var liFinanceCollectionRows = fca.SelectByMonth(dtpDate.Value.Date);

                financeCollectionRowBindingSource.DataSource = liFinanceCollectionRows;
            }

            btnReport.Enabled = true;
        }

        private void dgvFinanceCollection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (FinanceCollectionRow)dgv.Rows[e.RowIndex].DataBoundItem;

            if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "AmountCollected")
            {
                if (row.AmountCollected == 0)
                {
                    e.Value = "";
                }
            }
            else if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Difference")
            {
                {
                    if (row.AmountCollected != 0)
                    {
                        var dif = row.AmountCollected - row.AmountComputer;
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
            }
        }

        private void dgvFinanceCollection_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dgv = (DataGridView)sender;
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "AmountCollected" || cell.OwningColumn.Name == "Comment")
                {
                    dgv.CurrentCell = cell;
                    dgv.BeginEdit(true);
                }
            }
        }

        private void dgvFinanceCollection_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            var row = (FinanceCollectionRow)dgv.Rows[e.RowIndex].DataBoundItem;

            switch (cell.OwningColumn.Name)
            {
                case "AmountCollected":
                    {
                        using (var dbSatelite = new DbManager(_mystoreSelected.Name))
                        {
                            var fca = DataAccessor.CreateInstance<FinanceCollectionAccessor>(dbSatelite);

                            var amount = double.Parse(cell.EditedFormattedValue.ToString());
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
                        using (var dbSatelite = new DbManager(_mystoreSelected.Name))
                        {
                            var fca = DataAccessor.CreateInstance<FinanceCollectionAccessor>(dbSatelite);

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
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "AmountCollected")
            {
                if (cell.IsInEditMode)
                {
                    if (double.TryParse(cell.EditedFormattedValue.ToString(), out var amount))
                    {
                        if (amount < 0)
                        {
                            MessageBox.Show(@"Вы не можете вести отрицательное число.", @"Внимание",
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.Finances.FinanceCollectionDetailed.rdlc");

            frmReportViewer.SetDataSource("FinanceCollectionRow", financeCollectionRowBindingSource);

            frmReportViewer.ShowDialog();
        }
    }
}
