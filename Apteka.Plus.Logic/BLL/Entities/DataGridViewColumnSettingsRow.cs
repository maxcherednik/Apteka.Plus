using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("DataGridViewColumnSettings")]
    [MapField("EmployeeID", "Employee.ID")]
    public class DataGridViewColumnSettingsRow
    {
        public Employee Employee { get; set; }

        public string GridName { get; set; }

        public int ColumnIndex { get; set; }

        public int ColumnSize { get; set; }
    }
}
