using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DSA.Problems.PriorityQueue;

public class LastStoneWeightSolution
{
    public int LastStoneWeight(int[] stones)
    {
        var pq = new PriorityQueue<int, int>();

        foreach (var stone in stones)
        {
            pq.Enqueue(stone, -stone);
        }
        while (pq.Count > 1)
        {
            var stoneA = pq.Dequeue();
            var stoneB = pq.Dequeue();

            if (stoneA != stoneB)
            {
                var weight = Math.Abs(stoneA - stoneB);
                pq.Enqueue(weight, -weight);
            }
        }
        return pq.Count == 0 ? 0 : pq.Dequeue();
    }
}