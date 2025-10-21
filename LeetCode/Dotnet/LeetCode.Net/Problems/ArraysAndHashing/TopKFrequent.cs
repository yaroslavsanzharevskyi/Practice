using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class TopKFrequent
{
    public int[] Solution(int[] nums, int k)
    {
        var numCountMap = new Dictionary<int, int>();
        foreach(int num in nums)
        {
            numCountMap[num] = numCountMap.GetValueOrDefault(num, 0) + 1;
        }

        return numCountMap.OrderByDescending( item => item.Value).Take(k).Select(item => item.Key).ToArray();
    }
}

