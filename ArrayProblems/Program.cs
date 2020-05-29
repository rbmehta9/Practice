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
                if (i > -1 && j < A.Length)
                {
                    if (Math.Abs(A[i]) < A[j])
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
                else if (i == -1)
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
            foreach (var height in heights)
            {
                buckets[height]++;
            }

            var moves = 0;
            var i = 0;
            for (var j = 0; j < buckets.Length; j++)
            {
                while (buckets[j] > 0)
                {
                    if (j != heights[i])
                        moves++;

                    i++;

                    buckets[j]--;
                }
            }

            return moves;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/523/conclusion/3230/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            var prevNumberofConsecutive1s = 0;
            var currentNumberofConsecutive1s = 0;
            var max = 0;
            var firstZeroReached = false;
            foreach (var num in nums)
            {
                if (num == 0)
                {
                    if (!firstZeroReached)
                        firstZeroReached = true;
                    else
                        max = Math.Max(max, prevNumberofConsecutive1s + currentNumberofConsecutive1s + 1);
                    prevNumberofConsecutive1s = currentNumberofConsecutive1s;
                    currentNumberofConsecutive1s = 0;
                }
                else
                {
                    currentNumberofConsecutive1s++;
                }
            }

            if (firstZeroReached)
                max = Math.Max(max, prevNumberofConsecutive1s + currentNumberofConsecutive1s + 1);
            else
                max = nums.Length;

            return max;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/523/conclusion/3231/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ThirdMax(int[] nums)
        {
            var distinctCounter = 0;
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        var t = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = t;
                    }
                }

                if (i == 0 || nums[nums.Length - 1 - i] != nums[nums.Length - i])
                    distinctCounter++;

                if (distinctCounter == 3)
                    return nums[nums.Length - 1 - i];
            }

            if (nums[0] != nums[1])
                distinctCounter++;

            if (distinctCounter == 3)
                return nums[0];

            return nums[nums.Length - 1];
        }
        //public static int ThirdMax(int[] nums)
        //{
        //    var max = FindMax();
        //    var bucket = new int[max + 1];
        //    foreach (var num in nums)
        //    {
        //        bucket[num]++;
        //    }

        //    var counter = 3;
        //    var lastmax = 0;
        //    for (var i = max; i > -1; i--)
        //    {
        //        if (bucket[i] > 0)
        //        {
        //            counter--;
        //            lastmax = i;
        //        }

        //        if (counter == 0)
        //            return i;
        //    }

        //    return max;

        //    int FindMax()
        //    {
        //        var mx = 0;
        //        foreach (var num in nums)
        //            mx = Math.Max(mx, num);

        //        return mx;
        //    }
        //}

        /// <summary>
        /// https://leetcode.com/problems/kth-largest-element-in-an-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargest(int[] nums, int k)
        {
            //Kth largest element is n - k smallest
            //eg. [3,2,1,5,6,4]. 2nd largest element is 4th smallest element (index starting zero)
            return FindKthSmallest(0, nums.Length - 1, nums.Length - k, nums);
        }

        private static int FindKthSmallest(int left, int right, int k, int[] nums)
        {
            var random = new Random();
            var pivotIndex = left + random.Next(right - left);
            pivotIndex = Partition(left, right, pivotIndex, nums);
            if (pivotIndex == k)
                return nums[k];
            else if (k > pivotIndex)
                return FindKthSmallest(pivotIndex + 1, right, k, nums);

            return FindKthSmallest(left, pivotIndex - 1, k, nums);

        }

        private static void Swap(int i, int j, int[] nums)
        {
            if (i == j)
                return;
            var t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }

        private static int Partition(int left, int right, int pivotIndex, int[] nums)
        {
            //counter for elements lest than pivot
            var smallerElementsCounter = left;
            var pivot = nums[pivotIndex];
            Swap(pivotIndex, right, nums);

            //At the end of this loop the value of the smallerElementsCounter will be equal to the number of elements less than pivot
            //The swap above Swap(pivotIndex, right, nums) will result as [4,2,1,5,6,3]
            //pivot = 3, pivotindex = 0. we can notice 2 elements (1 and 2) smaller than 3
            //when a smaller element less than pivot is found smallerElementsCounter is incremented
            //As mentioned in my comments we can notice 2 elements (1 and 2) smaller than 3(pivot). Means 1 and 2 will have positions (0 and 1 irrespective of order)
            //[4,2,1,5,6,3] 
            //i =0 , 4 is larger hence smallerElementsCounter remains zero
            //i = 1, 2 is smaller hence 2 must take the first spot i.e. 0 as per smallerElementsCounter. Hence we swap with positions 0 and 1. smallerElementsCounter becomes 1
            //i = 2, 1 is smaller hence 1 must take second spot i.e. position 1 (first spot i.e. position 0 taken by 2.Hence we swap positions 1 and 2. smallerElementsCounter becomes 2
            //i = 3, 4,5 are all larger hence smallerElementsCounter remains same. smallerElementsCounter will now reflect actual poistion of pivot element 3
            //The for loop below
            for (var i = left; i <= right; i++)
            {
                if (nums[i] < pivot)
                {
                    Swap(smallerElementsCounter, i, nums);
                    smallerElementsCounter++;
                }
            }

            //Pivot element is still at the end. smallerElementsCounter now reflects actual position of pivot element 3. Hence we swap
            //with rightmost element
            Swap(smallerElementsCounter, right, nums);

            return smallerElementsCounter;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/fun-with-arrays/523/conclusion/3270/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var missingArray = new List<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var value = Math.Abs(nums[i]);
                nums[value - 1] = -1 * Math.Abs(nums[value - 1]);
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    missingArray.Add(i + 1);
            }

            return missingArray;

        }

        public static int FindProximitySearch(List<string> text, string keyword1, string keyword2, int range)
        {
            var start = 0;
            var numberofMatches = 0;
            while (start < text.Count - 1)
            {
                if (text[start] != keyword1 && text[start] != keyword2)
                {
                    start++;
                    continue;
                }

                var secondWord = (text[start] == keyword1) ? keyword2 : keyword1;
                var secondWordCounter = start + 1;
                var secondWordLimit = start + range;
                if (secondWordLimit > text.Count - 1)
                    secondWordLimit = text.Count - 1;
                while (secondWordCounter < secondWordLimit)
                {
                    if (text[secondWordCounter] == secondWord)
                        numberofMatches++;

                    secondWordCounter++;
                }

                start++;

            }

            return numberofMatches;
        }

        public static int FindProximitySearch1(List<string> text, string keyword1, string keyword2, int range)
        {
            var keyWord1SortedIndexes = text.Select((item, index) => new { Word = item, Index = index })
                                        .Where(obj => obj.Word == keyword1).Select(i => i.Index);

            var keyWord2SortedIndexes = text.Select((item, index) => new { Word = item, Index = index })
                                        .Where(obj => obj.Word == keyword2).Select(i => i.Index);

            
            if (keyWord1SortedIndexes.Count() < keyWord2SortedIndexes.Count())
            {
                return Calculate(keyWord1SortedIndexes, keyWord2SortedIndexes);
            }
            else
            {
                return Calculate(keyWord2SortedIndexes, keyWord1SortedIndexes);
            }

            int Calculate(IEnumerable<int> smallerList, IEnumerable<int> largerList)
            {
                var numofMatches = 0;
                foreach (var index in smallerList)
                {
                    var lowerLimit = index - range + 1;
                    if (lowerLimit < 0)
                        lowerLimit = 0;

                    var upperLimit = index + range - 1;
                    if (upperLimit > text.Count - 1)
                        upperLimit = text.Count - 1;

                    numofMatches += largerList.Count(ind => lowerLimit <= ind && ind <= upperLimit);
                }

                return numofMatches;
            }


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
            //var heights = new int[] { 1, 2, 3, 4, 5 };
            //var result = ReplaceGreatestRightElement.HeightChecker(heights);

            //var nums = new int[] {0, 1, 0, 1, 1, 1, 0, 0 };
            //var nums = new int[] { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1 };
            //var nums = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            //var nums = new int[] { 0, 0, 0, 0, 0, 0 };
            //var a = ReplaceGreatestRightElement.FindMaxConsecutiveOnes(nums);

            //var nums = new int[] { 7 , 8, 8, 8};
            //var a = ReplaceGreatestRightElement.ThirdMax(nums);

            //var nums = new int[] { 3,2,1,5,6,4 };
            //var a = ReplaceGreatestRightElement.FindKthLargest(nums, 2);

            //var nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            //var a = ReplaceGreatestRightElement.FindDisappearedNumbers(nums);

            var text = new List<string>() { "the",
                                            "man",
                                            "the",
                                            "plan",
                                            "the",
                                            "canal",
                                            "panama",
                                            //"panama",
                                            //"canal",
                                            //"the",
                                            //"plan",
                                            //"the",
                                            //"man",
                                            //"the",
                                            //"the",
                                            //"man",
                                            //"the",
                                            //"plan",
                                            //"the",
                                            //"canal",
                                            //"panama"
                                            };

            var numberofMatches = ReplaceGreatestRightElement.FindProximitySearch1(text, "the", "canal", 3);

            Console.ReadLine();
        }
    }
}
