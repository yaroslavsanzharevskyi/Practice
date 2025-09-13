from typing import List


class ShuffleString:
    def restoreString(self, s: str, indices: List[int]) -> str:
        result = [""] * len(indices)
        
        for i in range(len(indices)):
            result[indices[i]] = s[i]
        
        return result