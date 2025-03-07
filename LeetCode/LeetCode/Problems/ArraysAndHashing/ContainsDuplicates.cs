namespace LeetCode.Problems;

public class ContainsDuplicate {
    public bool Solution(int[] nums) {
        if(nums.Length == 1)
            return false;


        for(var i = 0; i < nums.Length - 1; i++)
        {
            for(var j = i + 1; j < nums.Length; j++)
            {
                if(nums[i] == nums[j])
                    return true;
            }
        }

        return false;
    }
}