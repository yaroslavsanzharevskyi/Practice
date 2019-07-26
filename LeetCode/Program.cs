using System;
using System.Runtime.InteropServices.ComTypes;
using LeetCode.Algorithms;

namespace LeetCode
{


    class Program
    {
        static void Main(string[] args)
        {
            var md = new MedianOfTwoSortedArrays();
            md.FindMedianSortedArrays(new[] {1, 3}, new[] {2});

        }
    }
}
