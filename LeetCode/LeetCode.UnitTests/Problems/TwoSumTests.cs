using LeetCode.Algorithms;
using NUnit.Framework;

namespace LeetCode.Problems.Tests;

[TestFixture]
public class TwoSumTests
{
    [TestCase(new int[] { 2, 4, 3, 5, 6 }, 7, new int[]{1,2})]
    public void Should_FindPairs(int[] nums, int target, int[] expectedResult)
    {
        // Arrange
        var solution = new TwoSumAlgorithm();

        // Act
        var result = solution.TwoSum(nums, target);

        // Asserty
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}