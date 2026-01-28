from collections import deque

class Solution:
    def wordBreak(self, s: str, wordDict: list[str]) -> bool:
        word_set = set(wordDict)  # Convert wordDict to a set for O(1) lookups
        n = len(s)
        queue = deque([0])  # Start BFS from index 0
        visited = set()  # To avoid revisiting indices

        while queue:
            start = queue.popleft()
            if start in visited:
                continue
            visited.add(start)

            for end in range(start + 1, n + 1):
                if s[start:end] in word_set:
                    if end == n:  # If we reach the end of the string
                        return True
                    queue.append(end)

        return False

# class Solution:
#     def wordBreak(self, s: str, wordDict: list[str]) -> bool:
#         word_set = set(wordDict)
#         n = len(s)
#         dp = [False] * (n + 1)
#         dp[0] = True  # Empty string can be segmented

#         for i in range(1, n + 1):
#             for j in range(i):
#                 if dp[j] and s[j:i] in word_set:
#                     dp[i] = True
#                     break

#         return dp[n]Initialization:


# word_set = {"leet", "code"}
# dp = [True, False, False, False, False, False, False, False, False]
# Outer Loop(i):

# i = 1: No valid split, dp[1] = False.
# i = 2: No valid split, dp[2] = False.
# i = 3: No valid split, dp[3] = False.
# i = 4: j = 0, dp[j] = True and s[0:4] = "leet" in word_set. Set dp[4] = True.
# i = 5: No valid split, dp[5] = False.
# i = 6: No valid split, dp[6] = False.
# i = 7: No valid split, dp[7] = False.
# i = 8: j = 4, dp[4] = True and s[4:8] = "code" in word_set. Set dp[8] = True.
# Final dp Array:

# dp = [True, False, False, False, True, False, False, False, True]
# Result:

# dp[8] = True, so the function returns True.
