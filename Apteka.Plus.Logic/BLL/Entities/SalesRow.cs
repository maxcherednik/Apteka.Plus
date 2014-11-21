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
        #region Private fields
        private Employee _employee = new Employee();
        private LocalBillsRowEx _localBillsRow = new LocalBillsRowEx();
        private MyStore _myStore = new MyStore();
       
        #endregion
        
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

        public string MyStoreName
        {
            get { return _myStore.Name; }
        }

        public LocalBillsRowEx LocalBillsRow
        {
            get { return _localBillsRow; }
            set { _localBillsRow = value; }
        }

        public string ProductName
        {
            get { return _localBillsRow.ProductName; }            
        }

        public string PackageName
        {
            get { return _localBillsRow.PackageName; }
        }

        public string EmployeeName
        {
            get { return _employee.FullName; }
        }

        [Nullable]
        public string ClientID { get; set; }

        public static Comparison<SalesRow> DateComparison = delegate(SalesRow p1, SalesRow p2)
        {
            return p1.DateAccepted.CompareTo(p2.DateAccepted);
        };

        public static Comparison<SalesRow> CustomerNumberComparison = delegate(SalesRow p1, SalesRow p2)
        {
            return p1.CustomerNumber.CompareTo(p2.CustomerNumber);
        };

        public static Comparison<SalesRow> ProductNameComparison = delegate(SalesRow p1, SalesRow p2)
        {
            return p1.ProductName.CompareTo(p2.ProductName);
        };

        public static Comparison<SalesRow> EmployeeComparison = delegate(SalesRow p1, SalesRow p2)
        {
            return p1.EmployeeName.CompareTo(p2.EmployeeName);
        };

        public static Comparison<SalesRow> ClientIDComparison = delegate(SalesRow p1, SalesRow p2)
        {
            return p1.ClientID.CompareTo(p2.ClientID);
        };
    }
}

