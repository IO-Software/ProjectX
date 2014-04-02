using AForge;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectY
{
    class Player : VisibleObject
    {
        AForge.Point pos;
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
            pos.X = (corners[1].X + corners[3].X) / 2;
            pos.Y = (corners[1].Y + corners[3].Y) / 2;
        }

        public Bitmap draw(Bitmap image)
        {
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.DrawLine(pen, pos.X, pos.Y, pos.X+1, pos.Y+1);
            }
            return image;
        }
    }
}
