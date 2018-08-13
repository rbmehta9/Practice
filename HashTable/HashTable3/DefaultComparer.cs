using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class DefaultComparer<K> : IComparer<K>
    {
        public int Compare(K x, K y)
        {
            throw new NotImplementedException();
        }
    }
}
