using LeetCode.Problems.DynamicProgramming;
using Xunit;

namespace LeetCode.Problems.Tests;

public class ClimbingStairsTests
{
    [Fact]
    public void Test1()
    {
        var solution = new ClimbingStairsSolution();

        var result = solution.ClimbStairs(2);

        Assert.Equal(2, result);
    }
}
