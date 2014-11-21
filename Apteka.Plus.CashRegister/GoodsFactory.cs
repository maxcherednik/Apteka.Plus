using System;

namespace Apteka.Plus.CashRegister
{
    public static class GoodsFactory
    {
        public static IGood CreateGood()
        {
            return new Good();
        }

        private class Good:IGood
        {
            public string Name{get; set;}

            public float Amount { get; set; }

            public double Price { get; set; }

            public double Discount { get; set; }

            
        }
    }
}
