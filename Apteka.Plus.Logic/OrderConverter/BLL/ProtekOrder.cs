using System;
using BLToolkit.Mapping; 

namespace OrderConverter.BLL
{
    public class ProtekOrder : IForeignOrderConverter
    {
        [MapField("KOD")]
        public long SupplierProductID { get; set; }

        [MapField("Name")]
        public string SupplierProductName { get; set; }

        [MapField("QUANT")]
        public int Count { get; set; }

        [MapField("PRICENAKEN")]
        public double SupplierPriceWithNDS { get; set; }

        [MapField("PriceMake")]
        public double VendorPriceWithoutNDS { get; set; }

        [MapField("PRICEMAKEN")]
        public double VendorPriceWithNDS { get; set; }

        [MapField("Barcode")]
        public string EAN13 { get; set; }

        [MapField("NDSPr")]
        public int NDS { get; set; }

        [MapField("Series")]
        public string Series { get; set; }

        [MapField("DateBest")]
        public DateTime? ExpirationDate { get; set; }

        [MapField("PriceReestr")]
        public double PriceReestr { get; set; }

        [MapField("PRODUCER")]
        public string Producer { get; set; }

        [MapField("COUNTRY")]
        public string Country { get; set; }

        [MapField("IsLife")]
        public bool IsLifeImportant { get; set; }

        #region IForeignOrderConverter Members

        LocalOrder IForeignOrderConverter.ConvertToLocalOrder()
        {
            LocalOrder localOrder = new LocalOrder
            {
                Count = Count,
                PriceReestr = PriceReestr,
                EAN13 = EAN13,
                NDS = NDS,
                VendorPriceWithoutNDS = VendorPriceWithoutNDS,
                VendorPriceWithNDS = VendorPriceWithNDS,
                SupplierPriceWithNDS = SupplierPriceWithNDS,
                Producer = Producer,
                Country = Country,
                Series = Series,
                ExpirationDate = ExpirationDate,
                SupplierProductID = SupplierProductID,
                SupplierProductName = SupplierProductName,
                IsLifeImportant = IsLifeImportant
            };

            return localOrder; 

        }

        #endregion
    }
}
