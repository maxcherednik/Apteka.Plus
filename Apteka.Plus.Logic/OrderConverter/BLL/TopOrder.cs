using System;
using BLToolkit.Mapping; 

namespace OrderConverter.BLL
{
    public class TopOrder : IForeignOrderConverter
    {
        [MapField("CODTOVAR")]
        public long SupplierProductID { get; set; }

        [MapField("TOVARNAME")]
        public string SupplierProductName { get; set; }

        [MapField("KOLVO")]
        public int Count { get; set; }

        [MapField("CENASNDS")]
        public double SupplierPriceWithNDS { get; set; }

        [MapField("CENAPROIZ")]
        public double VendorPriceWithoutNDS { get; set; }

        [MapField("CENPRNDS")]
        public double VendorPriceWithNDS { get; set; }
        

        [MapField("SHTRIH")]
        public string EAN13 { get; set; }

        [MapField("NDS")]
        public int NDS { get; set; }

        [MapField("SERIA")]
        public string Series { get; set; }

        [MapField("SROK")]
        public DateTime? ExpirationDate { get; set; }

        [MapField("CENAREESTR")]
        public double PriceReestr { get; set; }

        [MapField("PROIZV")]
        public string Producer { get; set; }

        [MapField("STRANA")]
        public string Country { get; set; }

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
                SupplierProductName = SupplierProductName
            };

            return localOrder; 

        }

        #endregion
    }
}
