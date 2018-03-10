using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("Sales")]
    [MapField("EmployeeID", "Employee.ID")]
    [MapField("LocalBillsRowID", "LocalBillsRow.ID")]
    public class SalesRow
    {
        private Employee _employee = new Employee();

        private LocalBillsRowEx _localBillsRow = new LocalBillsRowEx();

        private MyStore _myStore = new MyStore();

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public int CustomerNumber { get; set; }

        public int Count { get; set; }

        public Double Price { get; set; }

        public Double PriceWithDiscount { get; set; }

        public Double Discount { get; set; }

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public MyStore MyStore
        {
            get { return _myStore; }
            set { _myStore = value; }
        }

        public string MyStoreName => _myStore.Name;

        public LocalBillsRowEx LocalBillsRow
        {
            get { return _localBillsRow; }
            set { _localBillsRow = value; }
        }

        public string ProductName => _localBillsRow.ProductName;

        public string PackageName => _localBillsRow.PackageName;

        public string EmployeeName => _employee.FullName;

        [Nullable]
        public string ClientID { get; set; }

        public static Comparison<SalesRow> DateComparison = (p1, p2) => p1.DateAccepted.CompareTo(p2.DateAccepted);

        public static Comparison<SalesRow> CustomerNumberComparison = (p1, p2) => p1.CustomerNumber.CompareTo(p2.CustomerNumber);

        public static Comparison<SalesRow> ProductNameComparison = (p1, p2) => p1.ProductName.CompareTo(p2.ProductName);

        public static Comparison<SalesRow> EmployeeComparison = (p1, p2) => p1.EmployeeName.CompareTo(p2.EmployeeName);

        public static Comparison<SalesRow> ClientIDComparison = (p1, p2) => p1.ClientID.CompareTo(p2.ClientID);
    }
}