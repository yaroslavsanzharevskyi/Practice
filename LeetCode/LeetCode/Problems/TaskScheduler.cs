using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class TaskScheduler
{
    public int LeastInterval(char[] tasks, int n)
    {
        if (n == 0) return tasks.Length;

        // Step 1: Count frequency of each task
        Dictionary<char, int> taskCount = new Dictionary<char, int>();
        foreach (char task in tasks)
        {
            if (!taskCount.ContainsKey(task))
                taskCount[task] = 0;
            taskCount[task]++;
        }

        PriorityQueue<int, int> maxQueue = new PriorityQueue<int, int>();
        foreach (var count in taskCount.Values)
        {
            maxQueue.Enqueue(count, -count); // That way we pull tasks that are has higher count first, that reduce idle time
        }

        var cooldownQueue = new Queue<(int countLeft, int availableAtTime)>();
        var time = 0;

        while (maxQueue.Count > 0 || cooldownQueue.Count > 0)
        {
            time++;

            if (maxQueue.Count > 0)
            {
                var nTasksLeft = maxQueue.Dequeue();
                if (nTasksLeft > 1)
                {
                    cooldownQueue.Enqueue((nTasksLeft - 1, time + n));
                }
            }

            if (cooldownQueue.Count > 0 && cooldownQueue.Peek().availableAtTime == time)
            {
                var (freq, _) = cooldownQueue.Dequeue();
                maxQueue.Enqueue(freq, -freq);
            }

        }
        return time;

    }

    public int LeastIntervalFormula(char[] tasks, int n)
    {
        int[] freq = new int[26];
        foreach (char task in tasks)
            freq[task - 'A']++;

        int maxFreq = freq.Max();
        int maxFreqCount = freq.Count(f => f == maxFreq);

        return Math.Max(tasks.Length, (maxFreq - 1) * (n + 1) + maxFreqCount);
    }
}