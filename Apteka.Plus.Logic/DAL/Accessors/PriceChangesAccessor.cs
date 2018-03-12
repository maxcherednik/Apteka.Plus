using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class PriceChangesAccessor:DataAccessor<PriceChangeRow> 
    {
        public abstract List<PriceChangeRow> GetRowsByDate(DateTime Date);

        public abstract List<PriceChangeRow> GetRows(DateTime startDate, DateTime endDate);

        public abstract long Insert(PriceChangeRow priceChangeRow);

        public abstract long GetMaxRowID();

        public abstract List<PriceChangeRow> GetUnsyncedRows();
    }
}
