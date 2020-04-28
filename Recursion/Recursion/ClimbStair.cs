using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class ClimbStair
    {
        public Dictionary<int, int> dictionary = new Dictionary<int, int>();
        public int ClimbStairs(int n)
        {
            var i = n;
            var j = 0;
            var sum = 0;
            while (i >= j)
            {
                sum += FindCombinations(i, j);
                i--;
                j++;
            }

            return sum;
        }

        public int ClimbStairs1(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        public int ClimbStairsRecursion(int n)
        {
            if (n == 0 || n == 1)
            {
                if (!dictionary.ContainsKey(n))
                    dictionary.Add(n, 1);
            }

            if (!dictionary.ContainsKey(n))
                dictionary.Add(n, ClimbStairsRecursion(n - 1) + ClimbStairsRecursion(n - 2));

            return dictionary[n];
        }

        private int FindCombinations(int i, int j)
        {
            var k = 1;
            var n = i;
            var prod = 1;
            while (k <= j)
            {
                prod = Convert.ToInt32((long)(prod * n) / k);
                n--;
                k++;
            }

            return prod;
        }
    }
}
