using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //var i = -2;
            //Console.WriteLine($"i=-2 {PrimeNumber.CheckIfPrime(-2)}");
            //i = 2;
            //result = PrimeNumber.CheckIfPrime(i);
            //i = 3;
            //result = PrimeNumber.CheckIfPrime(i);
            //i = 4;
            //result = PrimeNumber.CheckIfPrime(i);
            //i = 5;
            //result = PrimeNumber.CheckIfPrime(i);
            //i = 6;
            //result = PrimeNumber.CheckIfPrime(i);
            //i = 7;
            //result = PrimeNumber.CheckIfPrime(i);
            //i = 8;
            //result = PrimeNumber.CheckIfPrime(i);
            //i = 11;
            //result = PrimeNumber.CheckIfPrime(i);

            //var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 11 };
            //foreach(var i in nums)
            //{
            //    var result = PrimeNumber.CheckIfPrime(i);
            //    Console.WriteLine($"i={i} {result}");
            //}

            int numberofIterations = 0;
            var resultArr = PrimeNumbers.PrimeNumber.GetPrimeNumbers(1, 100,ref numberofIterations);
            var str = string.Empty;
            
            foreach(var i in resultArr)
            {
                str += i.ToString() + ",";
            }

            Console.WriteLine($"Brute Force: {str}");
            Console.WriteLine($"Number of Iterations = {numberofIterations}");
            numberofIterations = 0;
            resultArr = PrimeNumbers.PrimeNumber.GetPrimeNumbersBySieve(1, 100,ref numberofIterations);
            str = string.Empty;

            foreach (var i in resultArr)
            {
                str += i.ToString() + ",";
            }

            Console.WriteLine($"Sieve      : {str}");
            Console.WriteLine($"Number of Iterations = {numberofIterations}");
        }
    }
}
