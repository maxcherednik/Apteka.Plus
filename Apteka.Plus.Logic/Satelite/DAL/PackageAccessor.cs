using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class PackageAccessor : DataAccessor<Package>
    {
        //public abstract int Delete(long @LocalBillsRowID);


        private SqlQuery<Package> _query;
        public SqlQuery<Package> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<Package>(DbManager);
                return _query;
            }
        }
    }
    
}
