using System.Collections.Generic;
using System.IO;
using BLToolkit.Data;

namespace OrderConverter.DAL
{
    public class DBFFileReader
    {
        public DBFFileReader(string fileName)
        {
            _fi = new FileInfo(fileName);

            _fiShortFileName = _fi.CopyTo(_fi.DirectoryName + "//temp" + _fi.Extension, true);

            string _connectionString = _connectionStringWithoutFilename + _fi.DirectoryName;
            DbManager.AddConnectionString("OleDb", _fiShortFileName.Name, _connectionString);
        }

        private FileInfo _fi;
        private FileInfo _fiShortFileName;

        private string _connectionStringWithoutFilename = @"Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=dBASE IV;User ID=Admin;Password=;Data Source=";

        public IList<T> GetOrderRows<T>()
        {
            using (DbManager db = new DbManager("OleDb", _fiShortFileName.Name))
            {
                return db.SetCommand(@"select * from [" + _fiShortFileName.Name + "]").ExecuteList<T>();
            }
        }
    }
}
