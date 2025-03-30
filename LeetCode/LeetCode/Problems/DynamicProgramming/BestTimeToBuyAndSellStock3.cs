using System;

namespace LeetCode.Problems;

public class BestTimeToBuyAndSellStock3
{
    public int MaxProfit(int[] prices)
    {

        if (prices == null || prices.Length == 0) return 0;

        int buy1 = int.MinValue, sell1 = 0;
        int buy2 = int.MinValue, sell2 = 0;

        foreach (int price in prices)
        {
            buy1 = Math.Max(buy1, -price);
            sell1 = Math.Max(sell1, buy1 + price);
            buy2 = Math.Max(buy2, sell1 - price);
            sell2 = Math.Max(sell2, buy2 + price);
        }

        return sell2;
    }
}