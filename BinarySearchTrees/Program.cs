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
    class Program
    {
        private static Node root;

        public static Node Insert(int key, string Value, Node node)
        {
            if (node == null)
                return new Node(key, Value);
            else if (key < node.Key)
                node.Left = Insert(key, Value, node.Left);
            else if (key > node.Key)
                node.Right = Insert(key, Value, node.Right);

            return node;

        }

        public static Node InsertWithoutRecursion(int key, string value, Node node)
        {
            Node currentNode = root;
            Node prevNode = null;
            while (currentNode != null)
            {
                if (key == currentNode.Key)
                {
                    currentNode.Value = value;
                    return currentNode;
                }
                else if (key < currentNode.Key)
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Right;
                }
            }

            var newNode = new Node(key, value);
            if (key < prevNode.Key)
                prevNode.Left = newNode;
            else
            {
                prevNode.Right = newNode;
            }

            return newNode;

        }

        public static Node InsertWithoutRecursion1(int key, string value, Node node)
        {
            if (root == null)
            {
                root = new Node(key, value);
                return root;
            }

            Node currentNode = root;
            Node newNode = null;
            while (currentNode != null)
            {
                
                if (key == currentNode.Key)
                {
                    currentNode.Value = value;
                    return currentNode;
                }
                else if (key < currentNode.Key)
                {
                    if (currentNode.Left == null)
                    {
                        newNode = new Node(key, value);
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                        currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        newNode = new Node(key, value);
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                        currentNode = currentNode.Right;
                }
            }

            return newNode;

        }

        public static Node BinarySearchWithoutRecursion(int key, Node node)
        {
            Node currentNode = root;
            while (currentNode != null)
            {
                if (key == currentNode.Key)
                    return currentNode;
                else if(key < currentNode.Key)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return currentNode;
        }

        /// <summary>
        /// Returns the node upon searching the key. if key does not exist returns null
        /// </summary>
        /// <param name="key"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Node BinarySearch(int key, Node node)
        {
            if (node == null || node.Key == key)
                return node;
            else if (key < node.Key)
                return BinarySearch(key, node.Left);

            return BinarySearch(key, node.Right);
        }

        static void Main(string[] args)
        {
            root = new Node(44,"44");
            root.Left = new Node(17, "17");
            root.Left.Left = new Node(8, "8");
            root.Left.Right = new Node(32, "32");
            root.Left.Right.Left = new Node(28, "28");
            root.Left.Right.Left.Left = new Node(21, "21");
            root.Left.Right.Left.Right = new Node(29, "29");

            root.Right = new Node(88, "88");
            root.Right.Left = new Node(65, "65");

            root.Right.Left.Right = new Node(82, "82");
            root.Right.Left.Right.Left = new Node(76, "76");
            root.Right.Left.Right.Left.Right = new Node(80, "80");

            root.Right.Left.Left = new Node(54, "54");

            root.Right.Right = new Node(97, "97");
            root.Right.Right.Left = new Node(93, "93");

            //var searchedNode = BinarySearch(65, root);
            //searchedNode = BinarySearchWithoutRecursion(65, root);
            //searchedNode = BinarySearchWithoutRecursion(68, root);

            var node = InsertWithoutRecursion1(68, "68", root);
        }
    }
}
