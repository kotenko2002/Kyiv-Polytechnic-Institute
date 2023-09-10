namespace lab8.Stripe
{
    public class StripeAlgorithm
    {
        public static int[,] Multiply(int[,] matrixA, int[,] matrixB, int numOfThreads)
        {
            int numOfRowsA = matrixA.GetLength(0);
            int numOfColsA = matrixA.GetLength(1);
            int numOfRowsB = matrixB.GetLength(0);
            int numOfColsB = matrixB.GetLength(1);

            if (numOfColsA != numOfRowsB)
            {
                throw new ArgumentException("Matrices cannot be multiplied");
            }

            int[,] result = new int[numOfRowsA, numOfColsB];
            StripeSyncObject syncObject = new StripeSyncObject(matrixB);

            var threads = new Thread[numOfThreads];
            int rowsPerThread = Math.Max(result.GetLength(0) / numOfThreads, 1);

            int threadIndex = 0;
            List<int[]> listOfRows = new();
            List<int> listOfIndexes = new();

            for (int i = 0; i < numOfRowsA; i++)
            {
                listOfRows.Add(GetRow(matrixA, i));
                listOfIndexes.Add(i);

                if (i % rowsPerThread == rowsPerThread - 1)
                {
                    var bufflistOfRows = new List<int[]>(listOfRows);
                    var bufflistOfIndexes = new List<int>(listOfIndexes);

                    threads[threadIndex] = new Thread(() =>
                    {
                        new StripeTask(bufflistOfRows, bufflistOfIndexes, syncObject, threadIndex, result).Run();
                    });

                    listOfRows.Clear();
                    listOfIndexes.Clear();
                    threadIndex++;
                }
            }

            foreach (var thread in threads)
                thread.Start();

            foreach (var thread in threads)
                thread.Join();

            return result;
        }

        private static int[] GetRow(int[,] matrix, int rowIndex)
        {
            int columns = matrix.GetLength(1);
            int[] row = new int[columns];

            for (int i = 0; i < columns; i++)
            {
                row[i] = matrix[rowIndex, i];
            }
            return row;
        }
    }
}
