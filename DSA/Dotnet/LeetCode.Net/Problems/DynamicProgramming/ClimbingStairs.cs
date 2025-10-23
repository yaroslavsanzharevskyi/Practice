
namespace LeetCode.Problems.DynamicProgramming;

public class ClimbingStairsSolution
{
    private int variantCounter = 0;
    private int maxSteps = 0;
    
    public int ClimbStairs(int n)
    {
        maxSteps = n;
        if (n == 1) return 1;

        addSteps(0,1);
        addSteps(0,2);
        
        return variantCounter;
    }

    private void addSteps(int sum, int stepSize)
    {
        sum += stepSize;
        if (sum == maxSteps)
        {
            variantCounter++;
            return;
        } 
       
        addSteps(sum, 1);

        var remains = maxSteps - sum;
        if (remains >= 2)
        {
            addSteps(sum, 2);
        } 
    }
}

