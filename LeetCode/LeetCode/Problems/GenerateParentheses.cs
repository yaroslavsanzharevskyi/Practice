using System.Collections.Generic;
namespace LeetCode.GenerateParentheses;
public class Solution {
    private readonly IList<string> res = new List<string>();
    
    public void GenerateParenthesis(ref int n, int left, int right, string buffer)
    {
        if(left > n || right > left)
        {
            return;
        }
        if(buffer.Length == n*2)
        {
            res.Add(buffer);
            return;
        }
        GenerateParenthesis(ref n,left+1, right, buffer+'(');
        GenerateParenthesis(ref n,left, right+1, buffer+')');
    }
    public IList<string> GenerateParenthesis(int n) {
        GenerateParenthesis(ref n,0,0,"");
        return res;
    }
}