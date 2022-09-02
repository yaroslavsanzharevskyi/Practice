using System;
using LeetCode.Structures;

namespace LeetCode.Problems
{
    public class MaximumDepthOfBinaryTree
    {

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
         
            var leftDepth = MaxDepth(root.left);
            var rightDepth = MaxDepth(root.right);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
