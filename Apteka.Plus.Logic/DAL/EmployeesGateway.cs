using System;
using System.Collections.Generic;
using System.Text;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.Data;

namespace Apteka.Plus.Logic.DAL
{
    public class EmployeesGateway
    {
        Apteka.Plus.Logic.BLL.Entities.MyStore _myStore;
        
        public EmployeesGateway(Apteka.Plus.Logic.BLL.Entities.MyStore myStore)
        {
            _myStore = myStore;          
        }

        public List<Apteka.Plus.Satelite.Logic.BLL.Entities.Employee> GetRowsForMyStore()
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {
                return db.SetCommand("select id_smena as id, " +
                                        " ФИО as LastName" +
                                        " from смена " +
                                        " where статус='true'" )
                            .ExecuteList<Apteka.Plus.Satelite.Logic.BLL.Entities.Employee>();
            }
        }

        public Employee Auth(string login, string password)
        {
            using (DbManager db = new DbManager(_myStore.Name))
            {
                return db.SetSpCommand("employees_auth",
                        db.Parameter("@login",login),
                        db.Parameter("@password", password)
                        )
                            .ExecuteObject<Employee>();
            }
        }
    }
}
