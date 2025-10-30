
using LeetCode.Structures;

namespace DSA.Problems.Trees;

public class LowestCommonAncestorInBinarySearchTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || p == null || q == null)
            return null;

        if (root.val < p.val && root.val < q.val)
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        else if (root.val > p.val && root.val > q.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }

        return root;
    }
}