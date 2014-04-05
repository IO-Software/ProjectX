using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using System.Windows;

namespace ProjectZ
{
    class Edge
    {
        private IntPoint edgePointA_3D;
        private IntPoint edgePointB_3D;

        public Edge(IntPoint edgePointA_3D, IntPoint edgePointB_3D)
        {
            this.edgePointA_3D = edgePointA_3D;
            this.edgePointB_3D = edgePointB_3D;
        }

        public IntPoint getEdgePointA_3D()
        {
            return edgePointA_3D;
        }

        public IntPoint getEdgePointB_3D()
        {
            return edgePointB_3D;
        }

        public IntPoint getEdgePointA_2D()
        {
            return PointConverter.get2DPoint(edgePointA_3D);
        }

        public IntPoint getEdgePointB_2D()
        {
            return PointConverter.get2DPoint(edgePointB_3D);
        }

        public void updateEdge(IntPoint newEdgePointA_3D, IntPoint newEdgePointB_3D) 
        {
            this.edgePointA_3D = newEdgePointA_3D;
            this.edgePointB_3D = newEdgePointB_3D;
        }
    }
}