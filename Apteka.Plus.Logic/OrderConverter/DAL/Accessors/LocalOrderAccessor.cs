using BLToolkit.DataAccess;
using OrderConverter.BLL;

namespace OrderConverter.DAL.Accessors
{
    public abstract class LocalOrderAccessor : DataAccessor<LocalOrder>
    {
        private SqlQuery<LocalOrder> _query;
        public SqlQuery<LocalOrder> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<LocalOrder>(DbManager);
                return _query;
            }
        }
    }
}
