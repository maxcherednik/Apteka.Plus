using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class SalesReturnHistoryAccessor : DataAccessor<SalesReturnHistoryRow>
    {
        public abstract long Insert(SalesReturnHistoryRow row);

        public abstract List<SalesReturnHistoryRow> GetRows(DateTime startDate, DateTime endDate);
    }
}
