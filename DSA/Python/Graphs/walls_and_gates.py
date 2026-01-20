from collections import deque
from typing import List


class Solution:
    def islandsAndTreasure(self, grid: List[List[int]]) -> None:

        rows, cols = len(grid), len(grid[0])
        queue = deque()
        INF = 2**31 - 1
        for r in range(rows):
            for c in range(cols):
                if grid[r][c] == 0:
                    queue.append((r, c))

        while queue:
            x, y = queue.popleft()
            for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
                nx, ny = x + dx, y + dy

                if 0 <= nx < rows and 0 <= ny < cols and grid[nx][ny] == INF:
                    grid[nx][ny] = grid[x][y] + 1
                    queue.append((nx, ny))
