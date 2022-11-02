using Dijkstra.GraphItems;
using System;

namespace Dijkstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);
            var v8 = new Vertex(8);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);

            graph.AddEdge(v2, v5, 4);
            graph.AddEdge(v2, v8, 4);
            graph.AddEdge(v2, v3, 3);
            graph.AddEdge(v2, v4, 1);
            graph.AddEdge(v3, v4, 3);
            graph.AddEdge(v3, v5, 2);
            graph.AddEdge(v4, v2, 3);
            graph.AddEdge(v4, v7, 3);
            graph.AddEdge(v5, v6, 5);
            graph.AddEdge(v5, v7, 2);
            graph.AddEdge(v6, v2, 1);
            graph.AddEdge(v6, v3, 3);
            graph.AddEdge(v6, v5, 2);
            graph.AddEdge(v6, v7, 1);
            graph.AddEdge(v6, v8, 3);
            graph.AddEdge(v7, v6, 2);
            graph.AddEdge(v7, v2, 1);
            graph.AddEdge(v8, v3, 2);
            graph.AddEdge(v8, v4, 2);
            graph.AddEdge(v8, v7, 4);

            PrintMatrix(graph);
            Console.WriteLine();
            PrintVertwxList(graph, v1);
            PrintVertwxList(graph, v2);
            PrintVertwxList(graph, v3);
            PrintVertwxList(graph, v4);
            PrintVertwxList(graph, v5);
            PrintVertwxList(graph, v6);
            PrintVertwxList(graph, v7);
            PrintVertwxList(graph, v8);

            Console.WriteLine();
            var result = Algorithm.Dijkstra(graph, v5);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"Вiдстань вiд вершини \"{v2}\" до вершини \"{result[i]}\" - " +
                    $"{(result[i].Value == int.MaxValue ? "немає шляху" : result[i].Value)}\n");
            }
        }
        private static void PrintMatrix(Graph graph)
        {
            var matrix = graph.GetMatrix();

            Console.Write("__");
            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (i != graph.VertexCount - 1)
                    Console.Write($"{i + 1}_");
                else
                    Console.Write($"{i + 1}");
            }
            Console.WriteLine();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(i + 1 + "|");
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void PrintVertwxList(Graph graph, Vertex vertex)
        {
            Console.Write($"{vertex.Number}: ");

            var vertexes = graph.GetVertexList(vertex);
            for (int i = 0; i < vertexes.Count; i++)
            {
                if (i != vertexes.Count - 1)
                    Console.Write($"{vertexes[i].Number}, ");
                else
                    Console.Write($"{vertexes[i].Number} ");
            }

            Console.WriteLine();
        }
    }
}
