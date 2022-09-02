using LeetCode.Structures;

namespace LeetCode.Problems
{
    public class InvertBinaryTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            
            InvertTree(root.left);
            InvertTree(root.right);

            var tempRight = root.right;
            root.right = root.left;
            root.left = tempRight;

            return root;
        }
    }
}
