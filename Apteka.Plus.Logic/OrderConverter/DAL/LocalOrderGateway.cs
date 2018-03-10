using System;
using System.Collections.Generic;
using System.Text;
using BLToolkit.Data;
using OrderConverter.BLL;
using OrderConverter.DAL.Accessors;

namespace OrderConverter.DAL
{
    public class LocalOrderGateway
    {
        public LocalOrderGateway(string fileName)
        {
            _filename = fileName;
            string _connectionString = _connectionStringWithoutFilename + fileName;
            DbManager.AddConnectionString("OleDb", _filename , _connectionString);
        }

        private const string _connectionStringWithoutFilename = @"Provider=Microsoft.Jet.OLEDB.4.0;User Id=admin;Password=;Data Source=";
        private string _filename;
        
       
        public void AddOrderRows(List<LocalOrder> liLocalOrderRows)
        {
            using (DbManager db = new DbManager("OleDb",_filename))
            {
                foreach (LocalOrder LocalOrder in liLocalOrderRows)
                {
                    LocalOrderAccessor loa = LocalOrderAccessor.CreateInstance<LocalOrderAccessor>(db);
                    loa.Query.Insert(LocalOrder);
                }                
                
            }
        }
       
    }
}
