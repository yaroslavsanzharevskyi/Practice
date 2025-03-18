public class JumpGame {
    public bool CanJump(int[] nums) {
        
        var currentPosition = nums.Length -1;
        var jumpSize = 1;
        while(currentPosition - jumpSize >= 0)
        {
            if(nums[currentPosition - jumpSize] >= jumpSize){
                currentPosition--;
                jumpSize = 1;
            }
            else {
                jumpSize++;
            }
        }

        return currentPosition == 0;
    }
}