using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBinarySearchTree
{
    public class Node
    {
        public Node(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public Node(int key) : this(key, key.ToString())
        {
            
        }
        public int Key { get; set; }
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
    public static class BalancedBST
    {
        public static Node Root;
        public static Stack<Node> stack = new Stack<Node>();

        public static List<Node> TraverseNodesInOrderAndStoreInArray(Node node)
        {
            var currentNode = node;
            var nodes = new List<Node>();
            while (stack.Any() || currentNode != null)
            {
                var tempNode = currentNode;

                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.Left;
                }

                tempNode = stack.Pop();
                nodes.Add(tempNode);
                currentNode = tempNode.Right;

            }

            return nodes;
        }

        public static Node BuildTreeWithRecursion(List<Node> nodes, int start, int end)
        {
            if (start > end)
                return null;
            var mid = (start + end) / 2;
            var node = nodes[mid];

            node.Left = BuildTreeWithRecursion(nodes, start, mid - 1);
            node.Right = BuildTreeWithRecursion(nodes, mid + 1, end);

            return node;
        }

        /* Function to do preorder traversal of tree */
        public static  void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            
            InOrder(node.Left);
            Console.Write(node.Key + " ");
            InOrder(node.Right);
        }

        public static void BuildTree()
        {
            var nodes = TraverseNodesInOrderAndStoreInArray(Root);
            var node = BuildTreeWithRecursion(nodes, 0, nodes.Count - 1);
        }
    }
}
