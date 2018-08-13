using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class ProbeHashMap<K, V> : AbstractHashMap<K, V>
    {
        public ProbeHashMap(int capacity, int primefactor) : base(capacity, primefactor) { }

        public ProbeHashMap(int capacity) : base(capacity) { }

        public ProbeHashMap() : base() { }

        private List<Entry<K, V>> _hashTable;

        private Entry<K, V> DEFUNCT = new Entry<K, V>(default(K), default(V));

        public override IIterable<Entry<K, V>> EntrySet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override V BucketGet(int h, K key)
        {
            var slot = FindSlotForExistingKey(h, key);
            if (slot.HasValue)
                return _hashTable[slot.Value].Value;
            return default(V);
        }

        public override V BucketPut(int h, K key, V value)
        {
            var i = h;
            int? firstAvailableSlot = null;
            do
            {
                var entry = _hashTable[i];
                if (entry.Key.Equals(key))
                {
                    V oldValue = entry.Value;
                    entry.Value = value;
                    return oldValue;
                }
                else if (entry.Equals(DEFUNCT) || entry == null)
                {
                    if (!firstAvailableSlot.HasValue)
                        firstAvailableSlot = i;
                    if (entry == null)
                    {
                        _hashTable[i] = new Entry<K, V>(key, value);
                        n++;
                        return default(V);
                    }
                }
                i = (i + 1) % _capacity;
            } while (i != h);

            return default(V);//This statement will never be executed since if if or else must be executed at some point due to Resizing
        }

        public override V BucketRemove(int h, K key)
        {
            var slot = FindSlotForExistingKey(h, key);
            if (slot.HasValue)
            {
                var old = _hashTable[slot.Value].Value;
                _hashTable[slot.Value] = DEFUNCT;
                return old;
            }
            return default(V);
        }

        private int? FindSlotForExistingKey(int h,K key)
        {
            var i = h;
            do
            {
                var entry = _hashTable[i];
                if (entry.Key.Equals(key))
                {
                    return i;
                }
                i = (i + 1) % _capacity;

            } while (i != h);
            return null;
        }

        private int? FindSlotForExistingKeyQuadratic(int h, K key)
        {
            var i = h;
            var j = 1;
            do
            {
                var entry = _hashTable[i];
                if (entry.Key.Equals(key))
                {
                    return i;
                }
                j++;
                i = (h + j*j) % _capacity;

            } while (j<_capacity);
            return null;
        }

        public override bool ContainsKey(int h, K key)
        {
            return FindSlotForExistingKey(h,key).HasValue;
        }

        public override void CreateTable()
        {
            _hashTable = new List<Entry<K, V>>(_capacity);
        }
    }
}
