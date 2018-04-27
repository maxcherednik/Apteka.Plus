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
    public partial class ucSalesReturnHistory : UserControl
    {
        private List<SalesReturnHistoryRow> _liSalesReturnHistoryRows;

        public ucSalesReturnHistory()
        {
            InitializeComponent();
        }

        public bool IsInitialized { get; private set; }

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            using (var dbSatelite = new DbManager(myStore.Name))
            {
                var srha = DataAccessor.CreateInstance<SalesReturnHistoryAccessor>(dbSatelite);

                _liSalesReturnHistoryRows = srha.GetRows(startDate, endDate);
                RowCount = _liSalesReturnHistoryRows.Count;

                this.InvokeInGuiThread(() =>
                {
                    OnRowCountChanged(_liSalesReturnHistoryRows.Count);
                    salesReturnHistoryRowBindingSource.DataSource = _liSalesReturnHistoryRows;
                });
            }

            IsInitialized = true;
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
    }
}
