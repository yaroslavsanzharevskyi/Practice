

using System.Runtime.CompilerServices;
using Xunit;
namespace LeetCode.Problems.Tests;

public class RemoveDuplicateFromSortedArrayTests
{
    [Theory]
    [InlineData(new int[] {1,1}, 1)]
    [InlineData(new int[]{0,1,1,1,2,2,3}, 4)]
    [InlineData(new int[]{1,1,1,1,2,2,3}, 3)]
    [InlineData(new int[]{1,1,1,1,1,1,1}, 1)]
    [InlineData(new int[]{0,1,2,2,2,3,3}, 4)]
    public void Should_RemoveDuplicates(int[] nums, int count)
    {
        // Arrange
        var removeDuplicates = new RemoveDuplicateFromSortedArray();
        // Act
        var result = removeDuplicates.Solution(nums);
        // Assert
        Assert.Equal(count, result);
    }   
}
