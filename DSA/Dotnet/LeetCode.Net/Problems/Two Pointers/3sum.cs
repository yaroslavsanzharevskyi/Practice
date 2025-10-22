using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace LeetCode.Problems.TwoPointers;

public class ThreeSumSolution
{
    public List<List<int>> ThreeSum(int[] nums)
    {
        var pairs = new List<List<int>>();
        Array.Sort(nums);

        for (var t = 0; t < nums.Length - 2; t++)
        {
            if (t > 0 && nums[t] == nums[t - 1]) continue;

            var left = t + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[t] + nums[left] + nums[right];
                if (sum == 0)
                {
                    pairs.Add(new List<int>() { nums[t], nums[left], nums[right] });

                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return pairs;
    }
}
