using LeetCode.Structures;
using Microsoft.VisualBasic;

namespace DSA.Problems.Trees;

public class ValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    public bool IsValidBST(TreeNode node, long minValue, long maxValue)
    {
        if (node == null)
            return true;
        if (node.val <= minValue || node.val >= maxValue)
            return false;

        return IsValidBST(node.left, minValue, node.val) && IsValidBST(node.right, node.val, maxValue);
    }
}