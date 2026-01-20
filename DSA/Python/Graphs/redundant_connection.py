from typing import List


class Solution:
    def findRedundantConnection(self, edges: List[List[int]]) -> List[int]:
        parent = {}
        rank = {}

        def find_root(node: int) -> int: # node 4
            if parent[node] != node:
                parent[node] = find_root(parent[node])
            return parent[node]

        def union(u: int, v: int) -> bool:
            rootU = find_root(u) # 2 = 1
            rootV = find_root(v) # 4 = 1

            if rootU == rootV: # 1 != 2 |
                return False
            # cluster that has more nodes besides root merges the other one
            if rank[rootU] > rank[rootV]: # 0 > 0 | 
                parent[rootV] = rootU
            elif rank[rootU] < rank[rootV]:
                parent[rootU] = rootV
            else: # if they are equal just make one child of another
                parent[rootV] = rootU # 2 is child of 1
                rank[rootU] += 1 # 1 has 1 child now

            return True

        for u, v in edges:
            if u not in parent:
                parent[u] = u
                rank[u] = 0
            if v not in parent:
                parent[v] = v
                rank[v] = 0

            if not union(u, v):
                return [u, v]
