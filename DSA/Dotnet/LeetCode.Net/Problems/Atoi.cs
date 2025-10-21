using System.Collections.Generic;

namespace LeetCode.Problems;


public class Atoi
{
    public int TransformToInt(string s)
    {
        long? resultingNumber = null;
        int? sign = null;
        if (s.Length == 0)
        {
            return 0;
        }
        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsLetter(s[i]) || s[i] == '.')
            {
                break;
            }

            if (s[i] == ' ')
            {
                if (!resultingNumber.HasValue && !sign.HasValue)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (s[i] == '-' || s[i] == '+')
            {
                if (!resultingNumber.HasValue && !sign.HasValue)
                {
                    sign = s[i] == '-' ? -1 : 1;
                    continue;
                }
                else
                {
                    break;
                }
            }

            var currentDigit = int.Parse(s[i].ToString());
            if (!resultingNumber.HasValue)
            {
                sign = sign.HasValue ? sign : 1;
                resultingNumber = currentDigit * sign.Value;
            }
            else
            {
                resultingNumber = ((long)resultingNumber * 10) + (currentDigit * sign.Value);
                if (int.MaxValue < resultingNumber)
                {
                    resultingNumber = int.MaxValue;
                    break;
                }
                if (int.MinValue > resultingNumber)
                {
                    resultingNumber = int.MinValue;
                    break;
                }


            }

        }

        return resultingNumber.HasValue ? (int)resultingNumber.Value : 0;
    }
}