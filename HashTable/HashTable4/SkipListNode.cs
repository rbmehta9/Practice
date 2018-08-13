using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class SkipListNode<K,V> 
    {
        //public static K NegInf { get; set; }

        //public static K PosInf { get; set; }
        public SkipListNode(K key, V value)
        {
            //Key = key;
            //Value = value;
            Entry = new Entry<K, V>(key, value);
        }
        //public K Key { get;  }

        //public V Value { get; set; }

        public Entry<K,V> Entry { get; set; }

        public SkipListNode<K,V> Up { get; set; }
        public SkipListNode<K,V> Down { get; set; }
        public SkipListNode<K,V> Next { get; set; }
        public SkipListNode<K,V> Prev { get; set; }

        
    }
}
