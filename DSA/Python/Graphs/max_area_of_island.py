class Solution:
    def maxAreaOfIsland(self, grid: List[List[int]]) -> int:
        rows, cols = len(grid), len(grid[0])

        def dfs(r, c):
            if r < 0 or r >= rows or c < 0 or c >= cols or grid[r][c] == 0:
                return 0

            grid[r][c] = 0  # Mark as visited
            area = 1  # Current cell

            # Explore all four directions
            area += dfs(r + 1, c)
            area += dfs(r - 1, c)
            area += dfs(r, c + 1)
            area += dfs(r, c - 1)

            return area
        max_area = 0

        for r in range(rows):
            for c in range(cols):
                if grid[r][c] == 1:
                    max_area = max(max_area, dfs(r, c))

        return max_area
    
    def maxAreaOfIslandBFS(self, grid: List[List[int]]) -> int:
        from collections import deque

        rows, cols = len(grid), len(grid[0])

        def bfs(r, c):
            queue = deque([(r, c)])
            grid[r][c] = 0  # Mark as visited
            area = 1  # Current cell

            while queue:
                x, y = queue.popleft()

                for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
                    nx, ny = x + dx, y + dy

                    if 0 <= nx < rows and 0 <= ny < cols and grid[nx][ny] == 1:
                        grid[nx][ny] = 0  # Mark as visited
                        area += 1
                        queue.append((nx, ny))

            return area

        max_area = 0

        for r in range(rows):
            for c in range(cols):
                if grid[r][c] == 1:
                    max_area = max(max_area, bfs(r, c))

        return max_area