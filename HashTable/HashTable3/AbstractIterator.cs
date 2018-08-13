using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public abstract class AbstractIterator<T> : IIterator<T>
    {
        protected int currentIndex = -1;
        public bool HasNext()
        {
            return currentIndex < Size() - 1; 
        }

        public T Next()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public abstract int Size();
    }
}
