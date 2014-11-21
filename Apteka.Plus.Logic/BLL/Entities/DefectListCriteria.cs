using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("DefectListCriteria")]
    public class DefectListCriteria
    {
        [PrimaryKey, NonUpdatable]
        public int ID { get; set; }
        public string FieldName { get; set; }

        public string SearchValue { get; set; }

        public long DefectListID { get; set; }
    }
}
