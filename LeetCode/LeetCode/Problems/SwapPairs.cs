using System.Collections.Generic;

namespace Leetcode.Problems;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) { this.val = val; this.next = next; }
}

public class SwapPairs
{
    public ListNode Solution(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        if(head.next == null)
        {
            return head;
        }
        
        ListNode parent = null;
        var current = head;
        

        while(current != null)
        {
            if(current.next != null) {
                // 1 2 3 4 5 = > 2 1 4 3 5
                // 
                var temp = current;
                if(parent != null) {
                    parent.next = current.next; // 4
                }

                var tail = current.next.next; // 5 -> 

                current = current.next; // 4
                current.next = temp;
                current.next.next = tail; // 5


                parent = current.next; // 3
                current = current.next; // 5
            }

            current = current.next;
        }

        return head;
    }
}