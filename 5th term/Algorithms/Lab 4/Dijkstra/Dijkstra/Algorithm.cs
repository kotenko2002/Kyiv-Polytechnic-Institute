using System.Collections.Generic;
using Dijkstra.GraphItems;
using System.Linq;
using System;

namespace Dijkstra
{
    public static class Algorithm
    {
        public static Vertex[] Dijkstra(Graph graph, Vertex start)
        {
            Vertex[] vertexArray = graph.GetAllVertexesList().ToArray();

            Vertex curentVertex = start;
            curentVertex.Value = 0;

            while (vertexArray.Any(item => item.IsVisited == false))
            {
                int minValue = int.MaxValue;
                bool flag = true;
                
                foreach (var vertex in vertexArray)
                {
                    if (vertex.Value < minValue && !vertex.IsVisited)
                    {
                        curentVertex = vertex;
                        minValue = curentVertex.Value;
                        flag = false;
                    }
                }

                if (flag) break;

                List<Vertex> listOfVertexes = graph.GetVertexListWithoutVisuted(curentVertex);
                foreach (var vertex in listOfVertexes)
                {
                    int weight = graph.GetWeightByVertexes(curentVertex, vertex);
                    int index = Array.FindIndex(vertexArray, item => item == vertex);

                    if (vertexArray[index].Value > curentVertex.Value + weight)
                        vertexArray[index].Value = curentVertex.Value + weight;
                }

                curentVertex.IsVisited = true;
            }
            return vertexArray;
        }
    }
}
