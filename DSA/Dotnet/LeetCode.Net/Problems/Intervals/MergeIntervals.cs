using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Net.Problems.Intervals;

public class MergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        var result = new List<(int start, int end)>();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var currentInterval = intervals[0];
        for (var i = 1; i < intervals.Length; i++)
        {
            if (currentInterval[1] >= intervals[i][0])
            {
                var maxEnd = Math.Max(currentInterval[1], intervals[i][1]);
                currentInterval[1] = maxEnd;
            }
            else
            {
                result.Add((currentInterval[0], currentInterval[1]));
                currentInterval = intervals[i];
            }
        }

        result.Add((currentInterval[0], currentInterval[1]));
        return result.Select(i => new[] { i.start, i.end}).ToArray();
    }

}