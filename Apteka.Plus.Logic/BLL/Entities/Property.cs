using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("Properties")] 
    public class Property
    {
        [PrimaryKey]
        public string Name;
        public string Value;
    }
}
