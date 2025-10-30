using LeetCode.Structures;

namespace DSA.Problems.Trees;

public class SubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
            return false;

        // Check if trees rooted at current node are identical
        // OR if subRoot is subtree of left child
        // OR if subRoot is subtree of right child
        return IsSameTree(root, subRoot) ||
               IsSubtree(root.left, subRoot) ||
               IsSubtree(root.right, subRoot);
    }

    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }

        if (p == null || q == null)
        {
            return false;
        }

        return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}