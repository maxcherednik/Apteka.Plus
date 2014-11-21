using System;
using BLToolkit.Mapping; 

namespace OrderConverter.BLL
{
    public class SIAOrder:IForeignOrderConverter
    {
        
        [MapField("CODE")]
        public long SupplierProductID { get; set; }

        [MapField("PRODUCT")]
        public string SupplierProductName { get; set; }

        [MapField("kolvo")]
        public int Count { get; set; }

        [MapField("price_opl")]
        public double SupplierPriceWithNDS { get; set; }

        [MapField("PRO_NNDS")]
        public double VendorPriceWithoutNDS { get; set; }

        [MapField("PRO")]
        public double VendorPriceWithNDS { get; set; }

        [MapField("EAN13")]
        public string EAN13 { get; set; }

        [MapField("NDS_PR")]
        public int NDS { get; set; }

        
        [MapField("SERIES")]
        public string Series { get; set; }

        [MapField("SROK_S")]
        public DateTime? ExpirationDate { get; set; }

        [MapField("PRICE_REES")]
        public double PriceReestr { get; set; }

        
        [MapField("PRODUCER")]
        public string Producer { get; set; }

        [MapField("Country")]
        public string Country { get; set; }

        [MapField("GV")]
        public bool IsLifeImportant { get; set; }
        

        #region IForeignOrderConverter Members

        LocalOrder IForeignOrderConverter.ConvertToLocalOrder()
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
            localOrder.Country =Country;
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
