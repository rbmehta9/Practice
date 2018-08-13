using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable1
{
    public class Node
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Node Next { get; set; }
    }
    public class HashTable
    {

        private Node[] Array = new Node[5];

        private int Hash(string key)
        {
            var sum = 0;
            foreach (var ch in key)
            {
                sum += ch;
            }

            return sum % 5;
        }
        public void Add(string key, string value)
        {
            var node = new Node() { Key = key, Value = value };
            var index = Hash(key);
            if (Array[index] == null)
                Array[index] = node;
            else
            {
                var iterator = Array[index];
                while (iterator.Next != null)
                    iterator = iterator.Next;
                iterator.Next = node;
            }
        }

        public void Remove(string key)
        {
            var index = Hash(key);
            if (Array[index] == null)
                throw new Exception("Cannot delete a Key that does not exist");
            else
            {
                var iterator = Array[index];
                Node prev = null;
                while (iterator != null)
                {
                    if (iterator.Key == key)
                    {
                        if (iterator == Array[index])
                            Array[index] = iterator.Next;
                        else
                        {
                            prev.Next = iterator.Next;
                        }
                        break;
                    }
                    prev = iterator;
                    iterator = iterator.Next;
                }
            }
        }

        public string GetValue(string key)
        {

            var index = Hash(key);
            if (Array[index] == null)
                throw new Exception("Key not found");
            else
            {
                var iterator = Array[index];
                while (iterator != null)
                {
                    if (iterator.Key == key)
                    {
                        return iterator.Value;
                    }
                    iterator = iterator.Next;
                }

                throw new Exception("Key not found");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                //var hashTable = new HashTable1.HashTable();
                //hashTable.Add("abcde", "str1");
                //hashTable.Add("aedcb", "str2");
                //hashTable.Add("aedbc", "str3");
                //hashTable.Add("fghkk", "str4");
                //hashTable.Remove("aedcb");
                //var value = hashTable.GetValue("aedcb");
                //var i = 98;
                //var left = i << 5;
                //var right = i >> 27;

                var str = "dasiojknsdiaohdkasdhakjsdnaksjdn";
                uint h = 0;
                for(var i=0;i<str.Length;i++)
                {
                    h = h << 5 | h >> 27;
                    h += (uint)str[i];
                }
                
            }
        }
    }
}
