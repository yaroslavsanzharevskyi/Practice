from typing import List
from collections import defaultdict


class Solution:
    def canFinish(self, numCourses: int, prerequisites: List[List[int]]) -> bool:
        # Build adjacency list
        graph = defaultdict(list)
        for course, prereq in prerequisites:
            graph[prereq].append(course)
        
        # Three states for cycle detection
        UNVISITED, VISITING, VISITED = 0, 1, 2
        state = [UNVISITED] * numCourses
        
        def has_cycle(node: int) -> bool:
            # If currently visiting this node, we found a cycle
            if state[node] == VISITING:
                return True
            
            # If already fully explored, no cycle from here
            if state[node] == VISITED:
                return False
            
            # Mark as currently visiting
            state[node] = VISITING
            
            # Explore all neighbors
            for neighbor in graph[node]:
                if has_cycle(neighbor):
                    return True
            
            # Done visiting, mark as fully explored
            state[node] = VISITED
            return False
        
        # Check each course for cycles
        for course in range(numCourses):
            if state[course] == UNVISITED and has_cycle(course):
                return False
        
        return True