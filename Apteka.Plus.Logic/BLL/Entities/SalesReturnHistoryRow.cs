using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{

    [TableName("SalesReturnHistory")]
    [MapField("EmployeeID", "Employee.ID")]
    [MapField("LocalBillsRowID", "LocalBillsRow.ID")]
    public class SalesReturnHistoryRow
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public DateTime DateSold { get; set; }

        public int CustomerNumber { get; set; }

        public int Amount { get; set; }

        public Double Price { get; set; }

        public double PriceWithDiscount { get; set; }

        public double Discount { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public LocalBillsRowEx LocalBillsRow { get; set; } = new LocalBillsRowEx();

        public string ProductName => LocalBillsRow.ProductName;

        public string PackageName => LocalBillsRow.PackageName;

        public string EmployeeName => Employee.FullName;

        [Nullable]
        public string ClientID { get; set; }

        public string Comment { get; set; }
    }
}