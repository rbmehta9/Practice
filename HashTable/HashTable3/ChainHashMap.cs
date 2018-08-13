using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class ChainHashMap<K, V> : AbstractHashMap<K, V>
    {
        private UnSortedTableMap<K, V>[] _table;

        public ChainHashMap(int capacity, int primeFactor) : base(capacity, primeFactor) { }

        public ChainHashMap(int capacity) : base(capacity) { }
        public ChainHashMap() : base() { }
        public override V bucketGet(int hash, K key)
        {
            var bucket = _table[hash];
            return (bucket == null) ? default(V) : bucket.Get(key);
        }

        public override V bucketPut(int hash, K key, V value)
        {
            var bucket = _table[hash];
            if (bucket == null)
                _table[hash] = new UnSortedTableMap<K, V>();
            return bucket.Put(key, value);
        }

        public override V bucketRemove(int hash, K key)
        {
            var bucket = _table[hash];
            if (bucket == null)
                return default(V);
            var oldSize = bucket.size();
            var answer = bucket.Remove(key);
            n -= oldSize - bucket.size();
            return answer;
        }

        private class ChainHashMapKVPIterator : IIterator<KeyValuePair<K, V>>
        {
            private UnSortedTableMap<K, V> _table;
            public ChainHashMapKVPIterator(UnSortedTableMap<K, V>[] table)
            {
                foreach(var bucket in table)
                {
                    var iterator = bucket.entrySet().GetIterator();
                    while(iterator.HasNext())
                    {
                        var kvp = iterator.Next();
                        _table.Put(kvp.Key, kvp.Value);
                    }
                }
            }
            public bool HasNext()
            {
                return _table.entrySet().GetIterator().HasNext();
            }

            public KeyValuePair<K, V> Next()
            {
                return _table.entrySet().GetIterator().Next();
            }

            public void Remove()
            {
                _table.entrySet().GetIterator().Remove();
            }
        }

        private class ChainHashMapIterable : Iterable<KeyValuePair<K, V>>
        {
            private UnSortedTableMap<K, V>[] _table;
            public ChainHashMapIterable(UnSortedTableMap<K, V>[] table)
            {
                _table = table;
            }
            public IIterator<KeyValuePair<K, V>> GetIterator()
            {
                return new ChainHashMapKVPIterator(_table);
            }
        }

        public override void CreateTable()
        {
            _table = new UnSortedTableMap<K, V>[_capacity];
        }

        public override Iterable<KeyValuePair<K, V>> entrySet()
        {
            return new ChainHashMapIterable(_table);
        }
    }
}
