// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

// Given a string s, return true if it is a palindrome, or false otherwise.

// Example 1:

// Input: s = "A man, a plan, a canal: Panama"
// Output: true
// Explanation: "amanaplanacanalpanama" is a palindrome.

using System;

namespace LeetCode.Problems.TwoPointers;

public class ValidPalindrome
{
    public bool IsValid(string s)
    {
        if(string.IsNullOrWhiteSpace(s))
        {
            return true;
        }

        var leftPointer = 0;
        var rightPointer = s.Length-1;
  
        while(leftPointer < rightPointer)
        {
            while(leftPointer < rightPointer && !Char.IsLetterOrDigit(s[leftPointer]))
            {
                leftPointer++;
            }
            while(leftPointer < rightPointer && !Char.IsLetterOrDigit(s[rightPointer]))
            {
                rightPointer--;
            }

           if(Char.ToLower(s[leftPointer]) != Char.ToLower(s[rightPointer]))
            {
                 return false;
            }

            leftPointer++;
            rightPointer--;
        }

        return true;
    }
}