using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{   
    public abstract class LocalBillsAccountingAccessor: DataAccessor<LocalBillsRowEx>
    {
        [SprocName("LocalBillsAccounting_GetRowsByStartLetter")]
        public abstract List<LocalBillsRowEx> GetRowsByStartLetter(string @letter);

        [SprocName("LocalBillsAccounting_GetRowsAccountedByStartLetter")]
        public abstract List<LocalBillsRowEx> GetRowsAccountedByStartLetter(string @letter);

        [SprocName("LocalBillsAccounting_UpdateAccountedValue")]
        public abstract int AddAccountedValue(long @id, int @count);

        [SprocName("LocalBillsAccounting_Insert")]
        public abstract long Insert(LocalBillsRowEx row);

        public void InsertList(List<LocalBillsRowEx> lilocalBillsRows)
        {
            foreach (var localBillsRow in lilocalBillsRows)
            {
                Insert(localBillsRow);
            }
        }
    }
}
