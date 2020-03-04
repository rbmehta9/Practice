﻿using System;
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
            for (var i = 0; i< subset.Length; i++)
            {
                if (subset[i].HasValue)
                {
                    if(i != subset.Length - 1)
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
                for (int i = 0; i <= (row.Length -1)/2; i++)
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
            Console.ReadLine();
        }
    }
}
