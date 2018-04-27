using System.Collections.Generic;
using System.IO;
using BLToolkit.Data;

namespace Apteka.Plus.Logic.OrderConverter.DAL
{
    public class DbfFileReader
    {
        public DbfFileReader(string fileName)
        {
            var fi = new FileInfo(fileName);

            _fiShortFileName = fi.CopyTo(fi.DirectoryName + "//temp" + fi.Extension, true);

            var connectionString = _connectionStringWithoutFilename + fi.DirectoryName;
            DbManager.AddConnectionString("OleDb", _fiShortFileName.Name, connectionString);
        }

        private readonly FileInfo _fiShortFileName;

        private readonly string _connectionStringWithoutFilename = @"Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=dBASE IV;User ID=Admin;Password=;Data Source=";

        public IList<T> GetOrderRows<T>()
        {
            using (var db = new DbManager("OleDb", _fiShortFileName.Name))
            {
                return db.SetCommand(@"select * from [" + _fiShortFileName.Name + "]").ExecuteList<T>();
            }
        }
    }
}
