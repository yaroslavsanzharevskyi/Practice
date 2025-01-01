

using System.Runtime.CompilerServices;
using NUnit.Framework;
namespace LeetCode.Problems.Tests;

[TestFixture]
public class RemoveDuplicateFromSortedArrayTests
{
    [TestCase(new int[] {1,1}, 1)]
    [TestCase(new int[]{0,1,1,1,2,2,3}, 4)]
    [TestCase(new int[]{1,1,1,1,2,2,3}, 3)]
    [TestCase(new int[]{1,1,1,1,1,1,1}, 1)]
    [TestCase(new int[]{0,1,2,2,2,3,3}, 4)]
    public void Should_RemoveDuplicates(int[] nums, int count)
    {
        // Arrange
        var removeDuplicates = new RemoveDuplicateFromSortedArray();
        // Act
        var result = removeDuplicates.Solution(nums);
        // Assert
        Assert.That(result, Is.EqualTo(count));
    }   
}
