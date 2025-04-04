using LeetCode.Problems.DynamicProgramming;
using NUnit.Framework;

namespace LeetCode.Problems.Tests;

[TestFixture]
public class ClimbingStairsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var solution = new ClimbingStairsSolution();


        var result = solution.ClimbStairs(2);

        Assert.That(result, Is.EqualTo(2));
    }
}
