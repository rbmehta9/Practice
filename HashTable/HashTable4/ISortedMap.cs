using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public interface ISortedMap<K, V>
    {
        Entry<K, V> First();
        Entry<K, V> Last();

        Entry<K, V> Ceiling(K key);

        Entry<K, V> Floor(K key);

        Entry<K, V> Higher(K key);

        Entry<K, V> Lower(K key);

        IIterable<Entry<K, V>> SubMap(K key1, K key2);
    }
}
