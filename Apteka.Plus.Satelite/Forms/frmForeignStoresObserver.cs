using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Satelite.Properties;
using BLToolkit.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmForeignStoresObserver : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<LocalBillsRowEx> _liLocalBillRowsList;

        public frmForeignStoresObserver()
        {
            InitializeComponent();
            var connectionString = Settings.Default.ConnectionStringForSecondStore;
            DbManager.AddConnectionString("Second", connectionString);
        }

        private void ApplyStyle()
        {
            Font = new Font(Font.FontFamily, Convert.ToSingle(Settings.Default.FontSizeBase));
            splitContainer2.SplitterDistance = tbSearch.Top + tbSearch.Height + tbSearch.Top;
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
            var liFiltered = _liLocalBillRowsList.FindAll(p => p.ProductName.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase));

            localBillsRowExBindingSource.DataSource = liFiltered;
            localBillsRowExBindingSource.MoveFirst();
        }

        private void dgvLocalBills_KeyDown(object sender, KeyEventArgs e)
        {
            Log.DebugFormat("Key down:{0}", e.KeyCode.ToString());

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
                localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;

                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bgwForeignStoreOpener.RunWorkerAsync();

                e.SuppressKeyPress = true;
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
            dgvLocalBills.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void LoadLocalBillsByLetter(string letter)
        {
            using (var db = new DbManager("Second"))
            {
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);
                _liLocalBillRowsList = lba.GetRowsByStartLetter(letter);
            }

            this.InvokeInGuiThread(() =>
            {
                PerformSearch(tbSearch.Text);
                localBillsRowExBindingSource.ResetBindings(false);
            });
        }

        private void dgvLocalBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;

            if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "DateSupply")
            {
                var row = (LocalBillsRowEx) dgv.Rows[e.RowIndex].DataBoundItem;

                var ts = DateTime.Now - row.MainStoreRow.DateSupply;

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
            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка подключения к серверу баз данных. Возможно отсутствует интернет. " + Environment.NewLine + @" " + ex.Message, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
