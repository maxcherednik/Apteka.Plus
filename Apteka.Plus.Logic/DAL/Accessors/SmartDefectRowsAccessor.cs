using System;
using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class SmartDefectRowsAccessor : DataAccessor<SmartDefectRow>
    {
        [SprocName("GetDefectList")]
        public abstract List<SmartDefectRow> GetDefectList(DateTime @FromDate, DateTime @ToDate, int @DaysOfStockRotation, int @DaysOfMinAmount);

        [SprocName("SmartDefectRow_CheckAndUpdateDeliveredRows")]
        public abstract int CheckAndUpdateDeliveredRows();
        [SprocName("SmartDefectRow_FindNewDefectRows")]
        public abstract int FindNewDefectRows(DateTime @FromDate, DateTime @ToDate, int @DaysOfStockRotation, int @DaysOfMinAmount);

        [SprocName("DefectProccessedRows_UpdateManualAmountToOrderAndStatus")]
        public abstract int UpdateManualAmountToOrderAndStatus(SmartDefectRow row);

        [SprocName("DefectProccessedRows_UpdateReminderAndStatus")]
        public abstract void UpdateReminder(SmartDefectRow row);
        
    }
}
