using LeetCode.Problems;
using System;
using Xunit;

namespace LeetCode.UnitTests.Problems
{
    public class ReverseIntegerTests
    {
        [Theory]
        [InlineData(123,321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(2147483647, 0)]
        [InlineData(-2147483648, 0)]
        public void Reverse_ReversingIntegerValue(Int64 original, Int64 reversed)
        {
            // Arrange
            // Act 
            var result = ReverseInteger.Reverse(original);
            // Assert
            Assert.Equal(reversed, result);
        }
    }
}
