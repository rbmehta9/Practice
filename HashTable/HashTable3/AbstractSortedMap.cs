using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public abstract class AbstractSortedMap<K, V> : AbstractMap<K,V>, ISortedMap<K, V>
    {
        protected IComparer<K> _comparer;
        public AbstractSortedMap(IComparer<K> comparer)
        {
            _comparer = comparer;
        }

        protected int Compare(K key1, K key2)
        {
            return _comparer.Compare(key1, key2);
        }
        public abstract KeyValuePair<K, V> CeilingEntry(K key);

        public abstract KeyValuePair<K, V> FirstEntry();

        public abstract KeyValuePair<K, V> FloorEntry(K key);

        public abstract KeyValuePair<K, V> HigherEntry(K key);

        public abstract KeyValuePair<K, V> LastEntry();

        public abstract KeyValuePair<K, V> LowerEntry(K Key);

        public abstract Iterable<K> SubMap(K key1, K key2);
    }
}
