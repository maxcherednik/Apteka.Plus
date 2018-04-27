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
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public string SupplierName => LocalBillsRow.MainStoreRow.Supplier.Name;

        public FullProductInfo FullProductInfo { get; set; } = new FullProductInfo();

        public string ProductName => FullProductInfo.ProductName;

        public string PackageName => FullProductInfo.PackageName;

        public Supplier Supplier => LocalBillsRow.MainStoreRow.Supplier;

        public LocalBillsRowEx LocalBillsRow { get; set; } = new LocalBillsRowEx();

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