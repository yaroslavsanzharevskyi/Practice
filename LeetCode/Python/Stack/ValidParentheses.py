# // You are given a string s consisting of the following characters: '(', ')', '{', '}', '[' and ']'.

# // The input string s is valid if and only if:

# // Every open bracket is closed by the same type of close bracket.
# // Open brackets are closed in the correct order.
# // Every close bracket has a corresponding open bracket of the same type.
# // Return true if s is a valid string, and false otherwise.


def isValidParenthses(val: str) -> bool:
    stack = []
    map = {"(": ")", "{": "}", "[": "]"}

    for a in val:
        if map.get(a):
            stack.append(a)
        else:
            key_of_last_parentheses = stack.pop()
            if map[key_of_last_parentheses] != a:
                return False

    return True


def main():
    test_str = "({[]]})"
    print(isValidParenthses(test_str))


if __name__ == "__main__":
    main()