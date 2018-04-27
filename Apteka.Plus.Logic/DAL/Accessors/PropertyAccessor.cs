using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class PropertyAccessor : DataAccessor<Property>
    {
        private SqlQuery<Property> _query;
        public SqlQuery<Property> Query => _query ?? (_query = new SqlQuery<Property>(DbManager));

        public abstract IList<Property> GetAllRows();

        public abstract Property GetByName(string @Name);

        public abstract long Update(Property property);
    }
}
