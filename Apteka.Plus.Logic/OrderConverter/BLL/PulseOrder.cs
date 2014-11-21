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
            LocalOrder localOrder = new LocalOrder();
            localOrder.Count = Count;
            localOrder.PriceReestr = PriceReestr;
            localOrder.EAN13 = EAN13;
            localOrder.NDS = NDS;
            localOrder.VendorPriceWithoutNDS = VendorPriceWithoutNDS;
            localOrder.VendorPriceWithNDS = VendorPriceWithNDS;
            localOrder.SupplierPriceWithNDS = SupplierPriceWithNDS;
            localOrder.Producer = Producer;
            localOrder.Country = Country;
            localOrder.Series = Series;
            localOrder.ExpirationDate = ExpirationDate;
            localOrder.SupplierProductID = SupplierProductID;
            localOrder.SupplierProductName = SupplierProductName;
            localOrder.IsLifeImportant = IsLifeImportant;
            return localOrder; 
        }

        #endregion
    }
}
