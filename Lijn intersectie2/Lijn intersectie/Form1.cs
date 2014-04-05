using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;

using System.Windows;





namespace Lijn_intersectie
{
    public partial class Form1 : Form
    {

        Ball ball = new Ball();
        Wall wall1 = new Wall();
        Wall wall2 = new Wall();
        Wall wall3 = new Wall();
        Wall wall4 = new Wall();
        Wall test = new Wall();

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
          
            
           

            // Aanmaken van alle punten die gebruikt gaan worden
            // Geven van waarden van muur 1
            wall1.a.X = 0;
            wall1.a.Y = 0;

            wall1.b.X = 400;
            wall1.b.Y = 50;

            // Geven van waarden van muur 2
            wall2.a.X = 400;
            wall2.a.Y = 0;

            wall2.b.X = 400;
            wall2.b.Y = 400;

            // Geven van waarden van muur 3
            wall3.a.X = 400;
            wall3.a.Y = 300;

            wall3.b.X = 0;
            wall3.b.Y = 400;

            // Geven van waarden van muur 4
            wall4.a.X = 0;
            wall4.a.Y = 400;

            wall4.b.X = 0;
            wall4.b.Y = 0;

            test.a.X = 30;
            test.a.Y = 30;

            test.b.X = 60;
            test.b.Y = 60;

            // Positie van de ball zetten
            ball.positie.X = 200;
            ball.positie.Y = 200;

            // Snelheid van de bal
            ball.speedx = -6;
            ball.speedy = 7;

            // Teken de Ball
            //using (var graphics = Graphics.FromImage(pictureBox1.Image))
            //{
                // Teken de voorspelling van beweging
              //  Pen penbeweging = new Pen(Color.Red, 2);
//                graphics.DrawLine(penbeweging, ball.positie.X, ball.positie.Y, ball.positie.X + ball.speedx, ball.positie.Y + ball.speedy);

                // Teken de bal
  //              Pen balpen = new Pen(Color.Blue, 10);
    //            graphics.DrawLine(balpen, ball.positie.X - 5, ball.positie.Y, ball.positie.X + 5, ball.positie.Y);
      //      }

            // Teken de muren
            tekenmuur(wall1.a,wall1.b);
            tekenmuur(wall2.a,wall2.b);
            tekenmuur(wall3.a, wall3.b);
            tekenmuur(wall4.a, wall4.b);
            tekenmuur(test.a, test.b);




        }

        public void tekenmuur(AForge.IntPoint A, AForge.IntPoint B)
        {

            using (var graphics = Graphics.FromImage(pictureBox1.Image))
            {
                // Teken de muur
                Pen penlijnstuk = new Pen(Color.Black, 2);
                graphics.DrawLine(penlijnstuk, A.X, A.Y, B.X, B.Y);

            }

        }

        public Bitmap tekenbal(AForge.IntPoint A)
        {
            // Teken de Ball

            Bitmap plaatje = (Bitmap) pictureBox1.Image;

            using (var graphics = Graphics.FromImage(plaatje))
            {
                // Teken de bal
                Pen balpen = new Pen(Color.Blue, 2);
                graphics.DrawLine(balpen, A.X - 1, A.Y, A.X + 1, A.Y);
                //graphics.DrawLine(balpen, 10, 10, 20, 20);
            }

            return plaatje;


        }
       

        public void timer1_Tick(object sender, EventArgs e)
        {
            ball.positie.X = Convert.ToInt32(ball.positie.X + Math.Cos(ball.hoek)*ball.snelheid);
            ball.positie.Y = Convert.ToInt32(ball.positie.Y + Math.Sin(ball.hoek)*ball.snelheid);
            
            pictureBox1.Image= tekenbal(ball.positie);

           // Console.WriteLine(ball.positie);

            bool check1 = new bool();

            // check of de ball muur 1 raakt
            check1 = ball.checkcollision(wall1.a, wall1.b);
            // Console.WriteLine("collisie met muur 1 is " + check);
            if (check1 == true)
            {
                ball.bounce(wall1.a, wall1.b);
                check1 = false;
            }


            // check of de ball muur 2 raakt
            bool check2 = ball.checkcollision(wall2.a, wall2.b);
            // Console.WriteLine("collisie met muur 2 is " + check);
            if (check2 == true)
            {
                ball.bounce(wall2.a, wall2.b);
                check2 = false;
            }

            // check of de ball muur 3 raakt
            bool check3 = ball.checkcollision(wall3.a, wall3.b);
            // Console.WriteLine("collisie met muur 1 is " + check);
            if (check3 == true)
            {
                ball.bounce(wall3.a, wall3.b);
                check3 = false;
            }


            // check of de ball muur 4 raakt
            bool check4 = ball.checkcollision(wall4.a, wall4.b);
            // Console.WriteLine("collisie met muur 2 is " + check);
            if (check4 == true)
            {
                ball.bounce(wall4.a, wall4.b);
                check4 = false;
            }

            bool checkTest = ball.checkcollision(test.a, test.b);
            if (checkTest)
            {
                ball.bounce(test.a, test.b);
                checkTest = false;
            }






        }

    }
}
