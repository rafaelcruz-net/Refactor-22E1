using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public static class TicTacToe
    {
        private static int? Winner { get; set; }

        public static int SolveGame(int[,] board)
        {
            if (RowIsWon(board) || ColumnIsWon(board) || DiagonalIsWon(board))
            {
                return Winner.GetValueOrDefault();
            }

            return GameInProgress(board);
        }

        private static bool DiagonalIsWon(int[,] board)
        {
            var diagonal = GetDiagonal(board);

            for (int i = 0; i < 2; i++)
            {
                if (CheckIfGameIsWon(diagonal[i]))
                {
                    Winner = diagonal[i][0];
                    return true;
                }

            }

            return false;
        }

        private static List<List<int>> GetDiagonal(int[,] board)
        {
            var diagonal = new List<List<int>>() { new List<int>(), new List<int>() };

            for (int i = 0; i < board.GetLength(0); i++)
            {
                diagonal[0].Add(board[i, i]);
            }

            for (int i = board.GetLength(0) - 1, j = 0; i >= 0; i--, j++)
            {
                diagonal[1].Add(board[i, j]);
            }

            return diagonal;
            
        }

        private static bool ColumnIsWon(int[,] board)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                var column = GetColumn(board, i);

                if (CheckIfGameIsWon(column))
                {
                    Winner = column[0];
                    return true;
                }
            }

            return false;
        }

        private static List<int> GetColumn(int[,] board, int i)
        {
            var column = new List<int>();

            for (int j = 0; j < board.GetLength(0); j++)
            {
                column.Add(board[j, i]);
            }

            return column;
            
        }

        private static bool RowIsWon(int[,] board)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                var row = GetRow(board, i);

                if (CheckIfGameIsWon(row))
                {
                    Winner = row[0];
                    return true;
                }
            }

            return false;
        }

        private static bool CheckIfGameIsWon(List<int> row)
        {
            return row.All(x => x == row.First());
        }

        private static List<int> GetRow(int[,] board, int i)
        {
            var row = new List<int>();

            for (int j = 0; j < board.GetLength(1); j++)
            {
                row.Add(board[i, j]);
            }

            return row;
            
        }

        private static int GameInProgress(int[,] board)
        {
            var result = board.Cast<int>().Contains(0);

            return result ? -1 : 0;

        }
    }
}
