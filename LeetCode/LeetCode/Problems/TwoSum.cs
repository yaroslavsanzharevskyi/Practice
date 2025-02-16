using System.Collections.Generic;

namespace LeetCode.Algorithms
{
    public class TwoSumAlgorithm
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var pairToFind = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (pairToFind.ContainsKey(nums[i]))
                {
                    return new[] { pairToFind[nums[i]], i };
                }

                var val = target - nums[i];
                pairToFind[val] = i;
            }

            return new int[0];
        }
    }
}
