# Definition for a Node.
from typing import Optional


class Node:
    def __init__(self, val = 0, neighbors = None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []

class Solution:
    def __init__(self):
        self.visited = {}
        
    def cloneGraph(self, node: Optional[Node]) -> Optional[Node]:
        if node is None:
            return None
        # current = 1 | 2 | 1
        # visited = []  | [1] | 
        if node.val in self.visited:
            return self.visited[node]
        
        clone = Node(node.val) # clone is 1 | clone 2 |  
        self.visited[node]=clone  # visited = [1] | [1,2]
        
        # current neigbors is [2] |  [1,3]
        for neighbor in node.neighbors:
            # 2 | 1 |
           neighbor_clone = self.cloneGraph(neighbor)
           # 2 | None
           clone.neighbors.append(neighbor_clone)
           
        return clone