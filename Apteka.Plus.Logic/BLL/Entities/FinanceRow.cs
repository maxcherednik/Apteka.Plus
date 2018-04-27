using System;

namespace Apteka.Plus.Logic.BLL.Entities
{
    public class FinanceRow
    {
        public DateTime Date { get; set; }

        public double Revenue { get; set; }

        public int CustomerCount { get; set; }

        public double NetProfit { get; set; }

        public double Discount { get; set; }

        public double Receipt { get; set; }

        public double Costs { get; set; }

        public double LocalTransferSum { get; set; }

        public double PriceChangesSum { get; set; }

        public double StockInTradeSum { get; set; }
    }
}
