using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Constructed skewed binary tree is  
                10  
               /  
              8  
             /  
            7  
           /  
          6  
         /  
        5   */

            //BalancedBST.Root = new Node(10);
            //var root = BalancedBST.Root;
            //root.Left = new Node(8);
            //root.Left.Left = new Node(7);
            //root.Left.Left.Left = new Node(6);
            //root.Left.Left.Left.Left = new Node(5);
            //BalancedBST.InOrder(root);
            //BalancedBST.BuildTree();
            //Console.WriteLine("Inorder traversal of balanced BST is :");
            //BalancedBST.InOrder(root);

            BalancedBST.Root = new Node(1);
            var root = BalancedBST.Root;
            root.Left = new Node(2);
            root.Right = new Node(3);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);
            //root.Right.Left = new Node(6);
            root.Right.Right = new Node(7);
            var a = BalancedBST.Connect1(root);
        }
    }
}
