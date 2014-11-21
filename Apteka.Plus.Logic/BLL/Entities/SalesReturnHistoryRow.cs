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
        #region Private fields
        private Employee _employee = new Employee();
        private LocalBillsRowEx _localBillsRow = new LocalBillsRowEx();

       
        #endregion

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }
        public DateTime DateSold { get; set; }
        public int CustomerNumber { get; set; }

        public int Amount { get; set; }
        public Double Price { get; set; }
        public Double PriceWithDiscount { get; set; }
        public Double Discount { get; set; }

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
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

        public string Comment { get; set; }    
    }
}