using System.Collections.Generic;

namespace LeetCode.Problems.PriorityQueue;

public class KthLargest
{
    private PriorityQueue<int, int> minHeap; 
    private int numberK;
    public KthLargest(int k, int[] nums)
    {
        minHeap = new PriorityQueue<int, int>();

        numberK = k;

        foreach( var num in nums)
        {
            Add(num);
        }
    }

    public int Add(int val)
    {
        minHeap.Enqueue(val, val);
        if (minHeap.Count > numberK)
        {
            minHeap.Dequeue();
        }

        return minHeap.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */