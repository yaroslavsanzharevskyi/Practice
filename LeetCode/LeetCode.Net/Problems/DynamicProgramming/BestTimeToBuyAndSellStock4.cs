using System;

namespace LeetCode.Problems;

public class BestTimeToBuyAndSellStock4
{
    public int MaxProfit(int k, int[] prices)
    {
        if (prices == null || prices.Length == 0) return 0;

        (int buy, int sell)[] transactions = new (int, int)[k + 1];

        for (var i = 0; i < k; i++)
        {
            transactions[i] = (int.MinValue, 0);
        }

        foreach (int price in prices)
        {
            for (var i = 0; i < k; i++)
            {
                transactions[i].buy = Math.Max(transactions[i].buy, -price);
                transactions[i].sell = Math.Max(transactions[i].sell, transactions[i].buy + price);

                transactions[i + 1].buy = Math.Max(transactions[i + 1].buy, transactions[i].sell - price);
                transactions[i + 1].sell = Math.Max(transactions[i + 1].sell, transactions[i + 1].buy + price);

            }
        }

        return transactions[k - 1].sell;
    }
}
