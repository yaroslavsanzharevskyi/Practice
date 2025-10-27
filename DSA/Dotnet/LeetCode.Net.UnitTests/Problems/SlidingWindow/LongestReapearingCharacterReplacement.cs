using NUnit.Framework;
using DSA.Problems.SlidingWindow;

namespace DSA.Problems.SlidingWindow.Tests;

[TestFixture]
public class LongestRepeatingCharacterReplacementTests
{
    [TestCase("ABCDZZZ", 3, 6)]
    public void CharacterReplacement_ShouldReturnExpectedResult(string s, int k, int expected)
    {
        // Arrange
        var solver = new LongestRepeatingCharacterReplacement();

        // Act
        var result = solver.CharacterReplacement(s, k);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }
}