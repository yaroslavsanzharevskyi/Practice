

def subsets(nums: List[int]) -> List[List[int]]:
    subsets = []
    def backtrack(nums: List[int], path: List[int], index: int):
        subsets.append(list(path))
        
        for i in range(index, len(nums)):
            path.append(nums[i])
            backtrack(nums, path, i + 1)
            del path[-1] 
    
    backtrack(nums, [], 0) 
    
    return subsets