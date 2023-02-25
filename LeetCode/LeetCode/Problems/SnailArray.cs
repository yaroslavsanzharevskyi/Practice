using System.Collections.Generic;

namespace LeetCode.Algorithms
{
    public class SnailArray
    {
        public int[] Snail(int[][] array)
        {
            if (array.Length == 0)
            {
                return new int[0];
            }

            if (array[0].Length == 0)
            {
                return new int[0];
            }

            var list = new List<int>();
            var h = 0;
            var v = 0;
            var vTopBoundary = 0;
            var hLeftBoundary = 0;
            var hBoundary = array.Length;
            var vBoundary = array.Length;

            while (array.Length * array.Length > list.Count)
            {
                for (;h < hBoundary;++h)
                {
                    list.Add(array[v][h]);
                }

                h--;
                v = ++vTopBoundary;

                for (; v < vBoundary; v++)
                {
                    list.Add(array[v][h]);
                }

                v--;
                hBoundary--;
                h--;

                for (; h > hLeftBoundary-1; h--)
                {
                    list.Add(array[v][h]);
                }

                h = hLeftBoundary;
                vBoundary--;
                v = vBoundary - 1;

                for (; v > vTopBoundary-1; v--)
                {
                    list.Add(array[v][h]);
                }

                v = vTopBoundary;
                hLeftBoundary++;
                h = hLeftBoundary;
            }

            return list.ToArray();
        }
    }
}
