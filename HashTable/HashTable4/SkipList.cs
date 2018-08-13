using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class SkipList<K,V> : AbstractMap<K, V>, ISortedMap<K,V>
    {
        private SkipListNode<K, V> _head;
        private SkipListNode<K, V> _tail;
        private IComparer<K> _comparer;
        private Random _random = new Random();
        private int _height = 0;
        private int n = 0;

        public K NegInf { get; set; }
        public K PosInf { get; set; }

        public override IIterable<Entry<K, V>> EntrySet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Size
        {
            get
            {
                return n; 
            }
        }

        public SkipList(IComparer<K> comparer)
        {
            _comparer = comparer;
            CreateNewLevel();
        }

        private SkipListNode<K,V> CreateNegInfNode()
        {
            return new SkipListNode<K, V>(NegInf, default(V));
        }

        private SkipListNode<K, V> CreatePosInfNode()
        {
            return new SkipListNode<K, V>(PosInf, default(V));
        }



        public Entry<K, V> First()
        {
            if (n == 0)
                return null;
            var currentNode = _head;
            while (currentNode != null)
                currentNode = currentNode.Down;

            return currentNode.Next.Entry;

        }

        public Entry<K, V> Last()
        {
            if (n == 0)
                return null;

            var currentNode = _tail;
            while (currentNode != null)
                currentNode = currentNode.Down;

            return currentNode.Prev.Entry;
        }

        public Entry<K, V> Ceiling(K key)
        {
            var currentNode = Find(key);

            if (currentNode.Next == _tail)
                return null;

            if (_comparer.Compare(currentNode.Entry.Key, key) == 0)
                return currentNode.Entry;

            

            return currentNode.Next.Entry;
        }

        public Entry<K, V> Floor(K key)
        {
            var currentNode = Find(key);
            
            if (currentNode == _head)
                return null;

            return currentNode.Entry;
        }

        public Entry<K, V> Higher(K key)
        {
            var currentNode = Find(key);

            if (currentNode.Next == _tail)
                return null;

            return currentNode.Next.Entry;
        }

        public Entry<K, V> Lower(K key)
        {
            var currentNode = Find(key);
            if (currentNode == _head)
                return null;

            if (_comparer.Compare(currentNode.Entry.Key, key) == 0)
                return currentNode.Entry;

            return currentNode.Prev.Entry;

        }

        public IIterable<Entry<K, V>> SubMap(K key1, K key2)
        {
            throw new NotImplementedException();
        }

        public override V Get(K key)
        {
            var node = Find(key);
            if (_comparer.Compare(key, node.Entry.Key) == 0)
                return node.Entry.Value;

            return default(V);
        }

        public override V Put(K key, V value)
        {
            var node = Find(key);
            if(_comparer.Compare(key, node.Entry.Key) == 0)
            {
                var old = node.Entry.Value;
                node.Entry.Value = value;
                return old;
            }

            var prevNewNode = new SkipListNode<K, V>(key, value);
            InsertAfterOnCurrentLevel(node, prevNewNode);
            var i = 1;
            while(_random.NextDouble()<0.5)
            {
                if (i > _height)
                {
                    CreateNewLevel();
                    _height++;
                }

                while (node.Up == null)
                    node = node.Prev;

                node = node.Up;
                var newNode = new SkipListNode<K, V>(key, default(V)); //value only needs to be stored on lowest level
                InsertAfterOnCurrentLevel(node, newNode);
                prevNewNode.Up = newNode;
                newNode.Down = prevNewNode;

                prevNewNode = newNode;

                i++;
            }

            n++;

            return value;


        }

        private void CreateNewLevel()
        {
            var negInfNode = CreateNegInfNode();
            var posInfNode = CreatePosInfNode();
            if (_head != null && _tail!=null)
            {
                _head.Up = negInfNode;
                _tail.Up = posInfNode;
                negInfNode.Down = _head;
                posInfNode.Down = _tail;
            }

            _head = negInfNode;
            _tail = posInfNode;
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        private void InsertAfterOnCurrentLevel(SkipListNode<K,V> prevNode,SkipListNode<K,V> newNode)
        {
            var successorNode = prevNode.Next;
            prevNode.Next = newNode;
            newNode.Prev = prevNode;
            newNode.Next = successorNode;
            successorNode.Prev = newNode;
        }

        public override V Remove(K key)
        {
            var node = Find(key);
            if (_comparer.Compare(node.Entry.Key,key) == 0)
                return default(V);

            var valueofKeyToRemove = node.Entry.Value;
            while(node!=null)
            {
                var prev = node.Prev;
                var successor = node.Next;
                prev.Next = successor;
                successor.Prev = prev;
                var higherNode = node.Up;
                node.Up = null;
                higherNode.Down = null;
                node.Next = null;
                node.Prev = null;
                node = higherNode;
            }

            return valueofKeyToRemove;

        }


        public override bool ContainsKey(K key)
        {
            var node = Find(key);
            return _comparer.Compare(key, node.Entry.Key) == 0;
        }

        private SkipListNode<K,V> Find(K key)
        {
            var currentNode = _head;
            while(currentNode!=null)
            {
                currentNode = FindHighestNodeLessThanAtCurrentLevel(currentNode, key);
                currentNode = currentNode.Down;
            }

            return currentNode;
        }

        private SkipListNode<K,V> FindHighestNodeLessThanAtCurrentLevel(SkipListNode<K,V> startNode,K key)
        {
            var currentNode = startNode;
            //currentnodekey<=key
            while (_comparer.Compare(currentNode.Next.Entry.Key,key) <= 0)
                currentNode = currentNode.Next;

            return currentNode;
        }
    }
}
