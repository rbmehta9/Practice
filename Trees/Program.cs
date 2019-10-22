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
            public Node Parent { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

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

        static void Insert(int value)
        {
            var newNode = new Node(value);
            var currentNode = root;
            var queue = new Queue<Node>();
            queue.Enqueue(currentNode);
            while (queue.Count > 0)
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
            //root.left.left.right.left = new Node(8);
            //root.left.right = new Node(12);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);

            //Console.WriteLine("Before Insert Inorder");
            //InOrder(root);
            //InOrderWithoutRecursion();
            //DifferentOrder(root);
            //Insert(55);
            //Console.WriteLine("After Insert Inorder");
            //InOrder1(root);


            //example 3:left sides tree only
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.left.left = new Node(50);
            //InOrder(root);
            //InOrderWithoutRecursion();
            //DifferentOrder(root);

            //example 4:right side tree only
            root = new Node(10);
            root.right = new Node(11);
            root.right.right = new Node(7);
            root.right.right.right = new Node(50);
            InOrder(root);
            InOrderWithoutRecursion();
            //DifferentOrder(root);

            Console.ReadLine();
        }
    }
}
