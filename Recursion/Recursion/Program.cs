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

            //var root = new TreeNode(3);
            //root.left = new TreeNode(9);
            //root.right = new TreeNode(20);
            //root.right.left = new TreeNode(15);
            //root.right.left = new TreeNode(7);

            //var pow = new Power().MyPow(0.00001, 2147483647);

            //var pow = new Power().MyPow(2, 15);

            //var l1 = new ListNode(1);
            //l1.next = new ListNode(2);
            //l1.next.next = new ListNode(4);

            //var l2 = new ListNode(3);
            //l2.next = new ListNode(7);
            //l2.next.next = new ListNode(8);
            //l2.next.next.next = new ListNode(9);

            //var l1 = new ListNode(1);
            //l1.next = new ListNode(2);
            //l1.next.next = new ListNode(4);

            //var l2 = new ListNode(1);
            //l2.next = new ListNode(3);
            //l2.next.next = new ListNode(4);
            //l2.next.next.next = new ListNode(9);

            //var node = new Merge().MergeTwoListsRecursion(l1, l2);

            //var val = new KGrammer().KthGrammar(30, 434991989);
            //var headA = new ListNode(4);
            //headA.next = new ListNode(1);
            //headA.next.next = new ListNode(8);
            //headA.next.next.next = new ListNode(4);
            //headA.next.next.next.next = new ListNode(5);

            //var headB = new ListNode(5);
            //headB.next = new ListNode(0);
            //headB.next.next = new ListNode(1);
            //headB.next.next.next = headA.next.next;
            //headB.next.next.next.next = headA.next.next.next;
            //headB.next.next.next.next.next = headA.next.next.next.next;

            //non intersecting
            //var headA = new ListNode(2);
            //headA.next = new ListNode(6);
            //headA.next.next = new ListNode(4);

            //var headB = new ListNode(1);
            //headB.next = new ListNode(5);

            //var node = new LinkedList().GetIntersectionNode1(headA, headB);

            var head = new ListNode(4);
            head.next = new ListNode(1);
            head.next.next = new ListNode(8);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(9);
            head.next.next.next.next.next.next = new ListNode(10);
            var node = new LinkedList().RemoveNthFromEnd(head, 3);
        }
    }
}
