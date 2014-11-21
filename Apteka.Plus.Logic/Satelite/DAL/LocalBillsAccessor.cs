using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class LocalBillsAccessor : DataAccessor<LocalBillsRow>
    {
        public abstract int DeleteAll();

        public abstract long GetMaxRowID();


        private SqlQuery<LocalBillsRow> _query;
        public SqlQuery<LocalBillsRow> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<LocalBillsRow>(DbManager);
                return _query;
            }
        }
    }
    
}
