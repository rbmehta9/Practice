using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class SwapNodesRecursion
    {
        public ListNode SwapPairs(ListNode head)
        {
            var currentNode = swap(null, ref head);
            return head;
        }
        private ListNode swap(ListNode N, ref ListNode head)
        {
            if (head == null)
                return null;
            ListNode first;
            ListNode second;
            if (N == null)
                first = head;
            else if (N.next == null)
                return null;
            else
                first = N.next;

            if (first.next == null)
                return null;

            second = first.next;
            first.next = second.next;
            second.next = first;
            if (N == null) head = second;
            else
                N.next = second;

            return swap(first, ref head);

        }
    }
}
