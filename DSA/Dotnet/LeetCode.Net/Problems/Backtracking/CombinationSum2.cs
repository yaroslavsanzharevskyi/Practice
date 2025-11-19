using System;
using System.Collections.Generic;

namespace DSA.Problems.Backtracking;

public class CombinationSum2Solution
{
    public List<List<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
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

            // 1 2 2 3 4
            for (var i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i] == candidates[i - 1])
                {
                    continue;
                }

                path.Add(candidates[i]); // 2 

                Backtracking(i + 1, remaining - candidates[i], path); // 2 

                path.RemoveAt(path.Count - 1); // 2
            }
        }
    }
}