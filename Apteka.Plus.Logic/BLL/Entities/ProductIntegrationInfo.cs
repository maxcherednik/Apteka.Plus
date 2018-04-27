using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [MapField("SupplierID", "Supplier.ID")]
    [MapField("FullProductInfoID", "ParentFullProductInfo.ID")]
    public class ProductIntegrationInfo
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public Supplier Supplier { get; set; } = new Supplier();

        public long SupplierProductID { get; set; }

        public FullProductInfo ParentFullProductInfo { get; set; } = new FullProductInfo();
    }
}
