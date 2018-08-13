using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable2
{
    public class CollectionIterable<T> : Interable<T>
    {
        public CollectionIterable(T[] array)
        {
            _iterator = new CollectionIterator<T>(array);
        }

        private Iterator<T> _iterator;
        public Iterator<T> GetIterator()
        {
            return _iterator;
        }
    }
}
