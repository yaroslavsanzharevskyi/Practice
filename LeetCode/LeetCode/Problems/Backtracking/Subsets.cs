using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.Backtracking;

public class FindSubsets
{
    private IList<IList<int>> Sets = new List<IList<int>>();

    public IList<IList<int>> Subsets(int[] nums)
    {
        Backtracking(nums, 0, new List<int>());

        return Sets.ToList();
    }

    private void Backtracking(int[] nums, int currentIndex, List<int> path)
    {
        Sets.Add(new List<int>(path));

        for (var i = currentIndex; i < nums.Length; i++)
        {
            path.Add(nums[i]);
            Backtracking(nums, i + 1, path);
            path.RemoveAt(path.Count - 1);
        }
    }

    // private void Backtracking(int[] nums, int currentIndex, List<int> path)
    // {
    //     var copy = new List<int>(path);
    //     Sets.Add(copy);

    //     for(var i = currentIndex; i < nums.Length; i++){
    //         Backtracking(nums, i+1, copy);
    //         copy.Add(nums[i]);
    //     }
    // }
}