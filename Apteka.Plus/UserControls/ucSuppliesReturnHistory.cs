using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.UserControls
{
    public partial class ucSuppliesReturnHistory : UserControl
    {
        private List<SuppliesReturnHistoryRow> _liSuppliesReturnHistoryRows = null;
        private int _rowCount;

        public ucSuppliesReturnHistory()
        {
            InitializeComponent();
        }

        public int RowCount
        {
            get { return _rowCount; }
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

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {

            using (DbManager dbSatelite = new DbManager(myStore.Name))
            {
                SuppliesReturnHistoryAccessor srha =
                    SuppliesReturnHistoryAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(dbSatelite);

                _liSuppliesReturnHistoryRows = srha.GetRows(startDate, endDate);

                _rowCount = _liSuppliesReturnHistoryRows.Count;

                this.InvokeInGUIThread(() =>
                {
                    OnRowCountChanged(_liSuppliesReturnHistoryRows.Count);
                    suppliesReturnHistoryRowBindingSource.DataSource = _liSuppliesReturnHistoryRows;
                });
            }
        }
    }
}
