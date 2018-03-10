using System;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("LocalBillsTransfers")]
    public class LocalBillsTransferInfoRow
    {
        public DateTime DateAccepted { get; set; }

        public MyStore SourceStore { get; set; }

        public MyStore DestinationStore { get; set; }
    }
}
