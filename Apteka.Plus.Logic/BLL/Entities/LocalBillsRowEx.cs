using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("Накладные")]
    [MapField("MainStoreRowID", "MainStoreRow.ID")]
    [MapField("MyStoreID", "MyStore.ID")]
    public class LocalBillsRowEx
    {
        [PrimaryKey, NonUpdatable]
        public int ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public long LocalBillNumber { get; set; }

        public double StartPrice { get; set; }

        public double CurrentPrice { get; set; }

        public int StartAmount { get; set; }

        public int Amount { get; set; }

        public string Country => MainStoreRow.FullProductInfo.CountryProducer;

        public string SupplierBillNumber => MainStoreRow.SupplierBillNumber;

        public string ProductName => MainStoreRow.FullProductInfo.ProductName;

        public string PackageName => MainStoreRow.FullProductInfo.PackageName;

        public double SupplierPrice => MainStoreRow.SupplierPrice;

        public string SupplierName => MainStoreRow.Supplier.Name;

        public DateTime DateSupply => MainStoreRow.DateSupply;

        public DateTime? ExpirationDate => MainStoreRow.ExpirationDate;

        public MyStore MyStore { get; set; } = new MyStore();

        public DateTime? DateDisposal { get; set; }

        [MapIgnore]
        public int? DaysDisposal
        {
            get
            {
                if (DateDisposal.HasValue)
                {
                    var ts = DateDisposal.Value - MainStoreRow.DateSupply;
                    return ts.Days;
                }
                return null;
            }
        }

        public MainStoreRow MainStoreRow { get; set; } = new MainStoreRow();

        public bool IsDelayed { get; set; }

        public bool IsPriceUpdated { get; set; }
    }
}
