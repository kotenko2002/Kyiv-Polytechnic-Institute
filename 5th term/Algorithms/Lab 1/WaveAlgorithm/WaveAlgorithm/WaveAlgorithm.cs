using System;
using System.Collections.Generic;

namespace WaveAlgorithm
{
    public static class WaveAlgorithm
    {
        private static Route[] routes = Constants.routes;

        public static List<(int, int,string)> Algorithm(string[,] board)
        {
            var Points = FindStartAndEnd(board);
            var startPoint = Points.Item1;
            var goalPoint = Points.Item2;

            string[,] buffMatrix = new string[board.GetLength(0), board.GetLength(1)];
            Array.Copy(board, 0, buffMatrix, 0, board.Length);
            buffMatrix[startPoint.Item1, startPoint.Item2] = "0";

            var solvedBoard = BFS(buffMatrix, "0");

            List<(int,int, string)> list = new List<(int, int, string)>() { (goalPoint.Item1, goalPoint.Item2, solvedBoard[goalPoint.Item1, goalPoint.Item2]) };
            (int, int, string) currentPoint = list[^1];

            while (currentPoint.Item1 != startPoint.Item1 || currentPoint.Item2 != startPoint.Item2)
            {
                for (int j = 0; j < routes.Length; j++)
                {
                    currentPoint = 
                        (list[^1].Item1 + routes[j].Coordinates.Item1,
                        list[^1].Item2 + routes[j].Coordinates.Item2,
                        (Convert.ToInt32(list[^1].Item3) - 1).ToString());

                    if (solvedBoard[currentPoint.Item1, currentPoint.Item2] == currentPoint.Item3)
                    {
                        list.Add(currentPoint);
                        break;
                    }
                }
            }

            return list;
        }
        public static string[,] BFS(string[,] board, string prevValue)
        {
            var nextValue = (Convert.ToInt32(prevValue) + 1).ToString();

            List<(int, int)> list = new List<(int, int)>();
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(0); j++)
                    if (board[i, j] == prevValue) list.Add((i, j));

            string[,] buffMatrix = new string[board.GetLength(0), board.GetLength(1)];
            Array.Copy(board, 0, buffMatrix, 0, board.Length);

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < routes.Length; j++)
                {
                    (int, int) newPoint = (list[i].Item1 + routes[j].Coordinates.Item1, list[i].Item2 + routes[j].Coordinates.Item2);

                    if (buffMatrix[newPoint.Item1, newPoint.Item2] == "E")
                    {
                        buffMatrix[newPoint.Item1, newPoint.Item2] = nextValue;
                        return buffMatrix;
                    }

                    if (buffMatrix[newPoint.Item1, newPoint.Item2] == " ")
                        buffMatrix[newPoint.Item1, newPoint.Item2] = nextValue;
                }
            }

            for (int i = 0; i < buffMatrix.GetLength(0); i++)
                for (int j = 0; j < buffMatrix.GetLength(0); j++)
                    if (buffMatrix[i, j] == " ")
                    {
                        Console.Clear();
                        PrintMatrix(buffMatrix);
                        System.Threading.Thread.Sleep(250);// time
                        return BFS(buffMatrix, nextValue);
                    }

            return buffMatrix;
        }
        private static ((int, int), (int, int)) FindStartAndEnd(string[,] board)
        {
            (int, int) start = (0,0), goal = (0, 0);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if(board[i,j] == "S") start = (i,j);
                    if(board[i,j] == "E") goal = (i,j);
                }
            }

            return (start, goal);
        }
        public static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == " ")
                        Console.BackgroundColor = ConsoleColor.Black;
                    else if (matrix[i, j] == "%")
                        Console.BackgroundColor = ConsoleColor.Blue;
                    else if (matrix[i, j] == "S")
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    else
                        Console.BackgroundColor = ConsoleColor.White;

                    if(matrix[i, j] == "%")
                        Console.Write("  ");
                    else if(matrix[i, j].Length == 1)
                        Console.Write($"{matrix[i, j]} ");
                    else
                        Console.Write($"{matrix[i, j]}");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
#region MyRegion
//Console.WriteLine($"Start: {temp.Item1.Item1}, {temp.Item1.Item2} -> {board[temp.Item1.Item1, temp.Item1.Item2]}");
//Console.WriteLine($"End: {temp.Item2.Item1}, {temp.Item2.Item2} -> {board[temp.Item2.Item1, temp.Item2.Item2]}");
#endregion