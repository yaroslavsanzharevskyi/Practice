using System;
using LeetCode.Structures;

namespace DSA.Problems.Trees;

public class CountGoodNodesInBinaryTree
{
    public int GoodNodes(TreeNode root)
    {
        if (root == null)
            return 0;

        return GoodNodes(root.left, root.val) + GoodNodes(root.right, root.val) + 1;
    }

    private int GoodNodes(TreeNode node, int currentMax)
    {
        if (node == null)
            return 0;

        var newMax = Math.Max(currentMax, node.val);

        return GoodNodes(node.left, newMax) + GoodNodes(node.right, newMax) + (node.val >= currentMax ? 1 : 0);
    }
}