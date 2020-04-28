using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            var firstNode = head;
            while(firstNode.next != null)
            {
                var nextNode = firstNode.next;
                firstNode.next = nextNode.next;
                nextNode.next = head;
                head = nextNode;
            }

            return head;

        }
    }

    public class ReverseLinkedListRecursion
    {
        public ListNode Head { get; set; }
        private ListNode  _firstNode;
        public ReverseLinkedListRecursion(ListNode head)
        {
            Head = head;
            _firstNode = head;
        }
        public void ReverseList()
        {
            if (Head == null || _firstNode.next == null)
                return ;

            var nextNode = _firstNode.next;
            _firstNode.next = nextNode.next;
            nextNode.next = Head;
            Head = nextNode;

            ReverseList();

        }
    }
}
