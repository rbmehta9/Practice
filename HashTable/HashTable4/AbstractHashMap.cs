using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public abstract class AbstractHashMap<K,V> : AbstractMap<K,V>
    {
        protected int _capacity;
        protected int _primefactor;
        protected int n;
        private int _scale;
        private int _shift;

        public AbstractHashMap(int capacity,int primefactor)
        {
            _capacity = capacity;
            _primefactor = primefactor;
            var random = new Random();
            _scale = random.Next(_primefactor - 1) + 1;
            _shift = random.Next(_primefactor);
            CreateTable();
        }

        public AbstractHashMap(int capacity) : this(capacity, 109345121) { }

        public AbstractHashMap() : this(17) { }

        public override int Size
        {
            get
            {
                return n;
            }
        }

        private int GetHashCode(K key)
        {
            return (Math.Abs(key.GetHashCode() * _scale + _shift) % _primefactor) % _capacity;
        }

        public override V Get(K key)
        {
            return BucketGet(this.GetHashCode(key), key);
        }

        public override V Put(K key, V value)
        {
            var V = BucketPut(this.GetHashCode(key),key,value);
            if(n>_capacity/2)
            {
                ReSize(2 * _capacity);
            }
            return V;
        }

        public override V Remove(K key)
        {
            return BucketRemove(this.GetHashCode(key), key);
        }

        private void ReSize(int capacity)
        {
            var iterator = EntrySet.Iterator;
            
            var list =new  List<Entry<K, V>>();
            while(iterator.HasNext)
            {
                var entry = iterator.Next;
                list.Add(entry);

            }

            _capacity = capacity;
            CreateTable();
            n = 0;
            foreach(var entry in list)
            {
                Put(entry.Key, entry.Value);
            }
        }

        public override bool ContainsKey(K key)
        {
            return ContainsKey(this.GetHashCode(key), key);
        }

        public abstract V BucketGet(int h, K key);
        public abstract V BucketPut(int h, K key, V value);

        public abstract V BucketRemove(int h, K key);

        public abstract bool ContainsKey(int h, K key);
        public abstract void CreateTable();


    }
}
