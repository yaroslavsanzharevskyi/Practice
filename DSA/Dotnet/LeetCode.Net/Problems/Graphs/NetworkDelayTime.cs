using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeetCode.Problems.Graphs;

public class NetworkDelayTime
{
    public int FindNetworkDelayTime(int[][] times, int n, int k)
    {
        var neighborsDict = new Dictionary<int, List<(int neighbor, int weight)>>();
        for (var i = 0; i < n; i++) neighborsDict[i] = new List<(int, int)>();

        foreach (var connection in times)
        {
            var origin = connection[0]; var dest = connection[1]; var time = connection[2];
            neighborsDict[origin].Add((dest, time));
        }

        var pr = new PriorityQueue<(int node, int distance), int>();
        pr.Enqueue((k, 0), 0);
        Dictionary<int, int> visitedNodes = new();
        while (pr.Count > 0)
        {
            var (node, currentDuration) = pr.Dequeue();
            if (visitedNodes.ContainsKey(node)) continue;

            visitedNodes[node] = currentDuration;

            foreach (var (neighbor, weight) in neighborsDict[node])
            {
                if (!visitedNodes.ContainsKey(neighbor))
                {
                    pr.Enqueue((neighbor, currentDuration + weight), currentDuration + weight);
                }
            }

        }

        if(visitedNodes.Count != n) return -1;

        return visitedNodes.Values.Max();
    }
}