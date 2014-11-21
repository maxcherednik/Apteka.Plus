using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class SalesAccessor:DataAccessor<SalesRow>
    {
        public abstract int Insert(SalesRow salesRow);

        [SqlQuery(@"select *
                    FROM 
                        defect
                    where 
                        StatusID=0")]
        public abstract List<SalesRow> GetUnsyncRows();

        public abstract int MarkSyncedRows(long @id);

        private SqlQuery<SalesRow> _query;
        public SqlQuery<SalesRow> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<SalesRow>(DbManager);
                return _query;
            }
        }
    }

}

