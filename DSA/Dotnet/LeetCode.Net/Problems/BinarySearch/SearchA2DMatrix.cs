namespace LeetCode.Problems.BinarySearch;

public class Search2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        // Fast fail
        if (target < matrix[0][0] || target > matrix[matrix.Length - 1][matrix[matrix.Length - 1].Length - 1])
        {
            return false;
        }

        var tRow = 0;
        var bRow = matrix.Length - 1;
        var foundRow = tRow == bRow ? tRow : -1;
        while (tRow <= bRow)
        {
            var pointer = tRow + (bRow - tRow) / 2;

            if (target >= matrix[pointer][0] && target <= matrix[pointer][matrix[pointer].Length - 1])
            {
                foundRow = pointer;
                var left = 0;
                var right = matrix[foundRow].Length - 1;

                while (left <= right)
                {
                    var internalPointer = left + (right - left) / 2;

                    if (target == matrix[foundRow][internalPointer])
                    {
                        return true;
                    }
                    if (target > matrix[foundRow][internalPointer])
                    {
                        left = internalPointer + 1;
                    }
                    else
                    {
                        right = internalPointer - 1;
                    }
                }
                break;

            }

            if (target > matrix[pointer][0])
            {
                tRow = pointer + 1;
            }
            else
            {
                bRow = pointer - 1;
            }
        }


        return false;
    }
}