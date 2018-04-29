using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Apteka.Plus.Logic.OrderConverter.BLL;
using BLToolkit.Data;
using BLToolkit.Mapping;
using BLToolkit.Reflection;
using BLToolkit.Reflection.MetadataProvider;

namespace Apteka.Plus.Logic.OrderConverter.DAL
{
    public class DbfFileReader
    {
        private readonly FileInfo _fiShortFileName;

        private readonly string _connectionStringWithoutFilename = @"Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=dBASE IV;User ID=Admin;Password=;Data Source=";


        public DbfFileReader(string fileName)
        {
            var fi = new FileInfo(fileName);

            _fiShortFileName = fi.CopyTo(fi.DirectoryName + "//temp" + fi.Extension, true);

            var connectionString = _connectionStringWithoutFilename + fi.DirectoryName;
            DbManager.AddConnectionString("OleDb", _fiShortFileName.Name, connectionString);
        }
        
        public DataTable GetOrderRowsAsIs()
        {
            using (var db = new DbManager("OleDb", _fiShortFileName.Name))
            {
                return db.SetCommand(@"select * from [" + _fiShortFileName.Name + "]").ExecuteDataTable();
            }
        }

        public IList<LocalOrder> GetLocalOrderRows(IDictionary<string, string> localToExternalFieldMapping)
        {
            using (var db = new DbManager("OleDb", _fiShortFileName.Name))
            {   
                db.MappingSchema = new MyMappingSchema(localToExternalFieldMapping);
                return db.SetCommand(@"select * from [" + _fiShortFileName.Name + "]").ExecuteList<LocalOrder>();
            }
        }

        private class MappingMetaDataProvider: MetadataProviderBase
        {
            private readonly IDictionary<string, string> _localToExternalFieldMapping;

            public MappingMetaDataProvider(IDictionary<string,string> localToExternalFieldMapping)
            {
                _localToExternalFieldMapping = localToExternalFieldMapping;
            }

            public override string GetFieldName(ObjectMapper mapper, MemberAccessor member, out bool isSet)
            {
                if(_localToExternalFieldMapping.TryGetValue(member.Name, out var externalFieldName) && !string.IsNullOrEmpty(externalFieldName))
                {
                    isSet = true;
                    return externalFieldName;
                }

                return base.GetFieldName(mapper, member, out isSet);
            }
        }

        private class MyMappingSchema : MappingSchema
        {
            private readonly IDictionary<string, string> _localToExternalFieldMapping;

            public MyMappingSchema(IDictionary<string,string> localToExternalFieldMapping)
            {
                _localToExternalFieldMapping = localToExternalFieldMapping;
            }

            protected override ObjectMapper CreateObjectMapper(Type type)
            {
                var objMapper = base.CreateObjectMapper(type);

                if(type == typeof(LocalOrder))
                {
                    objMapper.MetadataProvider = new MappingMetaDataProvider(_localToExternalFieldMapping);
                }

                return objMapper;
            }
        }
    }
}
