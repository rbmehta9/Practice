using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    public class SingleNode<E> : INode<E>
    {
        public SingleNode(E element)
        {
            Element = element;
        }
        public E Element
        {
            get; set;
        }

        public SingleNode<E> Next { get; set; }
    }
}
