

using Xunit;

namespace LeetCode.Problems.Tests;


public class ValidAnagramTests 
{
    [Theory]
    [InlineData("anagram","angaram", true)]
    public void Should_ValidAnagram(string s, string t, bool expectedResult)
    {
        // Arrange
        var solution = new ValidAnagram();

        // Act
        var actualResult = solution.Solution(s,t);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("anagram","angaram", true)]
    public void Should_ValidAnagram_Fast(string s, string t, bool expectedResult)
    {
        // Arrange
        var solution = new ValidAnagram();

        // Act
        var actualResult = solution.Solution_Fast(s,t);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}