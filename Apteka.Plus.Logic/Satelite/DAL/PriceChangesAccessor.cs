using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class PriceChangesAccessor : DataAccessor<PriceChangeRow>
    {
        //public abstract int Delete(long @LocalBillsRowID);

        [SqlQuery(@"select *
                    FROM 
                        defect
                    where 
                        StatusID=0")]
        public abstract List<PriceChangeRow> GetUnsyncRows();

        public abstract int MarkSyncedRows(long @id);

        private SqlQuery<PriceChangeRow> _query;
        public SqlQuery<PriceChangeRow> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<PriceChangeRow>(DbManager);
                return _query;
            }
        }

        
    }
    
}
