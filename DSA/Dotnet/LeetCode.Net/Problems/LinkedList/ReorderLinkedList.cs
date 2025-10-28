using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Transactions;

namespace DSA.Problems.LinkedList;


public class ReorderLinkedList
{
    public void ReorderList(ListNode head)
    {
        if (head == null || head.next == null)
            return;
        // find middle
        var slow = head;
        var fast = head;

        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode prev = null;
        var current = slow.next;



        while (current != null)
        {
            var next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }



        var reversedSecondHalf = prev;
        slow.next = null;

        ListNode first = head;
        ListNode second = reversedSecondHalf;

        while (second != null)
        {
            var temp1 = first.next;
            var temp2 = second.next;

            first.next = second;
            second.next = temp1;

            first = temp1;
            second = temp2;
        }


        // reverse second half


        // merge two halves
    }
}