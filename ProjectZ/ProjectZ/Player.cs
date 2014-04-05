using AForge;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    class Player : VisibleObject
    {
        Edge edge1;
        Edge edge2;
        Edge edge3;
        Edge edge4;

        Pen pen;

        public Player(int penNo)
        {
            IntPoint temp = new IntPoint(0, 0);
            edge1 = new Edge(temp, temp);
            edge2 = new Edge(temp, temp);
            edge3 = new Edge(temp, temp);
            edge4 = new Edge(temp, temp);
            if (penNo == 1)
            {
                pen = new Pen(Color.Red, 2);
            }
            else
            {
                pen = new Pen(Color.Blue, 2);
            }
        }

        public void updatePosition(List<IntPoint> corners)
        {
            edge1.updateEdge(corners[0], corners[1]);
            edge2.updateEdge(corners[1], corners[2]);
            edge3.updateEdge(corners[2], corners[3]);
            edge4.updateEdge(corners[3], corners[0]);
        }

        public Bitmap draw(Bitmap image)
        {
            if (image != null)
            {
                try
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        graphics.DrawLine(pen, edge1.getEdgePointA_3D().X, edge1.getEdgePointA_3D().Y, edge1.getEdgePointB_3D().X, edge1.getEdgePointB_3D().Y);
                        graphics.DrawLine(pen, edge2.getEdgePointA_3D().X, edge2.getEdgePointA_3D().Y, edge2.getEdgePointB_3D().X, edge2.getEdgePointB_3D().Y);
                        graphics.DrawLine(pen, edge3.getEdgePointA_3D().X, edge3.getEdgePointA_3D().Y, edge3.getEdgePointB_3D().X, edge3.getEdgePointB_3D().Y);
                        graphics.DrawLine(pen, edge4.getEdgePointA_3D().X, edge4.getEdgePointA_3D().Y, edge4.getEdgePointB_3D().X, edge4.getEdgePointB_3D().Y);
                        graphics.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return image;
        }
    }
}
