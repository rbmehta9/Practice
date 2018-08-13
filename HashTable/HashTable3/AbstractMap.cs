using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public abstract class AbstractMap<K, V> : IMap<K, V>
    {


        

        public bool isEmpty()
        {
            return size() == 0;
        }

        private class KeyIterator : IIterator<K>
        {
            private Iterable<KeyValuePair<K, V>> _entrySet;
            public KeyIterator(Iterable<KeyValuePair<K, V>> entrySet)
            {
                _entrySet = entrySet;
            }
            public bool HasNext()
            {
                return _entrySet.GetIterator().HasNext();
            }

            public K Next()
            {
                return _entrySet.GetIterator().Next().Key;
            }

            public void Remove()
            {
                throw new NotImplementedException();
            }
        }

        protected class KeyIterable : Iterable<K>
        {
            private Iterable<KeyValuePair<K, V>> _entrySet;

            public KeyIterable(Iterable<KeyValuePair<K,V>> entrySet)
            {
                _entrySet = entrySet;
            }
            public IIterator<K> GetIterator()
            {
                return new KeyIterator(_entrySet);
            }
        }

        public Iterable<K> KeySet()
        {
            return new KeyIterable(entrySet());
        }

        public abstract V Get(K key);

        public abstract V Put(K key, V value);

        public abstract V Remove(K key);

        public abstract int size();

        public abstract Iterable<KeyValuePair<K, V>> entrySet();

        public Iterable<V> ValueSet()
        {
            throw new NotImplementedException();
        }
    }
}
