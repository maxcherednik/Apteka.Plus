using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    public abstract class ClientsSummaryAccessor : DataAccessor<ClientSummaryRow>
    {
        [SprocName("GetClientsSummary")]
        public abstract List<ClientSummaryRow> GetClientsSummary();

    }
}

