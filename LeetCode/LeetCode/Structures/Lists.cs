

using System.Collections.Generic;
using System.Runtime;
using Leetcode.Problems;
namespace LeetCode.Utills;


public static class ListFunctions
{
    public static ListNode BuildLinkedList(int[] numbers)
    {
        var head = new ListNode();
        var target = head;

        for (var i = 0; i < numbers.Length; i++)
        {
            target.val = numbers[i];
            if(i == numbers.Length-1){
                break;
            }
            target.next = new ListNode();
            target = target.next;
        }

        return head;
    }

    public static int[] BuildArrayFromList(ListNode head)
    {
        var list = new List<int>();
        var target = head;

        while(target != null)
        {
            list.Add(target.val);
            target = target.next;
        }

        return list.ToArray();
    }
}