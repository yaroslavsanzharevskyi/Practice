namespace LeetCode.Problems.ArraysAndHashing;

// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
// You must write an algorithm that runs in O(n) time and without using the division operation.
// Example 1:

// Input: nums = [1,2,3,4]
// Output: [24,12,8,6]
// Example 2:

// Input: nums = [-1,1,0,-3,3]
// Output: [0,0,9,0,0]

public class ProductOfArrayExceptSelf
{
    public int[] Solution(int[] nums)
    {
        var length = nums.Length;
        var prefix = new int[length];
        var suffix = new int[length];   
        var result = new int[length];

        prefix[0] = 1;
        suffix[length - 1] = 1;

        for (var i = 1; i < length; i++)
        {
            prefix[i] = prefix[i - 1] * nums[i - 1];
            suffix[length - i-1] = suffix[length - i] * nums[length - i];
        }

        for( var i = 0; i< length; i++)
        {
            result[i] = suffix[i] * prefix[i];
        }

        return result;
    }
}