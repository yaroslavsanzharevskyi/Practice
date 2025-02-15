using System.Collections.Generic;

namespace LeetCode.Algorithms
{
    public class TwoSumAlgorithm
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var calculated = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var val = target - nums[i];

                if (calculated.ContainsKey(nums[i]))
                {
                    return new[] {calculated[nums[i]], i};
                }

                calculated[val] = i;
            }

            return new int[0];
        }
    }
}
