using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.OrderConverter.BLL
{
    public class ExternalOrderMappingRow
    {
        public int Id { get; set; }

        public int ExternalOrderSupplierId { get; set; }

        [MapIgnore]
        public string LocalNameUI { get; set; }

        public string LocalName { get; set; }

        public string ExternalName { get; set; }
    }
}
