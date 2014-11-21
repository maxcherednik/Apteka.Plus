using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("MyStores")]
    public class MyStore
    {
        [PrimaryKey, NonUpdatable]
        public int ID { get; set; }

        public string Name { get; set; }

        [Nullable]
        public string IP { get; set; }

        [Nullable, MapIgnore]
        public int Port { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
