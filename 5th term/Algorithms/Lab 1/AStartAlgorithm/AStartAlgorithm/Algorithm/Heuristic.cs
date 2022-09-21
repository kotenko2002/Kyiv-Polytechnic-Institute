using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStartAlgorithm.Algorithm
{
    public static class Heuristic
    {
        public static int F((int, int) currentPoint, (int, int) goalPoint)
        {
            return
                Math.Abs(goalPoint.Item1 - currentPoint.Item1) + Math.Abs(goalPoint.Item2 - currentPoint.Item2);
        }
    }
}
