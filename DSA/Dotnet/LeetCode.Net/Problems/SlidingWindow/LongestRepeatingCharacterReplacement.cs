using System;
using System.Collections.Generic;

namespace DSA.Problems.SlidingWindow;

public class LongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        var left = 0;
        var charCount = new Dictionary<char, int>();
        var maxLength = 0;
        var maxFreq = 0;

        for (var right = 0; right < s.Length; right++)
        {
            var rightChar = s[right];
            charCount[rightChar] = charCount.GetValueOrDefault(rightChar, 0) + 1;

            maxFreq = Math.Max(charCount[rightChar], maxFreq);

            var windowSize = right - left + 1; // because indexes are 0 based, we need to turn it into actual length

            if (windowSize - maxFreq > k)
            {
                var leftChar = s[left];
                charCount[leftChar]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

}