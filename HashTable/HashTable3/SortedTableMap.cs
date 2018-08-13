using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class SortedTableMap<K, V> : AbstractSortedMap<K, V>
    {
        private IList<KeyValuePair<K, V>> table = new List<KeyValuePair<K, V>>();

        public int FindIndex(int low, int high, K key)
        {
            var mid = (low + high) / 2;
            if (low > high) return high + 1;
            var comp = _comparer.Compare(key, table[mid].Key);
            if (comp == 0) return mid;
            if (comp < 0)
                return FindIndex(low, mid - 1, key);

            return FindIndex(mid + 1, high, key); //comp>0
        }

        private int FindIndex(K key)
        {
            return FindIndex(0, size() - 1, key);
        }

        private KeyValuePair<K,V> SafeEntry(int j)
        {
            if (size() == 0 ||j < 0 || j >= size())
                return default(KeyValuePair<K, V>);
            return table[j];
        }

        public SortedTableMap():base(new DefaultComparer<K>())
        {
            
        }
        public override KeyValuePair<K, V> CeilingEntry(K key)
        {
            var index = FindIndex(key);
            return SafeEntry(index);
        }

        public override KeyValuePair<K, V> FloorEntry(K key)
        {
            var index = FindIndex(key);
            if (index == size() && _comparer.Compare(key, SafeEntry(index).Key) == 0)
                return SafeEntry(index - 1);

            return SafeEntry(index);
        }

        public override KeyValuePair<K, V> HigherEntry(K key)
        {
            var index = FindIndex(key);
            if (index == size() || _comparer.Compare(key, SafeEntry(index).Key) > 0)
                return SafeEntry(index);

            return SafeEntry(index + 1);
        }

        public override KeyValuePair<K, V> LowerEntry(K key)
        {
            var index = FindIndex(key);
            return SafeEntry(index - 1);

        }

        private class SortableIterator : IIterator<KeyValuePair<K, V>>
        {
            private IList<KeyValuePair<K, V>> _table = new List<KeyValuePair<K, V>>();
            private int position = 0;
            public SortableIterator(IList<KeyValuePair<K, V>> table)
            {
                _table = table;
            }
            public bool HasNext()
            {
                return position < _table.Count() - 1;
            }

            public KeyValuePair<K, V> Next()
            {
                position++;
                return _table[position];
            }

            public void Remove()
            {
                throw new NotImplementedException();
            }
        }

        private class SortableTableMapIterable : Iterable<KeyValuePair<K, V>>
        {
            private IList<KeyValuePair<K, V>> _table = new List<KeyValuePair<K, V>>();
            public SortableTableMapIterable(IList<KeyValuePair<K, V>> table)
            {
                _table = table;
            }
            public IIterator<KeyValuePair<K, V>> GetIterator()
            {
                return new SortableIterator(_table);
            }
        }

        public override Iterable<KeyValuePair<K, V>> entrySet()
        {
            return new SortableTableMapIterable(table);
        }

        public override KeyValuePair<K, V> FirstEntry()
        {
            return SafeEntry(0);
        }

        public override KeyValuePair<K, V> LastEntry()
        {
            return SafeEntry(size() - 1);
        }


        public override V Get(K key)
        {
            var indexedEntry = SafeEntry(FindIndex(key));
            if (indexedEntry.Equals(default(KeyValuePair<K,V>)))
                return default(V);
            return SafeEntry(FindIndex(key)).Value;
        }

        

        

        

        public override V Put(K key, V value)
        {
            var index = FindIndex(key);
            var indexedEntry = SafeEntry(index);
            if (index<size() && _comparer.Compare(indexedEntry.Key, key)==0)
            {
                table[index] = new KeyValuePair<K, V>(key, value);//this will not be new if we avoid using keyvaluepair class
                return value;
            }
            else
            {
                table.Insert(index, new KeyValuePair<K, V>(key, value));
                return value;
            }
                
        }

        public override V Remove(K key)
        {
            var index = FindIndex(key);
            var indexedEntry = SafeEntry(index);
            if (index < size() && _comparer.Compare(indexedEntry.Key, key) == 0)
            {
                V returnVal = indexedEntry.Value;
                table.RemoveAt(index);
                return returnVal;
            }

            return default(V);
        }

        public override int size()
        {
            return table.Count();
        }

        public override Iterable<K> SubMap(K key1, K key2)
        {
            var indexCeilingK1 = FindIndex(key1);
            var indexFloorK2 = FindIndex(key2) - 1;
            var partialList = new List<KeyValuePair<K, V>>();
            for (var i = 0; i >= indexCeilingK1 && i <= indexFloorK2; i++)
                partialList.Add(table[i]);
            var partialEntrySet = new SortableTableMapIterable(partialList);
            return new KeyIterable(partialEntrySet);
        }
    }
}
