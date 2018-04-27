using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [MapField("ProductGroupID", "ProductGroup.ID")]
    [MapField("FullProductInfoID", "ParentFullProductInfo.ID")]
    public class ProductGroupInfo
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public ProductGroup ProductGroup { get; set; } = new ProductGroup();

        public FullProductInfo ParentFullProductInfo { get; set; } = new FullProductInfo();
    }
}