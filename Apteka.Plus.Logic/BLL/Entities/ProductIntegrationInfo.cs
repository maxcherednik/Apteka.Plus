using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [MapField("SupplierID", "Supplier.ID")]
    [MapField("FullProductInfoID", "ParentFullProductInfo.ID")]
    public class ProductIntegrationInfo
    {
        private Supplier _Supplier = new Supplier();

        private FullProductInfo _FullProductInfo = new FullProductInfo();

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public Supplier Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        public long SupplierProductID { get; set; }

        public FullProductInfo ParentFullProductInfo
        {
            get { return _FullProductInfo; }
            set { _FullProductInfo = value; }
        }
    }
}
