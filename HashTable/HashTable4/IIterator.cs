using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public interface IIterator<T>
    {
        bool HasNext { get; }
        T Next { get; }

    }
}
