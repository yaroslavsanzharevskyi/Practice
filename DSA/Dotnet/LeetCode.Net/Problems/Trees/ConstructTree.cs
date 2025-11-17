using System.Collections.Generic;
using System.Linq;
using LeetCode.Structures;

namespace DSA.Problems.Trees;

public class ConstructBinaryTreeFromPreorderAndInorder
{
    private Dictionary<int, int> inorderIndex;
    private int preorderIndex;

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        inorderIndex = new Dictionary<int, int>();
        preorderIndex = 0;

        // Map each value to its index in inorder
        for (int i = 0; i < inorder.Length; i++)
            inorderIndex[inorder[i]] = i;

        return Build(preorder, 0, inorder.Length - 1);
    }

    private TreeNode Build(int[] preorder, int left, int right)
    {
        if (left > right)
            return null;

        // Pick the next root from preorder
        int rootValue = preorder[preorderIndex++];
        TreeNode root = new TreeNode(rootValue);

        // Find root position in inorder
        int mid = inorderIndex[rootValue];

        // Build left and right subtrees recursively
        root.left = Build(preorder, left, mid - 1);
        root.right = Build(preorder, mid + 1, right);

        return root;
    }
}