using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable2
{
    public interface Iterator<T>
    {
        T Current { get; }
        bool MoveNext();

        void Reset();
    }
}
