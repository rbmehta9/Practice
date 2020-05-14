using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class KGrammer
    {
        //public int KthGrammar(int N, int K)
        //{
        //    //The questions assumes N and K start from 1 but my code starts from 0;
        //    N = N - 1;
        //    K = K - 1;
        //    if (N == 0)
        //        return GetList(0)[0];
        //    var prevList = GetList(N - 1);
        //    return GetValue(K, prevList);

        //}

        //public int KthGrammar(int N, int K)
        //{
        //    //The questions assumes N and K start from 1 but my code starts from 0;
        //    N = N - 1;
        //    K = K - 1;
        //    if (N == 0)
        //        return GetList(0)[0];

        //    var numofElementinNMinus1thRow = (int)Math.Pow(2, N - 1);
        //    var n1 = (K < numofElementinNMinus1thRow) ? (int)Math.Ceiling(Math.Log(K, 2)) : (int)Math.Ceiling(Math.Log(K - numofElementinNMinus1thRow , 2));
        //    var prevList = GetList(n1);
        //    if (K < numofElementinNMinus1thRow)
        //        return GetValue(K, prevList);
        //    else
        //    {
        //        var val = GetValue(K - (int)numofElementinNMinus1thRow, prevList);
        //        return (val == 0) ? 1 : 0;

        //    }
        //}

        public int KthGrammar(int N, int K)
        {
            //The questions assumes N and K start from 1 but my code starts from 0;
            N = N - 1;
            K = K - 1;
            return KthGrammar1(N, K);

        }

        public int KthGrammar1(int N, int K)
        {
            if (N == 0 && K == 0)
                return 0;

            //The first half of bits in any rows is same as the previous row. The second half is the complement of the previous row
            var numberofElementInPreviousRow = (int)Math.Pow(2, N - 1);
            if (K < numberofElementInPreviousRow)
                return KthGrammar1(N - 1, K);
            else
            {
                return Opposite(KthGrammar1(N - 1, K - numberofElementInPreviousRow));
            }
        }

        public int Opposite(int val)
        {
            return (val == 0) ? 1 : 0;
        }

        public int GetValue(int col, List<int> prevList)
        {
            if (col < prevList.Count)
                return prevList[col];
            else if (prevList[col - prevList.Count] == 0)
                return 1;
            else
                return 0;
        }

        public List<int> GetList(int n)
        {
            if (n == 0)
                return new List<int>() { 0 };

            var prevList = GetList(n - 1);
            var newList = new List<int>();
            for (var i = 0; i < Math.Pow(2, n); i++)
            {
                newList.Add(GetValue(i, prevList));
            }

            return newList;
        }
    }
}
