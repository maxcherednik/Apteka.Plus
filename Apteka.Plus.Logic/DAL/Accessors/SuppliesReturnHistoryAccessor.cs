using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class SuppliesReturnHistoryAccessor : DataAccessor<SuppliesReturnHistoryRow>
    {
        public abstract long Insert(SuppliesReturnHistoryRow row);

        public abstract List<SuppliesReturnHistoryRow> GetRows(DateTime startDate, DateTime endDate);

        public abstract List<SuppliesReturnHistoryRow> GetUnsyncedRows();

        public abstract long GetMaxRowID();
    }
}
