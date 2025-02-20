using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Problems.Tests;

[TestFixture]
public class EncodeDecodeTests
{

    [Test]
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
        Assert.That(decodedStrings, Is.EquivalentTo(expectedCollection));
    }
}