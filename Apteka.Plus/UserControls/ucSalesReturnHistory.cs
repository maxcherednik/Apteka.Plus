using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.UserControls
{
    public partial class ucSalesReturnHistory : UserControl
    {
        private List<SalesReturnHistoryRow> _liSalesReturnHistoryRows;
        private bool _isInitialized = false;
        private int _rowCount;

        public ucSalesReturnHistory()
        {
            InitializeComponent();
        }

        public bool IsInitialized
        {
            get { return _isInitialized; }
        }

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            using (DbManager dbSatelite = new DbManager(myStore.Name))
            {
                SalesReturnHistoryAccessor srha =
                    SalesReturnHistoryAccessor.CreateInstance<SalesReturnHistoryAccessor>(dbSatelite);

                _liSalesReturnHistoryRows = srha.GetRows(startDate, endDate);
                _rowCount = _liSalesReturnHistoryRows.Count;

                this.InvokeInGuiThread(() =>
                {
                    OnRowCountChanged(_liSalesReturnHistoryRows.Count);
                    salesReturnHistoryRowBindingSource.DataSource = _liSalesReturnHistoryRows;
                });
            }

            _isInitialized = true;

        }

        public int RowCount
        {
            get
            {
                return _rowCount;
            }
        }

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

    }
}
