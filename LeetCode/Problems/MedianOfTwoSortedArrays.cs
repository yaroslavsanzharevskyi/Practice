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

            // 0 1 2 3 4 5 = 6
            // even
            //if (mergedArray.Length % 2 == 0) // is Even
            //{
            //    var index1 = mergedArray / 
            //}

            //var median1 = mergedArray[index];
            //var median2 = index2.HasValue ? mergedArray[(int)index2] : 0;

            //return (median2 + median1) / 2;
            return 0;
        }
    }
}
