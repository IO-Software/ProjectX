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
    class Converteer
    {
        public Converteer()
        { 
        
        }
        
        



        public AForge.IntPoint naar2D(AForge.IntPoint punt)
        {
            AForge.IntPoint punt3D = punt;   
            AForge.IntPoint punt2D = new AForge.IntPoint(0,0);

            punt2D.X = Convert.ToInt32(((punt3D.X) - 320) * ((0.00000134 * Math.Pow(punt3D.Y, 2))-0.0022568 * punt3D.Y + 1.781)+320);
            punt2D.Y = Convert.ToInt32(punt3D.Y + (0.000003 * Math.Pow(punt3D.Y, 3.00)) - (0.0043 * Math.Pow(punt3D.Y, 2.00)) + (2.0908 * punt3D.Y) - 176.2);
  
            return punt2D;

        }

        public AForge.IntPoint naar3D(AForge.IntPoint punt)
        {
            AForge.IntPoint punt2D = punt;
            AForge.IntPoint punt3D = new AForge.IntPoint(0, 0);

            //punt3D.X = 
            //punt3D.Y = 

            return punt3D;

        }
    }
}
