using System;
using BLToolkit.Mapping;
using OrderConverter.BLL;

namespace Apteka.Plus.Logic.OrderConverter.BLL
{
    public class PulseOrder : IForeignOrderConverter
    {
        [MapField("CODE")]
        public long SupplierProductID { get; set; }

        [MapField("TOVAR")]
        public string SupplierProductName { get; set; }

        [MapField("KOLVO")]
        public int Count { get; set; }

        [MapField("CENA_NDS")]
        public double SupplierPriceWithNDS { get; set; }

        [MapField("CENA_MAN")]
        public double VendorPriceWithoutNDS { get; set; }

        [MapField("CENA_M")]
        public double VendorPriceWithNDS { get; set; }

        [MapField("EAN")]
        public string EAN13 { get; set; }

        [MapField("NDS")]
        public int NDS { get; set; }


        [MapField("SERIA")]
        public string Series { get; set; }

        [MapField("GDATE")]
        public DateTime? ExpirationDate { get; set; }

        [MapField("CENA_REG")]
        public double PriceReestr { get; set; }


        [MapField("MANUF")]
        public string Producer { get; set; }

        [MapField("COUNTRY")]
        public string Country { get; set; }

        [MapField("GNLVS")]
        public bool IsLifeImportant { get; set; }
        
        #region IForeignOrderConverter Members

        public LocalOrder ConvertToLocalOrder()
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
