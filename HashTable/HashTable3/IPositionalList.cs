using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    interface IPositionalList<E>
    {
        int size();
        bool isEmpty();
        INode<E> First();
        INode<E> Last();
        INode<E> Before(INode<E> element);
        INode<E> After(INode<E> element);
        INode<E> AddFirst(E element);
        INode<E> AddLast(E element);

        INode<E> AddBefore(INode<E> node ,E element);

        INode<E> AddAfter(INode<E> node, E element);

        E Set(INode<E> node, E element);

        E Remove(INode<E> node);

    }
}
