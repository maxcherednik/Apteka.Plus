using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    
    public abstract class FullProductInfoAccessor: DataAccessor<FullProductInfo>
    {

        private SqlQuery<FullProductInfo> _query;
        public SqlQuery<FullProductInfo> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<FullProductInfo>(DbManager);
                return _query;
            }
        }

        [SprocName("FullProductInfo_GetAllActiveProductInfos")]
        public abstract List<FullProductInfo> GetAllActiveProductInfos();

        [SprocName("FullProductInfo_GetAllActiveProductInfosByLetter")]
        public abstract List<FullProductInfo> GetAllActiveProductInfosByLetter(string letter);

        [SprocName("FullProductInfo_GetAllActiveProductInfosDividesOnly")]
        public abstract List<FullProductInfo> GetAllActiveProductInfosDividesOnly();

        [SprocName("FullProductInfo_UpdateDivider")]
        public abstract void UpdateDivider(long @ID, int @Divider);

        public abstract long Insert(FullProductInfo row);

        [SprocName("FullProductInfo_MarkAsDeleted")]
        public abstract long MarkAsDeleted(FullProductInfo row);
        

        public abstract void DeleteAll();

        [SprocName("FullProductInfo_SelectByKey")]
        public abstract FullProductInfo SelectByKey(long ID);

    }
}
