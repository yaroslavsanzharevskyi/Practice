using LeetCode.Problems.ArraysAndHashing;
using NUnit.Framework;

namespace LeetCode.Problems.Tests;

[TestFixture]
public class ProductOfArrayExceptSelfTests
{
    [Test]
    public void Should_ReturnCorrectProduct()
    {
        // Arrange
        var solution = new ProductOfArrayExceptSelf();
        var nums = new int[] { 1, 2, 3, 4 };
        // Act
        var result = solution.Solution(nums);
        // Assert
        Assert.That(result, Is.EqualTo(new int[] { 24, 16, 8, 6 }));
    }
}