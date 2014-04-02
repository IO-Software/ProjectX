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
        IntPoint pos1;
        IntPoint pos2;
        IntPoint pos3;
        IntPoint pos4;
        Pen pen;

        public Player(int penNo)
        {
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
            pos1.X = corners[0].X;
            pos1.Y = corners[0].Y;
            pos2.X = corners[1].X;
            pos2.Y = corners[1].Y;
            pos3.X = corners[2].X;
            pos3.Y = corners[2].Y;
            pos4.X = corners[3].X;
            pos4.Y = corners[3].Y;
        }

        public Bitmap draw(Bitmap image)
        {
            if (image != null)
            {
                try
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        graphics.DrawLine(pen, pos1.X, pos1.Y, pos2.X, pos2.Y);
                        graphics.DrawLine(pen, pos2.X, pos2.Y, pos3.X, pos3.Y);
                        graphics.DrawLine(pen, pos3.X, pos3.Y, pos4.X, pos4.Y);
                        graphics.DrawLine(pen, pos4.X, pos4.Y, pos1.X, pos1.Y);
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
