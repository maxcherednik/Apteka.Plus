using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class DefectAccessor : DataAccessor<DefectRow>
    {
        public abstract int Delete(long @LocalBillsRowID);
        
        [SqlQuery(@"select *
                    FROM 
                        defect
                    where 
                        StatusID=0")]
        public abstract List<DefectRow> GetUnsyncRows();

        public abstract int MarkSyncedRows(long @id);

        private SqlQuery<DefectRow> _query;
        public SqlQuery<DefectRow> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<DefectRow>(DbManager);
                return _query;
            }
        }
    }
    
}
