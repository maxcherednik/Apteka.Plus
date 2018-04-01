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
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public int CustomerNumber { get; set; }

        public int Count { get; set; }

        public Double Price { get; set; }

        public double PriceWithDiscount { get; set; }

        public double Discount { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public MyStore MyStore { get; set; } = new MyStore();

        public string MyStoreName => MyStore.Name;

        public LocalBillsRowEx LocalBillsRow { get; set; } = new LocalBillsRowEx();

        public string ProductName => LocalBillsRow.ProductName;

        public string PackageName => LocalBillsRow.PackageName;

        public string EmployeeName => Employee.FullName;

        [Nullable]
        public string ClientID { get; set; }

        public static Comparison<SalesRow> DateComparison = (p1, p2) => p1.DateAccepted.CompareTo(p2.DateAccepted);

        public static Comparison<SalesRow> CustomerNumberComparison = (p1, p2) => p1.CustomerNumber.CompareTo(p2.CustomerNumber);

        public static Comparison<SalesRow> ProductNameComparison = (p1, p2) => p1.ProductName.CompareTo(p2.ProductName);

        public static Comparison<SalesRow> EmployeeComparison = (p1, p2) => p1.EmployeeName.CompareTo(p2.EmployeeName);

        public static Comparison<SalesRow> ClientIDComparison = (p1, p2) => p1.ClientID.CompareTo(p2.ClientID);
    }
}