using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class ClientAccessor : DataAccessor<Client>
    {
        private SqlQuery<Client> _query;
        public SqlQuery<Client> Query => _query ?? (_query = new SqlQuery<Client>(DbManager));
    }
}
