using System;
using System.Runtime.InteropServices.ComTypes;
using LeetCode.Algorithms;

namespace LeetCode
{


    class Program
    {
        static void Main(string[] args)
        {
            var md = new SnailArray();
            int[][] array =
            {
                new []{1, 2, 3},
                new []{4, 5, 6},
                new []{7, 8, 9}
            };
           
            md.Snail(array);
        }
    }
}
