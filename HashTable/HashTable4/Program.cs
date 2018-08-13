using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable4
{
    class Program
    {
        static void Main(string[] args)
        {
            var singlelinkedList = new SinglyLinkedList<string>();
            singlelinkedList.AddLast("A");
            singlelinkedList.AddLast("B");
            singlelinkedList.AddLast("C");
            singlelinkedList.AddLast("D");
            singlelinkedList.AddLast("E");
            singlelinkedList.AddLast("F");

            //print all element
            var node = singlelinkedList.First();
            while(node!=null)
            {
                Console.WriteLine($"Element {node.Element}");
                node = singlelinkedList.After(node);
            }

            //Reverse the linked list
            //Total Time = O(n) + n*[O(1) + O(1) + O(1)] = O(n)
            var initialLastElement = singlelinkedList.Last(); //O(n)
            var currentFirstElement = singlelinkedList.First();//O(1)
            while(currentFirstElement != initialLastElement)
            {
                singlelinkedList.Remove(currentFirstElement);//Removal of first element is always O(1)
                singlelinkedList.AddAfter(initialLastElement,currentFirstElement);//O(1)
                currentFirstElement = singlelinkedList.First();//O(1)
            }


            //print all
            node = singlelinkedList.First();
            while (node != null)
            {
                Console.WriteLine($"Element {node.Element}");
                node = singlelinkedList.After(node);
            }

        }
    }
}
