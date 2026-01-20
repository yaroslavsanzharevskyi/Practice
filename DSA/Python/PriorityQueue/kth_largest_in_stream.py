import heapq

class KthLargest:
    def __init__(self, k: int, nums: List[int]):
        self.k = k
        self.priority_queue = []
        
        for num in nums:
            self.add(num)
    
        
    def add(self, val: int) -> int:
        heapq.heappush(self.priority_queue, val)
        
        if len(self.priority_queue) > self.k:
            heapq.heappop(self.priority_queue)
            
        return self.priority_queue[0]

    
            
        
        
        