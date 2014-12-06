using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Satelite.Properties;
using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmForeignStoresObserver : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<LocalBillsRowEx> _liLocalBillRowsList;
        private MyStore _currentStore;
        private int _storeID;

        public frmForeignStoresObserver()
        {
            InitializeComponent();
            _storeID = int.Parse(Settings.Default.SateliteID);
            _currentStore = MyStoresCollection.AllStores.Find(store => _storeID == store.ID);
            var connectionString = Settings.Default.ConnectionStringForSecondStore;
            DbManager.AddConnectionString("Second", connectionString);
        }


        private void ApplyStyle()
        {
            Font f = new Font(this.Font.FontFamily, Convert.ToSingle(Settings.Default.FontSizeBase));
            this.Font = f;
            splitContainer2.SplitterDistance = (tbSearch.Top + tbSearch.Height + tbSearch.Top);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 1 && _liLocalBillRowsList != null)
            {
                PerformSearch(tbSearch.Text);
            }
        }

        private void PerformSearch(string searchString)
        {
            List<LocalBillsRowEx> liFiltered = _liLocalBillRowsList.FindAll(p => p.ProductName.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase));

            localBillsRowExBindingSource.DataSource = liFiltered;
            localBillsRowExBindingSource.MoveFirst();
        }

        private void dgvLocalBills_KeyDown(object sender, KeyEventArgs e)
        {
            log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

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
                        localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;

                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.Enter:
                    {
                        toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                        bgwForeignStoreOpener.RunWorkerAsync();

                        e.SuppressKeyPress = true;
                    }
                    break;
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                tbSearch.Text = "";
                e.SuppressKeyPress = true;

            }
        }

        private void dgvLocalBills_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar;
        }

        private void frmMainSalesWindow_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            dgvLocalBills.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void LoadLocalBillsByLetter(string letter)
        {
            using (DbManager db = new DbManager("Second"))
            {
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
                _liLocalBillRowsList = lba.GetRowsByStartLetter(letter);
            }

            this.InvokeInGUIThread(() =>
            {
                PerformSearch(tbSearch.Text);
                localBillsRowExBindingSource.ResetBindings(false);
            });
        }

        private void dgvLocalBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            LocalBillsRowEx row1 = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {

                case "DateSupply":
                    {
                        LocalBillsRowEx row = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

                        TimeSpan ts = DateTime.Now - row.MainStoreRow.DateSupply;

                        //TODO плохо так делать  :) 
                        if (ts.Days > 25)
                        {
                            e.Value = ts.Days.ToString();
                        }
                        else
                        {
                            e.Value = "";
                        }
                        e.FormattingApplied = true;

                    }
                    break;

                default:
                    break;
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            dgvLocalBills.Select();
        }

        private void bgwForeignStoreOpener_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void bgwForeignStoreOpener_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                LoadLocalBillsByLetter(tbSearch.Text[0].ToString());
                localBillsRowExBindingSource.MoveFirst();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка подключения к серверу баз данных. Возможно отсутствует интернет.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

    }
}
