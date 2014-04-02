using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AForge;

namespace ProjectY
{
    class PointConverter
    {
        public static ArrayList from2Dto3D;
        public static ArrayList from3Dto2D;

        public PointConverter()
        {
            initialize2Dto3D();
            initialize3Dto2D();
        }

        private void initialize2Dto3D()
        {
            for (int i = 0; i < 1000; i++)
            {
                ArrayList from2Dto3Dline = new ArrayList();

                for (int j = 0; j < 1000; j++)
                {
                    IntPoint point = new IntPoint(i, j);
                    from2Dto3Dline.Add(naar3D(point));
                }
                from2Dto3D.Add(from2Dto3Dline);
            }
        }

        private void initialize3Dto2D()
        {
            for (int i = 0; i < 640; i++)
            {
                ArrayList from3Dto2Dline = new ArrayList();
                for (int j = 0; j < 480; j++)
                {
                    IntPoint point = new IntPoint(i, j);
                    from3Dto2Dline.Add(naar2D(point));
                }
                from3Dto2D.Add(from3Dto2Dline);
            }
        }

        private IntPoint naar2D(IntPoint punt)
        {
            IntPoint punt3D = punt;
            IntPoint punt2D = new IntPoint(0, 0);

            punt2D.X = Convert.ToInt32(((punt3D.X) - 320) * ((0.00000134 * Math.Pow(punt3D.Y, 2)) - 0.0022568 * punt3D.Y + 1.781) + 320);
            punt2D.Y = Convert.ToInt32(punt3D.Y + (0.000003 * Math.Pow(punt3D.Y, 3.00)) - (0.0043 * Math.Pow(punt3D.Y, 2.00)) + (2.0908 * punt3D.Y) - 176.2);

            return punt2D;
        }

        private IntPoint naar3D(IntPoint punt)
        {
            return null;
        }

        public static IntPoint get3DPoint (IntPoint point) 
        {
            ArrayList from3Dto2Dline = (ArrayList) from3Dto2D[point.X];
            IntPoint newPoint = (IntPoint) from3Dto2Dline[point.Y];
            return newPoint;
        }

        public static IntPoint get2DPoint(IntPoint point)
        {
            ArrayList from2Dto3DLine = (ArrayList)from2Dto3D[point.X];
            IntPoint newPoint = (IntPoint)from2Dto3DLine[point.Y];
            return newPoint;
        }
    }
}
