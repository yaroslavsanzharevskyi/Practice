using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems;

public class ValidAnagram
{
    public bool Solution(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var charArrayS = s.ToCharArray();
        var charArrayT = t.ToCharArray();

        Array.Sort(charArrayS);
        Array.Sort(charArrayT);

        for (var i = 0; i < charArrayS.Length; i++)
        {
            if (charArrayS[i] != charArrayT[i])
            {
                return false;
            }
        }

        return true;
    }

    public bool Solution_Fast(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var letterDict = new Dictionary<char, uint>();
        for (var i = 0; i < s.Length; i++)
        {
            letterDict[s[i]] = letterDict.GetValueOrDefault(s[i]) + 1;
        }

        for (var i = 0; i < t.Length; i++)
        {
            if (!letterDict.ContainsKey(t[i]))
            {
                return false;
            }

            letterDict[t[i]] = letterDict[t[i]] - 1;

            if(letterDict[t[i]] == 0)
            {
                letterDict.Remove(t[i]);
            }
            
        }

        return true;
    }
}