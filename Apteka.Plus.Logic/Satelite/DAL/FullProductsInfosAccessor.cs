
using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class FullProductsInfosAccessor : DataAccessor<FullProductInfo>
    {
        //public abstract int Delete(long @LocalBillsRowID);



        private SqlQuery<FullProductInfo> _query;
        public SqlQuery<FullProductInfo> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<FullProductInfo>(DbManager);
                return _query;
            }
        }
    }
    
}
