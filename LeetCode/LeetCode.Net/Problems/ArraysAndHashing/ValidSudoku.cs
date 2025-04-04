using System.Collections.Generic;

namespace LeetCode.Problems.ArraysAndHashing;

public class ValidSudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        var rows = new List<HashSet<char>>();
        var columns = new List<HashSet<char>>();
        var boxes = new Dictionary<string, HashSet<char>>();

        for (var i = 0; i < 9; i++)
        {
            rows.Add(new HashSet<char>());
            columns.Add(new HashSet<char>());
        }

        for (var i = 0; i < 9; i++)
        {
            var boxIndexI = i / 3;
            for (var j = 0; j < 9; j++)
            {
                var cell = board[i][j];

                if( cell == '.') continue;

                if (rows[i].Contains(cell))
                {
                    return false;
                }
                else
                {
                    rows[i].Add(cell);
                }
                if (columns[j].Contains(cell))
                {
                    return false;
                }
                else
                {
                    columns[j].Add(cell);
                }

                var boxIndexJ = j / 3;
                string boxName = $"{boxIndexI}{boxIndexJ}";
                
                if (boxes.ContainsKey(boxName))
                {
                    if (boxes[boxName].Contains(cell))
                    {
                        return false;
                    }
                    else
                    {
                        boxes[boxName].Add(cell);
                    }
                }
                else
                {
                    var hashset = new HashSet<char>
                    {
                        cell
                    };
                    boxes.Add(boxName, hashset);
                }
            }
        }

        return true;
    }
}

