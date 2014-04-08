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
        private static Edge edgeUp;
        private static Edge edgeDown;
        private static Edge edgeLeft;
        private static Edge edgeRight;
        Pen bluePen = new Pen(Color.Blue, 3);
        Pen redPen = new Pen(Color.Red, 3);
        Pen whitePen = new Pen(Color.White, 3);

        public PlayingField()
        {
            edgeUp = new Edge(new IntPoint(142, 3), new IntPoint(498, 3));
            edgeDown = new Edge(new IntPoint(3, 477), new IntPoint(637, 477));
            edgeLeft = new Edge(new IntPoint(3, 477), new IntPoint(142, 3));
            edgeRight = new Edge(new IntPoint(637, 477), new IntPoint(498, 3));
        }

        public static Edge getLeft()
        {
            return edgeLeft;
        }

        public static Edge getRight()
        {
            return edgeRight;
        }

        public void addEdgesToKeeper()
        {
            EdgeKeeper.addEdge(edgeUp);
            EdgeKeeper.addEdge(edgeDown);
            EdgeKeeper.addEdge(edgeLeft);
            EdgeKeeper.addEdge(edgeRight);
        }

        // TEST
        public Bitmap draw(Bitmap image)
        {
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.DrawLine(whitePen, edgeUp.getEdgePointA_3D().X, edgeUp.getEdgePointA_3D().Y, edgeUp.getEdgePointB_3D().X, edgeUp.getEdgePointB_3D().Y);
                graphics.DrawLine(whitePen, edgeDown.getEdgePointA_3D().X, edgeDown.getEdgePointA_3D().Y, edgeDown.getEdgePointB_3D().X, edgeDown.getEdgePointB_3D().Y);
                graphics.DrawLine(redPen, edgeLeft.getEdgePointA_3D().X, edgeLeft.getEdgePointA_3D().Y, edgeLeft.getEdgePointB_3D().X, edgeLeft.getEdgePointB_3D().Y);
                graphics.DrawLine(bluePen, edgeRight.getEdgePointA_3D().X, edgeRight.getEdgePointA_3D().Y, edgeRight.getEdgePointB_3D().X, edgeRight.getEdgePointB_3D().Y);
                graphics.Dispose();
            }

            return image;
        }

        public void updatePosition(List<IntPoint> corners)
        {
            
        }
    }
}

