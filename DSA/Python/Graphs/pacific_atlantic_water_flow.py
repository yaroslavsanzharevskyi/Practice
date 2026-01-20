class Solution:
    def pacificAtlantic(self, heights: List[List[int]]) -> List[List[int]]:
        rows, cols = len(heights), len(heights[0])
        pacific_reachable = set()
        atlantic_reachable = set()

        def dfs(r, c, reachable):
            reachable.add((r, c))

            for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
                nx, ny = r + dx, c + dy

                if (0 <= nx < rows and 0 <= ny < cols and
                        (nx, ny) not in reachable and
                        heights[nx][ny] >= heights[r][c]):
                    dfs(nx, ny, reachable)

        for r in range(rows):
            dfs(r, 0, pacific_reachable)
            dfs(r, cols - 1, atlantic_reachable)

        for c in range(cols):
            dfs(0, c, pacific_reachable)
            dfs(rows - 1, c, atlantic_reachable)

        result = list(pacific_reachable & atlantic_reachable)
        return result
