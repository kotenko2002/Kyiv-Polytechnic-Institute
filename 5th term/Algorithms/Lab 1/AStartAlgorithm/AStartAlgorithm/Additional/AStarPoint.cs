namespace AStartAlgorithm.Additional
{
    public class AStarPoint
    {
        public (int, int ) Coordinates { get; set; }
        public int HeuristicValue { get; set; }
        public int СostValue { get; set; } = 1;
        public int TotallValue { get; set; }
        public AStarPoint Parent { get; set; } = null;

        public AStarPoint(int i, int j, int HeuristicValue)
        {
            Coordinates = (i,j);
            this.HeuristicValue = HeuristicValue;

            TotallValue = HeuristicValue + СostValue;
        }
    }
}
