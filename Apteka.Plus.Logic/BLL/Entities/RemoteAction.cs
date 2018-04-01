using Apteka.Plus.Logic.BLL.Enums;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("RemoteActions")]
    [MapField("EmployeeID", "Employee.ID")]
    public class RemoteAction
    {
        [PrimaryKey, NonUpdatable]
        public long ID;

        public RemoteActionEnum TypeOfAction;

        public double NewPrice;

        public int AmountToReturn;

        public long LocalBillsRowID;

        public long MainStoreRowID;

        public long SalesRowID;

        public bool IsSynced;

        public string Comment { get; set; }

        public SuppliesReturnReasonEnum Reason { get; set; }

        public Employee Employee { get; set; } = new Employee();
    }
}
