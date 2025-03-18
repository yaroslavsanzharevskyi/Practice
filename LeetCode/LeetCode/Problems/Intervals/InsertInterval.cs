using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Intervals;

public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var newIntervals = new List<int[]>();
        var i = 0; 
        var n = intervals.Length;

        while(i < n && newInterval[0] > intervals[i][1])
        {
            newIntervals.Add(intervals[i]);
            i++;
        }

        while( i < n && newInterval[1] > intervals[i][0])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);

            i++;
        }

        newIntervals.Add(newInterval);

        while(i < n)
        {
            newIntervals.Add(intervals[i]);
            i++;
        }

        return newIntervals.ToArray();
    }
}