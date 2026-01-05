
def isValidParentheses(s: str) -> bool:
    stack = []
    map_of_brackets = {'}':'{', ']':'[', ')':'('}
    
    for c in s:
        if c in map_of_brackets:
            if len(stack) > 0:
                previous_bracket = stack.pop()
                if previous_bracket == map_of_brackets[c]:
                    continue
                else:
                    return False
            else:
                return False
        
        else:
            # appending an opening bracket
            stack.append(c)
            
    return len(stack) == 0 # not stack
    