using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class Node<E> : INode<E>
    {
        public Node(E element)
        {
            Element = element;
        }
        public Node<E> Next { get; set; }
        public Node<E> Prev { get; set; }
        public E Element
        {
            get;set;
        }
    }
}
