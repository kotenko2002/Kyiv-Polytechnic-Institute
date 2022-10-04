using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public static class Algorithm
    {
        public static (char[,], long) MiniMax(char[,] array, int depth, long alpha, long beta, bool miximizigPlayerTurnToMove)
        {
            if (depth == 0 || Additional.CheckWinner(array, 'O'))
                return (array, EvaluationClass.F(array));

            if (miximizigPlayerTurnToMove)
            {
                (char[,], long) maxEval = (null, -999999999999999999);
                List<char[,]> children = GetAllChildren(array, 'O');// дети ПК
                foreach (var child in children)
                {
                    (char[,], long) eval = MiniMax(child, depth - 1, alpha, beta, false);
                    char[,] buffArray = new char[array.GetLength(0), array.GetLength(1)];
                    Array.Copy(child, 0, buffArray, 0, array.Length);
                    maxEval = (maxEval.Item2 < eval.Item2) ? (buffArray, eval.Item2) : maxEval;

                    alpha = (alpha < eval.Item2) ? eval.Item2 : alpha;
                    if (beta <= alpha)
                        break;
                }
                return maxEval;
            }
            else
            {
                (char[,], long) minEval = (null, 999999999999999999);
                List<char[,]> children = GetAllChildren(array, 'X');// дети Игрока, вот так и становятся отцами...
                foreach (var child in children)
                {
                    (char[,], long) eval = MiniMax(child, depth - 1, alpha, beta, true);
                    char[,] buffArray = new char[array.GetLength(1), array.GetLength(1)];
                    Array.Copy(child, 0, buffArray, 0, array.Length);
                    minEval = (minEval.Item2 > eval.Item2) ? (buffArray, eval.Item2) : minEval;

                    beta = (beta > eval.Item2) ? eval.Item2 : beta;
                    if (beta <= alpha)
                        break;
                }
                return minEval;
            }
        }
        public static List<char[,]> GetAllChildren(char[,] board, char symbol)
        {
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
