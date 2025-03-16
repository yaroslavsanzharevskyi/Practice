
using System;
using System.Runtime.Versioning;
using LeetCode.Structures;


/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class DiameterOfBinaryTree
{
    private int globalDiameter = 0;
    public int CalcDiameter(TreeNode root)
    {
        if (root != null)
        {
            var leftBranchDepth = CalcMaxDepth(root.left);
            var rightBranchDepth = CalcMaxDepth(root.right);
            var localMax = leftBranchDepth + rightBranchDepth;
            globalDiameter = Math.Max(localMax, globalDiameter);

        }

        return globalDiameter;
    }

    private int CalcMaxDepth(TreeNode root, int baseDepth = 0)
    {
        if(root == null)
        {
            return 0;
        }
        baseDepth++;
        var leftBranchDepth = CalcMaxDepth(root.left);
        var rightBranchDepth = CalcMaxDepth(root.right);

        var localDiameter = leftBranchDepth + rightBranchDepth;
        globalDiameter = Math.Max(localDiameter, globalDiameter);

        var branchMax = Math.Max(leftBranchDepth, rightBranchDepth);

        return baseDepth + branchMax;
    }
}