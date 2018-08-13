using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable2
{
    //public interface IA
    //{
    //    object Get();
    //}

    //public interface IA<T> : IA
    //{
    //    T Get();
    //}

    //public class A<T> : IA<T>
    //{
    //    public T Get()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    object IA.Get()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public interface IMap<K,V>
    {
        IEnumerable<int> a;
        int size();
        bool IsEmpty();
        V Add(K key, V value);
        V Put(K key, V value);

        V Get(K key);

        V Remove(K key);
        Interable<K> Keys();// { get; set; }
        Interable<V> Values();// { get; set; }

        Interable<KeyValuePair<K, V>> KeyValuePairs();// { get; set; }
    }
}
