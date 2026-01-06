class Solution:
    def hammingWeight(self, n: int) -> int:
        count_bits =0
        for i in range(32):
            count_bits += n & 1
            n = n >> 1
        
        return count_bits
            