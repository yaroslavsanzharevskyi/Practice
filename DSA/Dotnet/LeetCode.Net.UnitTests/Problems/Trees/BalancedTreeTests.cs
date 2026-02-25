using DSA.Problems.Helpers;
using DSA.Problems.Trees;
using Xunit;

namespace DSA.Problems.Tests.Trees;


public class BalancedTreeTests
{
    [Fact]
    public void IsBalanced_ShouldReturnTrue_ForBalancedTree()
    {
        // Arrange
        var solution = new BalancedBinaryTree();
        var root = TreeHelpers.TransformToTree([1, 2, 2, 3, null, null, 3, 4, null, null, 4]);
        TreeHelpers.PrintTree(root);


        // Act
        var result = solution.IsBalanced(root);


        // Assert
        Assert.False(result);
    }
}