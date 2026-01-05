

namespace LeetCode.Problems.BinarySearch;

public class BinarySearch
{
    public int Search(int[] nums, int target) {
        var leftPointer = 0;
        var rightPointer = nums.Length-1;

        while(leftPointer <= rightPointer)
        {
            var pointer = leftPointer + (rightPointer-leftPointer) / 2;

            if(nums[pointer] == target)
            {
                return pointer;
            }

            if(nums[pointer] < target)
            {
                leftPointer = pointer + 1;
                continue;
            } 
            if(nums[pointer] > target)
            {
                rightPointer = pointer - 1;
                continue;
            }
        }

        return -1;
    }
}