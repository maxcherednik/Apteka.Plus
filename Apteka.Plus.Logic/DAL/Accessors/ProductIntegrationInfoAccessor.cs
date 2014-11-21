using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class ProductIntegrationInfoAccessor : DataAccessor<ProductIntegrationInfo>
    {

        public abstract List<ProductIntegrationInfo> SelectByFullProductInfoID(long FullProductInfoID);

        public abstract long Insert(ProductIntegrationInfo row);

        public abstract long DeleteByKey(long id);

        public abstract ProductIntegrationInfo Get(long SupplierProductID, long SupplierID);

    }
}
