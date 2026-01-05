class Solution:
    def rob(self, nums: List[int]) -> int:
        if len(nums) == 0:
            return 0
        if len(nums) == 1:
            return nums[0]
        results = [nums[0],nums[1]]
        max_profit = max(nums[0], nums[1])
        for i in range(2,len(nums)):
                
            new_val = results[-2] + nums[i]
            if i >= 3:
                new_val_2 = results[-3] + nums[i]
                local_max = max(new_val, new_val_2)
                results.append(local_max)
                new_val = local_max
            else:   
                results.append(new_val)
                    
            max_profit = max(max_profit, new_val)
        
        return max_profit
            
            
            
            