using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.UserControls
{
    public partial class ucPriceChangesHistory : UserControl
    {
        private List<PriceChangeRow> _liPriceChangeRows;

        public ucPriceChangesHistory()
        {
            InitializeComponent();
        }

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            using (var dbSatelite = new DbManager(myStore.Name))
            {
                var pca = DataAccessor.CreateInstance<PriceChangesAccessor>(dbSatelite);

                _liPriceChangeRows = pca.GetRows(startDate, endDate);
                RowCount = _liPriceChangeRows.Count;

                double dSum = 0;
                foreach (var row in _liPriceChangeRows)
                {
                    dSum += row.Difference;
                }

                DiffSum = dSum;


                this.InvokeInGuiThread(() =>
                    {
                        OnRowCountChanged(_liPriceChangeRows.Count);
                        priceChangeRowBindingSource.DataSource = _liPriceChangeRows;
                    });
            }

        }

        public int RowCount { get; private set; }

        public double DiffSum { get; private set; }

        public class RowCountChangedEventArgs : EventArgs
        {
            public RowCountChangedEventArgs(int rowCount)
            {
                RowCount = rowCount;
            }

            public int RowCount { get; }
        }

        public event EventHandler<RowCountChangedEventArgs> RowCountChanged;

        protected virtual void OnRowCountChanged(int rowCount)
        {
            RowCountChanged?.Invoke(this, new RowCountChangedEventArgs(rowCount));
        }

        private void ucPriceChangesHistory_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dgvPriceChanges.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void dgvPriceChanges_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (PriceChangeRow)dgv.Rows[e.RowIndex].DataBoundItem;

            if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "OldPrice")
            {
                var oldPrice = row.NewPrice - row.Difference / row.Count;

                e.Value = oldPrice;
            }
            else if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Difference")
            {
                if (row.Difference < 0)
                    e.CellStyle.BackColor = Color.Salmon;
            }
        }
    }
}
