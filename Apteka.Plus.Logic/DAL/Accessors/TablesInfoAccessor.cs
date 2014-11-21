using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class TablesInfoAccessor : DataAccessor<TableInfo>
    {
        [SqlQuery("update @Name set isSynced='true' where id<=@MaxID) and isSynced='false'")]
        public abstract int MarkSyncedRows(TableInfo tableInfo);

        [SqlQuery("DBCC CHECKIDENT (@Name, RESEED, @MaxID)")]
        public abstract int InitTable(TableInfo tableInfo);

        [SqlQuery("DELETE FROM @Name")]
        public abstract int DeleteAllRows(TableInfo tableInfo);

        public void UpdateTables(DbManager db, List<TableInfo> liTablesInfo)
        {
            foreach (TableInfo tableInfo in liTablesInfo)
            {
                UpdateToID(tableInfo.Name, tableInfo.MaxID);
            }
        }

        [SqlQuery("Update {0} set isSynced='true' where id<@maxID and isSynced='false' ")]
        public abstract void UpdateToID([Format(0)]string tableName, long @maxID);

        public void InitTables(List<TableInfo> liTablesInfo)
        {
            foreach (TableInfo tableInfo in liTablesInfo)
            {
                DeleteAll(tableInfo.Name);
                SetInitialCounterValue(tableInfo.Name, tableInfo.MaxID);
            }
        }

        [SqlQuery("DBCC CHECKIDENT ({0}, RESEED, {1})")]
        public abstract void SetInitialCounterValue([Format(0)]string tableName, [Format(1)]long newID);

        [SqlQuery("Delete from {0}")]
        public abstract void DeleteAll([Format(0)]string tableName);

    }
}
