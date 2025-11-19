using System;
using System.Collections.Generic;

namespace DSA.Problems.Backtracking;

public class Permutations
{
    public List<List<int>> Permute(int[] nums)
    {
        var results = new List<List<int>>();

        Backtracking(new bool[nums.Length], new List<int>());
        return results;

        void Backtracking(bool[] usedNumbers, List<int> path)
        {
            if (path.Count == nums.Length)
            {
                results.Add(new List<int>(path));
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (usedNumbers[i])
                    continue;

                usedNumbers[i] = true;
                path.Add(nums[i]);

                Backtracking(usedNumbers, path);

                path.RemoveAt(path.Count - 1);
                usedNumbers[i] = false;
            }
        }
    }
}