using BLToolkit.DataAccess;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using System.Collections.Generic;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class EmployeesAccessor : DataAccessor<DefectRow>
    {
        [SqlQuery("DELETE FROM employees")]
        public abstract int DeleteAll();
        
        

        private SqlQuery<Employee> _query;
        public SqlQuery<Employee> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<Employee>(DbManager);
                return _query;
            }
        }

        internal void UpdateEmployees(List<Employee> liEmployees)
        {
            throw new System.NotImplementedException();
        }
    }
    
}
