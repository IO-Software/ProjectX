using AForge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    class PlayingField : ObjectWithEdge, VisibleObject
    {
        Edge edgeUp;
        Edge edgeDown;
        Edge edgeLeftTop;
        Edge edgeLeftBottom;
        Edge edgeRightTop;
        Edge edgeRightBottom;
        Pen pen = new Pen(Color.Pink, 3);

        public PlayingField()
        {
            edgeUp = new Edge(new IntPoint(92, 0), new IntPoint(548, 0));
            edgeDown = new Edge(new IntPoint(0, 480), new IntPoint(640, 480));
            edgeLeftTop = new Edge(new IntPoint(0, 240), new IntPoint(92, 0));
            edgeLeftBottom = new Edge(new IntPoint(0, 240), new IntPoint(0, 480));
            edgeRightTop = new Edge(new IntPoint(548, 0), new IntPoint(640, 240));
            edgeRightBottom = new Edge(new IntPoint(640, 240), new IntPoint(640, 480));
        }

        public Edge getLeftTopEdge()
        {
            return edgeLeftTop;
        }

        public Edge getLeftBottomEdge()
        {
            return edgeLeftBottom;
        }

        public Edge getRightTopEdge()
        {
            return edgeRightTop;
        }

        public Edge getRightBottomEdge()
        {
            return edgeRightBottom;
        }

        public void addEdgesToKeeper()
        {
            EdgeKeeper.addEdge(edgeUp);
            EdgeKeeper.addEdge(edgeDown);
            EdgeKeeper.addEdge(edgeLeftTop);
            EdgeKeeper.addEdge(edgeLeftBottom);
            EdgeKeeper.addEdge(edgeRightTop);
            EdgeKeeper.addEdge(edgeRightBottom);
        }

        // TEST
        public Bitmap draw(Bitmap image)
        {
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.DrawLine(pen, edgeUp.getEdgePointA_3D().X, edgeUp.getEdgePointA_3D().Y, edgeUp.getEdgePointB_3D().X, edgeUp.getEdgePointB_3D().Y);
                graphics.DrawLine(pen, edgeDown.getEdgePointA_3D().X, edgeDown.getEdgePointA_3D().Y, edgeDown.getEdgePointB_3D().X, edgeDown.getEdgePointB_3D().Y);
                graphics.DrawLine(pen, edgeLeftTop.getEdgePointA_3D().X, edgeLeftTop.getEdgePointA_3D().Y, edgeLeftTop.getEdgePointB_3D().X, edgeLeftTop.getEdgePointB_3D().Y);
                graphics.DrawLine(pen, edgeLeftBottom.getEdgePointA_3D().X, edgeLeftBottom.getEdgePointA_3D().Y, edgeLeftBottom.getEdgePointB_3D().X, edgeLeftBottom.getEdgePointB_3D().Y);
                graphics.DrawLine(pen, edgeRightTop.getEdgePointA_3D().X, edgeRightTop.getEdgePointA_3D().Y, edgeRightTop.getEdgePointB_3D().X, edgeRightTop.getEdgePointB_3D().Y);
                graphics.DrawLine(pen, edgeRightBottom.getEdgePointA_3D().X, edgeRightBottom.getEdgePointA_3D().Y, edgeRightBottom.getEdgePointB_3D().X, edgeRightBottom.getEdgePointB_3D().Y);
                graphics.Dispose();
            }

            return image;
        }

        public void updatePosition(List<IntPoint> corners)
        {
            
        }
    }
}

