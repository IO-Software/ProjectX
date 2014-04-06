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
        private static ArrayList array3D = new ArrayList();
        private static ArrayList array2D = new ArrayList();

        public PointConverter()
        {
            initialize2DArray();
            initialize3DArray();
        }

        private void initialize2DArray()
        {
            for (int i = 0; i < 1000; i++)
            {
                ArrayList array3DLine = new ArrayList();

                for (int j = 0; j < 1000; j++)
                {
                    IntPoint point = new IntPoint(i, j);
                    IntPoint convertedPoint = convertTo3D(point);
                    array3DLine.Add(convertedPoint);
                }
                array3D.Add(array3DLine);
                
            }
        }

        private void initialize3DArray()
        {
            for (int i = 0; i < 640; i++)
            {
                ArrayList array2DLine = new ArrayList();
                for (int j = 0; j < 480; j++)
                {
                    IntPoint point = new IntPoint(i, j);
                    IntPoint convertedPoint = convertTo2D(point);
                    array2DLine.Add(convertedPoint);
                }
                array2D.Add(array2DLine);
            }
        }

        private IntPoint convertTo2D(IntPoint punt)
        {
            IntPoint point3D = punt;
            IntPoint point2D = new IntPoint(0, 0);

            point2D.X = Convert.ToInt32(((point3D.X) - 320) * ((0.00000134 * Math.Pow(point3D.Y, 2)) - 0.0022568 * point3D.Y + 1.781) + 320 + 180);
            point2D.Y = Convert.ToInt32(point3D.Y + (0.000003 * Math.Pow(point3D.Y, 3.00)) - (0.0043 * Math.Pow(point3D.Y, 2.00)) + (2.0908 * point3D.Y) - 176.2 + 180);

            return point2D;
        }

        private IntPoint convertTo3D(IntPoint punt)
        {
            IntPoint point2D = new IntPoint(punt.X - 180, punt.Y - 180);
            IntPoint point3D = new IntPoint(0, 0);

            point3D.Y = Convert.ToInt32(0.1111111111e1 * Math.Pow(-0.78505640e8 + 0.121500e6 * point2D.Y + 0.36e2 * Math.Sqrt(0.11390625e8 * point2D.Y * point2D.Y - 0.1471980750e11 * point2D.Y + 0.5381613239e13), 0.1e1 / 0.3e1) - 0.1036355556e6 * Math.Pow(-0.78505640e8 + 0.121500e6 * point2D.Y + 0.36e2 * Math.Sqrt(0.11390625e8 * point2D.Y * point2D.Y - 0.1471980750e11 * point2D.Y + 0.5381613239e13), -0.1e1 / 0.3e1) + 0.4777777778e3);
            point3D.X = Convert.ToInt32(((point2D.X - 320) / ((0.00000134 * Math.Pow(point3D.Y, 2)) - 0.0022568 * point3D.Y + 1.781)) + 320);
            return point3D;
        }

        public static IntPoint get3DPoint(IntPoint point)
        {
            ArrayList from3Dto2Dline = (ArrayList)array2D[point.X];
            IntPoint newPoint = (IntPoint)from3Dto2Dline[point.Y];
            return newPoint;
        }

        public static IntPoint get2DPoint(IntPoint point)
        {
            ArrayList from2Dto3DLine = (ArrayList)array3D[point.X];
            IntPoint newPoint = (IntPoint)from2Dto3DLine[point.Y];
            return newPoint;
        }
    }
}
