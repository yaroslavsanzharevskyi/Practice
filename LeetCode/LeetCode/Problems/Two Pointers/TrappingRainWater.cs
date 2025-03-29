using System;
using System.ComponentModel.DataAnnotations;

namespace LeetCode.Problems.TwoPointers;

public class TrappingRainWater
{
    public int Trap(int[] height)
    {
        if (height.Length < 3)
        {
            return 0;
        }

        var trappedWater = 0;
        var left = 0;
        var right = height.Length - 1;
        var leftMax = height[0];
        var rightMax = height[right];

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                trappedWater += Math.Max(0, leftMax - height[left]);
            }
            else
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                trappedWater += Math.Max(0, rightMax - height[right]);
            }
        }

        return trappedWater;
    }
}