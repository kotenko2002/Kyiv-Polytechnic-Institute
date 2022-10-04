using AStartAlgorithm.Additional;
using AStartAlgorithm.Algorithm;
using System;
using System.Collections.Generic;

namespace AStartAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press Enter to start");
            //Console.ReadKey();

            var matrix = Constants.matrix3;

            AStarAlgorithm.PrintMatrix(matrix);

            var answerPoints = AStarAlgorithm.Algorithm(matrix);

            Console.ReadKey();

            if(answerPoints != null)
                PrintSolvedMatrix(matrix, answerPoints);
            else
                Console.WriteLine("Шлях не знайдено");

            Console.ReadKey();
        }

        public static void PrintSolvedMatrix(string[,] matrix, List<(int, int)> answerPoints)
        {
            for (int p = 0; p < answerPoints.Count; p++)
            {
                matrix[answerPoints[p].Item1, answerPoints[p].Item2] = $"+";
            }

            Console.Clear();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == " ")
                        Console.BackgroundColor = ConsoleColor.Black;
                    else if (matrix[i, j] == "%")
                        Console.BackgroundColor = ConsoleColor.Blue;
                    else if (matrix[i, j] == "+")
                        Console.BackgroundColor = ConsoleColor.Red;

                    Console.Write("  ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
