using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace DSA.Problems.BinarySearch;

public class TimeMap
{
    private Dictionary<string, List<(int, string)>> storage;
    public TimeMap()
    {
        storage = new Dictionary<string, List<(int, string)>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        if (!storage.ContainsKey(key))
        {
            storage[key] = new List<(int, string)>();
        }

        storage[key].Add((timestamp, value));
    }

    private string SearchVal(int upperBound, (int key, string value)[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;
        var result = string.Empty;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid].key <= upperBound)
            {
                result = nums[mid].value;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    public string Get(string key, int timestamp)
    {
        if (!storage.ContainsKey(key))
        {
            return string.Empty;
        }

        var dict = storage[key];



        // sorted because of SortedDictionary
        var values = dict.ToArray();
        var closestTimeStampVal = SearchVal(timestamp, values);

        return closestTimeStampVal;
    }
}