using System;

namespace LeetCode.Problems.Intervals;

public class NonOverlappingIntervals
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return 0;
        }

        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        var count = 0;
        var currentInterval = intervals[0];
        for (var i = 1; i < intervals.Length; i++)
        {
            if (currentInterval[1] > intervals[i][0])
            {
                count++;
            }
            else
            {
                currentInterval = intervals[i];
            }
        }

        return count;
    }
}
