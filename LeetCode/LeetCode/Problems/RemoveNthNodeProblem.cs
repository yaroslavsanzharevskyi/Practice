namespace LeetCode.RemoveNthNodeProblem
{
    public static class RemoveNthNodeSolution
    {
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            CalcDepth(ref head, n);

            return head;
        }

        public static int CalcDepth(ref ListNode node, int n)
        {
            var currentDepth = 0;
            if (node == null)
            {
                return currentDepth;
            }
            if (node.next == null)
            {
                currentDepth = 1;
            }
            else
            {
                currentDepth = 1 + CalcDepth(ref node.next, n);
            }

            if (currentDepth == n)
            {
                node = node.next;
            }

            return currentDepth;
        }
    }
    public class DataSetup
    {
        public static ListNode BuildListOurOfArray(int[] arr)
        {
            var head = new ListNode();
            head.val = arr[0];
            var target = head;
            for(var i = 1; i < arr.Length; i++)
            {
                target.next = new ListNode(arr[i]);
                target = target.next;
            }

            return head;
        }

      
     }
}

