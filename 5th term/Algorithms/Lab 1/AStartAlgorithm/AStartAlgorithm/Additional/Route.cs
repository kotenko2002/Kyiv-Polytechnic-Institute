namespace AStartAlgorithm.Additional
{
    public class Route
    {
        public string Direction { get; }
        public (int, int) Coordinates { get; }

        public Route(string direction, (int, int) coordinates)
        {
            Direction = direction;
            Coordinates = coordinates;
        }
    }
}
