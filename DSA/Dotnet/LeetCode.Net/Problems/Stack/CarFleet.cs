using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LeetCode.Problems.Stack;

public class CarFleetSolution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var orderedCars = position.Select((pos, index) => new { Position = pos, Speed = speed[index] })
                                    .OrderByDescending(c => c.Position)
                                    .ToArray();

        var stack = new Stack<double>();
        for (var i = 0; i < orderedCars.Length; i++)
        {
            var time = (target - orderedCars[i].Position) / (double)orderedCars[i].Speed;

            if (stack.Count == 0 || time > stack.Peek())
            {
                stack.Push(time);
            }
        }

        return stack.Count;
    }
}
