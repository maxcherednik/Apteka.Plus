using BLToolkit.DataAccess;
using ClientServerSharedTypes.BLL.Entities;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public abstract class TablesInfoAccessor:DataAccessor<TableInfo> 
    {
        [SqlQuery("update @Name set statusID=1 where id<=@MaxID)")]
        public abstract int MarkSyncedRows(TableInfo tableInfo);

        [SqlQuery("DBCC CHECKIDENT (@Name, RESEED, @MaxID)")]
        public abstract int InitTable(TableInfo tableInfo);

        [SqlQuery("DELETE FROM @Name")]
        public abstract int DeleteAllRows(TableInfo tableInfo);
    }
}
