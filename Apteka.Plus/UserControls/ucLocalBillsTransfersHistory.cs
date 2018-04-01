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
    public partial class ucLocalBillsTransfersHistory : UserControl
    {
        private List<LocalBillsTransferRow> _liLocalBillsTransferRows;

        public ucLocalBillsTransfersHistory()
        {
            InitializeComponent();
        }

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            using (var dbSatelite = new DbManager(myStore.Name))
            {
                var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);

                _liLocalBillsTransferRows = lbta.GetRows(startDate, endDate);
                RowCount = _liLocalBillsTransferRows.Count;

                this.InvokeInGuiThread(() =>
                {
                    OnRowCountChanged(_liLocalBillsTransferRows.Count);
                    localBillsTransferRowBindingSource.DataSource = _liLocalBillsTransferRows;
                });
            }

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
