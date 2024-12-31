namespace LeetCode.MergeTwoSortedLists
{
    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var head = new ListNode();
            var current = head;
            while( list1 != null || list2 != null)
            {
                if(list1 == null)
                {
                    current.next = list2;
                    break;
                }
                else if(list2 == null)
                {
                    current.next = list1;
                    break;
                }
                else if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }

                current = current.next;
            }

            return head.next;
        }
    }
}
