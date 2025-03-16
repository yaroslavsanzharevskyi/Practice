using System;

namespace LeetCode.Algorithms
{
    public class MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArray = new int[nums1.Length + nums2.Length];
            nums1.CopyTo(mergedArray, 0);
            nums2.CopyTo(mergedArray, nums1.Length);
            Array.Sort(mergedArray);

            return 0;
        }
    }
}
