
using Xunit;

namespace LeetCode.Problems.Tests;

public class AtoiTests
{
    [Theory]
    [InlineData("42", 42)]
    [InlineData("-42", -42)]
    [InlineData("1337c0d3", 1337)]
    [InlineData("0-1", 0)]
    [InlineData("words and 987", 0)]
    [InlineData("000100", 100)]
    [InlineData("   100", 100)]
    [InlineData("-91283472332", -2147483648)]
    [InlineData("3.123", 3)]
    [InlineData("+-12", 0)]
    [InlineData("  +  413", 0)]
    public void TransformToInt_ShouldTransformStringToInt(string numberAsString, int expectedNumber)
    {
        // Arrange
        var sut = new Atoi();

        // Act
        var result = sut.TransformToInt(numberAsString);

        // Assert
        Assert.Equal(expectedNumber, result);
    }
}
