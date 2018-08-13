using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class SinglyLinkedList<E> : IPositionalList<E>
    {
        public SingleNode<E> _head;
        public SingleNode<E> _tail;
        public int _size = 0;

        public int Size
        {
            get
            {
                return _size; ;
            }
        }

        public bool isEmpty
        {
            get
            {
                return _size == 0; ;
            }
        }

        public SinglyLinkedList()
        {
            _head = new SingleNode<E>(default(E));
            _tail = new SingleNode<E>(default(E));
            _head.Next = _tail;
        }

        public INode<E> First()
        {
            return After(_head); 
        }

        private INode<E> Position(INode<E> element)
        {
            if (element == _head || element == _tail)
                return null;

            return element;
        }

        public INode<E> Last()
        {
            return Before(_tail);
        }

        public INode<E> Before(INode<E> p)
        {
            return Position(GetRawNodeBefore(p));
        }

        private INode<E> GetRawNodeBefore(INode<E> p)
        {
            var currentNode = _head;
            while (currentNode.Next != p)
                currentNode = currentNode.Next;

            return currentNode;
        }

        private SingleNode<E> Validate(INode<E> p)
        {
            if (p is SingleNode<E>)
                return (SingleNode<E>)p;

            return null;
        }

        public INode<E> After(INode<E> p)
        {
            return Position(Validate(p).Next); ;
        }

        public INode<E> AddFirst(E element)
        {
            return AddAfter(_head,element);
        }

        public INode<E> AddLast(E element)
        {
            var last = GetRawNodeBefore(_tail);
            return AddAfter(last, element);
        }

        public INode<E> AddBefore(INode<E> p, E element)
        {
            var beforeNode = GetRawNodeBefore(p);
            return AddAfter(beforeNode, element);
        }

        public INode<E> AddAfter(INode<E> p, E element)
        {
            var newNode = new SingleNode<E>(element);
            var firstNode = Validate(p);
            var secondNode = firstNode.Next;
            firstNode.Next = newNode;
            newNode.Next = secondNode;
            return newNode;

        }

        public INode<E> AddAfter(INode<E> p, INode<E> element)
        {
            var newNode = Validate(element);
            var firstNode = Validate(p);
            var secondNode = firstNode.Next;
            firstNode.Next = newNode;
            newNode.Next = secondNode;
            return newNode;
        }

        public E Set(INode<E> p, E element)
        {
            var old = p.Element;
            p.Element = element;
            return old;
        }

        public E Remove(INode<E> p)
        {
            var beforeNode = GetRawNodeBefore(p);
            var firstNode = Validate(beforeNode);
            var secondNode = Validate(p).Next;
            firstNode.Next = secondNode;
            Validate(p).Next = null;
            return p.Element;
        }
    }
}
