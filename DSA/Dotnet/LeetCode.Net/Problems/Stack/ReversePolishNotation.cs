using System.Collections.Generic;

namespace LeetCode.Problems.Stack;

public class ReversePolishNotation
{
    public int EvalRNP(string[] tokens)
    {
        var stack = new Stack<int>();
        for (var i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" | tokens[i] == "/")
            {
                var b = stack.Pop();
                var a = stack.Pop();

                int result = tokens[i] switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => 0
                };

                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(tokens[i]));
            }
        }

        return stack.Pop();
    }
}
