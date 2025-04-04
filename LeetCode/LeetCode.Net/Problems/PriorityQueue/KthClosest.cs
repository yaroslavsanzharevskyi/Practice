using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.PriorityQueue;

public class KthClosest
{
    public int[][] FindKthClosest(int[][] points, int k)
    {
        var heap = new PriorityQueue<int[], double>(k + 1);

        for (var i = 0; i < points.Length; i++)
        {
            var distance = Math.Sqrt(Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2));
            heap.Enqueue(points[i], -distance);

            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        return heap.UnorderedItems.Select(item => item.Element).ToArray();
    }
}