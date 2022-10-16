using System;
using System.Collections.Generic;
using System.Linq;

namespace WaveAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to start");
            Console.ReadKey();

            var matrix = Constants.matrix3;

            WaveAlgorithm.PrintMatrix(matrix);

            try
            {
                List<(int, int, string)> answerPoints = WaveAlgorithm.Algorithm(matrix);

                Console.ReadKey();
                PrintSolvedMatrix(matrix, answerPoints);
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Шлях не знайдено");
            }
        }
        public static void PrintSolvedMatrix(string[,] matrix, List<(int, int, string)> answerPoints)
        {
            for (int p = 0; p < answerPoints.Count; p++)
            {
                matrix[answerPoints[p].Item1, answerPoints[p].Item2] = $"{answerPoints[p].Item3}";
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
                    else if (answerPoints.Contains((i, j, matrix[i, j])))
                        Console.BackgroundColor = ConsoleColor.Red;

                    if (matrix[i, j] == "%")
                        Console.Write("  ");
                    else if (matrix[i, j].Length == 1)
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
