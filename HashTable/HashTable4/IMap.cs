using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public interface IMap<K,V>
    {
        V Get(K key);
        V Put(K key, V value);

        V Remove(K key);

        int Size { get; }

        bool IsEmpty { get; }

        bool ContainsKey(K key);

        IIterable<Entry<K,V>> EntrySet { get; }

        IIterable<K> KeySet { get;}

        IIterable<V> ValueSet { get;}

    }
}
