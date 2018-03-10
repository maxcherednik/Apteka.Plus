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
        public string FullName
        {
            get { return LastName + " " + FirstName + " " + MiddleName; }
        }
        public string Login;
        public string Password;

        public override string ToString()
        {
            return FullName;
        }

        #region IUserInfo Members

        [MapIgnore()]
        string IUserInfo.ID
        {
            get { return ID.ToString(); }
        }

        [MapIgnore()]
        string IUserInfo.Name
        {
            get { return Login; }
        }

        #endregion
    }
}
