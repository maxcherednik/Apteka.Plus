using System;
using System.Collections.Generic;
using System.Data;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    
    public abstract class LocalBillsAccessor: DataAccessor<LocalBillsRowEx>
    {
        [SprocName("GetLocalBillByNumber")]
        public abstract List<LocalBillsRowEx> GetLocalBillByNumber(long  @localBillNumber);

        [SprocName("GetProductSupplies")]
        public abstract List<LocalBillsRowEx> GetProductSupplies(long @ProductID,DateTime @fromDate);

        [SprocName("GetProductSuppliesAccuracy")]
        public abstract List<LocalBillsRowEx> GetProductSupplies(long @ProductID, int @TopRows, DateTime @fromDate);

        [SprocName("LocalBills_GetRecent")]
        public abstract DataTable GetRecentLocalBills(int @topRows);

        [SprocName("LocalBills_GetStockInTradeSumByDate")]
        public abstract double GetStockInTradeSumByDate(DateTime Date);

        [SprocName("LocalBills_GetRowsByStartLetter")]
        public abstract List<LocalBillsRowEx> GetRowsByStartLetter(string @letter);

        [SprocName("LocalBills_GetRowsWithChangedPrices")]
        public abstract List<LocalBillsRowEx> GetRowsWithChangedPrices();

        [SprocName("[LocalBills_ChangeAmount]")]
        public abstract int ChangeAmount(long id, int count);

        [SprocName("LocalBills_CheckDelayedBills")]
        public abstract int CheckDelayedBills();

        [SprocName("LocalBills_CheckForNewPrices")]
        public abstract int CheckForNewPrices();

        [SprocName("LocalBills_GetDelayedBills")]
        public abstract List<long> GetDelayedBills();

        [SprocName("LocalBills_MarkAsUndelayedBill")]
        public abstract int MarkAsUndelayedBill(long localBillNumber);

        [SprocName("LocalBills_GetUnsyncedRows")]
        public abstract List<LocalBillsRowEx> GetUnsyncedRows();

        [SprocName("LocalBills_GetRows")]
        public abstract List<LocalBillsRowEx> GetRows(DateTime startDate, DateTime endDate);

        [SprocName("LocalBills_GetRowsForInitialize")]
        public abstract List<LocalBillsRowEx> GetRowsForInitialize();

        [SprocName("LocalBills_MarkSyncedBeforeID")]
        public abstract int MarkSyncedBeforeID(long id);

        [SprocName("LocalBills_UpdatePrice")]
        public abstract void UpdatePrice(long id, double newPrice);

        [SprocName("LocalBills_GetRowByID")]
        public abstract LocalBillsRowEx GetRowByID(long id);

        
        [SprocName("LocalBills_GetMaxRowID")]
        public abstract long GetMaxRowID();

        [SprocName("LocalBills_Insert")]
        public abstract long Insert(LocalBillsRowEx row);

        public void InsertList(List<LocalBillsRowEx> lilocalBillsRows)
        {
            foreach (LocalBillsRowEx localBillsRow in lilocalBillsRows)
            {
                Insert(localBillsRow);
            }

        }

        public void ProcessRemoteActions(DbManager db, List<RemoteAction> liRemoteActions)
        {
            RemoteActionAccessor raa = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(db);
            long lastActionID = raa.GetMaxRowID();
            long newLastActionID = lastActionID;

            foreach (RemoteAction remoteAction in liRemoteActions)
            {
                if (remoteAction.ID <= lastActionID) continue;

                if (remoteAction.ID > newLastActionID)
                    newLastActionID = remoteAction.ID;

                switch (remoteAction.TypeOfAction)
                {
                    case RemoteActionEnum.SuppliesReturn:
                        {
                            LocalBillsRowEx localBillsRow = GetRowByID(remoteAction.LocalBillsRowID);

                            SuppliesReturnHistoryRow suppliesReturnHistoryRow = new SuppliesReturnHistoryRow();
                            suppliesReturnHistoryRow.Comment = remoteAction.Comment;
                            suppliesReturnHistoryRow.Reason = remoteAction.Reason;
                            suppliesReturnHistoryRow.Price = localBillsRow.CurrentPrice;
                            suppliesReturnHistoryRow.Employee = remoteAction.Employee;
                            suppliesReturnHistoryRow.LocalBillsRow = localBillsRow;
                            
                            
                            
                            if (remoteAction.AmountToReturn ==0) // вернуть все что осталось
                            {
                                ChangeAmount(remoteAction.LocalBillsRowID, -1*localBillsRow.Amount);
                                suppliesReturnHistoryRow.Amount = localBillsRow.Amount;
        
                            }
                            else // вернуть часть того что осталось
                            {
                                if (remoteAction.AmountToReturn >= localBillsRow.Amount)
                                {
                                    ChangeAmount(remoteAction.LocalBillsRowID, -1 * localBillsRow.Amount);
                                    suppliesReturnHistoryRow.Amount = localBillsRow.Amount;
                                }
                                else
                                {
                                    ChangeAmount(remoteAction.LocalBillsRowID, -1 * remoteAction.AmountToReturn);
                                    suppliesReturnHistoryRow.Amount = remoteAction.AmountToReturn;
                                }
                            }

                            SuppliesReturnHistoryAccessor srha =
                                SuppliesReturnHistoryAccessor.CreateInstance<SuppliesReturnHistoryAccessor>(db);

                            srha.Insert(suppliesReturnHistoryRow);
                            
                        }
                        break;
                    case RemoteActionEnum.PriceChange:
                    {
                        LocalBillsRowEx localBillsRow = GetRowByID(remoteAction.LocalBillsRowID);

                        if (localBillsRow != null)
                        {
                            PriceChangesAccessor pca = PriceChangesAccessor.CreateInstance<PriceChangesAccessor>(db);
                            PriceChangeRow priceChangeRow = new PriceChangeRow();
                            priceChangeRow.DateAccepted = DateTime.Now;
                            priceChangeRow.LocalBillsRowID = remoteAction.LocalBillsRowID;
                            priceChangeRow.Count = localBillsRow.Amount;
                            priceChangeRow.Difference = remoteAction.NewPrice*localBillsRow.Amount -
                                                        localBillsRow.CurrentPrice*localBillsRow.Amount;
                            priceChangeRow.NewPrice = remoteAction.NewPrice;

                            pca.Insert(priceChangeRow);
                            UpdatePrice(remoteAction.LocalBillsRowID, remoteAction.NewPrice);
                        }
                    }
                        break;
                    case    RemoteActionEnum.SalesReturn:
                        {
                            ChangeAmount(remoteAction.LocalBillsRowID, remoteAction.AmountToReturn);
                            SalesAccessor salesAccessor = SalesAccessor.CreateInstance<SalesAccessor>(db);
                            SalesRow salesRow =salesAccessor.GetRowByID(remoteAction.SalesRowID);
                            if (salesRow.Count==remoteAction.AmountToReturn)
                            {
                                salesAccessor.Query.DeleteByKey(remoteAction.SalesRowID);
                            }
                            else
                            {
                                salesAccessor.ChangeAmount(remoteAction.SalesRowID, -1 * remoteAction.AmountToReturn);
                            }
                            
                        }
                        break;
                }

            }

            raa.Update(newLastActionID);

        }

        [SqlQuery("Delete from LocalBills")]
        public abstract void DeleteAll();

        [SqlQuery("Delete from LocalBills where MainStoreRowID=@MainStoreRowID")]
        public abstract void DeleteByMainStoreID(long @MainStoreRowID);

        private SqlQuery<LocalBillsRowEx> _query;
        public SqlQuery<LocalBillsRowEx> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<LocalBillsRowEx>(DbManager);
                return _query;
            }
        }

        [SprocName("LocalBills_UpdatePriceChangedMark")]
        public abstract int UpdatePriceChangedMark(long id, bool flag);

        
    }
}
