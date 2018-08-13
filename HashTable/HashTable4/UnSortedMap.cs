using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class UnSortedMap<K, V> : AbstractMap<K, V>
    {
        private List<Entry<K, V>> _table = new List<Entry<K, V>>();

        public override int Size
        {
            get
            {
                return _table.Count;
            }
        }
        public override IIterable<Entry<K, V>> EntrySet
        {
            get
            {
                return new EntrySetIterable(_table);
            }
        }

        private class EntrySetIterator : IIterator<Entry<K, V>>
        {
            private List<Entry<K, V>> _table;
            private int position = -1;
            public EntrySetIterator(List<Entry<K, V>> table)
            {
                _table = table;
            }
            public bool HasNext
            {
                get
                {

                    return position < _table.Count - 1;
                }
            }

            public Entry<K, V> Next
            {
                get
                {
                    position++;
                    if (position >= _table.Count)
                        throw new IndexOutOfRangeException();
                    return _table[position];
                }
            }
        }

        private class EntrySetIterable : IIterable<Entry<K, V>>
        {
            private List<Entry<K, V>> _table;
            public EntrySetIterable(List<Entry<K, V>> table)
            {
                _table = table;
            }
            public IIterator<Entry<K, V>> Iterator
            {
                get
                {
                    return new EntrySetIterator(_table);
                }
            }
        }

        //returns -1 if key not found
        private int FindIndex(K key)
        {
            var index = 0;
            foreach(var entry in _table)
            {
                if (entry.Key.Equals(key))
                    return index;

                index++;
            }

            return -1;

        }

        public override V Get(K key)
        {
            var index = FindIndex(key);
            if (index == -1)
                return default(V);

            return _table[index].Value;
        }

        public override V Put(K key, V value)
        {
            var index = FindIndex(key);
            if(index == -1)
            {
                _table.Add(new Entry<K, V>(key, value));
                return default(V);
            }

            var oldValue = _table[index].Value;
            _table[index].Value = value;
            return oldValue;
        }

        public override V Remove(K key)
        {
            var index = FindIndex(key);
            if (index == -1)
                return default(V);

            var oldValue = _table[index].Value;
            if(index!=Size -1)
                _table[index] = _table[Size - 1];
            _table.Remove(_table[Size - 1]);
            return oldValue;
        }

        public override bool ContainsKey(K key)
        {
            var index = FindIndex(key);
            return index != -1;
        }
    }
}
