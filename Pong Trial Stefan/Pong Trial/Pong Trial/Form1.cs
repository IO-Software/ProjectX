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
using AForge.Imaging;



namespace Pong_Trial
{
    public partial class Form1 : Form
    {
       TekenVierkant Grafisch = new TekenVierkant();
       Converteer Conversie = new Converteer();
      
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var graphics = Graphics.FromImage(pictureBox1.Image))
            {
                Pen pennetje = new Pen(Color.Red, 2);
                graphics.DrawLine(pennetje, 0, 480, 320, -600);
                graphics.DrawLine(pennetje, 640, 480, 320, -600);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            MouseEventArgs me = (MouseEventArgs)e;
            System.Drawing.Point Muis = me.Location;
            AForge.IntPoint punten3D = new AForge.IntPoint(0,0);
            AForge.IntPoint punten2D = new AForge.IntPoint(0, 0);
            punten3D.X = Muis.X;
            punten3D.Y = Muis.Y;            
            Bitmap plaatje2D = (Bitmap)pictureBox2.Image;
            Bitmap plaatje3D = (Bitmap)pictureBox1.Image;

            punten2D = Conversie.naar2D(punten3D);

            plaatje2D = Grafisch.stip(punten2D, plaatje2D);
            plaatje3D = Grafisch.stip(punten3D, plaatje3D);

            pictureBox1.Image = plaatje3D;
            pictureBox2.Image = plaatje2D;

            label1.Text = "3D coordinaten: " + punten3D;
            label2.Text = "2D coordinaten: " + punten2D;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
