class Solution:
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        n = len(cost)

        prev2 = 0  # dp[0]
        prev1 = 0  # dp[1]

        for i in range(2, n + 1):
            curr = min(
                prev1 + cost[i - 1],
                prev2 + cost[i - 2]
            )
            prev2 = prev1
            prev1 = curr

        return prev1
# class Solution:
#     def minCostClimbingStairs(self, cost: List[int]) -> int:
#         n = len(cost)

#         if n == 0:
#             return 0
#         if n == 1:
#             return cost[0]

#         dp = [0] * (n + 1) # n+1 to represent the top of the stairs
#         dp[0], dp[1] = 0, 0
#         for i in range(2, n+1):
#             one_step = dp[i-1] + cost[i-1]
#             two_step = dp[i-2] + cost[i-2]
#             dp[i] = min(one_step, two_step)

#         return dp[n]
