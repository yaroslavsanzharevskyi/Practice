using System;

namespace DSA.Dotnet.Problems.TwoPointers;

public class TwoIntegerSum2
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (left < right)
        {
            var result = numbers[left] + numbers[right];
            if (result == target)
            {
                return [left + 1, right + 1];
            }
            if (result < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return Array.Empty<int>();
    }
}