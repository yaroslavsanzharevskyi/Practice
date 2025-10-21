using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class GroupAnagrams
{

    public IList<IList<string>> Solution(string[] strs)
    {
        var groups = new Dictionary<string, IList<string>>();
        for (var j = 0; j < strs.Length; j++)
        {
            var uniqueGroupName = strs[j].ToCharArray();
            Array.Sort(uniqueGroupName);
            var backeToString = new string(uniqueGroupName);
            if (groups.ContainsKey(backeToString))
            {
                var list = groups[backeToString];
                list.Add(strs[j]);
            }
            else
            {
                groups[backeToString] = new List<string>() { strs[j] };
            }
        }

        return groups.Values.ToList();
    }
}