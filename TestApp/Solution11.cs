using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Solution1
    {
        private readonly string _nums = "123456789";

        public void SolveSudoku(char[][] board)
        {
            var n = board.Length;
            var boxes = Enumerable.Range(0, n).Select(x => new Dictionary<char, bool>()).ToArray();
            var rows = Enumerable.Range(0, n).Select(x => new Dictionary<char, bool>()).ToArray();
            var cols = Enumerable.Range(0, n).Select(x => new Dictionary<char, bool>()).ToArray();

            for (var r = 0; r < n; r++)
            {
                for (var c = 0; c < n; c++)
                {
                    if (board[r][c] != '.')
                    {
                        var val = board[r][c];
                        var boxId = GetBoxId(r, c);
                        boxes[boxId][val] = true;
                        rows[r][val] = true;
                        cols[c][val] = true;
                    }
                }
            }

            SolveBacktrack(board, boxes, rows, cols, 0, 0);
        }

        private bool SolveBacktrack(char[][] board, Dictionary<char, bool>[] boxes, Dictionary<char, bool>[] rows, Dictionary<char, bool>[] cols, int r, int c)
        {
            if (r == board.Length || c == board[0].Length) return true;

            if (board[r][c] == '.')
            {
                foreach (var num in _nums)
                {
                    board[r][c] = num;
                    var boxId = GetBoxId(r, c);
                    var box = boxes[boxId];
                    var row = rows[r];
                    var col = cols[c];
                    if (IsValid(box, row, col, num))
                    {
                        box[num] = true;
                        row[num] = true;
                        col[num] = true;

                        if (c == board[0].Length - 1)
                        {
                            if (SolveBacktrack(board, boxes, rows, cols, r + 1, 0)) return true;
                        }
                        else
                        {
                            if (SolveBacktrack(board, boxes, rows, cols, r, c + 1)) return true;
                        }
                        box.Remove(num);
                        row.Remove(num);
                        col.Remove(num);
                    }
                    board[r][c] = '.';
                }
            }
            else
            {
                if (c == board[0].Length - 1)
                {
                    if (SolveBacktrack(board, boxes, rows, cols, r + 1, 0)) return true;
                }
                else
                {
                    if (SolveBacktrack(board, boxes, rows, cols, r, c + 1)) return true;
                }
            }

            return false;
        }

        private bool IsValid(Dictionary<char, bool> boxes, Dictionary<char, bool> rows, Dictionary<char, bool> cols, char num)
        {
            return !boxes.ContainsKey(num) && !rows.ContainsKey(num) && !cols.ContainsKey(num);
        }

        private int GetBoxId(int row, int col)
        {
            return col / 3 + (row / 3) * 3;
        }
    }
}
