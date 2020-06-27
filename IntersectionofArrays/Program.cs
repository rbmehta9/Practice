using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionofArrays
{
    public static class Intersection
    {
        /// <summary>
        /// Assumption is the arrays are sorted
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int[] FindIntersection(int[] a, int[] b, int[] c)
        {
            var i = 0;
            var j = 0;
            var k = 0;
            var intersect = new List<int>();
            while (i<a.Length && j<b.Length && k<c.Length)
            {
                if (a[i] == b[j] && b[j] == c[k])
                {
                    intersect.Add(a[i]);
                    i++;
                    j++;
                    k++;
                    continue;
                }

                var max = FindMax(a[i], b[j], c[k]);
                if (a[i] != max)
                    i++;

                if (b[j] != max)
                    j++;

                if (c[k] != max)
                    k++;

            }

            return intersect.ToArray();
        }

        public static int FindMax(int a, int b, int c)
        {
            int max = a;
            if (b > max)
                max = b;
            if (c > max)
                max = c;

            return max;
        }
    }

    public static class Test
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var hasSet = new HashSet<int>();
            foreach(var val in A)
            {
                if (!hasSet.Contains(val))
                    hasSet.Add(val);
            }

            for(var i = 1; i<= 1000000; i++ )
            {
                if (!hasSet.Contains(i))
                    return i;
            }

            return 1000001;
        }

        public static String solution1(String S)
        {
            var dictionary = new Dictionary<char, int>();
            var vowels = "aeiou";
            foreach (var vowel in vowels)
                dictionary.Add(vowel, 0);

            var max = 0;
            foreach(var ch in S)
            {
                var lowerCh = Char.ToLower(ch);
                if (dictionary.ContainsKey(lowerCh))
                {
                    dictionary[lowerCh] = dictionary[lowerCh]+ 1;
                    if (max < dictionary[lowerCh])
                        max = dictionary[lowerCh];
                }
            }

            var outStr = string.Empty;
            foreach(var kvp in dictionary)
            {
                if (kvp.Value == max)
                {
                    outStr += $"{kvp.Key} appears {max} time";
                    if (max > 1)
                        outStr += "s";
                    outStr += "\n";
                }

                
            }

            return outStr.Substring(0, outStr.Length - 1);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var a = new int[7] {1, 3, 7, 8, 12, 14, 17};
            //var b = new int[7] { 2, 4, 6, 7, 12, 13, 14};
            //var c = new int[7] { 7, 12, 14, 16, 17, 18, 19 };

            //var a = new int[6] {1, 5, 10, 20, 40, 80};
            //var b = new int[5] {6, 7, 20, 80, 100};
            //var c = new int[8] {3, 4, 15, 20, 30, 70, 80, 120};
            //var intersection = Intersection.FindIntersection(a, b, c);

            //var str = Test.solution1("e should be the most common vowel in this sentence");
            var str = Test.solution1("SAMPLE");
            Console.ReadLine();
        }
    }
}
