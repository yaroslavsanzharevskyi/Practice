using System;
using System.Data;

namespace LeetCode.Problems.DynamicProgramming;

public class BuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 1)
        {
            return 0;
        }

        int profit = 0;
        var buyPrice = prices[0];

        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] <= buyPrice)
            {
                buyPrice = prices[i];
                continue;
            }

            profit = Math.Max(prices[i] - buyPrice, profit);

        }
        return profit;
    }
}