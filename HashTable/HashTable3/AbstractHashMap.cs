using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public abstract class AbstractHashMap<K, V> : AbstractMap<K, V>
    {
        protected int _capacity;
        protected int n = 0;
        private int _primeFactor;
        private int _scale;
        private int _shift;
        public AbstractHashMap(int capacity,int primefactor)
        {
            _capacity = capacity;
            _primeFactor = primefactor;
            var random = new Random();
            _scale = random.Next(_primeFactor - 1) + 1;
            _shift = random.Next(_primeFactor);
            CreateTable();
        }

        public AbstractHashMap(int capacity): this(capacity, 109345121) { }


        public AbstractHashMap() : this(17) { }


        public override V Get(K key)
        {
            return bucketGet(GetHashCode(key),key);
        }

        public override V Put(K key, V value)
        {
            var V = bucketPut(this.GetHashCode(key),key,value);
            if (n > _capacity / 2)
                Resize(2 * _capacity - 1);

            return V;
        }

        public override V Remove(K key)
        {
            return bucketRemove(this.GetHashCode(key),key);
        }

        private void Resize(int newCapacity)
        {
            var buffer = new List<KeyValuePair<K,V>>(n);
            var entrySetEnumerator = entrySet().GetIterator();
            while(entrySetEnumerator.HasNext())
            {
                var kvp = entrySetEnumerator.Next();
                buffer.Add(kvp);
            }

            _capacity = newCapacity;
            CreateTable();
            n = 0;
            for (var i = 0; i < n; i++)
                Put(buffer[i].Key, buffer[i].Value);
            
        }

        public override int size()
        {
            return n; 
        }

        private int GetHashCode(K key)
        {
            return (int)((Math.Abs(key.GetHashCode() * _scale + _shift) % _primeFactor) % _capacity);
        }

        public abstract void CreateTable();
        public abstract V bucketGet(int hash, K key);

        public abstract V bucketPut(int hash, K key, V value);

        public abstract V bucketRemove(int hash, K key);
    }
}
