using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Problems.SlidingWindow;

public class PermutationInString
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        // Count characters in s1
        var s1Count = new Dictionary<char, int>();
        foreach (char c in s1)
        {
            s1Count[c] = s1Count.GetValueOrDefault(c, 0) + 1;
        }

        var windowCount = new Dictionary<char, int>();
        int left = 0;

        for (int right = 0; right < s2.Length; right++)
        {
            // Add character from right
            char rightChar = s2[right];
            windowCount[rightChar] = windowCount.GetValueOrDefault(rightChar, 0) + 1;

            // Maintain window size equal to s1.Length
            if (right - left + 1 > s1.Length)
            {
                char leftChar = s2[left];
                windowCount[leftChar]--;
                if (windowCount[leftChar] == 0)
                    windowCount.Remove(leftChar);
                left++;
            }

            // Check if current window is a permutation of s1
            if (right - left + 1 == s1.Length && DictionariesEqual(s1Count, windowCount))
            {
                return true;
            }
        }

        return false;
    }

    private bool DictionariesEqual(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        if (dict1.Count != dict2.Count)
            return false;

        foreach (var kvp in dict1)
        {
            if (!dict2.TryGetValue(kvp.Key, out int count) || count != kvp.Value)
                return false;
        }

        return true;
    }
}