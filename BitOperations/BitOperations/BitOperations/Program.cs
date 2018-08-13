using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitFlags = new BitFlags();
            bitFlags.Set(2);
            bitFlags.Set(3);
            bitFlags.UnSet(3);
            bitFlags.Flip(7);
            var bit7 = bitFlags.Query(7);
            var val = bitFlags.GetFlags();
            var leastSetBitPosition = bitFlags.GetLeastSetBitPosition();
            var highestSetBitPosition = bitFlags.GetHighestSetBitPosition();
            double d = 5.9;
            var isInt = d % 1 == 0;
            var n = 33;
            var isInt1 = Math.Log(n, 2) % 1 ==0;
            short a = -32768;
            ushort b = 65535;
        }
    }

    public class BitFlags
    {
        private int _flags;
        public BitFlags(int flags)
        {
            _flags = flags;
        }

        public BitFlags()
        {
            _flags = 0;
        }

        public void Set(int num)
        {
            _flags |= Mask(num);
        }

        public void UnSet(int num)
        {
            _flags &= ~Mask(num);
        }

        public void Flip(int num)
        {
            _flags ^= Mask(num);
        }

        public bool Query(int num)
        {
            return Convert.ToBoolean(_flags & Mask(num));

        }

        public void UnSetLeastSetBit()
        {
            //_flags - 1 results in making the least set bit to zero and all the succesive bits(after least set bit) to 1
            //eg if _flags = 00110100
            //least set bit position is 2. If we take all bits after the least set bit position which in this case is 100(positions 2,1,0)
            //Hence _flags -1 values for bits in position2 2,1 0 would be 011
            //Remaining bits remain same from positions 3 to 7
            //By Anding them bits from positions 3 to 7 remain the same and position 2 is unset (0) and also positions 1 and 0
            _flags = _flags & (_flags - 1);
        }

        public int GetLeastSetBitPosition()
        {
            //_flags - 1 results in making the least set bit to zero and all the succesive bits(after least set bit) to 1
            //eg if _flags = 00110100
            //least set bit position is 2. If we take all bits after the least set bit position which in this case is 100(positions 2,1,0)
            //Hence _flags -1 values for bits in position2 2,1 0 would be 011
            //Remaining bits remain same from positions 3 to 7
            //By flipping them i.e. ~(_flags - 1) all bits from position 7 to 3 are zero are inverse of _flags. Hence anding bits from 
            //positions 7 to 3 will always be zero
            //position 2,1,0 would be the same for both _flags and ~(_flags-1) i.e. 100. In General ~(_flags-1) will have bit in the
            //least set bit to 1 and all successive bits to 0. Hence anding them would be 100
            //So the end result would be 00000100
            var tmp = _flags & ~(_flags - 1);//4
            return (int)Math.Log(tmp, 2);//2
        }

        public int GetHighestSetBitPosition()
        {
            var tmpFlags = _flags;
            var intSizeinBits = sizeof(int)*8;
            
            for(int i =1; i<Math.Log(intSizeinBits,2);i++ )
            {
                /*This equation does an OR operation with itself by right shifting
                 For eg 01000001. The higest set bit position  6
                 For i =1 = pow(2,0), the highest set bit retains its initial position of 6 and also gets assigned in position 5 due to right shifting by 1. 
                 So bit 1 will now be in positions 6 and 5
                 For i =2 = pow(2,1), the highest set bit retains its initial positions of 6 and 5 and also gets assigned positions
                 4 and 3 due to the right shifting by 2 
                 This way by looping throught all bits would be 1 from positions 6 to 0 i.e. 01111111 which is pow(2,7) -1 = 127
                 
                 */
                tmpFlags |= tmpFlags >> i;
            }

            //Adding a 1 will set the bit which is one position higher than the highest set bit.
            //i.e. if we take the eg in the comments above in the for loop tmpFlags = 127 . Hence tmpFlags + 1 = 128 i.e. 10000000 i.e. bit 7 is set
            //log(128,2) = 7
            //7 -1 =6
            return (int)Math.Log(tmpFlags + 1,2) - 1; 
        }

        public int GetFlags()
        {
            return _flags;
        }

        private int Mask(int num)
        {
            return 1 << num;
        }



    }
}
