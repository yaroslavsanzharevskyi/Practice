using System;

namespace LeetCode.Algorithms;

public class BinarySearchAlgo
{
    public int SearchWithArrayCopy(int[] array, int value)
    {
        var splitIndex = array.Length / 2;
        var splitValue = array[splitIndex];
        if (splitValue < value)
        {
            var rightPart = new int[array.Length - splitIndex];
            Array.Copy(array, splitIndex + 1, rightPart, 0, rightPart.Length);
            return this.SearchWithArrayCopy(rightPart, value);
        }
        else if (splitValue > value)
        {
            var leftPart = new int[splitIndex];
            Array.Copy(array, leftPart, leftPart.Length);
            return this.SearchWithArrayCopy(leftPart, value);
        }
        else
        {
            return splitIndex;
        }
    }

    public int Search(int[] array, int leftIndex, int rightIndex, int value)
    {
        if (leftIndex > rightIndex)
        {
            return -1;
        }

        var midIndex = (rightIndex - leftIndex) / 2;
        var midValue = array[midIndex];
        if (midValue == value)
        {
            return midIndex;
        }

        return midValue < value ? 
            this.Search(array, midIndex + 1, rightIndex, value) : 
            this.Search(array, leftIndex, midIndex - 1, value);
    }
}