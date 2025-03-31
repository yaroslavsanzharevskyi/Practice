using System.Collections.Generic;

namespace LeetCode.Problems.PriorityQueue;

public class MaxSlidingWindow
{
    public int[] FindMaxSlidingWindow(int[] nums, int k)
    {
        var deque = new LinkedList<int>();
        var answers = new int[nums.Length - (k - 1)];

        for (var i = 0; i < nums.Length; i++)
        {
            if (deque.Count > 0 && deque.First.Value < i - k + 1)
            {
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            if (i >= k - 1)
            {
                answers[i - k + 1] = nums[deque.First.Value];
            }
        }

        return answers;
    }
}