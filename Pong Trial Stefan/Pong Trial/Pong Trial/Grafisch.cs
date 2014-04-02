using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Imaging;
using System.Drawing;



namespace Pong_Trial
{
    class TekenVierkant
    {
        public TekenVierkant()
    { 
        }

        public Bitmap stip(AForge.IntPoint cntrpoint, Bitmap plaatje)
        {
            using (var graphics = Graphics.FromImage(plaatje))
            {
                Pen pennetje = new Pen(Color.Red, 5);
                graphics.DrawLine(pennetje, cntrpoint.X, cntrpoint.Y, cntrpoint.X+5, cntrpoint.Y);
            }


            return plaatje;
        }

        
        
    }
    
}
