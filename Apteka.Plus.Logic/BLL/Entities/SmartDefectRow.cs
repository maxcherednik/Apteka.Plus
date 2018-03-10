using System;
using Apteka.Plus.Logic.BLL.Enums;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("DefectProccessedRows")]
    [MapField("SupplierID", "Supplier.ID")]
    public class SmartDefectRow
    {
        private FullProductInfo _FullProductInfo = new FullProductInfo();

        private LocalBillsRowEx _LocalBillsRow = new LocalBillsRowEx();

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public string SupplierName => _LocalBillsRow.MainStoreRow.Supplier.Name;

        public FullProductInfo FullProductInfo
        {
            get { return _FullProductInfo; }
            set { _FullProductInfo = value; }
        }

        public string ProductName => _FullProductInfo.ProductName;

        public string PackageName => _FullProductInfo.PackageName;

        public Supplier Supplier => _LocalBillsRow.MainStoreRow.Supplier;

        public LocalBillsRowEx LocalBillsRow
        {
            get => _LocalBillsRow;
            set => _LocalBillsRow = value;
        }

        public int OrderedAmount;

        public int? RemindAt { get; set; }

        public int CurrentAmount { get; set; }

        public double DailyAverage { get; set; }

        public float AutoAmountToOrder { get; set; }

        public double LastPrice { get; set; }

        public int Amount { get; set; }

        public int StartAmount { get; set; }

        public DateTime DateSupply { get; set; }

        public DateTime DateAccepted { get; set; }

        public DateTime DateLastSale { get; set; }

        public int? ManualAmountToOrder { get; set; }

        [DefaultValue(0)]
        public SmartDefectRowStatusEnum Status { get; set; }
    }
}