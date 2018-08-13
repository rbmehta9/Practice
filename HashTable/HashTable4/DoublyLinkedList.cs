using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class DoublyLinkedList<E> : IPositionalList<E>
    {
        private int _size = 0;

        private Node<E> _head = new Node<E>(default(E));
        private Node<E> _tail = new Node<E>(default(E));

        private Node<E> Validate(INode<E> p)
        {
            if (p is Node<E>)
                return (Node<E>)p;

            throw new InvalidCastException();
        }
        public DoublyLinkedList()
        {
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        public bool isEmpty
        {
            get
            {
                return _size == 0;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        private INode<E> Position(Node<E> node)
        {
            if (node == _head || node == _tail)
                return null;

            return node;
        }

        private Node<E> AddBetween(Node<E> first , Node<E> second,E element)
        {
            var node = new Node<E>(element);
            node.Next = second;
            node.Prev = first;
            first.Next = node;
            second.Prev = node;
            _size++;
            return node;
        }

        public INode<E> AddAfter(INode<E> p, E element)
        {
            var node = Validate(p);
            return AddBetween(node, node.Next, element);
        }

        public INode<E> AddBefore(INode<E> p, E element)
        {
            var node = Validate(p);
            return AddBetween(node.Prev, node, element);
        }

        public INode<E> AddFirst(E element)
        {
            return AddBetween(_head, _head.Next, element);
        }

        public INode<E> AddLast(E element)
        {
            return AddBetween(_tail.Prev, _tail, element);
        }

        public INode<E> After(INode<E> p)
        {
            return Position(Validate(p).Next);
        }

        public INode<E> Before(INode<E> p)
        {
            return Position(Validate(p).Prev);
        }

        public INode<E> First()
        {
            return Position(_head.Next);
        }

        public INode<E> Last()
        {
            return Position(_tail.Prev);
        }

        public E Remove(INode<E> p)
        {
            //This is not needed since this class should never return a  head or tail hence it 
            //will never be exposed
            //if (p == _head || p == _tail)
            //    throw new ArgumentException("Node cannot be a head or tail");
            var node = Validate(p);
            var predecessor = node.Prev;
            var successor = node.Next;
            predecessor.Next = successor;
            successor.Prev = predecessor;
            _size--;
            return node.Element;
        }

        public E Set(INode<E> p, E element)
        {
            var old = p.Element;
            p.Element = element;
            return old;
        }
    }
}
