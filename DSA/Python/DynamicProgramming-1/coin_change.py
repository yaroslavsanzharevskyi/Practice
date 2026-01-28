class Solution:
    def coinChange(self, coins: list[int], amount: int) -> int:
        dp = [amount + 1] *(amount +1)
        dp[0] = 0


        for i in range(1, amount + 1):
            for coin in coins:
                if coin <= i:
                    dp[i] = min(dp[i], dp[i - coin] + 1) # choose the coin that gives the minimum count
        
        return dp[amount] if dp[amount] != amount + 1 else -1 


# class Solution:
#     def coinChange(self, coins: list[int], amount: int) -> int:
#         coins.sort(reverse=True)
#         target = amount
#         count = 0
#         for coin in coins:
#             while coin <= target and amount != 0:
                
#                 target -= coin
#                 count +=1
        
#         if target > 0:
#             return -1
#         else:
#             return count
