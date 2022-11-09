namespace Dijkstra.GraphItems
{
    public class Vertex
    {
        public int Number { get; set; }
        public bool IsVisited { get; set; } = false;
        public int Value { get; set; } = int.MaxValue;

        public Vertex(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
