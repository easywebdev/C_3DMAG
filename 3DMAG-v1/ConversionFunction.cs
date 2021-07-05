using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DMAG_v1
{
    class ConversionFunction
    {
        /*
         * Function convert voltag V intu other units
         * Uses linear regression method
         */
        public static double linearConversion(double V, double A0, double A1)
        {
            return A0 + A1 * V;
        }

        /*
         * Function convert voltag V intu other units
         * Uses 3-n polynom regression method
         */
        public static double polynomConversion(double V, double A0, double A1, double A2, double A3)
        {
            return A0 + A1 * V + A2 * Math.Pow(V, 2) + A3 * Math.Pow(V, 3);
        }
    }
}
