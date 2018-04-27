using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class DefectExceptionsAccessor : DataAccessor<DefectExceptionRow>
    {

        [SqlQuery("select * from DefectExceptions where DefectListID=@defectListID")]
        public abstract List<DefectExceptionRow> SelectByKey(long @defectListID);

        [SqlQuery("delete from DefectExceptions where FullProductInfoID= @ProductID")]
        public abstract void DeletebyProduct(long @ProductID);
        
        private SqlQuery<DefectExceptionRow> _query;
        public SqlQuery<DefectExceptionRow> Query => _query ?? (_query = new SqlQuery<DefectExceptionRow>(DbManager));
    }
}
