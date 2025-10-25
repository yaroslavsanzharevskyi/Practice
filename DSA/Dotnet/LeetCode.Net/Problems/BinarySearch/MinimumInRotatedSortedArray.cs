using System;
using System.Security.AccessControl;

namespace DSA.Problems.BinarySearch;

public class MinimumInRotatedArray
{
    public int FindMin(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;
        var minimum = nums[left];

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            minimum = Math.Min(nums[mid], minimum);

            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return minimum;
    }
}