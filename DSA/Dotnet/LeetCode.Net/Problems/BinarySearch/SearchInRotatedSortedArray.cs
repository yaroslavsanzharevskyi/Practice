namespace DSA.Problems.BinarySearch;

public class SearchInRotatedSortedArray
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }

            // move right boundary
            if (nums[left] <= nums[mid])
            {
                if (target >= nums[left] && target < nums[mid])
                {
                    right = mid - 1;
                    continue;
                }
                else
                {
                    left = mid + 1;
                    continue;
                }
            }
            else
            {
                // move left boundary
                if (target > nums[mid] && target <= nums[right])
                {
                    left = mid + 1;
                    continue;
                }
                else
                {
                    right = mid - 1;
                    continue;
                }
            }
        }
        return -1;
    }
}