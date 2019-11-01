using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var root = BinarySearch.root;
            root = new Node(44, "44");
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

            var searchedNode = BinarySearch.Search(65, root);
            searchedNode = BinarySearch.BinarySearchWithoutRecursion(65, root);
            searchedNode = BinarySearch.BinarySearchWithoutRecursion(68, root);

            var node = BinarySearch.InsertWithoutRecursion1(68, "68", root);
        }
    }
}
