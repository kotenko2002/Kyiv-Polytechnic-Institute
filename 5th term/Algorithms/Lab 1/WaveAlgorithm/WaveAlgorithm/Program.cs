using System;

namespace WaveAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = Constants.matrix1;

            PrintMatrix(matrix);
        }

        public static void Algorithm()
        {

        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == ' ') 
                        Console.BackgroundColor = ConsoleColor.Black;
                    else if(matrix[i,j] == '%')
                        Console.BackgroundColor = ConsoleColor.Blue;
                    else if (matrix[i, j] == 'S')
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    else
                        Console.BackgroundColor = ConsoleColor.White;

                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        
    }
}
