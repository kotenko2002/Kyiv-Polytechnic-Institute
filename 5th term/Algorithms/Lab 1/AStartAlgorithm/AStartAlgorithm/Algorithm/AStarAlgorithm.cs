using AStartAlgorithm.Additional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AStartAlgorithm.Algorithm
{
    public static class AStarAlgorithm
    {
        private static Route[] routes = Constants.routesReverse;

        public static List<(int, int)> Algorithm(string[,] board)
        {
            List<(int, int)> pathList = new List<(int, int)>();
            var Points = FindStartAndEnd(board);
            //var startPoint = Points.Item1;
            (int, int) goalPoint = Points.Item2;

            List<AStarPoint> openList = new List<AStarPoint>();
            List<AStarPoint> closeList = new List<AStarPoint>();

            var startPoint = new AStarPoint(Points.Item1.Item1, Points.Item1.Item2, Heuristic.F((Points.Item1.Item1, Points.Item1.Item2), (goalPoint.Item1, goalPoint.Item2)));
            openList.Add(startPoint);
            while (true)
            {
                if (openList == null || openList.Count <= 0)
                    return null;

                AStarPoint endNode = closeList.FirstOrDefault(item => item.Coordinates.Item1 == goalPoint.Item1 && item.Coordinates.Item2 == goalPoint.Item2);
                if (endNode != null)
                {
                    var curNode = endNode;

                    while (true)
                    {
                        if (curNode.Parent == null)
                        {
                            pathList.Add((curNode.Coordinates.Item1, curNode.Coordinates.Item2));
                            break;
                        }

                        curNode = curNode.Parent;
                        pathList.Add((curNode.Coordinates.Item1, curNode.Coordinates.Item2));
                    }

                    return pathList;
                }

                var heuristic = openList.Min(item => item.HeuristicValue);
                var minNode = openList.Where(item => item.HeuristicValue == heuristic).Last();

                openList.Remove(minNode);
                closeList.Add(minNode);

                for (int i = 0; i < routes.Length; i++)
                {
                    (int, int) currentPoint = (minNode.Coordinates.Item1 + routes[i].Coordinates.Item1, minNode.Coordinates.Item2 + routes[i].Coordinates.Item2);

                    if (board[currentPoint.Item1, currentPoint.Item2] == "%")
                        continue;

                    if (closeList.Find(item => item.Coordinates.Item1 == currentPoint.Item1
                        && item.Coordinates.Item2 == currentPoint.Item2) != null)
                            continue;

                    var node = openList.FirstOrDefault(item => item.Coordinates.Item1 == currentPoint.Item1
                        && item.Coordinates.Item2 == currentPoint.Item2);

                    if (node == null)
                    {
                        int heuristicValue = Heuristic.F((currentPoint.Item1, currentPoint.Item2), (goalPoint.Item1, goalPoint.Item2));
                        openList.Add(new AStarPoint(currentPoint.Item1, currentPoint.Item2, heuristicValue) { Parent = minNode});
                    }
                    else
                    {
                        int costValue = minNode.СostValue + 1;
                        if (costValue < node.СostValue)
                        {
                            node.СostValue = costValue;
                            node.Parent = minNode;
                        }
                    }
                }
            }
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

                    Console.Write("  ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static ((int, int), (int, int)) FindStartAndEnd(string[,] board)
        {
            (int, int) start = (0, 0), goal = (0, 0);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i, j] == "S") start = (i, j);
                    if (board[i, j] == "E") goal = (i, j);
                }
            }

            return (start, goal);
        }
    }
}
