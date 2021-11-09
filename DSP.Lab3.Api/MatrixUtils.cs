using System;
using System.Collections.Generic;
using System.Text;

namespace DSP.Lab3.Api
{
    public static class MatrixUtils
    {
        public static double[,] Transpose(double[,] matr)
        {
            int n = matr.GetUpperBound(0) + 1;
            int m = matr.GetUpperBound(1) + 1;
            double[,] result = new double[m, n];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    result[j, i] = matr[i, j];
                }
            }
            return result;
        }

        public static double[,] GetNeighbourhood(double[,] matrix, int x, int y, int size)
        {
            double[,] result = new double[size, size];
            result.Initialize();
            int delta = size / 2;
            for (int i = x - delta; i <= x + delta; i++)
            {
                for (int j = y - delta; j <= y + delta; j++)
                {
                    result[i - (x - delta), j - (y - delta)] = matrix[i, j];
                }
            }
            return result;
        }

        public static double MultiplyMatrix(double[,] first, double[,] second)
        {
            double sum = 0d;
            for (int i = 0; i < second.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < second.GetUpperBound(0) + 1; j++)
                {
                    sum += first[i, j] * second[i, j];
                }
            }
                
            return sum;
        }
    }
}
