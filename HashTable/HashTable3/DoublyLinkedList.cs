using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class DoublyLinkedList<E> : IPositionalList<E>
    {
        private Node<E> _head;
        private Node<E> _tail;
        private int _size = 0;

        public DoublyLinkedList()
        {
            _head = new Node<E>(default(E));
            _tail = new Node<E>(default(E));
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        private INode<E> AddBetween(E element, INode<E> first, INode<E> second)
        {
            var newNode = new Node<E>(element);
            var castNode1 = Validate(first);
            var castNode2 = Validate(second);
            newNode.Next = castNode2;
            newNode.Prev = castNode1;
            castNode1.Next = newNode;
            castNode2.Prev = newNode;
            _size++;
            return newNode;

        }
        public INode<E> AddAfter(INode<E> node, E element)
        {
            var castNode = Validate(node);
            return AddBetween(element, castNode, castNode.Next);
        }

        public INode<E> AddBefore(INode<E> node, E element)
        {
            var castNode = Validate(node);
            return AddBetween(element, castNode.Prev, castNode);

        }

        public INode<E> AddFirst(E element)
        {

            return AddBetween(element, _head, _head.Next);
        }

        public INode<E> AddLast(E element)
        {
            return AddBetween(element, _tail.Prev, _tail);
        }

        //private INode<E> InitEmptyList(E element)
        //{
        //    var newNode = new Node<E>(element);
        //    _head = newNode;
        //    _tail = newNode;
        //    _size++;
        //    return newNode;
        //}

        public INode<E> After(INode<E> element)
        {
            return (Validate(element)).Next;
        }

        public INode<E> Before(INode<E> element)
        {
            return (Validate(element)).Prev;
        }

        public INode<E> First()
        {
            return _head.Next;
        }

        public bool isEmpty()
        {
            return _size == 0;
        }

        public INode<E> Last()
        {
            return _tail.Prev;
        }

        public E Remove(INode<E> node)
        {
            var castNode = Validate(node);
            castNode.Prev.Next = castNode.Next;
            castNode.Next.Prev = castNode.Prev;

            _size--;
            return castNode.Element;
        }

        public E Set(INode<E> node, E element)
        {
            var oldElement = node.Element;
            node.Element = element;
            return oldElement;
        }

        public int size()
        {
            return _size;
        }

        private Node<E> Validate(INode<E> node)
        {
            if (!(node is Node<E>))
                throw new ArgumentException("Cannot cast");

            return (Node<E>)node;
        }

    }
}
