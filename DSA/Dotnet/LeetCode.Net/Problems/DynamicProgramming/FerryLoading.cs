

namespace LeetCode.Net.Problems.DynamicProgramming;

public class FerryLoading
{
    public int Solution(int[] cars, int capacity)
    {
        var carsLoaded = 0;
        var leftCapacity = capacity;
        var rightCapacity = capacity;

        for (var i = 0; i < cars.Length && (leftCapacity > 0 || rightCapacity > 0); i++)
        {
            if (cars[i] <= leftCapacity)
            {
                carsLoaded++;
                leftCapacity -= cars[i];
            }
            else if (cars[i] <= rightCapacity)
            {
                carsLoaded++;
                rightCapacity -= cars[i];
            }
        }
        
        return carsLoaded;
    }
}