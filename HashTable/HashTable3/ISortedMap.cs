using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public interface ISortedMap<K,V> : IMap<K,V>
    {
        KeyValuePair<K, V> FirstEntry();
        KeyValuePair<K, V> LastEntry();

        KeyValuePair<K, V> FloorEntry(K key);

        KeyValuePair<K, V> CeilingEntry(K key);

        KeyValuePair<K, V> LowerEntry(K key);
        KeyValuePair<K, V> HigherEntry(K key);

        Iterable<K> SubMap(K key1, K key2);
    }
}
