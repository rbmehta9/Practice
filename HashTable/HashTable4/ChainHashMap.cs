using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class ChainHashMap<K, V> : AbstractHashMap<K, V>
    {
        public ChainHashMap(int capacity, int primefactor) : base(capacity, primefactor) { }

        public ChainHashMap(int capacity) : base(capacity) { }

        public ChainHashMap() : base() { }

        private UnSortedMap<K, V>[] _hashTable;
        public override IIterable<Entry<K, V>> EntrySet
        {
            get
            {
                return new ChainHashMapIterable(_hashTable);
            }
        }
        private class ChainHashMapKVPIterator : IIterator<Entry<K, V>>
        {
            private UnSortedMap<K, V> _table;
            public ChainHashMapKVPIterator(UnSortedMap<K, V>[] table)
            {
                foreach (var bucket in table)
                {
                    var iterator = bucket.EntrySet.Iterator;
                    while (iterator.HasNext)
                    {
                        var kvp = iterator.Next;
                        _table.Put(kvp.Key, kvp.Value);
                    }
                }
            }
            public bool HasNext
            {
                get
                {
                    return _table.EntrySet.Iterator.HasNext;
                }
            }

            public Entry<K, V> Next
            {
                get { return _table.EntrySet.Iterator.Next; }
            }

            
        }

        private class ChainHashMapIterable : IIterable<Entry<K, V>>
        {
            private UnSortedMap<K, V>[] _table;
            public ChainHashMapIterable(UnSortedMap<K, V>[] table)
            {
                _table = table;
            }
            public IIterator<Entry<K, V>> Iterator
            {
                get
                {
                    return new ChainHashMapKVPIterator(_table);
                }
            }
        }




        public override V BucketGet(int h, K key)
        {
            var bucket = _hashTable[h];
            return bucket.Get(key);
        }

        public override V BucketPut(int h, K key, V value)
        {
            var bucket = _hashTable[h];
            if (bucket == null)
            {
                bucket = new UnSortedMap<K, V>();
                _hashTable[h] = bucket;
            }

            var oldSize = bucket.Size;
            var answer = bucket.Put(key, value);
            n += bucket.Size - oldSize;
            return answer;
        }

        public override V BucketRemove(int h, K key)
        {
            var bucket = _hashTable[h];
            if (bucket == null)
                return default(V);

            var oldSize = bucket.Size;
            V answer = bucket.Remove(key);
            n -= oldSize - bucket.Size;
            return answer;
        }

        public override bool ContainsKey(int h, K key)
        {
            var bucket = _hashTable[h];
            return bucket.ContainsKey(key);
        }

        public override void CreateTable()
        {
            _hashTable = new UnSortedMap<K, V>[_capacity];
        }

    }
}
