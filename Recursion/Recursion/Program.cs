using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        public ListNode ReverseList(ListNode head)
        {
            var recursion = new ReverseLinkedListRecursion(head);
            recursion.ReverseList();
            return recursion.Head;
        }
        static void Main(string[] args)
        {
            //var head = new ListNode(1);
            //head.next = new ListNode(2);
            //head.next.next = new ListNode(3);
            //head.next.next.next = new ListNode(4);

            //head = new SwapNodesRecursion().SwapPairs(head);
            //head = new ReverseLinkedList().ReverseList(head);
            //var recursion = new ReverseLinkedListRecursion(head);
            //recursion.ReverseList();

            //var root = new TreeNode(4);
            //root.left = new TreeNode(2);
            //root.right = new TreeNode(7);

            //root.left.left = new TreeNode(1);
            //root.left.right = new TreeNode(3);

            //var node = new BinarySearchRecursion().SearchBST(root, 9);

            //var val = new PascalsTriangle().GetCoefficientMemoization(4, 2);

            //var lst = new PascalsTriangle().GeneratePascalRecursionWithMemoization(4);

            //for (var i = 1; i < 50; i++)
            //{
            //    var a = new ClimbStair().ClimbStairs(i);
            //    var b = new ClimbStair().ClimbStairsRecursion(i);
            //    if(a != b)
            //        break;
            //}

            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.left = new TreeNode(7);

        }
    }
}
