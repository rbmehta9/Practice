using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    public class Combinations
    {
        private int _n;
        private int _r;
        private List<List<int>> pascalsTriangle = new List<List<int>>();
        public Combinations(int n, int r)
        {
            _n = n;
            _r = r;
        }

        public List<int[]> GeneratePascalsTriangle(int n)
        {
            if(n<=0)
                throw new ArgumentException("n must be greater than 0");
            else
            {
                var pascalsTriangle1 = new List<int[]>();
                for (var i = 0; i <= n; i++)
                {
                    var ithRow = new int[i + 1];
                    pascalsTriangle1.Add(ithRow);
                    if (i == 0)
                        ithRow[0] = 1;
                    else if (i == 1)
                    {
                        ithRow[0] = 1;
                        ithRow[1] = 1;
                    }
                    else
                    {
                        for (var j = 0; j <= i/2; j++)
                        {
                            if (j == 0)
                                ithRow[j] = 1;
                            else
                            {
                                ithRow[j] = pascalsTriangle1[i - 1][j - 1] + pascalsTriangle1[i - 1][j];
                                
                            }

                            if (j != i - j)
                                ithRow[i - j] = ithRow[j];
                        }
                    }

                }

                return pascalsTriangle1;
            }
        }

        public int FindNCr()
        {
            if (_n < _r || _n <= 0 || _r<0)
                throw new ArgumentException("n mush be greater than or equal to r;n must be greater than 0");
            else if (_r == 0 || _n == _r)
                return 1;
            else if (_r == 1)
                return _n;
            else if (_r > _n - _r)  //This condition is not required. But will improve performane bcoz nCr = nCn-r
                _r = _n - _r;
            for (var i = 0; i <= _n; i++)
            {
                if (i == 0)
                    pascalsTriangle.Add(new List<int>() { 1 });
                else if (i == 1)
                    pascalsTriangle.Add(new List<int>() { 1, 1 });
                else
                {
                    var ithRow = new List<int>();
                    pascalsTriangle.Add(ithRow);
                    for (var j = 0; j <= i; j++)
                    {
                        if (j == 0 || j == i)
                            pascalsTriangle[i].Add(1);
                        else
                        {
                            pascalsTriangle[i].Add(pascalsTriangle[i - 1][j - 1] + pascalsTriangle[i - 1][j]);
                            if (i==_n && j == _r)
                                break;
                        }


                    }
                }
            }

            return pascalsTriangle[_n][_r];
        }


    }
}
