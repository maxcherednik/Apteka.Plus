
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class MyStoresAccessor : DataAccessor<MyStore>
    {
        public abstract long Insert(MyStore row);

        public abstract List<MyStore> SelectAll();

        private SqlQuery<MyStore> _query;
        public SqlQuery<MyStore> Query => _query ?? (_query = new SqlQuery<MyStore>(DbManager));
    }
}
