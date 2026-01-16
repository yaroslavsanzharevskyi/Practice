from typing import List

class Solution:
    def partition(self, s: str) -> List[List[str]]:
        result = []

        def backtrack(start: int, path: List[str]):
            # Base case: used entire string
            if start == len(s):
                result.append(path.copy())
                return

            # Try all substrings starting at `start`
            # start = 0
            # 0 to len(s)-1
            for end in range(start, len(s)): # first iteration end = 0
                if not is_palindrome(start, end): # a 
                    continue

                # Choose
                path.append(s[start:end + 1]) # path = [a]

                # Explore
                backtrack(end + 1, path) # path [a ,a , b] after that we store result in array

                # Undo:  we pop 'b', but path is [a, a] now
                path.pop()

        def is_palindrome(l: int, r: int) -> bool:
            while l < r:
                if s[l] != s[r]:
                    return False
                l += 1
                r -= 1
            return True

        backtrack(0, [])
        return result
