using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    /// <summary>
    /// Returns the node upon searching the key. if key does not exist returns null
    /// </summary>
    /// <param name="key"></param>
    /// <param name="node"></param>
    /// <returns></returns>
    public static class BinarySearch
    {
        public static Node root;
        public static Node Search(int key, Node node)
        {
            if (node == null || node.Key == key)
                return node;
            else if (key < node.Key)
                return Search(key, node.Left);

            return Search(key, node.Right);
        }

        public static Node BinarySearchWithoutRecursion(int key, Node node)
        {
            Node currentNode = root;
            while (currentNode != null)
            {
                if (key == currentNode.Key)
                    return currentNode;
                else if (key < currentNode.Key)
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


    }

}
