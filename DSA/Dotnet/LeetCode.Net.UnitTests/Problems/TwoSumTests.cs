using LeetCode.Algorithms;
using Xunit;

namespace LeetCode.Problems.Tests;

public class TwoSumTests
{
    [Theory]
    [InlineData(new int[] { 2, 4, 3, 5, 6 }, 7, new int[]{1,2})]
    public void Should_FindPairs(int[] nums, int target, int[] expectedResult)
    {
        // Arrange
        var solution = new TwoSumAlgorithm();

        // Act
        var result = solution.TwoSum(nums, target);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}