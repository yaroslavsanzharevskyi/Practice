using LeetCode.Problems.Stack;
using Xunit;

namespace LeetCode.Problems.Tests;

public class ValidParenthesesTests
{
    [Theory]
    [InlineData("{}{}{}", true)]
    [InlineData("(]", false)]
    public void Should_ReturnCorrectResult(string s, bool expectedResult)
    {
        // Arrange
        var parenthesesValidator = new ValidParentheses();
        // Act
        var result = parenthesesValidator.IsValid(s);
        // Assert
        Assert.Equal(expectedResult, result);
    }
}