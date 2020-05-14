using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Merge
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode currNode = null;
            ListNode head = null;
            while (l1 != null || l2 != null)
            {
                var assignedNode = AssignNode(l1, l2);
                if (currNode == null)
                {
                    currNode = assignedNode;
                    head = assignedNode;
                }
                else
                {
                    currNode.next = assignedNode;
                    currNode = currNode.next;
                }


                if (assignedNode == l1)
                    l1 = l1.next;
                else
                    l2 = l2.next;
            }
            return head;
        }

        public ListNode AssignNode(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            else if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;

            return (l1.val < l2.val) ? l1 : l2;
        }

        public ListNode MergeTwoListsRecursion(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            else if(l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoListsRecursion(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoListsRecursion(l1, l2.next);
                return l2;
            }
        }


    }
}
