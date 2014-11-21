using System;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("PriceChanges")]
    public class PriceChangeRow
    {
        private LocalBillsRowEx _LocalBillsRow = new LocalBillsRowEx();

        [PrimaryKey, NonUpdatable]
        public long ID { get; set;}
        public DateTime DateAccepted { get; set; }
        public long LocalBillsRowID { get; set; }
        public int Count { get; set; }
        public double Difference { get; set; }
        public double NewPrice { get; set; }
        public bool IsSynced { get; set; }

        public LocalBillsRowEx LocalBillsRow
        {
            get { return _LocalBillsRow; }
            set { _LocalBillsRow = value; }
        }

        public string ProductName
        {
            get { return _LocalBillsRow.ProductName; }
        }

        public string PackageName
        {
            get { return _LocalBillsRow.PackageName; }
        }

    }
}
