using System.Collections.Generic;

namespace Apteka.Plus.CashRegister
{
    public interface ICashRegister
    {
        void PerformXReport();

        void PerformZReport();

        void RegisterGoods(IOperator cashOperator, IList<IGood> liGoods, double givenCash);
    }
}
