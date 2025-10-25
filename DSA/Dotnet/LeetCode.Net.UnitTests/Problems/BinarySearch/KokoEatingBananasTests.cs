using NUnit.Framework;

namespace LeetCode.Tests.Problems.BinarySearch;

[TestFixture]
public class KokoEatingBananasTests
{
    [Test]
    public void MinEatingSpeed_ShouldReturnCorrectSpeed()
    {
        // Arrange
        var solution = new LeetCode.Problems.BinarySearch.KokoEatingBananas();
        var piles = new int[] { 3, 6, 7, 11 };
        var expectedSpeed = 4;
        var h = 8;

        // Act
        var actualSpeed = solution.MinEatingSpeed(piles, h);

        // Assert
        Assert.That(actualSpeed, Is.EqualTo(expectedSpeed));
    }
}