using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Power
    {
        //public double MyPow(double x, int n)
        //{
        //    if (n == 0)
        //        return 1;

        //    if (n > 0)
        //        return x * MyPow(x, n - 1);
        //    else
        //        return MyPow(x, n + 1) / x;

        //}

        //public double MyPow(double x, int n)
        //{
        //    if (n == 0)
        //        return 1;
        //    long N = n;
        //    if (N < 0)
        //    {
        //        x = 1 / x;
        //        N = -N;
        //    }

        //    double prod = 1;
        //    var i = n;
        //    while (i > 0)
        //    {
        //        if (i % 2 == 1)
        //            prod = prod * prod * x;
        //        else
        //        {
        //            prod = prod * prod;
        //        }
        //        i /= 2;
        //    }

        //    return prod;

        //}
        private double fastPow(double x, long n)
        {
            if (n == 0)
            {
                return 1.0;
            }
            double half = fastPow(x, n / 2);
            if (n % 2 == 0)
            {
                return half * half;
            }
            else
            {
                return half * half * x;
            }
        }
        public double MyPow(double x, int n)
        {
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }

            return fastPow(x, N);
        }
    }
}
