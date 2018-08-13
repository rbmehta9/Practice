using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable2
{
    public class CollectionIterator<T> : Iterator<T>
    {
        public CollectionIterator(T[] list)
        {
            _array = list;
        }
        private int position = -1;
        private T[] _array;
        public T Current
        {
            get
            {
                try
                {
                    return _array[position];
                }
                catch(IndexOutOfRangeException ex)
                {
                    throw new InvalidOperationException("", ex);
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position <= _array.Length - 1);
                
        }
        public void Reset()
        {
            position = -1; ;
        }
    }
}
