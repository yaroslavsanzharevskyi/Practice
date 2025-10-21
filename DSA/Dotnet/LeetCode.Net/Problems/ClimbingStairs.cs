namespace LeetCode.ClimbingStairs;

public class Solution
{
    private int variantCounter = 1;
    private int maxSteps = 0;

    
    public int ClimbStairs(int n)
    {
        if (n == 1) return n;
        var previous = 0;
        for (int i = 1; i < n; i++)
        {
            previous = variantCounter;
            variantCounter = previous + variantCounter;
            
        }

        return variantCounter;
    }
    

    private void addSteps(int sum, int countOfSteps)
    {
        sum += countOfSteps;
        if (sum == maxSteps)
        {
            variantCounter++;
            return;
        } 
        // if (sum > maxSteps) return;
        var remains = maxSteps - sum;
        if (remains > 1)
        {
            addSteps(sum, 1);
            addSteps(sum, 2);
        }
    }
}