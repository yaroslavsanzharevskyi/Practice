class Solution:
    def missingNumber(self, nums: List[int]) -> int:
        n = len(nums)
        result = n  # Start with n (the missing index)
        
        for i in range(n): 
            # from 0 to n - 1 ( indices) while nums are from 0 to n except missing one
            # in case n = 10, nums = [0,1,2,3,4,5,6,7,8,9] missing 10
            # or n =10, nums = [0,1,2,3,4,5,6,7,8,10] missing 9
            result ^= i ^ nums[i] 
        
        return result
           