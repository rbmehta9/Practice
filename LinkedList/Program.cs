using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;
            var skips = 1;
            var currNode = head;
            var b = true;
            while(b)
            {
                b = RepointNode(ref currNode, skips);
                skips++;
            }

            return head;
        }

        private static bool RepointNode(ref ListNode currNode, int skips)
        {
            var newCurrentCntr = currNode;
            var skipCntr = 1;
            var t = currNode.next;
            while(skipCntr <= skips && newCurrentCntr != null)
            {
                newCurrentCntr = newCurrentCntr.next;
                skipCntr++;
            }

            if (skipCntr - 1 < skips || newCurrentCntr == null || newCurrentCntr.next == null)
                return false;

            currNode.next = newCurrentCntr.next;
            newCurrentCntr.next = newCurrentCntr.next.next;
            currNode.next.next = t;
            currNode = currNode.next;
            return true;
        }

        public static ListNode OddEvenList1(ListNode head)
        {
            if (head == null)
                return head;

            var oddElementPtr = head;
            var evenElementPtr = head.next;
            var initElementPtr = head.next;
            while(evenElementPtr != null && evenElementPtr.next != null)
            {
                oddElementPtr.next = evenElementPtr.next;
                evenElementPtr.next = evenElementPtr.next.next;
                oddElementPtr.next.next = initElementPtr;
                oddElementPtr = oddElementPtr.next;
                evenElementPtr = evenElementPtr.next;
            }

            return head;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var l1ptr = l1;
            var l2ptr = l2;
            ListNode head = null;
            ListNode prevNode = null;
            var isCarryOver = false;
            while(l1ptr != null || l2ptr != null || isCarryOver)
            {
                var node = new ListNode();
                var sum = ((l1ptr == null) ? 0 : l1ptr.val) + ((l2ptr == null) ? 0 : l2ptr.val);
                if (isCarryOver)
                    sum++;
                if(sum > 9)
                {
                    node.val = sum - 10;
                    isCarryOver = true;
                }
                else
                {
                    node.val = sum;
                    isCarryOver = false;
                }

                if (head == null)
                    head = node;
                else
                    prevNode.next = node;

                prevNode = node;

                if (l1ptr != null)
                    l1ptr = l1ptr.next;

                if (l2ptr != null)
                    l2ptr = l2ptr.next;

            }

            

            return head;
        }

        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;
            
            var cntr = 0;
            var currentNode = head;
            while(currentNode != null)
            {
                currentNode = currentNode.next;
                cntr++;
            }

            var size = cntr;
            var firstHalfEndIndex = size / 2;
            var secondHalfStartIndex = (size % 2 == 0) ? (size / 2) + 1 : (size / 2) + 2;
            Reverse(firstHalfEndIndex);
            cntr = 1;
            currentNode = head;
            while(cntr < secondHalfStartIndex)
            {
                currentNode = currentNode.next;
                cntr++;
            }

            var secondHalfPtr = currentNode;
            var firsthalfPtr = head;
            while(secondHalfPtr != null)
            {
                if (firsthalfPtr.val != secondHalfPtr.val)
                    return false;

                firsthalfPtr = firsthalfPtr.next;
                secondHalfPtr = secondHalfPtr.next;
            }
            return true;

            void Reverse(int index)
            {
                var ctr = 1;
                var firstNode = head;
                while(ctr < index)
                {
                    var t = firstNode.next;
                    firstNode.next = t.next;
                    t.next = head;
                    head = t;
                    ctr++;
                }
            }
        }
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
        public Node(int value)
        {
            val = value;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/linked-list/213/conclusion/1225/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Node Flatten(Node head)
        {
            Flatten(head, null);
            return head;
        }

        public static void Flatten(Node node, Node next)
        {
            if (node == null || (node.next == null && node.child == null))
            {
                if (next != null)
                {
                    node.next = next;
                    next.prev = node;
                }
                return;
            }
            else if (node.child == null)
                Flatten(node.next, next);
            else
            {
                var t = node.next;
                node.next = node.child;
                node.child.prev = node;
                node.child = null;
                Flatten(node.next, t);
                Flatten(t, next);
            }

            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6,new ListNode(7)))))));
            //var head = new ListNode(1);
            //head = null;
            //head = ListNode.OddEvenList1(head);

            //var head = new ListNode(1, new ListNode(0, new ListNode(0)));
            //var isPalindrome = ListNode.IsPalindrome(head);

            //var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            //var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            //var head = ListNode.AddTwoNumbers(l1, l2);

            //var head  = new Node(1);
            //var node2 = new Node(2);
            //var node3 = new Node(3);
            //var node4 = new Node(4);
            //var node5 = new Node(5);
            //var node6 = new Node(6);
            //var node7 = new Node(7);
            //var node8 = new Node(8);
            //var node9 = new Node(9);
            //var node10 = new Node(10);
            //var node11 = new Node(11);
            //var node12 = new Node(12);

            //head.next = node2;
            //node2.prev = head;

            //node2.next = node3;
            //node3.prev = node2;

            //node3.next = node4;
            //node4.prev = node3;

            //node4.next = node5;
            //node5.prev = node4;

            //node5.next = node6;
            //node6.prev = node5;

            //node7.next = node8;
            //node8.prev = node7;

            //node8.next = node9;
            //node9.prev = node8;

            //node9.next = node10;
            //node10.prev = node9;

            //node11.next = node12;
            //node12.prev = node11;

            //node3.child = node7;
            //node8.child = node11;

            var head = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);

            head.next = node2;
            node2.prev = head;

            head.child = node3;

            var a = Node.Flatten(null);
           
        }
    }
}
