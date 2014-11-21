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
        #region Private Fields
        FullProductInfo _FullProductInfo = new FullProductInfo();
        LocalBillsRowEx _LocalBillsRow = new LocalBillsRowEx();

        #endregion

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public string SupplierName
        {
            get { return _LocalBillsRow.MainStoreRow.Supplier.Name; }

        }

        public FullProductInfo FullProductInfo
        {
            get { return _FullProductInfo; }
            set { _FullProductInfo = value; }
        }

        public string ProductName
        {
            get { return _FullProductInfo.ProductName; }

        }

        public string PackageName
        {
            get { return _FullProductInfo.PackageName; }
        }

        public Supplier Supplier
        {
            get
            {
                return _LocalBillsRow.MainStoreRow.Supplier;
            }

        }

        public LocalBillsRowEx LocalBillsRow
        {
            get { return _LocalBillsRow; }
            set { _LocalBillsRow = value; }
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
        [BLToolkit.Mapping.DefaultValue(0)]
        public SmartDefectRowStatusEnum Status { get; set; }

    }
}
