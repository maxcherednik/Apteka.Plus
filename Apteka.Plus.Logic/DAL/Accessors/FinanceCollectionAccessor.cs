using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class FinanceCollectionAccessor : DataAccessor<FinanceCollectionRow>
    {
        public abstract int Insert(FinanceCollectionRow row);
        public abstract int Update(FinanceCollectionRow row);

        public abstract List<FinanceCollectionRow> SelectByMonth(DateTime date);

    }
}
