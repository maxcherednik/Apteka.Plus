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
        #region Private

        private MyStore _myStore = new MyStore();
        private MainStoreRow _mainStoreRow = new MainStoreRow();
        #endregion

        [PrimaryKey, NonUpdatable]
        public int ID { get; set; }

        public DateTime DateAccepted { get; set; }
        public long LocalBillNumber { get; set; }
        public double StartPrice { get; set; }
        public double CurrentPrice { get; set; }
        public int StartAmount { get; set; }
        public int Amount { get; set; }

        public string Country
        {
            get { return _mainStoreRow.FullProductInfo.CountryProducer; }
        }

        public string SupplierBillNumber
        {
            get { return _mainStoreRow.SupplierBillNumber; }
        }

        public string ProductName
        {
            get { return _mainStoreRow.FullProductInfo.ProductName; }
        }

        public string PackageName
        {
            get { return _mainStoreRow.FullProductInfo.PackageName; }
        }

        public double SupplierPrice
        {
            get { return _mainStoreRow.SupplierPrice; }
        }

        public string SupplierName
        {
            get { return _mainStoreRow.Supplier.Name; }
        }
        public DateTime DateSupply
        {
            get { return _mainStoreRow.DateSupply; }
        }

        public DateTime? ExpirationDate
        {
            get { return _mainStoreRow.ExpirationDate; }
        }

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
