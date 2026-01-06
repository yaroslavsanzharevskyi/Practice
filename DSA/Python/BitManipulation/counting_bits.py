class Solution:
    def countBits(self, n:int) -> List[int]:
        result = [0] * (n + 1)
        
        for i in range(1, n + 1):
            # result[i] = number of 1s in (i // 2) + last bit of i
            result[i] = result[i >> 1] + (i & 1)
        
        return result
    def countBits2(self, n: int) -> List[int]:
        result = [0] * (n + 1)
        offset = 1  # The current power of 2
        
        for i in range(1, n + 1):
            # When i reaches the next power of 2, update the offset
            if offset * 2 == i:
                offset = i
            
            # result[i] = 1 + result[i - offset]
            result[i] = 1 + result[i - offset]
        
        return result