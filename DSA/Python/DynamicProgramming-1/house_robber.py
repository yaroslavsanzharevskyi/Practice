class Solution:
    def rob(self, nums: List[int]) -> int:
        if len(nums) == 0:
            return 0
        if len(nums) == 1:
            return nums[0]

        prev, cur = 0, 0
        for v in nums:
            prev, cur = cur, max(cur, prev + v)
        return cur
            
            
            