namespace lab8.Stripe
{
    public class StripeTask
    {
        private List<int[]> rowsOfMatrixA;
        private List<int> rowsNumber;
        private StripeSyncObject syncObject;
        private int[,] result;
        private int columnsCount;
        private int currentColumnIndex;

        public StripeTask(List<int[]> rowsOfMatrixA, List<int> rowsNumber, StripeSyncObject syncObject, int currentColumnIndex, int[,] result)
        {
            this.rowsOfMatrixA = rowsOfMatrixA;
            this.rowsNumber = rowsNumber;
            this.syncObject = syncObject;
            this.result = result;
            this.columnsCount = result.GetLength(0);
            this.currentColumnIndex = currentColumnIndex % columnsCount;
        }

        public void Run()
        {
            for (var r = 0; r < rowsOfMatrixA.Count; r++)
            {

                int columnsCalculated = 0;
                while (columnsCalculated < columnsCount)
                {
                    int[] columnOfMatrixB = syncObject.getAndBlockColumn(currentColumnIndex);
                    columnsCalculated += 1;

                    int sum = 0;
                    for (int j = 0; j < columnOfMatrixB.Length; j++)
                    {
                        sum += rowsOfMatrixA[r][j] * columnOfMatrixB[j];
                    }
                    result[rowsNumber[r], currentColumnIndex] = sum;
                    int prevRightRowIndex = currentColumnIndex;
                    currentColumnIndex = (currentColumnIndex + 1) % columnsCount;

                    syncObject.unblockColumn(prevRightRowIndex);
                }
            }
        }
    }
}
