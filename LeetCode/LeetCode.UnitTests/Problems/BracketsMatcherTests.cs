
using System;
using Xunit;
using LeetCode.Problems;

namespace LeetCode.UnitTests.Problems
{
    public class BraketsChecker
    {
        [Theory]
        [InlineData("([][]{})", true)]
        [InlineData("([)[]{})", false)]
        public void Should_ReturnResultEqualsToExpected(string brackets, bool expectedResult)
        {
            // Arrange
            var matcher = new BracketsMatcher();
            
            // Act
            var result = matcher.BracketsMatch(brackets);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}