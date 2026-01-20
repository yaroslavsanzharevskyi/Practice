from collections import defaultdict
from typing import List


class Solution:
    def validTree(self, n: int, edges: List[List[int]]) -> bool:
        if len(edges) != n - 1:
            return False
    
        graph = defaultdict(list)

        for u, v in edges:
            graph[u].append(v)
            graph[v].append(u)

        visited = set()

        def dfs(node: int, parent: int) -> bool:
            visited.add(node)

            for neighbor in graph[node]:
                # if node has neighbor that is visited and is not parent -> cycle
                if neighbor not in visited:
                    if not dfs(neighbor, node):
                        return False
                elif neighbor != parent:
                    return False

            return True
        
        if not dfs(0, -1):
            return False    

        return len(visited) == n