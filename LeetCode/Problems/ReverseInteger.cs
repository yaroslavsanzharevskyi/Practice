using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode.Problems
{
    public static class ReverseInteger
    {
        public static int Reverse(Int64 original)
        {
            var sign = original < 0 ? -1 : 1;

            var originalUnsigned = sign < 0 ? 
                original.ToString().Substring(1).ToCharArray() 
                : original.ToString().ToCharArray();


            Array.Reverse(originalUnsigned);

            var reversedConverted = Int64.Parse(originalUnsigned);

            if (reversedConverted < Int32.MinValue || reversedConverted > Int32.MaxValue) return 0;
            var reversedInt = (int)reversedConverted;

            return sign * reversedInt;
        }
    }
}
