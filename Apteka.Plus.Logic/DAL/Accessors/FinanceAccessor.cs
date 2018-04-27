using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{

    public abstract class FinanceAccessor : DataAccessor<FinanceRow>
    {
        [SprocName("Finance_GetFinanceDaily")]
        public abstract List<FinanceRow> GetFinanceDaily(DateTime Date);

        [SprocName("Finance_GetFinanceMonthly")]
        public abstract List<FinanceRow> GetFinanceMonthly(DateTime Date);

        [SprocName("Finance_GetFinanceMonthlyPeriod")]
        public abstract List<FinanceRow> GetFinanceMonthlyPeriod(DateTime DateStart, DateTime DateEnd);

        public abstract List<FinanceRow> GetFinanceMonthly();
    }
}
