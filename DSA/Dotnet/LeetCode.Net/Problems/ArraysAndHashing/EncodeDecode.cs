using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems;

public class EncodeDecode
{
    public string Encode(IList<string> strs)
    {
        var encodedStringBuilder = new StringBuilder();

        foreach (var str in strs)
        {
            encodedStringBuilder.Append($"{str.Length}#{str}");
        }

        return encodedStringBuilder.ToString();
    }

    public List<string> Decode(string s)
    {
        var list = new List<string>();
        var currentWordLenghSubstring = new StringBuilder();
        for (var i = 0; i < s.Length;)
        {
            if (s[i] != '#')
            {
                currentWordLenghSubstring.Append(s[i]);
                i++;
            }
            else
            {
                var wordLength = Int32.Parse(currentWordLenghSubstring.ToString());
                list.Add(s.Substring(++i, wordLength));
                currentWordLenghSubstring.Clear();
                i+=wordLength;
            }
        }

        return list;
    }
}