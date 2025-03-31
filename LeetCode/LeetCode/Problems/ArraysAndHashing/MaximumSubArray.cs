using System;

namespace LeetCode.Problems.ArraysAndHashing;

public class MaximumSubArray
{
    public int MaxSubArray(int[] nums)
    {
        var maxSum = nums[0];
        var curSum = maxSum;
        for (var i = 1; i < nums.Length; i++)
        {
            if (curSum < 0) curSum = 0;

            curSum += nums[i];



            maxSum = Math.Max(curSum, maxSum);

        }

        return maxSum;
    }
}