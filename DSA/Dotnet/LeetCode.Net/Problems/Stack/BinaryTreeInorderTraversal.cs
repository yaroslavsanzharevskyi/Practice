using System.Collections.Generic;
using System.Security.AccessControl;
using System.Xml.XPath;
using LeetCode.Structures;

namespace leetCode.Problems.Stack;

public class BinaryTreeInorderTraversalStack
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        var list = new List<int>();
        var target = root;

        while (target != null || stack.Count > 0)
        {

            while (target != null)
            {
                stack.Push(target);
                target = target.left;
            }

            var node = stack.Pop();
            list.Add(node.val);

            target = node.right;
        }
        return list;
    }
}
public class BinaryTreeInorderTraversalRecursion
{
    private List<int> list = new List<int>();

    private void Traverse(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        if (node.left != null)
        {
            Traverse(node.left);
        }

        list.Add(node.val);

        Traverse(node.right);
    }
    public IList<int> InorderTraversal(TreeNode root)
    {
        Traverse(root);

        return list;
    }

}