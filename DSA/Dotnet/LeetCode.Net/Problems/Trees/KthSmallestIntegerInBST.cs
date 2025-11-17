using LeetCode.Structures;

namespace DSA.Problems.Trees;

public class KthSmallestIntegerInBst
{
    public int KthSmallest(TreeNode root, int k)
    {
        int count = 0;
        int result = -1;

        void Inorder(TreeNode node)
        {
            if (node == null || result != -1)
                return;

            Inorder(node.left);

            count++;
            if (count == k)
            {
                result = node.val;
                return;
            }

            Inorder(node.right);
        }

        Inorder(root);
        return result;
    }


}