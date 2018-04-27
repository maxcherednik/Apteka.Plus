using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("LocalBillsTransfers")]
    [MapField("EmployeeID", "Employee.ID")]
    [MapField("LocalBillsRowID", "LocalBillsRow.ID")]
    [MapField("MyStoreID", "MyStore.ID")]
    public class LocalBillsTransferRow
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        public bool IsSynced { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public LocalBillsRowEx LocalBillsRow { get; set; } = new LocalBillsRowEx();

        public MyStore MyStore { get; set; } = new MyStore();

        public string ProductName => LocalBillsRow.ProductName;

        public string PackageName => LocalBillsRow.PackageName;
    }
}
