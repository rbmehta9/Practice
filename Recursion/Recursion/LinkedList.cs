using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class LinkedList
    {
        public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;
            ListNode currentA = headA;
            ListNode currentB = headB;

            while (currentA != currentB)
            {
                currentA = currentA != null ? currentA.next : headB;
                currentB = currentB != null ? currentB.next : headA;
            }

            return currentB;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode ptr1 = head;
            ListNode ptr2 = head;
            for(var i = 0; i<n+1;i++)
            {
                if(ptr2 == null)
                {
                    head = head.next;
                    return head;
                }
                ptr2 = ptr2.next;
            }

            while(ptr2 != null)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            ptr1.next = ptr1.next.next;

            return head;

        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var currentNodeA = headA;
            var currentNodeB = headB;
            int sizeA = 0;
            int sizeB = 0;
            while (currentNodeA != null || currentNodeB != null)
            {
                if(currentNodeA != null)
                {
                    sizeA++;
                    currentNodeA = currentNodeA.next;
                }

                if (currentNodeB != null)
                {
                    sizeB++;
                    currentNodeB = currentNodeB.next;
                }
            }

            ListNode startPtrA = headA;
            ListNode startPtrB = headB;
            if(sizeB > sizeA)
            {
                for(var i = 0; i< sizeB - sizeA;i++)
                    startPtrB = startPtrB.next;

            }
            else if(sizeA > sizeB)
            {
                for (var i = 0; i < sizeA - sizeB; i++)
                    startPtrA = startPtrA.next;
            }

            while(startPtrA != null)
            {
                if (startPtrA == startPtrB)
                    return startPtrA;

                startPtrA = startPtrA.next;
                startPtrB = startPtrB.next;
            }

            return null;

        }
    }
}
