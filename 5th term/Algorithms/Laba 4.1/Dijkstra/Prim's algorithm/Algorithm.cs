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

            var generalList = new List<Vertex>();
            generalList.AddRange(skeletonGraph.GetAllVertexesList().Except(skeletonList));

            while (generalList.Count != 0)
            {
                Vertex from = null, to = null;
                int weight = int.MaxValue;

                for (int i = 0; i < skeletonList.Count; i++)
                {
                    for (int j = 0; j < generalList.Count; j++)
                    {
                        if(graph.GetAllEdgesList().Any(item => item.From == skeletonList[i] && item.To == generalList[j]))
                        {
                            var edgeWeight = graph.GetWeightByVertexes(skeletonList[i], generalList[j]);
                            if (weight > edgeWeight)
                            {
                                from = skeletonList[i];
                                to = generalList[j];
                                weight = edgeWeight;
                            }
                        }
                    }
                }
                skeletonGraph.AddEdge(from, to, weight);
                skeletonList.Add(to);
                generalList.Remove(to);
            }

            return skeletonGraph;
        }
    }
}
