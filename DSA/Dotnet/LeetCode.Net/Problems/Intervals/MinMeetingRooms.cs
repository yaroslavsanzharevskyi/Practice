using System.Collections.Generic;
using System.Linq;

public class Interval
{
    public int start, end;
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

public class MinMeetingRoomsProblem
{
    public int MinMeetingRooms(List<Interval> intervals)
    {
        if (intervals.Count == 0)
        {
            return 0;
        }

        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        var currentRoom = new List<Interval>([intervals[0]]);
        var rooms = new List<List<Interval>>([currentRoom]);

        for (var i = 1; i < intervals.Count; i++)
        {
            if (currentRoom[^1].end <= intervals[i].start)
            {
                currentRoom.Add(intervals[i]);
            }
            else
            {
                var goodRoom = rooms.FirstOrDefault(r => r[^1].end <= intervals[i].start);
                if (goodRoom == null)
                {
                    goodRoom = new List<Interval>([intervals[i]]);
                    rooms.Add(goodRoom);
                }
                else
                {
                    goodRoom.Add(intervals[i]);
                }
                currentRoom = goodRoom;
            }
        }

        return rooms.Count;
    }

    // Best solution
    public int MinMeetingRooms2(List<Interval> intervals)
    {
        if (intervals.Count == 0)
        {
            return 0;
        }

        // Sort by start time
        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        // Min heap to track end times of meetings
        var endTimes = new PriorityQueue<int, int>();
        endTimes.Enqueue(intervals[0].end, intervals[0].end);

        for (var i = 1; i < intervals.Count; i++)
        {
            // If earliest ending meeting finishes before current starts, reuse room
            if (endTimes.Peek() <= intervals[i].start)
            {
                endTimes.Dequeue();
            }

            // Add current meeting's end time
            endTimes.Enqueue(intervals[i].end, intervals[i].end);
        }

        // Number of rooms = size of heap
        return endTimes.Count;
    }
}