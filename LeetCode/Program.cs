using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using LeetCode.Algorithms;
using LeetCode.Problems;

namespace LeetCode
{


    class Program
    {
        static void Main(string[] args)
        {
            var single = new SingleNumberInArray();

            single.SingleNumber(new[] {4, 1, 2, 1, 2,2});
        }
    }
}
