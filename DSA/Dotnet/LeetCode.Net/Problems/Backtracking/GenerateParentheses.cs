using System.Collections.Generic;
namespace LeetCode.GenerateParentheses;
public class Solution
{
    private readonly List<string> res = new List<string>();

    public void GenerateParenthesis(ref int n, int left, int right, string buffer)
    {
        if (right + left == n * 2)
        {
            res.Add(buffer);
            return;
        }

        if (left < n)
        {
            GenerateParenthesis(ref n, left + 1, right, buffer + '(');
        }

        if (right < left)
        {
            GenerateParenthesis(ref n, left, right + 1, buffer + ')');
        }
    }
    public List<string> GenerateParenthesis(int n)
    {
        GenerateParenthesis(ref n, 0, 0, "");
        return res;
    }
}