using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim_s_algorithm.GraphItems
{
    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}
