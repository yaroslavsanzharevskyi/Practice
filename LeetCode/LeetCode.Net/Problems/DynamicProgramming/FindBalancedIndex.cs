using System.Linq;

namespace LeetCode.Problems;

// Find an index where count of Xs on left side will be equal to count of Ys on the right.
// 1) Ys on the left side of the index don't count
// 2) Xs on the right side of the index don't count

// Examples:
// [ X, X,              Y, Y ] ................. Index = 2
// [ Y, X, X,            X, Y, Y ] ................. Index = 3
// [ X, Y, X, X, Y, X, Y, Y, Y, X, X ] ................. Index = 5
// [ Y,Y,Y,Y,Y,Y, X, X, Y,Y,X]
// [ Y, Y, X, Y, X, Y, X ] ................. Index =  4
// [Y,Y,Y,Y,Y,Y, X, X, Y,Y,X]
// [ 1, 1, -1, 1, -1 ,1 ,-1]

public class FindBalancedIndex
{
    public int FindIndex(string input)
    {
        var countOfY = input.Count(c => c == 'Y');
        var xCount = 0;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == 'X') xCount++;
            else countOfY--;

            if (xCount == countOfY) return i;
        }

        return -1;
    }
}