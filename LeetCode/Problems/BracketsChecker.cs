using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class BracketsMatcher
    {
        private Dictionary<char, char> BraketsTypes;

        public BracketsMatcher()
        {
            BraketsTypes = new Dictionary<char, char> { { '{', '}' }, { '[', ']' }, { '(', ')' } };
        }

        private int globalIndex = 0;

        public bool BracketsMatch(string incomingBrakets, int previousOpenedIndex = 0)
        {
            while (globalIndex < incomingBrakets.Length)
            {
                if (BraketsTypes.ContainsKey(incomingBrakets[globalIndex]))
                {
                    var currentOpenIndex = globalIndex;
                    globalIndex++;
                    if (BracketsMatch(incomingBrakets, currentOpenIndex) == false) return false;
                }
                else
                {
                    var closingBracket = incomingBrakets[globalIndex];
                    if (incomingBrakets[previousOpenedIndex] == BraketsTypes.FirstOrDefault(b => b.Value == closingBracket).Key)
                    {
                        globalIndex++;
                        return true;
                    }

                    return false;
                }

               
            }

            return true;
        }

    }

}