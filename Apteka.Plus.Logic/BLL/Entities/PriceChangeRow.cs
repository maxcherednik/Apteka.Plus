using System;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("PriceChanges")]
    public class PriceChangeRow
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public long LocalBillsRowID { get; set; }

        public int Count { get; set; }

        public double Difference { get; set; }

        public double NewPrice { get; set; }

        public bool IsSynced { get; set; }

        public LocalBillsRowEx LocalBillsRow { get; set; } = new LocalBillsRowEx();

        public string ProductName => LocalBillsRow.ProductName;

        public string PackageName => LocalBillsRow.PackageName;
    }
}
