using System;
using System.Collections.Generic;

namespace LeetCode.Problems.ArraysAndHashing;

public class LongestConsecutiveNums
{
    public int Solution(int[] nums)
    {
        if(nums.Length == 0)
        {
            return 0;
        }
        var hashSet = new HashSet<int>(nums);

        var longest = 0;

        for(var i = 0; i< nums.Length; i++)
        {
            if(hashSet.Contains(nums[i] - 1))
            {
                continue;
            }
            var current_number = nums[i];
            var current_length = 1;

            while(hashSet.Contains(++current_number))
            {
                current_length++;
            }

            longest = Math.Max(longest, current_length);
        }

        return longest;
    }
}