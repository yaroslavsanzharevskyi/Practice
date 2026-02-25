using LeetCode.Problems.ArraysAndHashing;
using Xunit;

namespace LeetCode.Problems.Tests;

public class ProductOfArrayExceptSelfTests
{
    [Fact]
    public void Should_ReturnCorrectProduct()
    {
        // Arrange
        var solution = new ProductOfArrayExceptSelf();
        var nums = new int[] { 1, 2, 3, 4 };
        // Act
        var result = solution.Solution(nums);
        // Assert
        Assert.Equal(new int[] { 24, 16, 8, 6 }, result);
    }
}