using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class ProductsAccessor:DataAccessor<Product>
    {
        //public abstract int Delete(long @LocalBillsRowID);


        private SqlQuery<Product> _query;
        public SqlQuery<Product> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<Product>(DbManager);
                return _query;
            }
        }
    }
    
}
