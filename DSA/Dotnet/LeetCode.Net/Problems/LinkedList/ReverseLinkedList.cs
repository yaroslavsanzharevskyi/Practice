/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
namespace LeetCode.Problems.LinkedList;

public class ReverseLinkedList
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null)
        {
            return null;
        }
        var currentNode = head;
        ListNode oldParent = null;
        while (true)
        {
            ListNode next = currentNode.next;
            currentNode.next = oldParent;

            oldParent = currentNode;
            if (next == null)
            {
                break;
            }
            currentNode = next;
        }

        return currentNode;
    }
}