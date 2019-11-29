using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    

    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node left { get; set; }
            public Node right{ get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        static bool isUniValTree(Node node)
        {
            if (node == null)
                return true;

            var isUniValLeft = isUniValTree(node.left);
            var isUniValRight = isUniValTree(node.right);

            if (isUniValLeft && isUniValRight &&
                (node.left == null || node.left.Value == node.Value) &&
                (node.right == null || node.right.Value == node.Value))
            {
                numofUniValTrees++;
                return true;
            }

            return false;
        }

        static bool IsValidBST(Node node)
        {
            var currentNode = node;
            Node prevVisitedNode = null;
            while (stack.Count > 0 || currentNode!=null)
            {
                var tempNode = currentNode;
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.left;
                }

                var poppedNode = stack.Pop();
                if (poppedNode.Value <= prevVisitedNode.Value)
                    return false;

                prevVisitedNode = poppedNode;
                currentNode = poppedNode.right;

            }

            return true;

        }

        private static int numofUniValTrees;

        static void InOrder(Node node)
        {
            if (node == null)
                return;

            InOrder(node.left);
            Console.WriteLine($"Value is {node.Value}");
            InOrder(node.right);
        }

        static void InOrderWithoutRecursion()
        {
            var node = root;
            TraverseLeftOnlyAndPushOnStack(node);
            Node currentStackELement = null;
            do
            {
                currentStackELement = stack.Peek();
                stack.Pop();
                Console.WriteLine($"{currentStackELement.Value}");
                if (currentStackELement.right != null)
                    TraverseLeftOnlyAndPushOnStack(currentStackELement.right);

            } while (stack.Count > 0 || currentStackELement.right != null);
        }

        static void InOrderWithoutRecursion1()
        {
            var node = root;
            while (node != null || stack.Any())
            {
                TraverseLeftOnlyAndPushOnStack(node);
                node = stack.Peek();
                stack.Pop();
                Console.WriteLine($"{node.Value}");
                node = node.right;
            }
        }

        static void PreOrder(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine($"Value is {node.Value}");
            PreOrder(node.left);
            PreOrder(node.right);
        }

        static void PreOrderWithoutRecursion()
        {
            var node = root;
            while (node != null || stack.Any())
            {
                
                //TraverseLeftOnlyAndPushOnStack(node);
                var currentNode = node;
                while (currentNode != null)
                {
                    Console.WriteLine($"{currentNode.Value}");
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                node = stack.Peek();
                stack.Pop();
                
                node = node.right;
            }
        }

        static void PostOrder(Node node)
        {
            if (node == null)
                return;

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine($"Value is {node.Value}");
        }

        static void PostOrderWithoutRecursion()
        {
            var currentNode = root;
            Node lastNode = null;
            while (true)
            {
                while (currentNode!=null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Peek();

                if (currentNode != null && currentNode.right != null)
                    currentNode = currentNode.right;
                else
                {
                    Node prevNode = null;
                    while (true)
                    {
                        lastNode = stack.Peek();
                        if (lastNode.right == null || lastNode.right == prevNode)
                        {
                            Console.WriteLine($"Value is {lastNode.Value}");
                            stack.Pop();
                            prevNode = lastNode;
                            if(!stack.Any())
                                break;
                        }
                        else
                        {
                            currentNode = lastNode.right;
                            break;
                        }
                    }

                    if(prevNode == root)
                        break;

                    
                }

            }

            
        }

        public static IList<int> PostorderTraversal(Node root)
        {
            var output = new List<int>();
            var currentNode = root;
            var stack = new Stack<Node>();
            Node prevPoppedNode = null;
            while (stack.Count > 0 || currentNode != null)
            {
                var tempNode = currentNode;
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.left;
                }

                var lastNode = stack.Peek();
                if (lastNode.right == null || lastNode.right == prevPoppedNode)
                {
                    stack.Pop();
                    output.Add(lastNode.Value);
                    prevPoppedNode = lastNode;
                }

                if (lastNode == root && stack.Count == 0)
                    break;

                if(stack.Peek() == lastNode)
                 currentNode = lastNode.right;
                else
                {
                    currentNode = null;
                }

            }

            return output;
        }

        static Node TraverseLeftOnlyAndPushOnStack(Node parentNode)
        {
            if (parentNode == null)
                return null;

            Node currentNode = parentNode;
            Node previousNode = null;
            while (currentNode != null)
            {
                stack.Push(currentNode);
                previousNode = currentNode;
                currentNode = currentNode.left;
            }

            return previousNode;
        }

        static void DifferentOrder(Node node)
        {
            if(node == null) return;

            var queue = new Queue<Node>();
            queue.Enqueue(node);
            
            while (queue.Count>0)
            {
                var temp = queue.Peek();
                queue.Dequeue();

                Console.WriteLine($"Value is {temp.Value}");
                if (temp.left != null)
                    queue.Enqueue(temp.left);

                if (temp.right != null)
                    queue.Enqueue(temp.right);
            }
            
        }

        //Do a levelorder/BFS traversal and if a node has a left node available then insert the newnode or if the
        //node has a rightnode available then insert a newnode
        static void Insert(int value)
        {
            var newNode = new Node(value);
            var currentNode = root;
            var queue = new Queue<Node>();
            queue.Enqueue(currentNode);
            while (queue.Any())
            {
                var temp = queue.Peek();
                queue.Dequeue();
                if (temp.left == null)
                    temp.left = newNode;
                else if (temp.right == null)
                {
                    temp.right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(temp.left);
                    queue.Enqueue(temp.right);
                }

                //Console.WriteLine($"Queue size {queue.Count}");
            }
        }

        static IList<IList<int>> LevelOrderTraversal()
        {
            var output = new List<IList<int>>();
            var currentNode = root;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            Node firstNextLevelNode = root;
            while (queue.Any())
            {
                var firstNode = queue.Dequeue();
                IList<int> currentList = null;
                if (firstNode == firstNextLevelNode)
                {
                    currentList = new List<int>();
                    output.Add(currentList);
                }
                else
                {
                    currentList = output[output.Count - 1];
                }

                currentList.Add(firstNode.Value);
                

                if (firstNode.left != null && firstNode.right != null)
                {
                    queue.Enqueue(firstNode.left);
                    queue.Enqueue(firstNode.right);
                    if(firstNextLevelNode == null || firstNode == firstNextLevelNode)
                    firstNextLevelNode = firstNode.left;
                }
                else if (firstNode.left != null)
                {
                    queue.Enqueue(firstNode.left);
                    if (firstNextLevelNode == null || firstNode == firstNextLevelNode)
                        firstNextLevelNode = firstNode.left;
                }
                else if (firstNode.right != null)
                {
                    queue.Enqueue(firstNode.right);
                    if (firstNextLevelNode == null || firstNode == firstNextLevelNode)
                        firstNextLevelNode = firstNode.right;
                }
                else
                {
                    if (firstNextLevelNode == null || firstNode == firstNextLevelNode)
                        firstNextLevelNode = null;
                }

                

            }

            return output;
        }

        static IList<IList<int>> LevelOrderTraversal1()
        {
            var output = new List<IList<int>>();
            var currentNode = root;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var lst = new List<int>();
                output.Add(lst);
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var firstNodeInQueue = queue.Dequeue();
                    lst.Add(firstNodeInQueue.Value);
                    if (firstNodeInQueue.left != null)
                        queue.Enqueue(firstNodeInQueue.left);
                    if (firstNodeInQueue.right != null)
                        queue.Enqueue(firstNodeInQueue.right);

                }


            }

            return output;
        }

        static void Delete(int key)
        {
            var currentNode = root;
            Node nodeToBeDeleted = null;
            Node poppedNode = null;
            while (stack.Any() || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    if (currentNode.Value == key)
                        nodeToBeDeleted = currentNode;
                    currentNode = currentNode.left;
                }

                poppedNode = stack.Pop();
                currentNode = poppedNode.right;
                
            }

            var bottomMostAndRightMostNode = poppedNode;
            nodeToBeDeleted.Value = poppedNode.Value;
            DeleteBottomMostAndRightMostNode(bottomMostAndRightMostNode);

        }

        static void DeleteBottomMostAndRightMostNode(Node bottomMostAndRightMostNode)
        {
            var currentNode = root;
            Node poppedNode = null;
            while (stack.Any() || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                poppedNode = stack.Pop();
                if (poppedNode.left == bottomMostAndRightMostNode)
                {
                    poppedNode.left = null;
                    break;
                }
                else if(poppedNode.right == bottomMostAndRightMostNode)
                {
                    poppedNode.right = null;
                    break;
                }
                else
                {
                    currentNode = poppedNode.right;
                }

            }
        }

        static bool IsSymmetric(Node leftNode, Node rightNode)
        {
            if (leftNode == null && rightNode == null)
                return true;
            else if (leftNode == null || rightNode == null)
                return false;
            return leftNode.Value == rightNode.Value &&
                   IsSymmetric(leftNode.left, rightNode.right) &&
                   IsSymmetric(leftNode.right, rightNode.left);

        }

        static bool IsSymmetric(Node node)
        {
            if (node == null)
                return true;

            return IsSymmetric(node.left, node.right);
        }

        static Node root;

        static Stack<Node> stack = new Stack<Node>();
        static void Main(string[] args)
        {
            //example 1
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.left.left = new Node(50);
            //root.left.right = new Node(12);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);

            //example 2
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.left.right = new Node(6);
            //root.left.left.right.left = new Node(18);
            //root.left.left.right.right = new Node(19);
            //root.left.left.right.left.right = new Node(25);
            //root.left.right = new Node(12);
            //root.left.right.left = new Node(13);
            //root.left.right.right = new Node(14);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);
            //LevelOrderTraversal1();
            //PreOrder(root);
            //PreOrderWithoutRecursion();
            //PostOrder(root);
            //Console.WriteLine("Without Recursion");
            //PostOrderWithoutRecursion();
            //Console.WriteLine("Before Insert Inorder");
            //InOrder(root);
            //InOrderWithoutRecursion();
            //InOrderWithoutRecursion1();
            //DifferentOrder(root);
            //Insert(55);
            //Console.WriteLine("After Insert Inorder");
            //InOrder1(root);


            //example 3:left sides tree only
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.left.left = new Node(50);
            //PostOrder(root);
            //PostOrderWithoutRecursion();
            //InOrder(root);
            //InOrderWithoutRecursion();
            //DifferentOrder(root);

            //example 4:right side tree only
            //root = new Node(10);
            //root.right = new Node(11);
            //root.right.right = new Node(7);
            //root.right.right.right = new Node(50);
            //PostOrder(root);
            //PostOrderWithoutRecursion();
            //InOrder(root);
            //InOrderWithoutRecursion();
            //DifferentOrder(root);

            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.right = new Node(12);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);
            //InOrder(root);

            //int key = 11;
            //Delete(key);
            //InOrder(root);

            //Only for unival tree test
            //root = new Node(44);
            //root.left = new Node(32);
            //root.left.left = new Node(32);
            //root.left.left.left = new Node(24);
            //root.left.left.left.left = new Node(24);
            //root.left.left.left.right = new Node(24);

            //root.left.left.right = new Node(26);
            //root.left.left.right.left = new Node(26);
            //root.left.left.right.right = new Node(26);

            //root.right = new Node(55);
            //root.right.left = new Node(48);
            //root.right.left.left = new Node(48);
            //root.right.left.right = new Node(48);

            //root.right.left.left.left = new Node(48);
            //root.right.left.left.right = new Node(48);

            //root.right.left.right.left = new Node(48);
            //root.right.left.right.right = new Node(48);

            //root.right.right = new Node(51);
            //root.right.right.left = new Node(51);
            //root.right.right.right = new Node(51);
            //var isunival = isUniValTree(root);
            //Console.WriteLine($"Number of Unival Trees {numofUniValTrees}");

            //root = new Node(3);
            //root.left = new Node(1);
            //root.left.right = new Node(2);
            //var a = PostorderTraversal(root);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.right = new Node(2);

            //root.left.left = new Node(3);
            //root.right.right =  new Node(3);

            //root.left.right = new Node(4);
            //root.right.left = new Node(4);

            //root.left.left.left = new Node(5);
            //root.right.right.right = new Node(5);

            //root.left.left.right = new Node(6);
            //root.right.right.left = new Node(6);

            //root.left.right.left = new Node(7);
            //root.right.left.right = new Node(7);

            //root.left.right.right = new Node(8);
            //root.right.left.left = new Node(8);
            //var isSymmetric = IsSymmetric(root);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.right = new Node(2);

            //root.left.left = new Node(3);
            //root.right.right = new Node(3);

            //root.left.right = new Node(20);
            //root.right.left = new Node(4);

            //root.left.left.left = new Node(5);
            //root.right.right.right = new Node(5);

            //root.left.left.right = new Node(6);
            //root.right.right.left = new Node(6);

            //root.left.right.left = new Node(7);
            //root.right.left.right = new Node(7);

            //root.left.right.right = new Node(8);
            //root.right.left.left = new Node(8);

            //isSymmetric = IsSymmetric(root);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.right = new Node(3);
            //var isSymmetric = IsSymmetric(root);

            Console.ReadLine();
        }
    }
}
