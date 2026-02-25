using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LeetCode.Problems.Intervals;
using Xunit;

namespace LeetCode.Problems.Tests.Intervals;

public class NonOverlappingIntervalsTests
{
    private readonly NonOverlappingIntervals _solution;

    public NonOverlappingIntervalsTests()
    {
        _solution = new NonOverlappingIntervals();
    }

    [Theory]
    [InlineData("[[1,2],[2,3],[3,4],[1,3]]", 1)]
    [InlineData("[[1,2],[1,2],[1,2]]", 2)]
    [InlineData("[[1,2],[2,3]]", 0)]
    [InlineData("[[1,4], [2,3], [3,5]]", 1)]
    [InlineData("[[1,10],[5,15],[10,100],[10,15],[15,25],[25,75]]", 2)]
    [Trait("Category", "BasicCases")]
    public void EraseOverlapIntervals_BasicCases_ReturnsExpectedCount(string intervalsJson, int expected)
    {
        var intervals = ParseIntervals(intervalsJson);
        var result = _solution.EraseOverlapIntervals(intervals);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("[]", 0)]
    [InlineData("[[1,5]]", 0)]
    [InlineData("[[1,2],[2,3],[3,4],[4,5]]", 0)]
    [Trait("Category", "EdgeCases")]
    public void EraseOverlapIntervals_EdgeCases_ReturnsExpectedCount(string intervalsJson, int expected)
    {
        var intervals = ParseIntervals(intervalsJson);
        var result = _solution.EraseOverlapIntervals(intervals);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("[[1,100],[1,11],[1,22],[11,22]]", 2)]
    [InlineData("[[0,2],[1,2],[1,2],[2,3]]", 2)]
    [InlineData("[[1,10],[2,3],[4,5],[6,7]]", 1)]
    [InlineData("[[-100,100],[-50,50],[0,25]]", 2)]
    [InlineData("[[5,10],[1,3],[8,12],[2,6]]", 2)]
    [Trait("Category", "ComplexCases")]
    public void EraseOverlapIntervals_ComplexCases_ReturnsExpectedCount(string intervalsJson, int expected)
    {
        var intervals = ParseIntervals(intervalsJson);
        var result = _solution.EraseOverlapIntervals(intervals);
        Assert.Equal(expected, result);
    }

    private static int[][] ParseIntervals(string json)
    {
        return Regex.Matches(json, @"\[(-?\d+),(-?\d+)\]")
            .Select(m => new[] { int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value) })
            .ToArray();
    }
}
