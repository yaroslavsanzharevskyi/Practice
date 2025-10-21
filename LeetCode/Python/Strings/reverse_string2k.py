class ReverseString2k:
    def reverseStr(self, s: str, k: int) -> str:
        i = 0
        n = len(s)
        gap = 2 * k
        s_list = list(s)
        while i < n:
            if n-i < k:
                swap_length = n-i
            else:
                swap_length = k

            for s in range(swap_length):
                for j in range(i, i + swap_length - s):
                    temp = s_list[j]
                    s_list[j] = s_list[j+1]
                    s_list[j+1] = temp
                
            i+=gap
        return "".join(s_list)
