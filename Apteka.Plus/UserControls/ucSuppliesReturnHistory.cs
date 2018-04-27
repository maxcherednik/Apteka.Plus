using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.UserControls
{
    public partial class ucSuppliesReturnHistory : UserControl
    {
        private List<SuppliesReturnHistoryRow> _liSuppliesReturnHistoryRows;

        public ucSuppliesReturnHistory()
        {
            InitializeComponent();
        }

        public int RowCount { get; private set; }

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

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            using (var dbSatelite = new DbManager(myStore.Name))
            {
                var srha = DataAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(dbSatelite);

                _liSuppliesReturnHistoryRows = srha.GetRows(startDate, endDate);

                RowCount = _liSuppliesReturnHistoryRows.Count;

                this.InvokeInGuiThread(() =>
                {
                    OnRowCountChanged(_liSuppliesReturnHistoryRows.Count);
                    suppliesReturnHistoryRowBindingSource.DataSource = _liSuppliesReturnHistoryRows;
                });
            }
        }
    }
}
