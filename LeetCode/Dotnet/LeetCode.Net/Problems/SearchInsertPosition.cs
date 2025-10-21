namespace LeetCode.SearchInsertPositions;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        if (nums[0] > target)
        {
            return 0;
        }

        int low = 0, high = nums.Length - 1;

        while (low <= high)
        {
            if (nums[low] >= target)
            {
                return low;
            }
            else if (nums[high] == target)
            {
                return high;
            }
            else if (nums[high] < target)
            {
                return high + 1;
            }

            low++;
            high--;

            int mid = (low + high) / 2;

            if (target == nums[mid])
            {
                return mid;
            }
            else if (target < nums[mid])
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }

        return nums.Length;
    }
}