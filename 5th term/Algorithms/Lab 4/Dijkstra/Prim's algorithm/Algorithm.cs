using Prim_s_algorithm.GraphItems;
using System.Collections.Generic;
using System.Linq;

namespace Prim_s_algorithm
{
    public static class Algorithm
    {
        public static Graph Prim_s(Graph graph)
        {
            Graph skeletonGraph = new Graph();
            skeletonGraph.AddVertex(graph.GetAllVertexesList());

            var skeletonList = new List<Vertex>() { skeletonGraph.GetAllVertexesList()[0] };
            var generalList = new List<Vertex>(skeletonGraph.GetAllVertexesList().Except(skeletonList));

            while (generalList.Count != 0)
            {
                Vertex fromVertex = null, toVertex = null;
                int weight = int.MaxValue;

                foreach (var skeletonItem in skeletonList)
                {
                    foreach (var generalItem in generalList)
                    {
                        if (graph.GetAllEdgesList().Any(item => item.From == skeletonItem && item.To == generalItem))
                        {
                            var edgeWeight = graph.GetWeightByVertexes(skeletonItem, generalItem);
                            if (weight > edgeWeight)
                            {
                                fromVertex = skeletonItem;
                                toVertex = generalItem;
                                weight = edgeWeight;
                            }
                        }
                    }
                }

                skeletonGraph.AddEdge(fromVertex, toVertex, weight);
                skeletonList.Add(toVertex);
                generalList.Remove(toVertex);
            }

            return skeletonGraph;
        }
        public static Graph Prim_sOpt(Graph graph)
        {
            Graph skeletonGraph = new Graph();
            skeletonGraph.AddVertex(graph.GetAllVertexesList());

            var skeletonList = new List<Vertex>() { skeletonGraph.GetAllVertexesList()[0] };

            while (skeletonGraph.VertexCount != skeletonList.Count)
            {
                Vertex fromVertex = null, toVertex = null;
                int weight = int.MaxValue;

                foreach (var skeletonItem in skeletonList)
                {
                    foreach (var generalItem in skeletonGraph.GetAllVertexesList().Except(skeletonList))
                    {
                        if (graph.GetAllEdgesList().Any(item => item.From == skeletonItem && item.To == generalItem))
                        {
                            var edgeWeight = graph.GetWeightByVertexes(skeletonItem, generalItem);
                            if (weight > edgeWeight)
                            {
                                fromVertex = skeletonItem;
                                toVertex = generalItem;
                                weight = edgeWeight;
                            }
                        }
                    }
                }

                skeletonGraph.AddEdge(fromVertex, toVertex, weight);
                skeletonList.Add(toVertex);
            }

            return skeletonGraph;
        }
    }
}
