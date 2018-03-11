using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.UserControls
{
    public partial class ucPriceChangesHistory : UserControl
    {
        private int _rowCount;
        private List<PriceChangeRow> _liPriceChangeRows;

        public ucPriceChangesHistory()
        {
            InitializeComponent();
        }

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            using (DbManager dbSatelite = new DbManager(myStore.Name))
            {
                PriceChangesAccessor pca = PriceChangesAccessor.CreateInstance<PriceChangesAccessor>(dbSatelite);

                _liPriceChangeRows = pca.GetRows(startDate, endDate);
                _rowCount = _liPriceChangeRows.Count;

                double dSum = 0;
                foreach (PriceChangeRow row in _liPriceChangeRows)
                {
                    dSum += row.Difference;
                }

                DiffSum = dSum;


                this.InvokeInGUIThread(() =>
                    {
                        OnRowCountChanged(_liPriceChangeRows.Count);
                        priceChangeRowBindingSource.DataSource = _liPriceChangeRows;
                    });
            }

        }

        public int RowCount
        {
            get
            {
                return _rowCount;
            }
        }
        public double DiffSum { get; private set; }

        public class RowCountChangedEventArgs : EventArgs
        {
            public RowCountChangedEventArgs(int rowCount)
            {
                RowCount = rowCount;
            }

            public int RowCount { get; private set; }
        }

        public event EventHandler<RowCountChangedEventArgs> RowCountChanged;

        protected virtual void OnRowCountChanged(int rowCount)
        {
            RowCountChanged?.Invoke(this, new RowCountChangedEventArgs(rowCount));
        }

        private void ucPriceChangesHistory_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dgvPriceChanges.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void dgvPriceChanges_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            PriceChangeRow row = dgv.Rows[e.RowIndex].DataBoundItem as PriceChangeRow;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "OldPrice":
                    {
                        double oldPrice;
                        oldPrice = row.NewPrice - row.Difference / row.Count;

                        e.Value = oldPrice;

                    }
                    break;

                case "Difference":
                    {
                        if (row.Difference < 0)
                            e.CellStyle.BackColor = Color.Salmon;
                    }
                    break;
            }
        }

    }
}
