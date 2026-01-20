class Solution:
    def orangesRotting(self, grid: List[List[int]]) -> int:
        rows, cols = len(grid), len(grid[0])

        from collections import deque
        queue = deque()
        
        fresh_count = 0
        for r in range(rows):
           for c in range(cols):
                if grid[r][c] == 2:
                    queue.append((r, c))
                elif grid[r][c] == 1:
                    fresh_count += 1
        minutes = 0
        
        while queue and fresh_count > 0:
            for _ in range(len(queue)):
                x, y = queue.popleft()
                
                for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
                    nx, ny = x + dx, y + dy
                    
                    if 0 <= nx < rows and 0 <= ny < cols and grid[nx][ny] == 1:
                        grid[nx][ny] = 2
                        fresh_count -= 1
                        queue.append((nx, ny))
            minutes += 1

        return minutes if fresh_count == 0 else -1