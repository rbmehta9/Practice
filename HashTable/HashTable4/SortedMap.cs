using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class SortedMap<K, V> : AbstractMap<K, V>, ISortedMap<K, V>
    {
        private IComparer<K> _comparer;

        private List<Entry<K, V>> table = new List<Entry<K, V>>();
        public SortedMap(IComparer<K> comparer)
        {
            _comparer = comparer;
        }

        public override IIterable<Entry<K, V>> EntrySet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Size
        {
            get
            {
                return table.Count;
            }
        }

        public Entry<K, V> Ceiling(K key)
        {
            var index = FindIndex(key);

            if (index == Size)
                return null;

            return table[index];
        }

        public override bool ContainsKey(K key)
        {
            var index = FindIndex(key);

            return index < Size && _comparer.Compare(table[index].Key, key) == 0;
        }

        public Entry<K, V> First()
        {
            return SafeEntry(0);
        }

        public Entry<K, V> Floor(K key)
        {
            throw new NotImplementedException();
        }

        public override V Get(K key)
        {
            var index = FindIndex(key);
            if (index == Size || _comparer.Compare(table[index].Key, key) != 0)
                return default(V);

            return table[index].Value;
        }

        public Entry<K, V> Higher(K key)
        {
            var index = FindIndex(key);
            if (index >= Size)
                return null;
            if (_comparer.Compare(table[index].Key, key) == 0)
                return table[index + 1];

            return table[index];
        }

        public Entry<K, V> Last()
        {
            return SafeEntry(Size - 1);
        }

        public Entry<K, V> Lower(K key)
        {
            var index = FindIndex(key);
            if (index == 0)
                return null;

            return table[index - 1];


        }

        public override V Put(K key, V value)
        {
            var index = FindIndex(key);
            var entry = new Entry<K, V>(key, value);
            if (index == Size || _comparer.Compare(table[index].Key, key) != 0)
            {
                table.Insert(index, entry);
                return default(V);
            }
            else
            {
                var existingEntry = table[index];
                var oldValue = existingEntry.Value;
                existingEntry.Value = value;
                return oldValue;
            }
        }

        public override V Remove(K key)
        {
            var index = FindIndex(key);
            var safeEntry = SafeEntry(index);
            if (safeEntry == null)
                return default(V);
            table.RemoveAt(index);
            return safeEntry.Value;
        }

        public IIterable<Entry<K, V>> SubMap(K key1, K key2)
        {
            throw new NotImplementedException();
        }

        private Entry<K, V> SafeEntry(int index)
        {
            if (Size == 0 || index >= Size)
                return null;

            return table[index];
        }

        private int FindIndex(K key)
        {
            return FindIndex(key, 0, Size - 1);
        }
        private int FindIndex(K key, int low, int high)
        {
            if (low > high)
                return high + 1;
            var mid = (low + high) / 2;
            var comp = _comparer.Compare(key, table[mid].Key);
            if (mid == 0)
                return mid;

            if (comp < 0)
                return FindIndex(key, low, mid - 1);
            else
                return FindIndex(key, mid + 1, high);

        }

    }
}
