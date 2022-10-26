using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public static class Algorithm
    {
        public static (char[,], long) NegaMax(char[,] array, int depth, int color)
        {
            if (depth == 0 || Additional.CheckWinner(array, color))
                return (array, color * EvaluationClass.F(array));

            (char[,], long) maxEval = (null, -999999999999999999);

            var children = GetAllChildren(array, color);
            foreach (var child in children)
            {
                (char[,], long) eval = NegaMax(child, depth - 1, -color);
                eval = (eval.Item1, -eval.Item2);

                char[,] buffArray = new char[array.GetLength(0), array.GetLength(1)];
                Array.Copy(child, 0, buffArray, 0, array.Length);

                maxEval = (maxEval.Item2 < eval.Item2) ? (buffArray, eval.Item2) : maxEval;
            }
            return maxEval;
        }

        public static (char[,], long) NegaMaxWithAlphaBetaPruning (char[,] array, int depth, long alpha, long beta, int color)
        {
            if (depth == 0 || Additional.CheckWinner(array, color))
                return (array, color * EvaluationClass.F(array));

            (char[,], long) maxEval = (null, -999999999999999999);

            var children = GetAllChildren(array, color);
            foreach (var child in children)
            {
                (char[,], long) eval = NegaMaxWithAlphaBetaPruning(child, depth - 1, -alpha, -beta, -color);
                eval = (eval.Item1, -eval.Item2);

                char[,] buffArray = new char[array.GetLength(0), array.GetLength(1)];
                Array.Copy(child, 0, buffArray, 0, array.Length);

                maxEval = (maxEval.Item2 < eval.Item2) ? (buffArray, eval.Item2) : maxEval;

                alpha = (alpha < eval.Item2) ? eval.Item2 : alpha;
                if (alpha >= beta)
                    break;
            }
            return maxEval;
        }

        public static (char[,], long) NegaScout(char[,] array, int depth, long alpha, long beta, int color)
        {
            if (depth == 0 || Additional.CheckWinner(array, color))
                return (array, color * EvaluationClass.F(array));

            long b = beta;
            (char[,], long) maxEval = (null, -999999999999999999);

            var children = GetAllChildren(array, color);
            foreach (var child in children)
            {
                (char[,], long) eval = NegaScout(child, depth - 1, -alpha, -b, -color);

                if (alpha < eval.Item2 && eval.Item2 < beta)
                    eval = NegaScout(child, depth - 1, -alpha, -beta, -color);

                if(eval.Item2 > maxEval.Item2)
                {
                    char[,] buffArray = new char[array.GetLength(0), array.GetLength(1)];
                    Array.Copy(child, 0, buffArray, 0, array.Length);

                    maxEval = (buffArray, eval.Item2);
                }

                alpha = (alpha < eval.Item2 ? eval.Item2 : alpha);
                if (beta <= alpha)
                    break;

                b = alpha + 1;
            }
            return (maxEval.Item1, -maxEval.Item2);
        }
        public static List<char[,]> GetAllChildren(char[,] board, int color)
        {
            char symbol = color > 0 ? 'O' : 'X';

            var children = new List<char[,]>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[i, j] == ' ')
                    {
                        char[,] buffArray = new char[board.GetLength(0), board.GetLength(1)];
                        Array.Copy(board, 0, buffArray, 0, board.Length);

                        buffArray[i, j] = symbol;
                        children.Add(buffArray);
                    }
                }
            }

            return children;
        }
    }
}
