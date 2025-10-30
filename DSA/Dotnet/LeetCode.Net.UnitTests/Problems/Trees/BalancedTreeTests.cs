using DSA.Problems.Helpers;
using DSA.Problems.Trees;
using NUnit.Framework;

namespace DSA.Problems.Tests.Trees;


[TestFixture]
public class BalancedTreeTests
{
    [Test]
    public void IsBalanced_ShouldReturnTrue_ForBalancedTree()
    {
        // Arrange
        var solution = new BalancedBinaryTree();
        var root = TreeHelpers.TransformToTree([1, 2, 2, 3, null, null, 3, 4, null, null, 4]);
        TreeHelpers.PrintTree(root);


        // Act
        var result = solution.IsBalanced(root);


        // Assert
        Assert.That(result, Is.False);
    }
}