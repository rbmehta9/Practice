using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public abstract class AbstractMap<K, V> : IMap<K, V>
    {
        public abstract IIterable<Entry<K, V>> EntrySet { get; }

        public bool IsEmpty
        {
            get
            {
                return Size == 0;
            }
        }

        public IIterable<K> KeySet
        {
            get
            {
                return new KeyIterable(EntrySet);
            }

        }


        private class KeyIterator : IIterator<K>
        {
            private IIterable<Entry<K, V>> _entrySet;
            public KeyIterator(IIterable<Entry<K, V>> entrySet)
            {
                _entrySet = entrySet;
            }
            public bool HasNext
            {
                get
                {
                    
                    return _entrySet.Iterator.HasNext;
                }
            }

            public K Next
            {
                get
                {
                    return _entrySet.Iterator.Next.Key;
                }
            }
        }

        private class KeyIterable : IIterable<K>
        {
            private IIterable<Entry<K, V>> _entrySet;
            public KeyIterable(IIterable<Entry<K,V>> entrySet)
            {
                _entrySet = entrySet;
            }
            public IIterator<K> Iterator
            {
                get
                {
                    return new KeyIterator(_entrySet);
                }
            }
        }

        private class ValueIterator : IIterator<V>
        {
            private IIterable<Entry<K, V>> _entrySet;
            public ValueIterator(IIterable<Entry<K, V>> entrySet)
            {
                _entrySet = entrySet;
            }
            public bool HasNext
            {
                get
                {

                    return _entrySet.Iterator.HasNext;
                }
            }

            public V Next
            {
                get
                {
                    return _entrySet.Iterator.Next.Value;
                }
            }
        }

        private class ValueIterable : IIterable<V>
        {
            private IIterable<Entry<K, V>> _entrySet;
            public ValueIterable(IIterable<Entry<K, V>> entrySet)
            {
                _entrySet = entrySet;
            }
            public IIterator<V> Iterator
            {
                get
                {
                    return new ValueIterator(_entrySet);
                }
            }
        }

        public abstract int Size { get; }

        public IIterable<V> ValueSet
        {
            get
            {
                return new ValueIterable(EntrySet);
            }

        }

        public abstract V Get(K key);

        public abstract V Put(K key, V value);

        public abstract V Remove(K key);

        public abstract bool ContainsKey(K key);
    }
}
