using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Lijn_intersectie
{
    class Ball
    {
        public AForge.IntPoint positie = new AForge.IntPoint();
        public int speedx = 10;
        public int speedy = 10;
        public double hoek =0.8;
        public int snelheid = 4;


        public bool checkcollision(AForge.IntPoint A, AForge.IntPoint B)
    {
        return IsIntersecting(A, B, this.positie, speedx, speedy);
    }

        bool IsIntersecting(AForge.IntPoint a, AForge.IntPoint b, AForge.IntPoint c, int speedx, int speedy)
        {


            // Punt d is een voorspelling van het punt waar punt C de volgende stap gaat zijn
            AForge.IntPoint d = new AForge.IntPoint(Convert.ToInt32(c.X + Math.Cos(hoek) * snelheid), Convert.ToInt32(c.Y + Math.Sin(hoek) * snelheid));

            float denominator = ((b.X - a.X) * (d.Y - c.Y)) - ((b.Y - a.Y) * (d.X - c.X));
            float numerator1 = ((a.Y - c.Y) * (d.X - c.X)) - ((a.X - c.X) * (d.Y - c.Y));
            float numerator2 = ((a.Y - c.Y) * (b.X - a.X)) - ((a.X - c.X) * (b.Y - a.Y));


            if (denominator == 0) return numerator1 == 0 && numerator2 == 0;

            float r = numerator1 / denominator;
            float s = numerator2 / denominator;

            return (r >= 0 && r <= 1) && (s >= 0 && s <= 1);
        }

        public void bounce(AForge.IntPoint A, AForge.IntPoint B)
        {


            Double dX = A.X - B.X;
            Double dY = A.Y - B.Y;

            AForge.DoublePoint wallVector = new AForge.DoublePoint(dX, dY);

            Console.WriteLine("De norm x en y vd muur: " + wallVector.X  +"  " + wallVector.Y);


            // Breuken in de ATan functie werken niet goed, dus bij deze een helper
            double Atanhelper = wallVector.Y / wallVector.X;
            double hoekWall = Math.Atan(Atanhelper);
            Console.WriteLine("Hoek van de geraakte muur: " + hoekWall);




            double normaalhoekWall = hoekWall + 1.57;

            Console.WriteLine("Hoek van de normaal van de muur: " + normaalhoekWall);
             
            //double anglenVector = Math.Atan(wallVector.Y / wallVector.X);

            //Console.WriteLine("Hoek van de Normaalvector: " + anglenVector);

            double anglesVector = hoek;
            Console.WriteLine("Hoek van de snelheidsvector: " + anglesVector);

            double angleVerschil = normaalhoekWall - anglesVector;

            Console.WriteLine("Verschil tussen de vectoren: " + angleVerschil);

            double anglesVectorNew = anglesVector - 3.14 + (2 * angleVerschil);

            hoek = anglesVectorNew;
            //hoek = normaalhoekWall;

            Console.WriteLine("Hoek van de bal: " + hoek);

            positie.X = Convert.ToInt32(positie.X + Math.Cos(hoek) * snelheid);
            positie.Y = Convert.ToInt32(positie.Y + Math.Sin(hoek) * snelheid);

        }

    }
}
