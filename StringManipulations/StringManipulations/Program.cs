using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulations
{
    class Program
    {
        static void Main(string[] args)
        {
            //var i = FindIndexOf("abacaabadcabacabaabb", "abacab");
            var i = FindIndexOfByBoyerMoore("aaaaaaaaaaaa", "baaaa");
        }


        static List<int> GetIndicesListofChar(string str, char x)
        {
            var lst = new List<int>();
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == x)
                    lst.Add(i);
            }

            return lst;

        }

        static int FindIndexOf(string str, string search)
        {
            var n = 0;
            if (search == string.Empty)
                return 0;
            for (var i = 0; i <= str.Length - search.Length; i++)
            {
                var j = 0;
                while (j < search.Length && str[i + j] == search[j])
                {
                    j++;
                    n++;
                }


                if (j == search.Length)
                {
                    return i;
                }
                    n++;
            }

            return -1;
        }

        static int FindIndexOfByBoyerMoore(string text, string pattern)
        {
            var iter = 0;
            var m = pattern.Length;
            var n = text.Length;
            var i = m - 1;
            var k = m - 1;
            var map = new Dictionary<char, int>();
            foreach (var ch in text)
            {
                //iter++;
                if (!map.ContainsKey(ch))
                    map.Add(ch, -1);
            }

            for (var j = 0; j < pattern.Length; j++)
            {
                //iter++;
                var ch = pattern[j];
                if (map.ContainsKey(ch))
                    map[ch] = j;
                else
                    map.Add(ch, j);
            }

            while(i<n)
            {
                if (text[i] == pattern[k])
                {
                    //This means search successful
                    if (k == 0)
                        return i;
                    i--;
                    k--;
                    iter++;
                }
                else
                {

                    //else k represents index of pattern and i+k represents index of text where the chars were unequal
                    var failedchar = text[i];
                    var lastindexoffailedChar = map[failedchar];
                    if (lastindexoffailedChar == -1)
                        i += m;
                    else if (lastindexoffailedChar < k)
                    {
                        i += m - (lastindexoffailedChar + 1);
                    }
                    else
                    {
                        i += m - k;
                    }

                    k = m - 1;
                }

            }


            return -1;
        }
    }
}
