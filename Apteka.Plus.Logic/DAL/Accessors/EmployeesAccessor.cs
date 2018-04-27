
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{

    public abstract class EmployeesAccessor : DataAccessor<Employee>
    {

        public abstract Employee Auth(string @login, string @password);

        public abstract List<Employee> GetAllActiveEmployees();

        public abstract int Insert(Employee employee);

        [SqlQuery("Delete from Employees")]
        public abstract void DeleteAll();

        public void InsertList(List<Employee> liEmployees)
        {
            foreach (var employee in liEmployees)
            {
                Insert(employee);
            }
        }

        private SqlQuery<Employee> _query;
        public SqlQuery<Employee> Query => _query ?? (_query = new SqlQuery<Employee>(DbManager));
    }
}
