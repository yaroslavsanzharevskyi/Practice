using System.Collections.Generic;

namespace LeetCode.Net.Problems.Intervals;

public class Interval
{
    public int start, end;
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

public class MeetingRooms
{
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        for (var i = 0; i < intervals.Count - 1; i++)
        {
            if (intervals[i].end > intervals[i + 1].start)
            {
                return false;
            }
        }

        return true;
    }
}
