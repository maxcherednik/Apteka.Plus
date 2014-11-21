using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class SuppliersAccessor : DataAccessor<Supplier>
    {
        //public abstract int Delete(long @LocalBillsRowID);


        private SqlQuery<Supplier> _query;
        public SqlQuery<Supplier> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<Supplier>(DbManager);
                return _query;
            }
        }
    }
    
}
