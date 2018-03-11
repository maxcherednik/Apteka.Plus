using Apteka.Helpers;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("Employees")]
    public class Employee : IUserInfo
    {
        [PrimaryKey, NonUpdatable]
        public int ID;
        public string LastName;
        public string FirstName;
        public string MiddleName;

        [MapIgnore()]
        public string FullName => LastName + " " + FirstName + " " + MiddleName;
        public string Login;
        public string Password;

        public override string ToString() => FullName;

        [MapIgnore()]
        string IUserInfo.ID => ID.ToString();

        [MapIgnore()]
        string IUserInfo.Name => Login;
    }
}
