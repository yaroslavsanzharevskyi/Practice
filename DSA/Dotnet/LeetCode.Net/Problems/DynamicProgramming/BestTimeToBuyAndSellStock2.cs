namespace LeetCode.Problems;

public class BestTimeToBuyAndSellStock2
{
    public int MaxProfit(int[] prices)
    {
        var profit = 0;
        var buyPrice = prices[0];

        for (var i = 1; i < prices.Length; i++)
        {
            if (buyPrice > prices[i])
            {
                buyPrice = prices[i];
                continue;
            }

            profit += prices[i] - buyPrice;
            buyPrice = prices[i];
        }

        return profit;
    }
}