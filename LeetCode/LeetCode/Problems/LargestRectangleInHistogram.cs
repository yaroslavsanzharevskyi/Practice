using System;
using System.Collections.Generic;

namespace LeetCode.Problems;

public class LargestRectangleInHistogram
{
    public int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new Stack<int>();

        int result = 0;

        int n = heights.Length;

        int[] copyHeights = new int[n + 1];

        Array.Copy(heights, copyHeights, n);

        copyHeights[n] = 0;

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && copyHeights[i] < copyHeights[stack.Peek()])
            {
                var height = copyHeights[stack.Pop()];
                var width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                result = Math.Max(result, height * width);
            }
            stack.Push(i);
        }

        return result;
    }
}