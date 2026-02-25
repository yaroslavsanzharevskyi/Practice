using Xunit;

namespace DSA.Problems.Tests;

public class ContainsDuplicateTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4 }, false)]
    public void Should_ContainsDuplicate(int[] nums, bool expected)
    {
        // Arrange
        var containsDuplicate = new ContainsDuplicate();
        // Act
        var result = containsDuplicate.Solution(nums);
        // Assert
        Assert.Equal(expected, result);
    }
}