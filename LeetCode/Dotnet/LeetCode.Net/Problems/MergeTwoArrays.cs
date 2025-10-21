namespace LeetCode.Problems;

public class MergeTwoArrays
{
   public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (var imn = m + n; imn > m; imn--)
        {
            if (m > 0 && nums1[m - 1] > nums2[n - 1])
            {
                nums1[imn-1] = nums1[--m];
            }
            else
            {
                nums1[imn-1] = nums2[--n];
            }
        }
    }
}