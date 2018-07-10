using System;

namespace Apteka.Helpers
{
    public static class MathHelper
    {
        public static double RoundDown(double value, double roundto)
        {
            // 105.5 down to nearest 1 = 105
            // 105.5 down to nearest 10 = 100
            // 105.5 down to nearest 7 = 105
            // 105.5 down to nearest 100 = 100
            // 105.5 down to nearest 0.2 = 105.4
            // 105.5 down to nearest 0.3 = 105.3

            //if no roundto then just pass original number back
            if (roundto == 0)
            {
                return value;
            }

            return Math.Floor(value / roundto) * roundto;
        }

        public static double RoundUp(double value, double roundto)
        {
            // 105.5 up to nearest 1 = 106
            // 105.5 up to nearest 10 = 110
            // 105.5 up to nearest 7 = 112
            // 105.5 up to nearest 100 = 200
            // 105.5 up to nearest 0.2 = 105.6
            // 105.5 up to nearest 0.3 = 105.6

            //if no roundto then just pass original number back
            if (roundto == 0)
            {
                return value;
            }

            return Math.Ceiling(value / roundto) * roundto;
        }
    }
}
