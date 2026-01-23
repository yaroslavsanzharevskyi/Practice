from typing import List

class Solution:
    def rob(self, nums: List[int]) -> int:
        if not nums:
            return 0
        n = len(nums)
        if n == 1:
            return nums[0]

        def rob_linear(arr: List[int]) -> int:
            prev, cur = 0, 0
            for v in arr:
                prev, cur = cur, max(cur, prev + v)
            return cur

        return max(rob_linear(nums[:-1]), rob_linear(nums[1:]))
    
# class Solution:
#     def rob(self, nums: List[int]) -> int:
#         dp_i = [0] * (len(nums)-1)
#         dp_j = [0] * (len(nums)-1)
#         dp_i[0], dp_i[1] = nums[0], nums[1]
#         dp_j[0], dp_j[1] = nums[1], nums[2]

#         for k in range(2,len(nums)-1):
#             i = k
#             j = k + 1
#             dp_i[k] = dp_i[i-2] + nums[i]
#             dp_j[k] = dp_j[j-2] + nums[j]

#             if k >= 3:
#                 dp_i[k] = max(dp_i[k], dp_i[i-3] + nums[i])
#                 dp_j[k] = max(dp_j[k], dp_j[j-3] + nums[j])


#         return max(dp_i[-1], dp_j[-1])
