using System;
using System.Collections.Generic;
using Leetcode.Problems;
using LeetCode.Utills;
using NUnit.Framework;

namespace LeetCode.Problems.Tests;

[TestFixture]
public class SwapPairsTests
{
    [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 1, 4, 3 })]
    public void Should_SwapPairs(int[] inputArray, int[] expectedResult)
    {
        // Arrange
        var testList = ListFunctions.BuildLinkedList(inputArray);
        var swapSolution = new SwapPairs();

        // Act
        var result = swapSolution.Solution(testList);
        var flatResult = ListFunctions.BuildArrayFromList(result);
        // Assert
        Assert.That(flatResult, Is.EqualTo(expectedResult));
    }
}