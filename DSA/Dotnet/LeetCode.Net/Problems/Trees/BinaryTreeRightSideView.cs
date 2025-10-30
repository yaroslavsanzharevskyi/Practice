using System.Collections.Generic;
using LeetCode.Structures;

namespace DSA.Problems.Trees;

public class BinaryTreeRightSideView
{
    public List<int> RightSideViewBreadthApproach(TreeNode root)
    {
        List<int> result = new List<int>();

        if (root == null)
            return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {

            var currentLevelNodeCount = queue.Count;
            while (currentLevelNodeCount != 0)
            {
                var node = queue.Dequeue();

                if (currentLevelNodeCount == 1)
                {
                    result.Add(node.val);
                }

                currentLevelNodeCount--;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return result;
    }
}