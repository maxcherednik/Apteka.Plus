using System;
using System.Data;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmSalesStatistics : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        MyStore _mystoreSelected;
        DataTable _ResultRows; 
        public frmSalesStatistics()
        {
            InitializeComponent();
        }

        private void frmSalesStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show(); 
        }

        private void frmSalesStatistics_Load(object sender, EventArgs e)
        {
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _mystoreSelected = cbMyStores.SelectedItem as MyStore;

            using (DbManager dbSatelite = new DbManager(_mystoreSelected.Name))
            {
                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);

                _ResultRows = sa.GetSalesStatistics(dbSatelite, dtpStartDate.Value.Date, dtpEndDate.Value.Date);

                _ResultRows.Columns.Remove("FullProductInfoID");
                dgvSalesStatistics.DataSource = _ResultRows;
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

                
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 1)
            {
                DataTable filtered = _ResultRows.Clone() ;
                
                
                foreach (DataRow row in _ResultRows.Rows)
                {
                    if (row["Название"].ToString().IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                        || row["Фасовка"].ToString().IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        filtered.ImportRow(row);
                        //filtered.Rows.Add(row);
                    }
                }

                dgvSalesStatistics.DataSource = filtered;

            }
            else
            {
                dgvSalesStatistics.DataSource = _ResultRows;

            }
        }
    }
}
