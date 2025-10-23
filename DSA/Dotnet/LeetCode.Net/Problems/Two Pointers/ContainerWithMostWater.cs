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

    public class ContainerWithMostWaterN2
    {
        public int MaxArea(int[] height)
        {
            var maxSpace = 0;
            for (var i = 0; i <= height.Length - 1; i++)
            {
                for (var j = height.Length-1; j > i; j--)
                {
                    var space = (j - i) * Math.Min(height[i], height[j]); ;
                    if (space > maxSpace)
                    {
                        maxSpace = space;
                    }

                    if (height[i] <= height[j])
                    {
                        break;
                    }
                }
            }

            return maxSpace;
        }

    }