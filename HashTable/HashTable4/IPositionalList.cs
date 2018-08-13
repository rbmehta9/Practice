using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public interface IPositionalList<E>
    {
        INode<E> First();
        INode<E> Last();
        INode<E> Before(INode<E> p);
        INode<E> After(INode<E> p);

        int Size { get; }

        bool isEmpty { get; }

        INode<E> AddFirst(E element);
        INode<E> AddLast(E element);

        INode<E> AddBefore(INode<E> p, E element);
        INode<E> AddAfter(INode<E> p, E element);

        E Set(INode<E> p, E element);

        E Remove(INode<E> p);
    }
}
