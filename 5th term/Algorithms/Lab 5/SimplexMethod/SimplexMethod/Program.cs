using System;

namespace SimplexMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[,] A =
            {
                { -1, 1, 1, 0, 0 },
                { 5, 0, 1, 1, 1 },
                { 3, 2, 0, 0, 1 }
            };
            decimal[] B = { 2, 11, 6 };
            decimal[] C = { -6, 0, -2, 1, -1 };

            var reseult = SimplexMethod.Solve(A, B, C);
            SimplexMethod.PrintResult(reseult);
        }
    }
}
