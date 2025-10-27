using System;
using System.Collections.Generic;

namespace DSA.Problems.SlidingWindow;

public class MinimumWindowSubstring
{
    public string MinWindow(string s, string t)
    {
        if (t.Length > s.Length)
        {
            return string.Empty;
        }

        // while S dict keys has all keys and counts from t
        var tDict = new Dictionary<char, int>();

        for (var i = 0; i < t.Length; i++)
        {
            var iChar = t[i];
            tDict[iChar] = tDict.GetValueOrDefault(iChar, 0) + 1;
        }
        // A - 2
        // B - 1 
        // C - 3
        // min window == t.length
        var minSubString = string.Empty;
        var sDict = new Dictionary<char, int>();
        var left = 0;
        for (var right = 0; right < s.Length; right++)
        {
            var rightChar = s[right];
            sDict[rightChar] = sDict.GetValueOrDefault(rightChar, 0) + 1;

            while (ContainsAllSymbols(tDict, sDict))
            {
                var currentWindowSize = right - left + 1;
                var currentWindow = s.Substring(left, currentWindowSize);

                if (minSubString == string.Empty || currentWindow.Length < minSubString.Length)
                {
                    minSubString = currentWindow;
                }

                var leftChar = s[left];
                sDict[leftChar]--;
                if (sDict[leftChar] == 0)
                {
                    sDict.Remove(leftChar);
                }
                left++;
            }
        }

        return minSubString;
    }

    private bool ContainsAllSymbols(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        foreach (var kvp in dict1)
        {
            if (!dict2.TryGetValue(kvp.Key, out int count) || count < kvp.Value)
            {
                return false;
            }
        }

        return true;
    }
}