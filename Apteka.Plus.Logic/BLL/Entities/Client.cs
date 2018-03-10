using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    public class Client
    {
        [PrimaryKey]
        public string Id { get; set; }

        public float Discount { get; set; }
    }
}
