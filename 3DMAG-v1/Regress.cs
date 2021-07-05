using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DMAG_v1
{
    class Regress
    {
        /* Variables */
        double[] X;
        double[] Y;

        public double A0 { get; private set; }
        public double A1 { get; private set; }
        public double A2 { get; private set; }
        public double A3 { get; private set; }
        public double R2 { get; private set; }
        public double Err { get; private set; }
        /**/

        public Regress(double[] x, double [] y)
        {
            X = x;
            Y = y;
        }

        public void setData(double[] x, double[] y)
        {
            X = x;
            Y = y;
        }

        public void linearRegression()
        {
            if (X.Length > 1 && Y.Length > 1 && X.Length == Y.Length)
            {
                // finf summ X*Y and sum X^2
                double sumXY = 0;
                double sumXsqr = 0;

                for (int i = 0; i < X.Length; i++)
                {
                    sumXY += X[i] * Y[i];
                    sumXsqr += Math.Pow(X[i], 2);
                }

                // calculate slope and intercept
                A1 = (X.Length * sumXY - X.Sum() * Y.Sum()) / (X.Length * sumXsqr - Math.Pow(X.Sum(), 2));
                A0 = (Y.Sum() - A1 * X.Sum()) / X.Length;

                // calculate determination and error
                calculateDetermination();
            }
            else
            {
                MessageBox.Show("Input arrays are wrong\nArrays must consist of more than one element\nArrays sizes must be equal");
            }
        }

        public void polynomRegression()
        {
            if(X.Length > 3 && Y.Length > 3 && X.Length == Y.Length)
            {
                // working arrays
                double[,] workArr = new double[4, 4];
                double[] workColumn = new double[4];

                // calculate summs
                double summX = 0;
                double summY = 0;
                double summX2 = 0;
                double summX3 = 0;
                double summX4 = 0;
                double summX5 = 0;
                double summX6 = 0;
                double summXY = 0;
                double summX2Y = 0;
                double summX3Y = 0;

                for(int i = 0; i < X.Length; i++)
                {
                    summX = summX + X[i];
                    summY = summY + Y[i];
                    summX2 = summX2 + Math.Pow(X[i], 2);
                    summX3 = summX3 + Math.Pow(X[i], 3);
                    summX4 = summX4 + Math.Pow(X[i], 4);
                    summX5 = summX5 + Math.Pow(X[i], 5);
                    summX6 = summX6 + Math.Pow(X[i], 6);
                    summXY = summXY + X[i] * Y[i];
                    summX2Y = summX2Y + Math.Pow(X[i], 2) * Y[i];
                    summX3Y = summX3Y + Math.Pow(X[i], 3) * Y[i];
                }

                // create working arrays
                workArr[0, 0] = summX3; workArr[0, 1] = summX2; workArr[0, 2] = summX;  workArr[0, 3] = X.Length;
                workArr[1, 0] = summX4; workArr[1, 1] = summX3; workArr[1, 2] = summX2; workArr[1, 3] = summX;
                workArr[2, 0] = summX5; workArr[2, 1] = summX4; workArr[2, 2] = summX3; workArr[2, 3] = summX2;
                workArr[3, 0] = summX6; workArr[3, 1] = summX5; workArr[3, 2] = summX4; workArr[3, 3] = summX3;

                workColumn[0] = summY;
                workColumn[1] = summXY;
                workColumn[2] = summX2Y;
                workColumn[3] = summX3Y;

                // calculate coefficients
                double delta = calculateDeterminant(workArr);

                A0 = calculateDeterminant(replaceColumn(workArr, workColumn, 3)) / delta;
                A1 = calculateDeterminant(replaceColumn(workArr, workColumn, 2)) / delta;
                A2 = calculateDeterminant(replaceColumn(workArr, workColumn, 1)) / delta;
                A3 = calculateDeterminant(replaceColumn(workArr, workColumn, 0)) / delta;

                // calculate determination
                calculateDetermination();
            }
            else
            {
                MessageBox.Show("Input arrays are wrong\nArrays must consist of more than 3 element\nArrays sizes must be equal");
            }
        }

        double calculateDeterminant(double[,] arr)
        {
            return arr[0, 0] * (arr[1, 1] * arr[2, 2] * arr[3, 3] + arr[3, 1] * arr[1, 2] * arr[2, 3] + arr[2, 1] * arr[3, 2] * arr[1, 3] - arr[3, 1] * arr[2, 2] * arr[1, 3] - arr[2, 1] * arr[1, 2] * arr[3, 3] - arr[1, 1] * arr[3, 2] * arr[2, 3]) - 
                   arr[0, 1] * (arr[1, 0] * arr[2, 2] * arr[3, 3] + arr[2, 0] * arr[3, 2] * arr[1, 3] + arr[3, 0] * arr[1, 2] * arr[2, 3] - arr[3, 0] * arr[2, 2] * arr[1, 3] - arr[2, 0] * arr[1, 2] * arr[3, 3] - arr[1, 0] * arr[3, 2] * arr[2, 3]) +
                   arr[0, 2] * (arr[1, 0] * arr[2, 1] * arr[3, 3] + arr[2, 0] * arr[3, 1] * arr[1, 3] + arr[3, 0] * arr[1, 1] * arr[2, 3] - arr[3, 0] * arr[2, 1] * arr[1, 3] - arr[3, 1] * arr[2, 3] * arr[1, 0] - arr[3, 3] * arr[2, 0] * arr[1, 1]) -
                   arr[0, 3] * (arr[1, 0] * arr[2, 1] * arr[3, 2] + arr[3, 0] * arr[1, 1] * arr[2, 2] + arr[2, 0] * arr[3, 1] * arr[1, 2] - arr[3, 0] * arr[2, 1] * arr[1, 2] - arr[1, 0] * arr[3, 1] * arr[2, 2] - arr[2, 0] * arr[1, 1] * arr[3, 2]);
        }

        double[,] replaceColumn(double[,] arr, double[] column, int index)
        {
            double[,] result = new double[4, 4];
            Array.Copy(arr, result, 4 * 4);

            for (int i = 0; i < 4; i++)
            {
                result[i, index] = column[i];
            }

            return result;
        }

        void calculateDetermination()
        {
            double sumDeviate = 0;
            double sumNormalize = 0;
            double summDelta = 0;

            for (int i = 0; i < X.Length; i++)
            {
                sumDeviate += Math.Pow(((A0 + A1 * X[i] + A2 * Math.Pow(X[i], 2) + A3 * Math.Pow(X[i], 3)) - Y[i]), 2);
                sumNormalize += Math.Pow((Y[i] - Y.Average()), 2);
                if(Y[i] != 0)
                {
                    summDelta += Math.Abs((Y[i] - (A0 + A1 * X[i] + A2 * Math.Pow(X[i], 2) + A3 * Math.Pow(X[i], 3))) / Y[i]);
                } 
            }

            R2 = 1 - (sumDeviate / sumNormalize);
            Err = (summDelta / X.Length) * 100;
        }
    }
}
