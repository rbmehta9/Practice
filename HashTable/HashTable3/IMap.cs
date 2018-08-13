using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public interface IMap<K,V>
    {
        int size();
        bool isEmpty();

        V Get(K key);

        V Put(K key, V value);

        V Remove(K key);

        Iterable<KeyValuePair<K,V>> entrySet();

        Iterable<K> KeySet();

        Iterable<V> ValueSet();
    }
}
