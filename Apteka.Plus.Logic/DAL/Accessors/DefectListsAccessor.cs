
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class DefectListsAccessor : DataAccessor<DefectList>
    {

        [SqlQuery("insert into defectLists values(@Name,@IsSmartList); SELECT Cast(SCOPE_IDENTITY() as int)")] 
        public abstract long Insert(DefectList obj);

        private SqlQuery<DefectList> _query;
        public SqlQuery<DefectList> Query => _query ?? (_query = new SqlQuery<DefectList>(DbManager));
    }
}
