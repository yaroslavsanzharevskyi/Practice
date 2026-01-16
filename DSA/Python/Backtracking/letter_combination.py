from typing import List


class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        if not digits:
            return []
        
        key_pad = {
            '2': ['a', 'b', 'c'],
            '3': ['d', 'e', 'f'],
            '4': ['g', 'h', 'i'],
            '5': ['j', 'k', 'l'],
            '6': ['m', 'n', 'o'],
            '7': ['p', 'q', 'r', 's'],
            '8': ['t', 'u', 'v'],
            '9': ['w', 'x', 'y', 'z']
        }


        results = []

        def backtrack(index: int, path: List[str]):
            if index == len(digits):
                results.append(path)
                return

            key_options = key_pad[digits[index]]
            for letter in key_options:
                backtrack(index + 1, path + letter)

        backtrack(0, '')

        return results
