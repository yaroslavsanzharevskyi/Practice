using LeetCode.Problems.TwoPointers;
using NUnit.Framework;

namespace LeetCode.Problems.Tests;

[TestFixture]
public class ValidPalindromeTests
{
    [TestCase("1:2##32@%1$", true)]
    [TestCase("sobaka", false)]
    public void ShouldIdentifyPalindrome(string s, bool expectedResult)
    {
        // Arrange
        var validPalindrome = new ValidPalindrome();
        // Act 
        var actualResult = validPalindrome.IsValid(s);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}