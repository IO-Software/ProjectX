using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AForge;
using System.Collections.Generic;
using System.IO;

namespace ProjectZ
{
    class PointConverter
    {
        private static IntPoint[,] arrayTo3D = new IntPoint[1000 + 20, 1000];
        private static IntPoint[,] arrayTo2D = new IntPoint[640 + 20, 480];

        public PointConverter()
        {
            initializeTo3DArray();
            initializeTo2DArray();
        }

        private void initializeTo3DArray()
        {
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    arrayTo3D[x,y] = convertTo3D(new IntPoint(x, y));
                }
            }
        }

        private void initializeTo2DArray()
        {
            for (int x = 0; x < 640; x++)
            {
                for (int y = 0; y < 480; y++)
                {
                    IntPoint point = new IntPoint(x, y);
                    arrayTo2D[x,y] = convertTo2D(point);
                }
            }
        }

        private IntPoint convertTo2D(IntPoint point3D)
        {
            IntPoint point2D = new IntPoint(0, 0);

            point2D.X = Convert.ToInt32(((point3D.X) - 320) * ((0.00000134 * Math.Pow(point3D.Y, 2)) - 0.0022568 * point3D.Y + 1.781) + 320 + 180);
            point2D.Y = Convert.ToInt32(point3D.Y + (0.000003 * Math.Pow(point3D.Y, 3.00)) - (0.0043 * Math.Pow(point3D.Y, 2.00)) + (2.0908 * point3D.Y) - 176.2 + 180);
            return point2D;
        }

        private IntPoint convertTo3D(IntPoint point2D)
        {
            IntPoint point3D = new IntPoint(0, 0);

            point3D.Y = Convert.ToInt32(0.1111111111e1 * Math.Pow(-0.78505640e8 + 0.121500e6 * (point2D.Y - 180) + 0.36e2 * Math.Sqrt(0.11390625e8 * (point2D.Y - 180) * (point2D.Y - 180) - 0.1471980750e11 * (point2D.Y - 180) + 0.5381613239e13), 0.1e1 / 0.3e1) - 0.1036355556e6 *
                Math.Pow(-0.78505640e8 + 0.121500e6 * (point2D.Y - 180) + 0.36e2 * Math.Sqrt(0.11390625e8 * (point2D.Y - 180) * (point2D.Y - 180) - 0.1471980750e11 * (point2D.Y - 180) + 0.5381613239e13), -0.1e1 / 0.3e1) + 0.4777777778e3);
            //Console.WriteLine("POINT2D.X = " + point2D.X);
            //Console.WriteLine("POINT3D.Y = " + point3D.Y);

            //LET OP: de factor 1.26 aan het eind vd formule is een make-shift fix. Mathematisch probleem onbekend.
            point3D.X = Convert.ToInt32((((point2D.X - 320 - 180) / ((0.00000134 * Math.Pow((point3D.Y - 180), 2)) - 0.0022568 * (point3D.Y - 180) + 1.781))*1.26) + 320);
            return point3D;
        }

        public static IntPoint get3DPoint(IntPoint point)
        {
            try
            {
                return arrayTo3D[point.X, point.Y];
            }
            catch
            {
                Console.WriteLine("3D punten hebben problemen");
                Console.WriteLine("get3Dpoint: " + point.X + ";" + point.Y);
            }
            return new IntPoint(320, 240);
        }

        public static IntPoint get2DPoint(IntPoint point)
        {
            try
            {
                return arrayTo2D[point.X, point.Y];
            }
            catch
            {
                Console.WriteLine("get2Dpoint: " + point.X + ";" + point.Y);
                Console.WriteLine("2D punten hebben problemen");
            }
            return new IntPoint(500, 500);
        }
    }
}
