using System;

namespace DSA.Problems.LinkedList;

public class MiddleOfTheLinkedList
{
    public ListNode MiddleNode(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        var slow = head;
        var fast = head;

        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        if (fast.next != null)
        {
            slow = slow.next;
        }

        return slow;

    }
}