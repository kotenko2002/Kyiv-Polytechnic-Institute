using Prim_s_algorithm.GraphItems;
using System;

namespace Prim_s_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            #region CreateAndAddVertexes
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
            #endregion

            #region AddEdges
            graph.AddEdge(v2, v1, 4);
            graph.AddEdge(v2, v8, 4);
            graph.AddEdge(v2, v3, 3);
            graph.AddEdge(v2, v4, 1);// red
            graph.AddEdge(v3, v1, 3);
            graph.AddEdge(v3, v5, 2);
            //graph.AddEdge(v4, v2, 3);// red
            graph.AddEdge(v4, v7, 3);
            graph.AddEdge(v5, v6, 5);
            graph.AddEdge(v5, v7, 2);
            graph.AddEdge(v6, v2, 1);
            graph.AddEdge(v6, v3, 3);
            graph.AddEdge(v6, v5, 2);
            graph.AddEdge(v6, v7, 1);// blue
            graph.AddEdge(v6, v8, 3);
            //graph.AddEdge(v7, v6, 2);// blue
            graph.AddEdge(v7, v2, 1);
            graph.AddEdge(v8, v3, 2);
            graph.AddEdge(v8, v4, 2);
            graph.AddEdge(v8, v7, 4);
            #endregion

            #region PrintGraph
            PrintMatrix(graph);
            Console.WriteLine();
            PrintVertexList(graph, v1);
            PrintVertexList(graph, v2);
            PrintVertexList(graph, v3);
            PrintVertexList(graph, v4);
            PrintVertexList(graph, v5);
            PrintVertexList(graph, v6);
            PrintVertexList(graph, v7);
            PrintVertexList(graph, v8);
            Console.WriteLine();
            #endregion

            var skeletonGraph = Algorithm.Prim_s(graph);

            #region PrintSkeletonGraph
            PrintCoolMatrix(graph, skeletonGraph);
            Console.WriteLine();
            PrintVertexList(skeletonGraph, v1);
            PrintVertexList(skeletonGraph, v2);
            PrintVertexList(skeletonGraph, v3);
            PrintVertexList(skeletonGraph, v4);
            PrintVertexList(skeletonGraph, v5);
            PrintVertexList(skeletonGraph, v6);
            PrintVertexList(skeletonGraph, v7);
            PrintVertexList(skeletonGraph, v8);
            Console.WriteLine();
            #endregion
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
        private static void PrintCoolMatrix(Graph graph, Graph skeletonGraph)
        {
            var oldMatrix = graph.GetMatrix();
            var newMatrix = skeletonGraph.GetMatrix();

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
                    if(oldMatrix[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(newMatrix[i, j] + " ");
                    }
                    else if(oldMatrix[i, j] != newMatrix[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(newMatrix[i, j]);

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(newMatrix[i, j]);

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }

        private static void PrintVertexList(Graph graph, Vertex vertex)
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
