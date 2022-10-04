using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public static class Additional
    {
        public static bool CheckWinner(char[,] board, char symbol)
        {
            var winningSequence = $"{symbol}{symbol}{symbol}";
            var boardSequence = ConvertArrayToStringSequence(board);

            return boardSequence.Contains(winningSequence);
        }
        public static bool CheckDraw(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if(board[i, j] == ' ')
                        return false;

            return true;
        }
        public static string ConvertArrayToStringSequence(char[,] board)
        {
            var stringSequence = "";

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    stringSequence += board[i, j];
                }
                stringSequence += "-";
            }

            for (int j = 0; j < board.GetLength(0); j++)
            {
                for (int i = board.GetLength(1) - 1; i >= 0; i--)
                {
                    stringSequence += board[i, j];
                }
                stringSequence += "-";
            }

            stringSequence += $"{board[0, 0]}{board[1, 1]}{board[2, 2]}-";
            stringSequence += $"{board[2, 0]}{board[1, 1]}{board[0, 2]}-";

            return stringSequence;
        }
    }
}
