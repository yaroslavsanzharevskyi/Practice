using NUnit.Framework;

namespace DSA.Problems.Tests;

[TestFixture]
public class ContainsDuplicateTests
{
    [TestCase(new[] { 1, 2, 3, 1 }, true)]
    [TestCase(new[] { 1, 2, 3, 4 }, false)]
    public void Should_ContainsDuplicate(int[] nums, bool expected)
    {
        // Arrange
        var containsDuplicate = new ContainsDuplicate();
        // Act
        var result = containsDuplicate.Solution(nums);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}