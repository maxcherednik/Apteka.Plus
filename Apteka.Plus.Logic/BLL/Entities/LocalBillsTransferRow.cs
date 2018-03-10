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
        private Employee _Employee = new Employee();

        private LocalBillsRowEx _LocalBillsRow = new LocalBillsRowEx();

        private MyStore _MyStore = new MyStore();

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        public bool IsSynced { get; set; }

        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }

        public LocalBillsRowEx LocalBillsRow
        {
            get { return _LocalBillsRow; }
            set { _LocalBillsRow = value; }
        }

        public MyStore MyStore
        {
            get { return _MyStore; }
            set { _MyStore = value; }
        }

        public string ProductName => _LocalBillsRow.ProductName;

        public string PackageName => _LocalBillsRow.PackageName;
    }
}
