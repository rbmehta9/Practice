using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class Node
    {
        public Node(int key, string value)
        {
            Key = key;
            Value = value;
        }
        public int Key { get; set; }
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

}
