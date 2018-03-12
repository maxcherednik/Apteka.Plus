using System;
using System.Data;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmSalesStatistics : Form
    {
        private MyStore _mystoreSelected;
        private DataTable _resultRows;

        public frmSalesStatistics()
        {
            InitializeComponent();
        }

        private void frmSalesStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void frmSalesStatistics_Load(object sender, EventArgs e)
        {
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _mystoreSelected = (MyStore)cbMyStores.SelectedItem;

            using (var dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);

                _resultRows = sa.GetSalesStatistics(dbSatelite, dtpStartDate.Value.Date, dtpEndDate.Value.Date);

                _resultRows.Columns.Remove("FullProductInfoID");
                dgvSalesStatistics.DataSource = _resultRows;
                dgvSalesStatistics.Select();
                dgvSalesStatistics.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvSalesStatistics.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void dgvSalesStatistics_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar.ToString().ToUpper();
        }

        private void dgvSalesStatistics_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if (tbSearch.Text.Length != 0)
                {
                    tbSearch.Text = tbSearch.Text.Substring(0, tbSearch.Text.Length - 1);
                }

                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tbSearch.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 1)
            {
                var filtered = _resultRows.Clone();

                foreach (DataRow row in _resultRows.Rows)
                {
                    if (row["Название"].ToString().IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                        || row["Фасовка"].ToString().IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        filtered.ImportRow(row);
                    }
                }

                dgvSalesStatistics.DataSource = filtered;
            }
            else
            {
                dgvSalesStatistics.DataSource = _resultRows;
            }
        }
    }
}
