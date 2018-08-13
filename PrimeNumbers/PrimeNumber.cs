using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    public class ObjectHolder
    {
        public int Number { get; set; }
        public bool isDeleted { get; set; }
    }
    public class PrimeNumber
    {
        public static bool CheckIfPrime(int n,ref int numberofIterations)
        {
            if (n <= 0)
                throw new ArgumentException("n must be greater than zero");
            if (n == 1)
                return false;
            var result = true;
            
            for (var i =2;i<=Math.Sqrt(n);i++)
            {
                numberofIterations++;
                if (n%i==0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        //Brute Force
        public static List<int> GetPrimeNumbers(int low, int high,ref int numberofIterations)
        {
            var result = new List<int>();
            for (var i = low; i<=high;i++)
            {
                var isPrime = PrimeNumber.CheckIfPrime(i,ref numberofIterations);
                if (isPrime)
                    result.Add(i);
            }

            return result;
        }

        public static List<int> GetPrimeNumbersBySieve(int low,int high, ref int numberofIterations)
        {
            var initArray = new List<ObjectHolder>();
            for (var i =low;i<=high;i++)
            {
                initArray.Add(new ObjectHolder() {Number = i,isDeleted = false });
                //numberofIterations++;
            }

            for(var i = 1;i<=Math.Sqrt(high);i++)
            {
                foreach(var obj in initArray)
                {
                    //if (!obj.isDeleted && (obj.Number == 1 || (i!=1 && obj.Number!=i && obj.Number % i == 0)))
                    //    obj.isDeleted = true;
                    if (!obj.isDeleted)
                    {
                        if(obj.Number==1)
                            obj.isDeleted = true;
                        else if (i != 1 && obj.Number != i && obj.Number % i == 0)
                        {
                            obj.isDeleted = true;
                            numberofIterations++;
                        }
                    }
                    
                }
            }

            var retArray = new List<int>();
            foreach(var obj in initArray )
            {
                if (!obj.isDeleted)
                    retArray.Add(obj.Number);
                //numberofIterations++;
            }

            return retArray;

        }
    }
}
