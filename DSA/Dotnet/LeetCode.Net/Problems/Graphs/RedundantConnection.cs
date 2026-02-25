using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Graphs;

public class RedundantConnection {
    public int[] FindRedundantConnection(int[][] edges) {
        var parent = new Dictionary<int, int>();
        var rank = new Dictionary<int, int>();

        int FindRoot(int node) {
            if (parent[node] != node) {
                parent[node] = FindRoot(parent[node]);
            }
            return parent[node];
        }

        bool Union(int u, int v) {
            int rootU = FindRoot(u);
            int rootV = FindRoot(v);

            if (rootU == rootV) {
                return false;
            }

            if (rank[rootU] > rank[rootV]) {
                parent[rootV] = rootU;
            } else if (rank[rootU] < rank[rootV]) {
                parent[rootU] = rootV;
            } else {
                parent[rootV] = rootU;
                rank[rootU] += 1;
            }

            return true;
        }

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];

            if (!parent.ContainsKey(u)) {
                parent[u] = u;
                rank[u] = 0;
            }
            if (!parent.ContainsKey(v)) {
                parent[v] = v;
                rank[v] = 0;
            }

            if (!Union(u, v)) {
                return new[] { u, v };
            }
        }

        return Array.Empty<int>();
    }
}
