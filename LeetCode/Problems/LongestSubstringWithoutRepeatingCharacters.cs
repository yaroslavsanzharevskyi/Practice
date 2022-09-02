using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            var charDictionary = new Dictionary<char, int>();
            var longestSubStringLength = 0;
            var charBuffer = new StringBuilder();
            
            for (var i = 0; i < s.Length; i++)
            {
                if (charDictionary.ContainsKey(s[i]))
                {
                    longestSubStringLength = Math.Max(
                        charDictionary.Count,
                        longestSubStringLength);

                    // Find a tail
                    var removedTails = charBuffer.ToString().Substring(0, charDictionary[s[i]]+1);
                    // Remove tails from original buffer
                    charBuffer.Remove(0, charDictionary[s[i]]+1);

                    // remove all tail characters from dictionary
                    foreach (var c in removedTails)
                    {
                        charDictionary.Remove(c);
                    }

                    for(var d = 0; d < charBuffer.Length; d++)
                    {
                        charDictionary[charBuffer[d]] -= removedTails.Length;
                    }
                }

                charDictionary.Add(s[i], charBuffer.Length);
                charBuffer.Append(s[i]);

                if (longestSubStringLength >= charBuffer.Length + s.Length - (i + 1)) break;

            }

            return Math.Max(longestSubStringLength, charDictionary.Count);
        }
    }
}
