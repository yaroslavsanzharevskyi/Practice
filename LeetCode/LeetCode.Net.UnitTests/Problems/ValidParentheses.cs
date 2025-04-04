using LeetCode.Problems.Stack;
using NUnit.Framework;

namespace LeetCode.Problems.Tests;

[TestFixture]
public class ValidParenthesesTests
{
    [TestCase("{}{}{}", true)]
    [TestCase("(]", false)]
    public void Should_ReturnCorrectResult(string s, bool expectedResult)
    {
        // Arrange
        var parenthesesValidator = new ValidParentheses();
        // Act
        var result = parenthesesValidator.IsValid(s);
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}