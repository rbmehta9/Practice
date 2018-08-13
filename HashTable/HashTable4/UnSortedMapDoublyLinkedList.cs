using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class UnSortedMapDoublyLinkedList<K, V> : AbstractMap<K, V>
    {
        private DoublyLinkedList<Entry<K, V>> table = new DoublyLinkedList<Entry<K, V>>();
        public override IIterable<Entry<K, V>> EntrySet
        {
            get
            {
                return new EntrySetIterable(table);
            }
        }

        public override bool ContainsKey(K key)
        {
            var node = FindNode(key);
            return node!=null;
        }

        private class EntrySetIterable : IIterable<Entry<K, V>>
        {
            private DoublyLinkedList<Entry<K, V>> _table;
            public EntrySetIterable(DoublyLinkedList<Entry<K, V>> table)
            {
                _table = table;
            }
            public IIterator<Entry<K, V>> Iterator
            {
                get
                {
                    return new EntrySetIterator(_table);
                }
            }
        }

        private class EntrySetIterator : IIterator<Entry<K, V>>
        {
            private DoublyLinkedList<Entry<K, V>> _table;
            public EntrySetIterator(DoublyLinkedList<Entry<K,V>> table)
            {
                _table = table;
                currentNode = _table.First();
            }
            private INode<Entry<K, V>> currentNode  ;
            private bool isStart = false;
            public bool HasNext
            {
                get
                {
                    if (!isStart)
                    {
                        return currentNode != null;
                    }
                    else
                    {
                        var nextNode = _table.After(currentNode);
                        return nextNode != null;
                    }

                    

                }
            }

            public Entry<K, V> Next
            {
                get
                {
                    if (isStart)
                    {
                        currentNode = _table.After(currentNode);
                        if (currentNode == null)
                            throw new Exception("No next node");
                    }
                    else
                        isStart = true;
                    return currentNode.Element;
                }
            }
        }

        public override int Size
        {
            get
            {
                return table.Size;
            }
        }

        private INode<Entry<K,V>> FindNode(K key)
        {
            var node = table.First();
            while (node!=null)
            {
                if (node.Element.Key.Equals(key))
                    return node;
                node = table.After(node);
            }

            return null;
        }

        public override V Get(K key)
        {
            var node = FindNode(key);
            if (node == null)
                return default(V);
            return node.Element.Value;
        }

        public override V Put(K key, V value)
        {
            var node = FindNode(key);
            if (node == null)
            {
                var entry = new Entry<K, V>(key, value);
                table.AddLast(entry);
                return default(V);
            }

            var oldValue = node.Element.Value;
            node.Element.Value = value;
            return oldValue;
        }

        public override V Remove(K key)
        {
            var node = FindNode(key);
            if (node == null)
                return default(V);
            var oldValue = node.Element.Value;
            table.Remove(node);
            return oldValue;
        }
    }
}
