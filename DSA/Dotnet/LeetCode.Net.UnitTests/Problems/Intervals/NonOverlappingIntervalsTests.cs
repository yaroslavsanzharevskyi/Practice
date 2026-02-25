using System.Collections.Generic;
using System.Linq;
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
        json = json.Trim();
        if (json == "[]") return [];

        json = json.Trim('[', ']');
        var intervalStrings = new List<string>();
        var depth = 0;
        var currentInterval = "";

        foreach (var c in json)
        {
            if (c == '[') depth++;
            if (c == ']') depth--;

            currentInterval += c;

            if (depth == 0 && c == ']')
            {
                intervalStrings.Add(currentInterval.Trim());
                currentInterval = "";
            }
        }

        return intervalStrings
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim('[', ']').Split(',').Select(int.Parse).ToArray())
            .ToArray();
    }
}
