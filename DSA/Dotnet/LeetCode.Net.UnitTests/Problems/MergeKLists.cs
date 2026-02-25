
using LeetCode.Utills;
using Xunit;

namespace LeetCode.Problems.Tests;

public class MergeKListsTests
{
    [Fact]
    public void Should_MergeKLists()
    {
        // Arrange
        var list1 = new ListNode(1, new ListNode(4, new ListNode(5)));
        var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
        var list3 = new ListNode(2, new ListNode(6));
        var mergeKLists = new MergeKLists();
        // Act
        var result = mergeKLists.Solution(new[] { list1, list2, list3 });
        var flatResult = ListFunctions.BuildArrayFromList(result);

        // Assert 
        Assert.Equal(new[] { 1, 1, 2, 3, 4, 4, 5, 6 }, flatResult);
    }
}