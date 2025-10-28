using System.Collections.Generic;

namespace DSA.Problems.LinkedList;


public class LinkedListCycleDetection
{
    public bool HasCycle(ListNode head)
    {

        var visitedNodes = new List<ListNode>();
        var curr = head;

        while (curr!= null)
        {
            if (visitedNodes.Contains(curr))
            {
                return true;
            }

            visitedNodes.Add(curr);

            curr = curr.next;
        }

        return false;
    }
}
