namespace LeetCode.Problems.ArraysAndHashing;

public class RotateArray
{
    public void Solution(int[] nums, int k)
    {
        int n = nums.Length; // n equal 10 
        var new_k = k % n;

        void Reverse(int left, int right)
        {
            while (left < right)
            {
                int tmp = nums[left];
                nums[left] = nums[right];
                nums[right] = tmp;
                left++;
                right--;
            }
        }

        // [1 2 3 4 5 6 7], k = 3
        // Reverse all:
        // [7 6 5 4 3 2 1]
        // Reverse first k:
        // [5 6 7 | 4 3 2 1]
        // Reverse rest:
        // [5 6 7 1 2 3 4]
        Reverse(0, n - 1);
        Reverse(0, k - 1);
        Reverse(k, n - 1);
    }
}