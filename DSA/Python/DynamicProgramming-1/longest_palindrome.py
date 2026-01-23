class Solution:
    def longestPalindrome(self, s: str) -> str:
        if not s:
            return ""

        def expand_around_center(left: int, right: int) -> str:
            while left >= 0 and right < len(s) and s[left] == s[right]:
                left -= 1
                right += 1
            return s[left + 1:right]

        longest = ""
        for i in range(len(s)):
            # Odd length palindromes
            odd_pal = expand_around_center(i, i)
            if len(odd_pal) > len(longest):
                longest = odd_pal
            # Even length palindromes
            even_pal = expand_around_center(i, i + 1)
            if len(even_pal) > len(longest):
                longest = even_pal

        return longest

# class Solution:
#     def longestPalindrome(self, s: str) -> str:
#         n = len(s)
#         if n == 0:
#             return ""

#         dp = [[False] * n for _ in range(n)]
#         start, max_length = 0, 1

#         for i in range(n):
#             dp[i][i] = True

#         for length in range(2, n + 1):
#             for i in range(n - length + 1):
#                 j = i + length - 1

#                 if s[i] == s[j]:
#                     if length == 2:
#                         dp[i][j] = True
#                     else:
#                         dp[i][j] = dp[i + 1][j - 1]

#                 if dp[i][j] and length > max_length:
#                     start = i
#                     max_length = length

#         return s[start:start + max_length]
