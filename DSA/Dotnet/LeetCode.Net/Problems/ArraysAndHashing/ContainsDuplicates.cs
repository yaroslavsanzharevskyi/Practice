using System.Collections.Generic;

namespace DSA.Problems;

public class ContainsDuplicate
{
    public bool Solution(int[] nums)
    {
        if (nums.Length <= 1)
            return false;

        HashSet<int> seen = new HashSet<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (seen.Contains(nums[i]))
                return true;
            seen.Add(nums[i]);
        }
        return false;
    }
}
