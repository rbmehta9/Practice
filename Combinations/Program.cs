using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var comb = new Combinations(5, 3);
            var val = comb.FindNCr();
            var pascalsTriangle = comb.GeneratePascalsTriangle(10);
            var i = 0;
            foreach(var row in pascalsTriangle)
            {
                Console.WriteLine($"Row {i}");
                var str = string.Empty;
                foreach(var value in row)
                {
                    str += $"{value},";
                    
                }
                Console.WriteLine(str);
                i++;
            }
        }
    }
}
