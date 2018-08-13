using HashTable3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    class Program
    {
        static void Main(string[] args)
        {
            var low = 0;
            var high = 7;
            var mid = (low + high) / 2;
            Process(mid++);
            var sb = new StringBuilder();
            var b = sb.ToString().Equals(string.Empty);
        }

        public static void Process(int t)
        {

        }

    }
}
