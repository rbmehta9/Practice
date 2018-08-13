using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class ProbeHashMap<K, V> : AbstractHashMap<K, V>
    {
        private KeyValuePair<K, V>[] _table;
        private KeyValuePair<K, V> DEFUNCT = new KeyValuePair<K, V>(default(K), default(V));

        public ProbeHashMap(int capacity, int primeFactor) : base(capacity, primeFactor) { }
        public ProbeHashMap(int capacity) : base(capacity) { }
        public ProbeHashMap() : base() { }

        public bool IsAvailable(int index)
        {
            return _table[index].Equals(null) || _table[index].Equals(DEFUNCT);
        }

        public int FindSlot(int h, K key)
        {

            var j = h;
            var avail = -1;
            do
            {
                if (IsAvailable(j))
                {
                    if (avail == -1) avail = j;
                    if (_table[j].Equals(null)) break;
                }
                else if (_table[j].Key.Equals(key))
                    return j;
                j = (j + 1) % _capacity;
            }
            while (j != h);

            return -(avail + 1);
        }


        public override V bucketGet(int hash, K key)
        {
            var j = FindSlot(hash, key);
            if (j < 0)
                return default(V);
            return _table[j].Value;

        }

        public override V bucketPut(int hash, K key, V value)
        {
            var j = FindSlot(hash, key);
            if (j >= 0)
            {
                var oldValue = _table[j].Value;
                _table[j] = new KeyValuePair<K, V>(key, value); //KeyValuePair cannot change value in .NET else we could have something like _table[j].Value = value
                return oldValue;
            }
            else
            {
                _table[-(j + 1)] = new KeyValuePair<K, V>(key, value);
                n++;
                return value;
            }
        }

        public override V bucketRemove(int hash, K key)
        {
            var j = FindSlot(hash, key);
            if (j < 0)
                throw new Exception("Element does not exist");
            var oldValue = _table[j].Value;
            _table[j] = DEFUNCT;
            n--;
            return oldValue;

        }

        public override void CreateTable()
        {
            _table = new KeyValuePair<K, V>[_capacity];
        }

        private class ProbeHashMapIterator : IIterator<KeyValuePair<K, V>>
        {
            private KeyValuePair<K, V>[] _table;
            private int currentIndex = 0;
            public ProbeHashMapIterator(KeyValuePair<K, V>[] table)
            {
                _table = table;
            }
            public bool HasNext()
            {
                return currentIndex < _table.Count() -1;
            }

            public KeyValuePair<K, V> Next()
            {
                if (currentIndex == _table.Count() - 1)
                    throw new Exception("Finished iterating the Collection");
                currentIndex++;
                return _table[currentIndex];
            }

            public void Remove()
            {
                throw new NotImplementedException();
            }
        }

        private class ProbeHashIterable : Iterable<KeyValuePair<K, V>>
        {
            private KeyValuePair<K, V>[] _table;

            public ProbeHashIterable(KeyValuePair<K, V>[] table)
            {
                _table = table;
            }
            public IIterator<KeyValuePair<K, V>> GetIterator()
            {
                return new ProbeHashMapIterator(_table);
            }
        }

        public override Iterable<KeyValuePair<K, V>> entrySet()
        {
            return new ProbeHashIterable(_table); ;
        }
    }
}
