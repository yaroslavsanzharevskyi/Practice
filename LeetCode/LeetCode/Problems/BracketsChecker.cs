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

        private int pointer = 0;

        public bool BracketsMatch(string incomingBrakets, int? previousOpenedIndex = null)
        {
            if (incomingBrakets.Length % 2 != 0) return false;

            while (pointer < incomingBrakets.Length)
            {
                if (BraketsTypes.ContainsKey(incomingBrakets[pointer]) && pointer < incomingBrakets.Length - 1)
                {
                    var currentIndex = pointer;
                    pointer++;
                    var matched = BracketsMatch(incomingBrakets, currentIndex);
                    if (!matched) return false;

                }
                else
                {
                    var closingBracket = incomingBrakets[pointer];
                    if(previousOpenedIndex == null) return false;
                    if (incomingBrakets[(int)previousOpenedIndex] == BraketsTypes.FirstOrDefault(b => b.Value == closingBracket).Key)
                    {
                        pointer++;
                        return true;
                    }

                    return false;
                }
            }

            return previousOpenedIndex == 0? true : false;
        }

    }

}