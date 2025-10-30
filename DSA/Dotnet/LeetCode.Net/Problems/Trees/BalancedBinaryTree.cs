using System;
using LeetCode.Structures;

namespace DSA.Problems.Trees;

public class BalancedBinaryTree
{
    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        var leftDepth = GetHeight(root.left);
        var rightDepth = GetHeight(root.right);

        return Math.Abs(leftDepth - rightDepth) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int GetHeight(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var leftDepth = GetHeight(node.left);
        var rightDepth = GetHeight(node.right);
        return Math.Max(leftDepth, rightDepth) + 1;
    }
}