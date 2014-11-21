using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("DefectLists")]
    public class DefectList
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }
        public string Name { get; set; }

        public bool IsSmartList { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
