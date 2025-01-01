using System.Globalization;

namespace LeetCode.Problems;

public class RemoveDuplicateFromSortedArray
{
    public int Solution(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        var dupSize = 0;
        for (int i = 0; i < nums.Length - dupSize - 1; i++)
        {
            if (nums[i] < nums[i + 1])
            {
                continue;
            }
            if (i + 1 < nums.Length - 1)
            {
                while (nums[i] >= nums[i + 1] && dupSize < nums.Length -1 - i )
                {
                    for (int j = i + 1; j < nums.Length - dupSize - 1; j++)
                    {
                        var temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                    dupSize++;
                }
            } else {
                dupSize++;
            }

        }

        return nums.Length - dupSize;
    }
}