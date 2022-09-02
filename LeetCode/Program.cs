using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using LeetCode.Algorithms;
using LeetCode.Problems;

namespace LeetCode
{


    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            var brackets = "([][]{})";
            var matcher = new BracketsMatcher();
            
            // Act
            var result = matcher.BracketsMatch(brackets);
        }
    }
}
