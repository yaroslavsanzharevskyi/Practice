using LeetCode.MergeTwoSortedLists;

public class MergeKLists
{
    public ListNode Solution(ListNode[] lists)
    {
        var twoListMerge = new MergeTwoSortedLists();
        if (lists.Length == 0)
        {
            return null;
        }
        if (lists.Length == 1)
        {
            return lists[0];
        }

        var result = lists[0];
        for (var i = 1; i < lists.Length; i++)
        {
            result = twoListMerge.Solution(result, lists[i]);
        }

        return result;
    }
}