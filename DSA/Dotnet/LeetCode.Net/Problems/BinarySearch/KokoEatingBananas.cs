using System;
using System.Linq;

namespace LeetCode.Problems.BinarySearch;

public class KokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {

        // Array.Sort(piles);
        // var maxPileSize = piles[^1];
        var upperBound = piles.Max();
        var lowerBound = 1;
        var potentialSpeed = 1;
        while (lowerBound <= upperBound)
        {
            var mid = lowerBound + (upperBound - lowerBound) / 2;

            // CAN finish?
            var estimatedTime = 0;
            for (var i = 0; i < piles.Length; i++)
            {
                estimatedTime += (int)Math.Ceiling(piles[i] / (double)mid);
            }

            if (estimatedTime <= h)
            {
                potentialSpeed = mid;
                upperBound = mid - 1;
                continue;
            }

            if (estimatedTime > h)
            {
                lowerBound = mid + 1;
                continue;
            }
        }

        return potentialSpeed;
    }
}

