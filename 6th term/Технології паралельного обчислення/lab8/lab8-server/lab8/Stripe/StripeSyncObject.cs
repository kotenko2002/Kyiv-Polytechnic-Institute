namespace lab8.Stripe
{
    public class StripeSyncObject
    {
        private List<int[]> _columns;
        private List<int> _blockedColumns = new();
        private object _lockObject = new object();

        public StripeSyncObject(int[,] matrix)
        {
            _columns = new();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int[] column = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    column[i] = matrix[i, j];
                }
                _columns.Add(column);
            }
        }

        public int[] getAndBlockColumn(int index)
        {
            lock (_lockObject)
            {
                while (_blockedColumns.Contains(index))
                {
                    Monitor.Wait(_lockObject);
                }

                _blockedColumns.Add(index);

                return _columns[index];
            }
        }

        public void unblockColumn(int index)
        {
            lock (_lockObject)
            {
                _blockedColumns.Remove(index);

                Monitor.PulseAll(_lockObject);
            }
        }
    }
}
