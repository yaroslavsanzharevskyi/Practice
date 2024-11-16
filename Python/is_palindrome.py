class Solution:
    def isPalindrome(self, x: int) -> bool:
        if x < 0:
            return False
        num_str = str(x)
        last = len(num_str)//2
        for i in range(last):
            if num_str[i] != num_str[-i-1]:
                return False
        return True