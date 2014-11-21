using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("DefectExceptions")]
    public class DefectExceptionRow
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }
        public long FullProductInfoID { get; set; }
        public long DefectListID { get; set; }
    }
}

