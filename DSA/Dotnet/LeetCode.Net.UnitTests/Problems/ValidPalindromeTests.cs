using LeetCode.Problems.TwoPointers;
using Xunit;

namespace LeetCode.Problems.Tests;

public class ValidPalindromeTests
{
    [Theory]
    [InlineData("1:2##32@%1$", true)]
    [InlineData("sobaka", false)]
    public void ShouldIdentifyPalindrome(string s, bool expectedResult)
    {
        // Arrange
        var validPalindrome = new ValidPalindrome();
        // Act 
        var actualResult = validPalindrome.IsValid(s);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}