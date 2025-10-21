from typing import List


def hasDuplicate(nums: List[int]) -> bool:
    if len(nums) <= 1:
        return False
    
    map_of_nums = {}
    for num in nums:
        if num in map_of_nums:
            return True
        
        map_of_nums[num] = True

    return False
