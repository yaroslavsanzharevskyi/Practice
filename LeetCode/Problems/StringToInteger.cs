

using System;

namespace LeetCode.Problems;
public class StringToInteger
{
    public int myAtoi(string s)
    {
        var result = Int32.Parse(s);
        return result;
    }
}