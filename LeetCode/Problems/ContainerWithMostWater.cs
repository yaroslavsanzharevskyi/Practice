using System;

namespace LeetCode.Problems
{
    public class ContainerWithMostWater
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
}
