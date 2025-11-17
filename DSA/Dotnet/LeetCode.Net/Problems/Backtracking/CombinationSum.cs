using System.Collections.Generic;

namespace DSA.Problems.PriorityQueue;

public class CombinationSumSolution
{
    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        var result = new List<List<int>>();
        Backtracking(0, target, new List<int>());
        return result;

        void Backtracking(int index, int remaining, List<int> path)
        {
            if (remaining == 0)
            {
                result.Add(new List<int>(path));
            }

            if (remaining < 0)
            {
                return;
            }

            for (var i = index; i < nums.Length; i++)
            {
                int num = nums[i];

                path.Add(num);

                Backtracking(i, remaining - num, path);

                path.RemoveAt(path.Count - 1);
            }
        }
    }
}