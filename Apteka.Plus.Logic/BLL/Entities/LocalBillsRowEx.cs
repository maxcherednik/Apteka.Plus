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
        private MyStore _myStore = new MyStore();

        private MainStoreRow _mainStoreRow = new MainStoreRow();

        [PrimaryKey, NonUpdatable]
        public int ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public long LocalBillNumber { get; set; }

        public double StartPrice { get; set; }

        public double CurrentPrice { get; set; }

        public int StartAmount { get; set; }

        public int Amount { get; set; }

        public string Country => _mainStoreRow.FullProductInfo.CountryProducer;

        public string SupplierBillNumber => _mainStoreRow.SupplierBillNumber;

        public string ProductName => _mainStoreRow.FullProductInfo.ProductName;

        public string PackageName => _mainStoreRow.FullProductInfo.PackageName;

        public double SupplierPrice => _mainStoreRow.SupplierPrice;

        public string SupplierName => _mainStoreRow.Supplier.Name;

        public DateTime DateSupply => _mainStoreRow.DateSupply;

        public DateTime? ExpirationDate => _mainStoreRow.ExpirationDate;

        public MyStore MyStore
        {
            get { return _myStore; }
            set { _myStore = value; }
        }

        public DateTime? DateDisposal { get; set; }

        [MapIgnore]
        public int? DaysDisposal
        {
            get
            {
                if (DateDisposal.HasValue)
                {
                    TimeSpan ts = DateDisposal.Value - _mainStoreRow.DateSupply;
                    return ts.Days;
                }
                return null;
            }
        }

        public MainStoreRow MainStoreRow
        {
            get { return _mainStoreRow; }
            set { _mainStoreRow = value; }
        }

        public bool IsDelayed { get; set; }

        public bool IsPriceUpdated { get; set; }
    }
}
