# You are given an integer array prices where prices[i] is the price of NeetCoin on the ith day.

# You may choose a single day to buy one NeetCoin and choose a different day in the future to sell it.

# Return the maximum profit you can achieve. You may choose to not make any transactions, in which case the profit would be 0.

# Example 1:

# Input: prices = [10,1,5,6,7,1]

# Output: 6
def maxProfit(prices:List[int]) -> int:
    profit = 0
    purchasePrice = prices[0]
    
    for price in prices[1:]:
        if price < purchasePrice:
            purchasePrice = price
            
        profit = max(price - purchasePrice, profit)
        
    return profit
    
def maxProfitSliding(prices: List[int]) -> int:
    left = 0
    right = 1
    max_profit = 0
    
    while right < len(prices):
        if prices[right] < prices[left]:
            left = right
        max_profit = max(max_profit, prices[right] - prices[left])
        
        right += 1
    
    return max_profit