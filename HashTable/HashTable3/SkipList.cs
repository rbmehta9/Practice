using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class SkipList
    {
        public int Height { get; set; }
        private int n { get; set; } //size
        private Random random;
        private SkipListEntry _head;
        private SkipListEntry _tail;
        //private const string negInf = "-00";
        //private const string posInf = "+00";
        public SkipList()
        {
            Height = 0;
            n = 0;
            CreateNewLevel();
            //_head = new SkipListEntry(SkipListEntry.negInf, null);
            //_tail = new SkipListEntry(SkipListEntry.posInf, null);
            //_head.Right = _tail;
            //_tail.Left = _head;
        }

        private void CreateNewLevel()
        {
            var newHead = new SkipListEntry(SkipListEntry.negInf, null);
            var newTail = new SkipListEntry(SkipListEntry.posInf, null);
            newHead.Right = newTail;
            newTail.Left = newHead;
            newHead.Down = _head;
            if (_head != null)
                _head.Up = newHead;

            newTail.Down = _tail;

            if (_tail != null)
                _tail.Up = newTail;

            _head = newHead;
            _tail = newTail;
        }

        public int Size { get { return n; } }

        public SkipListEntry FindEntry(string key)
        {
            var skiplistEntryToSearch = _head;
            while (true)
            {
                while (skiplistEntryToSearch.Right.CompareTo(key) <= 0)
                    skiplistEntryToSearch = skiplistEntryToSearch.Right;

                if (skiplistEntryToSearch.Down != null)
                    skiplistEntryToSearch = skiplistEntryToSearch.Down;
                else
                    break;
            }

            return skiplistEntryToSearch;
        }

        public int? Get(string key)
        {
            var skiplistEntry = FindEntry(key);
            return skiplistEntry.CompareTo(key) == 0 ? skiplistEntry.Value : null;
        }

        public int? Put(string key, int? value)
        {
            if (key == null || value == null)
                throw new Exception("key or value cannot be null");

            var skiplistEntry = FindEntry(key);
            if (skiplistEntry.CompareTo(key) == 0)
            {
                var oldValue = skiplistEntry.Value;
                skiplistEntry.Value = value;
                return oldValue;
            }

            var level = 0;
            //Insert new entry on the bottommost level
            var currentEntry = InsertAfterInLinkedList(key, value, skiplistEntry);
            while (random.NextDouble() < 0.5)
            {
                if (level >= Height)
                {
                    CreateNewLevel();
                    Height++;
                }

                while (skiplistEntry.Up == null)
                    skiplistEntry = skiplistEntry.Left;
                skiplistEntry = skiplistEntry.Up;

                var newEntryonCurrentLevel = InsertAfterInLinkedList(key, null, skiplistEntry); //dont need the value
                newEntryonCurrentLevel.Down = currentEntry;
                currentEntry.Up = newEntryonCurrentLevel;

                currentEntry = newEntryonCurrentLevel;

                level++;
            }

            n++;
            return null;
        }

        public SkipListEntry InsertAfterInLinkedList(string key, int? value, SkipListEntry skipListEntry)
        {
            var newSkipListEntry = new SkipListEntry(key, value);
            newSkipListEntry.Right = skipListEntry.Right;
            skipListEntry.Right.Left = newSkipListEntry;
            skipListEntry.Right = newSkipListEntry;
            newSkipListEntry.Left = skipListEntry;
            return newSkipListEntry;
        }


    }
}
