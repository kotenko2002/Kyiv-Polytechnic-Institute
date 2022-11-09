using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.GraphItems
{
    public class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;

        public void AddVertex(Vertex vertex) => Vertexes.Add(vertex);
        public void AddEdge(Vertex from, Vertex to, int weight = 1)
        {
            var edge = new Edge(from, to, weight);
            Edges.Add(edge);
        }

        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Edges.Count];

            foreach (var edge in Edges)
            {
                var row = edge.From.Number;
                var column = edge.To.Number;

                matrix[row - 1, column - 1] = edge.Weight;
            }

            return matrix;
        }

        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in Edges)
                if (edge.From == vertex)
                    result.Add(edge.To);

            return result;
        }
        public List<Vertex> GetVertexListWithoutVisuted(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in Edges)
                if (edge.From == vertex && !edge.From.IsVisited)
                    result.Add(edge.To);

            return result;
        }

        public List<Vertex> GetAllVertexesList() => Vertexes;
        public int GetWeightByVertexes(Vertex start, Vertex end) =>
            Edges.FirstOrDefault(item => item.From == start && item.To == end).Weight;
    }
}
