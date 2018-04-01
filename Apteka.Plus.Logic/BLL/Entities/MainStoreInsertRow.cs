using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.OrderConverter.BLL;

namespace Apteka.Plus.Logic.BLL.Entities
{
    public class MainStoreInsertRow
    {
        double _supplierPrice;

        public LocalOrder EOrderRow;

        public FullProductInfo FullProductInfo = new FullProductInfo();

        public ProductIntegrationInfo ProductIntegrationInfo;

        public int Amount { get; set; }

        public MainStoreRow MainStoreRow { get; set; }

        public double PrevLocalPrice { get; set; }

        public bool IsSomethingWrongWithLocalPrice => PrevLocalPrice != 0 && PrevLocalPrice != _localPrice;

        public bool IsLocalPriceGrows => PrevLocalPrice <= double.Parse(_localPrice.ToString("0.00"));

        public double VendorPriceWithoutNDS { get; set; }

        public double SupplierPrice
        {
            get => double.Parse(_supplierPrice.ToString("0.00"));
            set => _supplierPrice = value;
        }

        double _extra;

        public double Extra
        {
            get => double.Parse(_extra.ToString("0.00"));
            set => _extra = value;
        }

        double _localPrice;

        public double LocalPrice
        {
            get => double.Parse(_localPrice.ToString("0.00"));
            set => _localPrice = value;
        }

        public DateTime? ExpirationDate { get; set; }

        public string Series { get; set; }

        public string EAN13 { get; set; }

        public Dictionary<int, int> MyStoresAmount = new Dictionary<int, int>();

        public string ProductName => FullProductInfo.ProductName;

        public string PackageName => FullProductInfo.PackageName;
    }
}
