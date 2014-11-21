using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class PropertiesAccessor : DataAccessor<Property>
    {

        private SqlQuery<Property> _query;
        public SqlQuery<Property> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<Property>(DbManager);
                return _query;
            }
        }
    }
}
    