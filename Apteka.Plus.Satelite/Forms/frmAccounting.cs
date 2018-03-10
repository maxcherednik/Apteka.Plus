using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apteka.Plus.Satelite.Properties;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.Data;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmAccounting : Form
    {
        private List<LocalBillsRowEx> _liLocalBillRowsList;
        private List<LocalBillsRowEx> _liLocalBillRowsListCounted = new List<LocalBillsRowEx>();
        public frmAccounting()
        {
            InitializeComponent();
        }

        private void frmAccounting_Load(object sender, EventArgs e)
        {
            ApplyStyle();

            dgvLocalBills.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            dgvLocalBillsToCount.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());

            LoadLocalBillsByLetter("А");
            LoadLocalBillsCountedByLetter("А");
        }

        private void ApplyStyle()
        {
            Font = new Font(Font.FontFamily, Convert.ToSingle(Settings.Default.FontSizeBase));
        }

        private void LoadLocalBillsByLetter(string letter)
        {
            LocalBillsAccountingAccessor lba = LocalBillsAccountingAccessor.CreateInstance<LocalBillsAccountingAccessor>();
            _liLocalBillRowsList = lba.GetRowsByStartLetter(letter);

            localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;
        }

        private void LoadLocalBillsCountedByLetter(string letter)
        {
            LocalBillsAccountingAccessor lba = LocalBillsAccountingAccessor.CreateInstance<LocalBillsAccountingAccessor>();
            _liLocalBillRowsListCounted = lba.GetRowsAccountedByStartLetter(letter);

            localBillsRowExBindingSource1.DataSource = _liLocalBillRowsListCounted;
        }

        private void dgvLocalBills_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = sender as DataGridView;

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
                case Keys.Enter:
                    {
                        if (dgv.CurrentRow != null)
                        {
                            dgv.CurrentCell = dgv.CurrentRow.Cells["Count"];
                            dgv.BeginEdit(true);
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;

                    }
                    break;
                case Keys.Escape:
                    {
                        tbSearch.Text = "";
                        localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;
                        localBillsRowExBindingSource1.DataSource = _liLocalBillRowsListCounted;
                        e.SuppressKeyPress = true;
                    }
                    break;
                case Keys.Tab:
                    {
                        dgvLocalBillsToCount.Select();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length == 1)
            {
                LoadLocalBillsByLetter(tbSearch.Text[0].ToString());
                localBillsRowExBindingSource.MoveFirst();

                LoadLocalBillsCountedByLetter(tbSearch.Text[0].ToString());
                localBillsRowExBindingSource1.MoveFirst();

            }
            else if (tbSearch.Text.Length > 1)
            {
                var liFiltered = _liLocalBillRowsList.FindAll(p => p.ProductName.StartsWith(tbSearch.Text, StringComparison.CurrentCultureIgnoreCase));

                localBillsRowExBindingSource.DataSource = liFiltered;
                localBillsRowExBindingSource.MoveFirst();

                var liFilteredCounted = _liLocalBillRowsListCounted.FindAll(p => p.ProductName.StartsWith(tbSearch.Text, StringComparison.CurrentCultureIgnoreCase));

                localBillsRowExBindingSource1.DataSource = liFilteredCounted;
                localBillsRowExBindingSource1.MoveFirst();
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            dgvLocalBills.Select();
        }

        private void dgvLocalBills_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar;
        }

        private void dgvLocalBills_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "Count":
                    {
                        var row = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

                        if (!int.TryParse(e.Value.ToString(), out int i))
                        {
                            MessageBox.Show("Вы ввели недопустимый символ");
                            e.Value = row.Amount;
                            e.ParsingApplied = true;
                            return;
                        }

                        LocalBillsAccountingAccessor lbaAccounting = LocalBillsAccountingAccessor.CreateInstance<LocalBillsAccountingAccessor>();
                        if (lbaAccounting.AddAccountedValue(row.ID, -i) > 0)
                        {
                            e.Value = row.Amount - i;
                            e.ParsingApplied = true;

                            var newRow = new LocalBillsRowEx
                            {
                                Amount = i,
                                CurrentPrice = row.CurrentPrice
                            };

                            newRow.MainStoreRow.FullProductInfo = new FullProductInfo
                            {
                                ProductName = row.ProductName,
                                PackageName = row.PackageName
                            };

                            localBillsRowExBindingSource1.List.Add(newRow);

                            localBillsRowExBindingSource1.ResetBindings(false);
                            localBillsRowExBindingSource1.MoveLast();
                            tbSearch.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Вы пытаетесь отпустить больше чем есть на самом деле");
                            e.Value = row.Amount;
                            e.ParsingApplied = true;
                        }
                    }
                    break;
            }
        }

        private void dgvLocalBillsToCount_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = sender as DataGridView;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        var row = dgv.CurrentRow.DataBoundItem as LocalBillsRowEx;
                        LocalBillsAccountingAccessor lbaAccounting = LocalBillsAccountingAccessor.CreateInstance<LocalBillsAccountingAccessor>();

                        lbaAccounting.AddAccountedValue(row.ID, row.Amount);
                        _liLocalBillRowsListCounted.Remove(row);
                        if (_liLocalBillRowsListCounted.Count == 0)
                        {
                            dgvLocalBills.Select();
                        }

                        localBillsRowExBindingSource1.ResetBindings(false);
                        dgvLocalBills.Refresh();

                        e.SuppressKeyPress = true;
                    }

                    break;

                case Keys.Tab:
                    {
                        dgvLocalBills.Select();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;
            }
        }

        private void flowLayoutPanel1_Layout(object sender, LayoutEventArgs e)
        {
            dgvLocalBills.Height = flowLayoutPanel1.DisplayRectangle.Height - tbSearch.Height - tbSearch.Margin.Vertical;
            dgvLocalBills.Width = flowLayoutPanel1.DisplayRectangle.Width - dgvLocalBills.Margin.Horizontal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new DbManager())
            {
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>();
                LocalBillsAccountingAccessor lbaAccounting = LocalBillsAccountingAccessor.CreateInstance<LocalBillsAccountingAccessor>();
                List<LocalBillsRowEx> liAccountedRows = lbaAccounting.GetRowsByStartLetter("");
                if (liAccountedRows.Count == 0)
                {
                    List<LocalBillsRowEx> _liLocalBillRowsList = lba.GetRowsByStartLetter("");
                    lbaAccounting.InsertList(_liLocalBillRowsList);
                    MessageBox.Show("Таблица инициализирована");
                }
                else
                {
                    MessageBox.Show("Таблица с учетными данными не пуста");
                }
            }
        }
    }
}
