using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{

    public class BinarySearchNode
    {
        public Node Parent { get; set; }
        public Node SearchedNode { get; set; }

        public bool? IsLeft
        {
            get { return (Parent == null)? (bool?)null : Parent.Left == SearchedNode; }
        }
    }

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

        public static BinarySearchNode BinarySearchWithRecursionReturnParentChild(int key, Node node)
        {
            var currentNode = node;
            Node parent = null;
            while (currentNode != null)
            {
                if(key == currentNode.Key)
                    break;
                else if (key < currentNode.Key)
                {
                    parent = currentNode;
                    currentNode = currentNode.Left;
                }
                else
                {
                    parent = currentNode;
                    currentNode = currentNode.Right;
                }
            }

            if (currentNode == null)
                return null;

            return new BinarySearchNode
            {
                Parent = parent,
                SearchedNode = currentNode
            };
        }

        public static void DeleteNode(int key)
        {
            var binarySearchNode = BinarySearchWithRecursionReturnParentChild(key, root);
            var searchedNode = binarySearchNode.SearchedNode;

            //external nodes
            if (searchedNode.Left == null || searchedNode.Right == null)
            {
                if (searchedNode.Left == null)
                    AssignToParent(binarySearchNode,searchedNode.Right);
                
                if(searchedNode.Right == null)
                    AssignToParent(binarySearchNode,searchedNode.Left);

                
            }
            else //if both children are internal
            {
                //There are two ways to implement this:
                //1.get max key less than the key to be deleted. i.e. rightmost descendant of the left child of the key  OR
                //2.get least key greater than the key to be deleted i.e. leftmost descendant of the right child of the key
                //we will implement using number 1 above
                var tempNode = searchedNode.Left;
                Node parentTempNode = null;
                while (tempNode.Right != null)
                {
                    parentTempNode = tempNode;
                    tempNode = tempNode.Right;
                }

                var tempbinarySearchNode = new BinarySearchNode()
                {
                    Parent = parentTempNode,
                    SearchedNode = tempNode
                };

                AssignToParent(tempbinarySearchNode, tempNode.Left);
                tempNode.Left = searchedNode.Left;
                tempNode.Right = searchedNode.Right;

                if (searchedNode == root)
                    root = tempNode;
                AssignToParent(binarySearchNode, tempNode);
            }

            DeleteNode(searchedNode);

            void AssignToParent(BinarySearchNode bsn, Node node)
            {
                if(bsn.Parent == null)
                    return;
                if (bsn.IsLeft.Value)
                    bsn.Parent.Left = node;
                else
                    bsn.Parent.Right = node;
            }

            void DeleteNode(Node node)
            {
                if(node == null)
                    return;
                node.Left = null;
                node.Right = null;
            }
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
