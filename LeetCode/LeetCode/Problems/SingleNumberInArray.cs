using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class SingleNumberInArray
    {
        public int SingleNumber(int[] nums)
        {
            var xor = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                xor ^= nums[i];
            }

            return xor;
        }
    }
}
