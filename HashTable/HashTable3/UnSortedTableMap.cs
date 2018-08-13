using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class UnSortedTableMap<K, V> : AbstractMap<K, V>
    {
        private IList<KeyValuePair<K, V>> table = new List<KeyValuePair<K, V>>();
        public int FindIndex(K key)
        {
            for(var i =0;i<table.Count;i++)
            {
                var kvp = table[i];
                if(kvp.Key.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        private class KVPIterator : IIterator<KeyValuePair<K, V>>
        {
            private int currentIndex = -1;
            private IList<KeyValuePair<K, V>> _table;
            public KVPIterator(IList<KeyValuePair<K, V>> table)
            {
                _table = table;
            }
            public bool HasNext()
            {
                return currentIndex < _table.Count - 1;
            }

            public KeyValuePair<K, V> Next()
            {
                if (currentIndex == _table.Count - 1)
                    throw new Exception("No Element further");

                currentIndex++;
                return _table[currentIndex];
            }

            public void Remove()
            {
                throw new NotImplementedException();
            }
        }

        private class KVPIterable : Iterable<KeyValuePair<K, V>>
        {
            private IList<KeyValuePair<K, V>> _table;
            public KVPIterable(IList<KeyValuePair<K, V>> table)
            {
                _table = table;
            }
            public IIterator<KeyValuePair<K, V>> GetIterator()
            {
                return new KVPIterator(_table);
            }
        }
        public override Iterable<KeyValuePair<K, V>> entrySet()
        {
            return new KVPIterable(table);
        }

        public override V Get(K key)
        {
            var index = FindIndex(key);
            return (index == -1) ? default(V) : table[index].Value;
        }

        public override V Put(K key, V value)
        {
            var index = FindIndex(key);
            var kvp = new KeyValuePair<K,V>(key, value);
            if (index != -1)
            {
                table.Add(kvp);
            }
            else
                table[index] = kvp;
            throw new NotImplementedException();
        }

        public override V Remove(K key)
        {
            var index = FindIndex(key);
            if (index == -1)
                throw new Exception("Element not found");
            var kvpToRemove = table[index];
            var lastkvp = table[size() - 1];
            table.RemoveAt(size() - 1);
            table[index] = lastkvp;
            return kvpToRemove.Value;
        }

        public override int size()
        {
            return table.Count;
        }
    }
}
