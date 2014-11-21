using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class MainStoreRowsAccessor:DataAccessor<MainStoreRow>
    {
        [SprocName("MainStore_Insert")] 
        public abstract long Insert(MainStoreRow row);

        [SprocName("MainStore_GetRowByID")]
        public abstract MainStoreRow GetRowByID(long ID);

        [SqlQuery("Delete from MainStoreSupplies")]
        public abstract void DeleteAll();

        [SprocName("MainStore_ChangeAmount")] 
        public abstract int ChangeAmount(long id, int count);

        [SprocName("MainStore_GetRowsBySupplier")]
        public abstract List<SupplierSummary> GetRowsBySupplier(long SupplierID, DateTime startDate, DateTime endDate);
        

        //private SqlQuery<MainStoreRow> _query;
        //public SqlQuery<MainStoreRow> Query
        //{
        //    get
        //    {
        //        if (_query == null)
        //            _query = new SqlQuery<MainStoreRow>(DbManager);
        //        return _query;
        //    }
        //}
        [SprocName("MainStore_UpdateEan13")]
        public abstract int UpdateEan13(long FullProductInfoID, string ean13);
    }
}
