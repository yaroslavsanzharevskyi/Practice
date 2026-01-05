def search(nums: List[int], target: int) -> int:
    left = 0
    right = len(nums) - 1
    
    while left < right:
        pointer = left + (right-left)//2 #int((right-left)/2)
        
        value = nums[pointer]
        if value == target:
            return pointer
        
        if value < target:
            left = pointer + 1
        else:
            right = pointer - 1
            
    return -1