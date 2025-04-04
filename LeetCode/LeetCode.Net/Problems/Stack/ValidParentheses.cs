// You are given a string s consisting of the following characters: '(', ')', '{', '}', '[' and ']'.

// The input string s is valid if and only if:

// Every open bracket is closed by the same type of close bracket.
// Open brackets are closed in the correct order.
// Every close bracket has a corresponding open bracket of the same type.
// Return true if s is a valid string, and false otherwise.

using System.Collections.Generic;

namespace LeetCode.Problems.Stack;

public class ValidParentheses
{
    public bool IsValid(string s)
    {
        var charStack = new Stack<char>();
        var parentheses = new Dictionary<char, char> { { '(', ')' }, { '{', '}' }, { '[', ']' } };

        for (var i = 0; i < s.Length; i++)
        {
            if (parentheses.ContainsKey(s[i]))
            {
                charStack.Push(s[i]);
                continue;
            }

            if(charStack.Count == 0)
            {
                return false;
            }

            var lastParentheses = charStack.Peek();
            var expectedParentheses = parentheses[lastParentheses];
            if (expectedParentheses == s[i])
            {
                charStack.Pop();
            }
            else
            {
                return false;
            }
        }

        return charStack.Count == 0;
    }
}