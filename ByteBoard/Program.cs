using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBoard
{

    public static class ClassA
    {
        public static List<string> Results = new List<string>();
        public static List<string> FlattenList(string str)
        {
            
            var tempResults = str.Split(',');
            foreach (var tempStr in tempResults)
            {
                if (!tempStr.Contains("["))
                    Results.Add(tempStr);
                else
                {
                    var subResults = FlattenList(tempStr);
                    Results.AddRange(subResults);
                }
            }

            return Results;
        }

        private static List<string> Split(string str)
        {
            var str1 = str.Substring(1, str.Length - 2);
            var tempResults = new List<string>();
            foreach(var ch in str1)
            {
                int res = 0;
                if (int.TryParse(ch.ToString(), out res))
                    tempResults.Add(ch.ToString());
                else if(!String.IsNullOrEmpty(ch.ToString()) && ch != ',' )
                {
                    var numberofOpenParens = 0;

                }
            }
            

            return null;
        }

        public static List<int> FlattenListIntoInt(string str)
        {
            var results = FlattenList(str);
            return results.Select(r => Convert.ToInt32(r)).ToList();
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = ClassA.FlattenList("[2,[[3,[4]], 5], 6]");
        }
    }
}
