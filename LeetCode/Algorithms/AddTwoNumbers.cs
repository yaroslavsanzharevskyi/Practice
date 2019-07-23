using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LeetCode.Algorithms
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class AddTwoNumbers
    {
        public ListNode Execute(ListNode l1, ListNode l2)
        {
            return RecursiveExecute(l1, l2, 0);
        }

        private ListNode RecursiveExecute(ListNode l1, ListNode l2, int addToSum)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            var l1val = 0;
            var l2val = 0;

            if (l1 != null)
            {
                l1val = l1.val;
            }

            if (l2 != null)
            {
                l2val = l2.val;
            }

            var sum = l1val + l2val + addToSum;
            var currentValue = 0;
            var toNextLevel = 0;
            if (sum < 10)
            {
                currentValue = sum;
            }  else if (sum == 10)
            {
                toNextLevel = 1;
            }
            else if(sum > 10)
            {
                currentValue = sum % 10;
                toNextLevel = 1;
            }

            var node = new ListNode(currentValue);
            node.next = RecursiveExecute(l1?.next, l2?.next, toNextLevel);
            if (node.next == null && toNextLevel != 0)
            {
                node.next = new ListNode(toNextLevel);
            }

            return node;
        }
    }
}
