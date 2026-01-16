class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:
        rows, cols = len(board), len(board[0])
        visited = set()

        def backtrack(i: int, j: int, index: int):
            if index == len(word):
                return True

            if (i < 0 or i >= rows or
               j < 0 or j >= cols or
               (i, j) in visited or
               board[i][j] != word[index]):
                return False

            visited.add((i, j))

            found = (backtrack(i + 1, j, index + 1) or
                     backtrack(i - 1, j, index + 1) or
                     backtrack(i, j + 1, index + 1) or
                     backtrack(i, j - 1, index + 1))
            
            visited.remove((i,j))
            
            return found

        for i in range(rows):
            for j in range(cols):
                if backtrack(i, j, 0):
                    return True

        return False
