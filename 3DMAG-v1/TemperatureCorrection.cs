using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DMAG_v1
{
    class TemperatureCorrection
    {
        /*
         * Function calculate voltage corrected to 25 Celsiy degree
         * Uses linear aproximation
         */
        public static double linearCorrection(double V, double T, double K)
        {
            return V / (1 + K * (T - 25));
        }

        /*
         * Function calculate voltage corrected to 25 Celsiy degree
         * Uses 3-n polynom aproximation
         */
        public static double polynomCorrection(double V, double T, double K1, double K2, double K3)
        {
            return V / (1 + K1 * (T - 25) + K2 * (Math.Pow(T, 2) - Math.Pow(25, 2)) + K3 * (Math.Pow(T, 3) - Math.Pow(25, 3)));
        }
    }
}
