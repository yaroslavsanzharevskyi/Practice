
using Xunit;

namespace LeetCode.Problems.Tests;

public class TopKFrequentTests
{

    [Theory]
    [InlineData(new int[] { 1, 1, 1, 2, 2, 3, 4, 5, 6 }, 2, new int[] { 1, 2 })]
    public void Should_FindTopKFrequent(int[] nums, int topK, int[] expectedResult)
    {
        // Arrange
        var TopKFrequent = new TopKFrequent();
        
        // Act
        var result = TopKFrequent.Solution(nums, topK);

        // Assert
        Assert.Equal(expectedResult, result);

    }
}