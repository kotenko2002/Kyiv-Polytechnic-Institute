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
                for (int i = 0; i < vertexArray.Length; i++)
                {
                    if (vertexArray[i].Value < minValue && !vertexArray[i].IsVisited)
                    {
                        minValue = vertexArray[i].Value;
                        curentVertex = vertexArray[i];
                        flag = false;
                    }
                }

                if (flag) break;

                List<Vertex> listOfVertexes = graph.GetVertexListWithoutVisuted(curentVertex);

                for (int i = 0; i < listOfVertexes.Count; i++)
                {
                    int weight = graph.GetWeightByVertexes(curentVertex, listOfVertexes[i]);
                    int index = Array.FindIndex(vertexArray, item => item == listOfVertexes[i]);

                    if (vertexArray[index].Value > curentVertex.Value + weight)
                        vertexArray[index].Value = curentVertex.Value + weight;
                }
                curentVertex.IsVisited = true;
            }
            return vertexArray;
        }
    }
}
