using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class LocalBillsTransfersAccessor : DataAccessor<LocalBillsTransferRow>
    {
        public abstract int MarkAsProcessed(long id);

        public abstract List<LocalBillsTransferInfoRow> GetTransfersInfoList();

        public abstract bool CheckIfUnprocessedExist();

        public abstract List<LocalBillsTransferRow> GetRowsByDate(DateTime Date);

        public abstract List<LocalBillsTransferRow> GetRows(DateTime startDate, DateTime endDate);

        public abstract List<LocalBillsTransferRow> GetUnprocessedRowsByDate(DateTime Date);

        public abstract List<LocalBillsTransferRow> GetUnsyncedRows();

        public abstract int Insert(LocalBillsTransferRow localBillsTransferRow);

        public abstract long GetMaxRowID();
    }
}
