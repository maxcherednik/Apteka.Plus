using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class DefectListCriteriaAccessor : DataAccessor<DefectListCriteria>
    {
        [SqlQuery("select * from DefectListCriteria where DefectListID=@defectListID")]
        public abstract List<DefectListCriteria> SelectByKey(long @defectListID);

        private SqlQuery<DefectListCriteria> _query;
        public SqlQuery<DefectListCriteria> Query => _query ?? (_query = new SqlQuery<DefectListCriteria>(DbManager));
    }
}
