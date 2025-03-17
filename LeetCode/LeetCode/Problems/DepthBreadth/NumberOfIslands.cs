using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace LeetCode.Problems.DepthBreadth;

public class NumberOfIslands
{
    public int NumIslandsDFS(char[][] grid)
    {
        var islandsCount = 0;
        void DFS(int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';

            DFS(r, c - 1); // Left
            DFS(r, c + 1); // Right
            DFS(r - 1, c); // Top
            DFS(r + 1, c); // Bottom
        }

        for (var r = 0; r < grid.Length; r++)
        {
            for (var c = 0; c < grid[0].Length; c++)
            {
                if (grid[r][c] == '1')
                {
                    islandsCount++;
                    DFS(r, c);
                }
            }
        }

        return islandsCount;

    }

    public int NumIslandsBFS(char[][] grid)
    {
        var queue = new Queue<(int, int)>();
        var islandsCount = 0;

        int[][] directions = new int[][] {
            new int[] {0, 1},
            new int[] {0,-1},
            new int[] {1, 0},
            new int[] {-1, 0}
        };

        void BFS(int r, int c)
        {
            queue.Enqueue((r,c));
            grid[r][c] = '0';

            while(queue.Count > 0)
            {
                var (curR, curC) = queue.Dequeue();
                foreach(var direciton in directions){
                    var nextR = curR + direciton[0];
                    var nextC = curC + direciton[1];

                    if(nextR >= 0 && nextR < grid.Length && nextC < grid[0].Length && nextC >= 0 && grid[nextR][nextC] == '1')
                    {
                        queue.Enqueue((nextR, nextC));
                        grid[nextR][nextC] = '0';
                    }
                }

            }
        }

        for (var r = 0; r < grid.Length; r++)
        {
            for (var c = 0; c < grid[0].Length; c++)
            {
                if (grid[r][c] == '1')
                {
                    islandsCount++;
                    BFS(r, c);
                }
            }
        }

        return islandsCount;
    }
}