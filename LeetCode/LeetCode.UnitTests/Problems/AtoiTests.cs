
using NUnit.Framework;

namespace LeetCode.Problems;

[TestFixture]
public class AtoiTests
{
    [TestCase("42", 42)]
    [TestCase("-42", -42)]
    [TestCase("1337c0d3", 1337)]
    [TestCase("0-1", 0)]
    [TestCase("words and 987", 0)]
    [TestCase("000100", 100)]
    [TestCase("   100", 100)]
    [TestCase("-91283472332", -2147483648)]
    [TestCase("3.123", 3)]
    [TestCase("+-12", 0)]
    [TestCase("  +  413", 0)]
    // [TestCase("-91283472332", -2147483648)]
    public void TransformToInt_ShouldTransformStringToInt(string numberAsString, int expectedNumber)
    {
        // Arrange
        var sut = new Atoi();

        // Act
        var result = sut.TransformToInt(numberAsString);

        // Assert
        Assert.That(result, Is.EqualTo(expectedNumber));
    }
}
