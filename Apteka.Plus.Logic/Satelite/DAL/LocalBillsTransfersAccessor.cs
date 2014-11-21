using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class LocalBillsTransfersAccessor : DataAccessor<LocalBillsTransferRow>
    {
        //public abstract int Delete(long @LocalBillsRowID);

        [SqlQuery(@"select *
                    FROM 
                        defect
                    where 
                        StatusID=0")]
        public abstract List<LocalBillsTransferRow> GetUnsyncRows();

        public abstract int MarkSyncedRows(long @id);

        private SqlQuery<LocalBillsTransferRow> _query;
        public SqlQuery<LocalBillsTransferRow> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<LocalBillsTransferRow>(DbManager);
                return _query;
            }
        }
    }
    
}
