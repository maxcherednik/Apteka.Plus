using System;

namespace Apteka.Plus.Logic.OrderConverter.BLL
{
    public class LocalOrder
    {
        public string SupplierProductName { get; set; }
        public long SupplierProductID { get; set; }
        public int Count { get; set; }
        public double SupplierPriceWithNDS { get; set; }
        public double VendorPriceWithNDS { get; set; }
        public double VendorPriceWithoutNDS { get; set; }
        public string EAN13 { get; set; }
        public int NDS { get; set; }
        public string Series { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public double PriceReestr { get; set; }
        public string Producer { get; set; }
        public string Country { get; set; }
        public bool IsLifeImportant { get; set; }
    }
}
