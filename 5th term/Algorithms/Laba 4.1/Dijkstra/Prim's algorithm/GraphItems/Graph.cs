using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim_s_algorithm.GraphItems
{
    public class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;

        public void AddVertex(Vertex vertex) => Vertexes.Add(vertex);
        public void AddVertex(IEnumerable<Vertex> vertexes) => Vertexes.AddRange(vertexes);
        public void AddEdge(Vertex from, Vertex to, int weight = 1)
        {
            Edges.Add(new Edge(from, to, weight));
            Edges.Add(new Edge(to, from, weight));
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

            return result.Distinct().OrderBy(item => item.Number).ToList();
        }

        public List<Vertex> GetAllVertexesList() => Vertexes;
        public List<Edge> GetAllEdgesList() => Edges;
        public int GetWeightByVertexes(Vertex start, Vertex end) =>
            Edges.FirstOrDefault(item => item.From == start && item.To == end).Weight;
    }
}
