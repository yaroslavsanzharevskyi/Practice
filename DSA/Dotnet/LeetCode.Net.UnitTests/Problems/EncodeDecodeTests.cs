using System.Collections.Generic;
using Xunit;

namespace LeetCode.Problems.Tests;

public class EncodeDecodeTests
{

    [Fact]
    public void Should_EncodeAndDecode()
    {
        // Arrange
        var expectedCollection = new List<string>() {
            "buba",
            "parapapa",
            "bababababub",
            "a",
            "ab",
            "abc"
        };
        var solution = new EncodeDecode();

        // Act
        var encodedString = solution.Encode(expectedCollection);
        var decodedStrings = solution.Decode(encodedString);
        // Assert
        Assert.Equal(expectedCollection, decodedStrings);
    }
}