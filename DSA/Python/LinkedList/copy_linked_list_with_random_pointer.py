
# Definition for a Node.
class Node:
    def __init__(self, x: int, next: 'Node' = None, random: 'Node' = None):
        self.val = int(x)
        self.next = next
        self.random = random

class Solution:
    def __init__(self):
        self.visited = {}
        
    def copyRandomList(self, head: Optional[Node]) -> Optional[Node]:
        if head is None: 
            return None
        
        if head in self.visited:
           return self.visited[head]
       
        clone = Node(head.val, head.next, head.random)
        self.visited[head] = clone
        
        next_clone = self.copyRandomList(head.next)
        clone.next = next_clone
        random_clone = self.copyRandomList(head.random)
        clone.random = random_clone
       
        return clone
       
       
           

           
        
        
        
      
        
        
            
        
        
        
            
       
        