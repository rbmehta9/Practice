using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class PascalsTriangle
    {
        private List<List<int>> _array = new List<List<int>>();

        public int GetCoefficient(int i, int j)
        {
            if (j == 0 || i == j)
                return 1;

            return GetCoefficient(i - 1, j) + GetCoefficient(i - 1, j - 1);
        }

        public int GetCoefficientMemoization(int i, int j)
        {
            for (var k = 0; k <= i; k++)
            {
                _array.Add(new List<int>());
                for (var l = 0; l <= j; l++)
                {
                    _array[k].Add(-1);
                }
            }

            return GetCoefficientMemoization1(i, j);
        }

        public int GetCoefficientMemoization1(int i, int j)
        {
            if (_array[i][j] == -1)
            {
                _array[i][j] = (j == 0 || j == i) ? 1 : GetCoefficientMemoization1(i - 1, j) + GetCoefficientMemoization1(i - 1, j - 1);
            }

            return _array[i][j];
        }

        public List<List<int>> GeneratePascalNoRecursion(int n)
        {
            for (var i = 0; i <= n; i++)
            {
                _array.Add(new List<int>());
                for (var j = 0; j <= i; j++)
                {
                    if (j == 0)
                        _array[i].Add(1);
                    else if (j <= i / 2)
                        _array[i].Add(_array[i - 1][j] + _array[i - 1][j - 1]);
                    else
                    {
                        _array[i].Add(_array[i][i - j]);
                    }

                }
            }

            return _array;
        }

        public IList<IList<int>> GeneratePascalRecursionWithMemoization(int numRows)
        {
            IList<IList<int>> array = new List<IList<int>>();

            for (var i = 0; i <= numRows; i++)
            {
                GetRow(i);
            }

            void GetRow(int i)
            {
                for (var j = 0; j <= i; j++)
                {
                    GenerateCoeffientWithMemoization(i, j);
                }
            }

            int GenerateCoeffientWithMemoization(int i, int j)
            {
                
                if (array.Count >= i + 1 && array[i].Count >= j + 1)
                    return array[i][j];
                else if (array.Count < i + 1)
                    array.Add(new List<int>());

                if (j == 0 || j == i)
                    array[i].Add(1);
                else if (j <= i / 2)
                {
                    array[i].Add(GenerateCoeffientWithMemoization(i - 1, j) +
                                  GenerateCoeffientWithMemoization(i - 1, j - 1));
                }
                else
                {
                    array[i].Add(array[i][i - j]);
                }

                return array[i][j];

            }

            return array;
        }
    }
}
