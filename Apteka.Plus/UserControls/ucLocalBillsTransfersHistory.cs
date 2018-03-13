using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.UserControls
{
    public partial class ucLocalBillsTransfersHistory : UserControl
    {
        private List<LocalBillsTransferRow> _liLocalBillsTransferRows;

        private int _rowCount;

        public ucLocalBillsTransfersHistory()
        {
            InitializeComponent();
        }

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            using (DbManager dbSatelite = new DbManager(myStore.Name))
            {
                LocalBillsTransfersAccessor lbta =
                    LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);

                _liLocalBillsTransferRows = lbta.GetRows(startDate, endDate);
                _rowCount = _liLocalBillsTransferRows.Count;

                this.InvokeInGuiThread(() =>
                {
                    OnRowCountChanged(_liLocalBillsTransferRows.Count);
                    localBillsTransferRowBindingSource.DataSource = _liLocalBillsTransferRows;
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
