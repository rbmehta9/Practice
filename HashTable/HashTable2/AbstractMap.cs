using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable2
{
    public abstract class AbstractMap<K, V> : IMap<K,V>
    {
        public Interable<K> Keys()
        {
            throw new NotImplementedException();
        }

        public Interable<KeyValuePair<K, V>> KeyValuePairs()
        {
            throw new NotImplementedException();
        }

        public Interable<V> Values()
        {
            throw new NotImplementedException();
        }

        public V Add(K key, V value)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            V result = default(V);
            var kvpEnumerator = KeyValuePairs().GetIterator();
            while(kvpEnumerator.MoveNext())
            {
                if (kvpEnumerator.Current.Key.Equals(key))
                    result = kvpEnumerator.Current.Value;
            }

            return result;
        }

        public bool IsEmpty()
        {
            return size() == 0;
        }

        public V Put(K key, V value)
        {
            throw new NotImplementedException();
        }

        public V Remove(K key)
        {
            throw new NotImplementedException();
        }

        public abstract int size();
        
    }
}
