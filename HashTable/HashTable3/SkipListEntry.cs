using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public class SkipListEntry : IComparable<string>
    {
        public const string negInf = "-00";
        public const string posInf = "+00";
        public SkipListEntry(string key,int? value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public int? Value { get; set; }

        //public static SkipListEntry Head
        //{
        //    get
        //    {
        //        if (_head == null)
        //            _head = new SkipListEntry(negInf, null);
        //        return _head;
        //    }
        //}

        //public static SkipListEntry Tail
        //{
        //    get
        //    {
        //        if (_tail == null)
        //            _tail = new SkipListEntry(posInf, null);
        //        return _tail;
        //    }
        //}

        public SkipListEntry Left { get; set; }

        public SkipListEntry Right { get; set; }

        public SkipListEntry Up { get; set; }

        public SkipListEntry Down{ get; set; }

        public int CompareTo(string other)
        {
            if(Key!=other)
            {
                if (other == negInf)
                    return 1;
                else if (other == posInf)
                    return -1;
                else if (Key == negInf)
                    return -1;
                else if (Key == posInf)
                    return 1;

            }

            return Key.CompareTo(other);

        }
    }
}
