using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class DataGridViewColumnSettingsAccessor : DataAccessor<DataGridViewColumnSettingsRow>
    {
        public abstract List<DataGridViewColumnSettingsRow> GetSettings(int employeeID, string gridName);

        protected abstract int DeleteSettings(int employeeID, string gridName);

        protected abstract int SaveSettings(DataGridViewColumnSettingsRow settingsRow);

        public void SaveSettings(List<DataGridViewColumnSettingsRow> liDataGridViewColumnSettingsRow)
        {
            if (liDataGridViewColumnSettingsRow.Count > 0)
            {
                DeleteSettings(liDataGridViewColumnSettingsRow[0].Employee.ID,
                               liDataGridViewColumnSettingsRow[0].GridName);

                foreach (var row in liDataGridViewColumnSettingsRow)
                {
                    SaveSettings(row);
                }
            }
        }

    }
}
