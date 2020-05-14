using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProblems
{
    public static class FindSubsets
    {
        public static void FindAllSubsets(int[] array)
        {
            var subset = new int?[array.Length];
            PrintSubsetsUtil(array, subset, 0);
        }

        private static void PrintSubsetsUtil(int[] array, int?[] subset, int i)
        {
            if (i == array.Length)
            {
                Console.WriteLine(PrintSubsets(subset));
                return;
            }

            subset[i] = null;

            var nonprintString = PrintSubsets(subset, false);
            Console.WriteLine($"Null assigned at position {i}. Calling {i + 1} from {i}. Subset is {nonprintString}");
            PrintSubsetsUtil(array, subset, i + 1);
            subset[i] = array[i];
            nonprintString = PrintSubsets(subset, false);
            Console.WriteLine($"Array Value {array[i]} assigned at position {i}. Calling {i + 1} from {i}. Subset is {nonprintString}");
            PrintSubsetsUtil(array, subset, i + 1);
        }

        public static string PrintSubsets(int?[] subset, bool isPrinting = true)
        {
            var str = string.Empty;
            for (var i = 0; i < subset.Length; i++)
            {
                if (subset[i].HasValue)
                {
                    if (i != subset.Length - 1)
                        str += subset[i].Value + " , ";
                    else
                    {
                        str += subset[i].Value;
                    }
                }

            }

            if (isPrinting)
                return "Printing " + str;
            return str;
        }
    }

    public static class ReplaceGreatestRightElement
    {
        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/511/in-place-operations/3259/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] ReplaceElements(int[] arr)
        {
            var lastMaxIndex = 0;
            var newList = new int[arr.Length];
            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (i == lastMaxIndex)
                {
                    lastMaxIndex = GetMaxIndex(i + 1);
                }

                newList[i] = arr[lastMaxIndex];
            }

            newList[arr.Length - 1] = -1;
            return newList;

            int GetMaxIndex(int start)
            {
                var max = arr[start];
                var maxIndex = start;
                for (var i = start + 1; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                        maxIndex = i;
                    }
                }

                return maxIndex;
            }
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/511/in-place-operations/3258/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            var currentElement = nums[0];
            var dupes = 0;
            var uniqueElements = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == currentElement)
                {
                    dupes++;
                }
                else if (nums[i] < currentElement)
                    break;
                else
                {
                    currentElement = nums[i];
                    nums[i - dupes] = nums[i];
                    uniqueElements++;
                }
            }

            return uniqueElements;


        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/511/in-place-operations/3157/
        /// </summary>
        /// <param name="nums"></param>
        public static void MoveZeroes(int[] nums)
        {
            var numofZeroes = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    numofZeroes++;
                else
                {
                    nums[i - numofZeroes] = nums[i];
                }

            }


            for (var i = nums.Length - 1; numofZeroes > 0; i--, numofZeroes--)
                nums[i] = 0;


        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/511/in-place-operations/3260/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[] SortArrayByParity(int[] A)
        {
            var i = 0;
            var j = A.Length - 1;
            while (i < j)
            {
                if (A[i] % 2 == 1 && A[j] % 2 == 0)
                {
                    var temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }

                if (A[i] % 2 == 0) i++;
                if (A[j] % 2 == 1) j--;
            }

            return A;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/511/in-place-operations/3261/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[] SortedSquares(int[] A)
        {
            var i = -1; //-ve counter
            var j = A.Length; //+ve counter
            var result = new int[A.Length];
            for (var k = 0; k < A.Length; k++)
            {
                if (A[k] < 0)
                {
                    i = k;
                }

                if (A[k] >= 0 && j == A.Length)
                {
                    j = k;
                    break;
                }

            }

            var t = 0;
            while (t < A.Length)
            {
                if(i> - 1 && j<A.Length)
                {
                    if(Math.Abs(A[i]) < A[j])
                    {
                        result[t] = A[i] * A[i];
                        i--;
                    }
                    else
                    {
                        result[t] = A[j] * A[j];
                        j++;
                    }
                }
                else if(i == -1)
                {
                    result[t] = A[j] * A[j];
                    j++;
                }
                else
                {
                    result[t] = A[i] * A[i];
                    i--;
                }
                t++;
                
            }

            return result;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/523/conclusion/3228/
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public static int HeightChecker(int[] heights)
        {
            var buckets = new int[101];

            //array where index is the value if the input array heights and value of buckets is the frequency
            foreach(var height in heights)
            {
                buckets[height]++;
            }

            var moves = 0;
            var i = 0;
            for(var j = 0; j < buckets.Length; j++)
            {
                while(buckets[j] > 0)
                {
                    if (j != heights[i])
                        moves++;

                    i++;

                    buckets[j]--;
                }
            }

            return moves;
        }

    }

    /// <summary>
    /// This is just to reimplement FindSubsets above to better understand as the idea is the same
    /// </summary>
    public static class BinaryBits
    {
        public static void PrintAllBinary(int numofDigits)
        {
            var subset = new int?[numofDigits];
            PrintAllBinaryUtil(numofDigits, subset, 0);
        }

        public static void PrintAllBinaryUtil(int numofDigits, int?[] subset, int i)
        {
            if (i == numofDigits)
            {
                Console.WriteLine(PrintSubsets(subset));
                return;
            }

            subset[i] = 0;
            PrintAllBinaryUtil(numofDigits, subset, i + 1);

            subset[i] = 1;
            PrintAllBinaryUtil(numofDigits, subset, i + 1);
        }

        public static void PrintAllThreeary(int numofDigits)
        {
            var subset = new int?[numofDigits];
            PrintAllThreeArytil(numofDigits, subset, 0);
        }

        public static void PrintAllThreeArytil(int numofDigits, int?[] subset, int i)
        {
            if (i == numofDigits)
            {
                Console.WriteLine(PrintSubsets(subset));
                return;
            }

            subset[i] = 0;
            PrintAllThreeArytil(numofDigits, subset, i + 1);

            subset[i] = 1;
            PrintAllThreeArytil(numofDigits, subset, i + 1);

            subset[i] = 2;
            PrintAllThreeArytil(numofDigits, subset, i + 1);

        }

        public static string PrintSubsets(int?[] subset, bool isPrinting = true)
        {
            var str = string.Empty;
            for (var i = 0; i < subset.Length; i++)
            {
                if (subset[i].HasValue)
                {
                    if (i != subset.Length - 1)
                        str += subset[i].Value + " , ";
                    else
                    {
                        str += subset[i].Value;
                    }
                }

            }

            if (isPrinting)
                return "Printing " + str;
            return str;
        }

        public static int[][] FlipAndInvertImage(int[][] A)
        {
            for (var i = 0; i < A.Length; i++)
            {
                A[i] = Process(A[i]);
            }

            int[] Process(int[] row)
            {
                for (int i = 0; i <= (row.Length - 1) / 2; i++)
                {
                    if (row[i] == row[row.Length - 1 - i])
                    {
                        if (row[i] == 1)
                        {
                            row[i] = 0;
                            row[row.Length - 1 - i] = 0;
                        }
                        else
                        {
                            row[i] = 1;
                            row[row.Length - 1 - i] = 1;
                        }
                    }
                }

                return row;
            }

            return A;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //FindSubsets.FindAllSubsets(new []{0,1,2});

            //BinaryBits.PrintAllBinary(5);

            //BinaryBits.PrintAllThreeary(3);

            int[][] A = new int[3][];
            A[0] = new int[3] { 1, 1, 0 };
            A[1] = new int[3] { 1, 0, 1 };
            A[2] = new int[3] { 0, 0, 0 };
            A = BinaryBits.FlipAndInvertImage(A);

            int[] arr = new int[] { 17, 18, 5, 4, 6, 1 };
            var newArr = ReplaceGreatestRightElement.ReplaceElements(arr);


            //int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //int[] nums = new int[] { 0, 0, 1, 1,1,1,1,1,1,1,1,1, 2, 2, 3, 3, 4 };
            //int[] nums = new int[] { 1, 1, 2 };
            //var a = ReplaceGreatestRightElement.RemoveDuplicates(nums);

            //var nums = new int[] { 0, 1, 0, 3, 12 };
            //ReplaceGreatestRightElement.MoveZeroes(nums);

            //var nums = new int[] { 3, 1, 2, 4 };
            //ReplaceGreatestRightElement.SortArrayByParity(nums);

            //var nums = new int[] { -4, -1, 0, 3, 10 };
            //var nums = new int[] { -7, -3, 2, 3, 11 };
            //var nums = new int[] { -1 };
            //var result = ReplaceGreatestRightElement.SortedSquares(nums);

            //var heights = new int[] { 1, 1, 4, 2, 1, 3 };
            //var heights = new int[] { 5, 1, 2, 3, 4 };
            var heights = new int[] { 1, 2, 3, 4, 5 };
            var result = ReplaceGreatestRightElement.HeightChecker(heights);
            Console.ReadLine();
        }
    }
}
