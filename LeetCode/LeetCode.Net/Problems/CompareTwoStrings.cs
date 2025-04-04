using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class CompareTwoStrings
    {
        public bool CompareBySort(string etalon, string example)
        {
            var ethalonArray = etalon.ToCharArray();
            Array.Sort(ethalonArray);

            var exampleArray = example.ToCharArray();
            Array.Sort(exampleArray);

            var sortetEtalon = string.Join("", ethalonArray);

            var sortedExample = string.Join("", exampleArray);

            return String.Equals(sortetEtalon, sortedExample);
        }

        public bool CompareByDictionary(string etalon, string example)
        {
            var dict = new Dictionary<char, int>();

            for (var i = 0; i < etalon.Length; i++)
            {
                var currentKey = etalon[i];
                if (dict.ContainsKey(currentKey))
                {
                    dict[currentKey] += 1;
                }
                else
                {
                    dict.Add(currentKey, 1);
                }
            }

            for (var i = 0; i < example.Length; i++)
            {
                var currentKey = example[i];
                if (dict.ContainsKey(currentKey))
                {
                    if (dict[currentKey] == 0)
                    {
                        return false;
                    }

                    dict[currentKey] -= 1;
                }
                else
                {
                    return false;
                }
            }

            int[] valuearray = dict.Values.ToArray();

            var sum = 0;
            for (var i = 0; i < valuearray.Length; i++)
            {
                sum += valuearray[i];
            }

            return sum == 0;
        }
    }
}
