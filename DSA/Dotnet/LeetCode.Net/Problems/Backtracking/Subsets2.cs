using System;
using System.Collections.Generic;

namespace DSA.Problems.Backtracking;

public class Subsets2
{
    public List<List<int>> SubsetWithDup(int[] nums)
    {
        Array.Sort(nums);
        var results = new List<List<int>>();

        Backtracking(0, new List<int>());
        return results;

        void Backtracking(int index, List<int> path)
        {
            results.Add(new List<int>(path));

            for (var i = index; i < nums.Length; i++)
            {
                if (i > index && nums[i] == nums[i - 1])
                {
                    continue;
                }

                path.Add(nums[i]);
                Backtracking(i + 1, path);

                path.RemoveAt(path.Count - 1);
            }
        }
    }
}