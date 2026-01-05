# Given an array of integers nums and an integer target, return the indices i and j such that nums[i] + nums[j] == target and i != j.

# You may assume that every input has exactly one pair of indices i and j that satisfy the condition.

# Return the answer with the smaller index first.

# Example 1:

# Input: 
# nums = [3,4,5,6], target = 7

# Output: [0,1]

def twoSum(nums: List[int], target: int) -> List[int]:
    hash_map = {}
    
    for i in range(len(nums)):
        
        current_num = nums[i]
        if current_num in hash_map:
            # where i is current index, and hash map has an neighbor that looking for our value under index i
            return [hash_map.get(current_num), i]

        # target - i = delta => delta is a key in a dict, so we looking if it exist in array on next iteration
        delta = target - nums[i]
        hash_map[delta] = i
    
    return [0,0]
        