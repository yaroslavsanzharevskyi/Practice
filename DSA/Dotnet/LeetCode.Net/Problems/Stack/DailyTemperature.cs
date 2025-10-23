using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LeetCode.Problems.Stack;

public class DialyTemperatureSolution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];
        for (var i = 0; i < temperatures.Length; i++)
        {
            if (stack.Count == 0 || temperatures[i] <= temperatures[stack.Peek()])
            {
                stack.Push(i);
            }
            else
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    var index = stack.Pop();
                    result[index] = i - index;
                }

                stack.Push(i);
            }
        }

        return result;
    }
}