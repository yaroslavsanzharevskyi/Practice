using System;

public class ContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        int maxWater = 0;
        for (int i = 0, j = height.Length - 1; i < height.Length;)
        {
            if (i > j)
                break;

            if (height[i] < height[j])
            {
                maxWater = Math.Max(maxWater, (j - i) * height[i]);
                i++;

            }
            else
            {
                maxWater = Math.Max(maxWater, (j - i) * height[j]);
                j--;
            }
        }
        return maxWater;
    }
}