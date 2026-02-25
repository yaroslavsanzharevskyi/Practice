using LeetCode.Problems.ArraysAndHashing;
using Xunit;

namespace LeetCode.Problems.Tests;

public class LongestConsecutiveNumsTests
{
    [Theory]
    [InlineData(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
    [InlineData(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
    [InlineData(new int[] { 1, 0, 1, 2 }, 3)]
    public void Should_ReturnCorrectLongestSecuence(int[] nums, int expectedResult)
    {
        // Act
        var problemSolver = new LongestConsecutiveNums();

        // Arrange
        var actualResult = problemSolver.Solution(nums);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}