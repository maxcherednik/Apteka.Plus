using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [MapField("ProductGroupID", "ProductGroup.ID")]
    [MapField("FullProductInfoID", "ParentFullProductInfo.ID")]
    public class ProductGroupInfo
    {
        private ProductGroup _ProductGroup = new ProductGroup();

        private FullProductInfo _FullProductInfo = new FullProductInfo();

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public ProductGroup ProductGroup
        {
            get { return _ProductGroup; }
            set { _ProductGroup = value; }
        }

        public FullProductInfo ParentFullProductInfo
        {
            get { return _FullProductInfo; }
            set { _FullProductInfo = value; }
        }
    }
}