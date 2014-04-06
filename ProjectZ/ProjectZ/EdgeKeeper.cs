using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    class EdgeKeeper
    {
        public static List<Edge> edgeList;

        public EdgeKeeper()
        {
            edgeList = new List<Edge>();
        }

        public static List<Edge> getEdges()
        {
            return edgeList;
        }

        public static void addEdge(Edge edge)
        {
            edgeList.Add(edge);
        }

        public static void emptyEdges()
        {
            edgeList.Clear();
        }
    }
}
