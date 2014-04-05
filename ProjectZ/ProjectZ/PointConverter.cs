using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AForge;

namespace ProjectZ
{
    class PointConverter
    {
        private static ArrayList from2Dto3D = new ArrayList();
        private static ArrayList from3Dto2D = new ArrayList();

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
                    IntPoint convertedPoint = convert3D(point);
                    from2Dto3Dline.Add(convertedPoint);
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
                    IntPoint convertedPoint = convert2D(point);
                    from3Dto2Dline.Add(convertedPoint);
                }
                from3Dto2D.Add(from3Dto2Dline);
            }
        }

        private IntPoint convert2D(IntPoint punt)
        {
            IntPoint point3D = punt;
            IntPoint point2D = new IntPoint(0, 0);

            point2D.X = Convert.ToInt32(((point3D.X) - 320) * ((0.00000134 * Math.Pow(point3D.Y, 2)) - 0.0022568 * point3D.Y + 1.781) + 320 + 180);
            point2D.Y = Convert.ToInt32(point3D.Y + (0.000003 * Math.Pow(point3D.Y, 3.00)) - (0.0043 * Math.Pow(point3D.Y, 2.00)) + (2.0908 * point3D.Y) - 176.2 + 180);

            return point2D;
        }

        private IntPoint convert3D(IntPoint punt)
        {
            IntPoint point2D = new IntPoint(punt.X - 180, punt.Y - 180);
            IntPoint point3D = new IntPoint(0, 0);

            point3D.Y = Convert.ToInt32(0.1111111111e1 * Math.Pow(-0.78505640e8 + 0.121500e6 * point2D.Y + 0.36e2 * Math.Sqrt(0.11390625e8 * point2D.Y * point2D.Y - 0.1471980750e11 * point2D.Y + 0.5381613239e13), 0.1e1 / 0.3e1) - 0.1036355556e6 * Math.Pow(-0.78505640e8 + 0.121500e6 * point2D.Y + 0.36e2 * Math.Sqrt(0.11390625e8 * point2D.Y * point2D.Y - 0.1471980750e11 * point2D.Y + 0.5381613239e13), -0.1e1 / 0.3e1) + 0.4777777778e3);
            point3D.X = Convert.ToInt32(((point2D.X - 320) / ((0.00000134 * Math.Pow(point3D.Y, 2)) - 0.0022568 * point3D.Y + 1.781)) + 320);
            return point3D;
        }

        public static IntPoint get3DPoint(IntPoint point)
        {
            ArrayList from3Dto2Dline = (ArrayList)from3Dto2D[point.X];
            IntPoint newPoint = (IntPoint)from3Dto2Dline[point.Y];
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
