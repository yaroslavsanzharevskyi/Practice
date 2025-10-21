

using NUnit.Framework;

namespace LeetCode.Problems.Tests;


[TestFixture]
public class ValidAnagramTests 
{
    [TestCase("anagram","angaram", true)]
    public void Should_ValidAnagram(string s, string t, bool expectedResult)
    {
        // Arrange
        var solution = new ValidAnagram();

        // Act
        var actualResult = solution.Solution(s,t);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase("anagram","angaram", true)]
    public void Should_ValidAnagram_Fast(string s, string t, bool expectedResult)
    {
        // Arrange
        var solution = new ValidAnagram();

        // Act
        var actualResult = solution.Solution_Fast(s,t);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}