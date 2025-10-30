using System;
using System.Collections.Generic;
using LeetCode.Structures;

namespace DSA.Problems.Helpers;


public static class TreeHelpers
{
    public static TreeNode? TransformToTree(int?[] array)
    {
        if (array.Length == 0 || array[0] == null)
            return null;

        var root = new TreeNode(array[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;
        while (i < array.Length)
        {
            var current = queue.Dequeue();

            if (i < array.Length && array[i] != null)
            {
                current.left = new TreeNode(array[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            if (i < array.Length && array[i] != null)
            {
                current.right = new TreeNode(array[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }

    public static void PrintTree(TreeNode root, string indent = "", bool isLast = true)
    {
        if (root == null) return;

        Console.WriteLine(indent + (isLast ? "└── " : "├── ") + root.val);

        if (root.left != null || root.right != null)
        {
            if (root.right != null)
                PrintTree(root.right, indent + (isLast ? "    " : "│   "), root.left == null);
            if (root.left != null)
                PrintTree(root.left, indent + (isLast ? "    " : "│   "), true);
        }
    }
}