using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("FinanceCollection")]
    [MapField("EmployeeID", "Employee.ID")]
    public class FinanceCollectionRow
    {
        private Employee _employee= new Employee();

        [PrimaryKey,NonUpdatable]
        public int ID { get; set; }

        public DateTime Date { get; set; }
        public double AmountCollected { get; set; }
        public double AmountComputer { get; set; }
        public string Comment { get; set; }

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public string EmployeeName
        {
            get { return _employee.FullName; }
            
        }

    }
}
