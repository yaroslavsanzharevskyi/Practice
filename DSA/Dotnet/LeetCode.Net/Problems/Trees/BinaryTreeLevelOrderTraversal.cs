using System.Collections.Generic;
using LeetCode.Structures;

namespace DSA.Problems.Trees;

// Breadth
public class BinaryTreeLevelOrderTraversal
{
    public List<List<int>> LevelOrder(TreeNode root)
    {
        List<List<int>> result = new List<List<int>>();

        if (root == null)
            return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var currentLevelList = new List<int>();
            var currentLevelCount = queue.Count;

            while (currentLevelCount != 0)
            {
                var node = queue.Dequeue();
                currentLevelList.Add(node.val);
                currentLevelCount--;

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);

            }

            result.Add(currentLevelList);

        }

        return result;
    }
}