using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge;
using AForge.Imaging.Filters;




namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;



        int rood = 254;
        int groen = 254;
        int blauw = 254;

        int roodmin = 0;
        int groenmin = 0;
        int blauwmin = 0;


        public Form1()
        {
            InitializeComponent();
            SetTrackBarProperties();
        }

        private void SetTrackBarProperties()
        {



            trackBar1.Maximum = 255;
            trackBar2.Maximum = 254;
            trackBar3.Maximum = 255;
            trackBar4.Maximum = 254;
            trackBar5.Maximum = 255;
            trackBar6.Maximum = 254;

            trackBar1.Minimum = 1;
            trackBar2.Minimum = 0;
            trackBar3.Minimum = 1;
            trackBar4.Minimum = 0;
            trackBar5.Minimum = 1;
            trackBar6.Minimum = 0;

            trackBar1.Value = 254;
            trackBar3.Value = 254;
            trackBar5.Value = 254;

            trackBar1.TickFrequency = 2;
            trackBar2.TickFrequency = 2;
            trackBar3.TickFrequency = 2;
            trackBar4.TickFrequency = 2;
            trackBar5.TickFrequency = 2;
            trackBar6.TickFrequency = 2;

            lRood.Text = "Rood. Van " + roodmin.ToString() + " tot " + rood.ToString();
            lGroen.Text = "Groen. Van " + groenmin.ToString() + " tot " + groen.ToString();
            lBlauw.Text = "Blauw. Van " + blauwmin.ToString() + " tot " + blauw.ToString();


        }

        private Bitmap ApplyRGBFilter(Bitmap sourceImage)
        {
            ColorFiltering filter = new ColorFiltering();
            filter.Red = new IntRange(roodmin, rood);
            filter.Green = new IntRange(groenmin, groen);
            filter.Blue = new IntRange(blauwmin, blauw);
            Bitmap processedImage = filter.Apply(sourceImage);
            return processedImage;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo Device in videoDevices)
            {
                comboBox1.Items.Add(Device.Name);
            }

            comboBox1.SelectedIndex = 0;

            videoSource = new VideoCaptureDevice();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning) //Als camera aanstaan
            {
                videoSource.Stop(); //Stop streamen
                pictureBox1.Image = null; //Verwijderd het image uit het geheugen van picturebox
                pictureBox1.Invalidate(); //Refreshed de picturebox
            }
            else //Als de camera nog niet aan staat
            {

                videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                // De Videokaart
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();


            }

        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image2 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = image2;
            pictureBox1.Image = ApplyRGBFilter(image);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lGroen_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (rood > roodmin)
            {
                rood = trackBar1.Value;
            }
            else
            {
                rood = trackBar1.Value;
                roodmin = rood - 1;
                trackBar2.Value = roodmin;
            }
            lRood.Text = "Rood. Van " + roodmin.ToString() + " tot " + rood.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (roodmin < rood)
            {
                roodmin = trackBar2.Value;
            }
            else
            {
                roodmin = trackBar2.Value;
                rood = roodmin + 1;
                trackBar1.Value = rood;
            }
            lRood.Text = "Rood. Van " + roodmin.ToString() + " tot " + rood.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (groen > groenmin)
            {
                groen = trackBar3.Value;
            }
            else
            {
                groen = trackBar3.Value;
                groenmin = groen - 1;
                trackBar4.Value = groenmin;
            }
            lGroen.Text = "Groen. Van " + groenmin.ToString() + " tot " + groen.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (groenmin < groen)
            {
                groenmin = trackBar4.Value;
            }
            else
            {
                groenmin = trackBar4.Value;
                groen = groenmin + 1;
                trackBar3.Value = groen;
            }
            lGroen.Text = "Groen. Van " + groenmin.ToString() + " tot " + groen.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            if (blauw > blauwmin)
            {
                blauw = trackBar5.Value;
            }
            else
            {
                blauw = trackBar5.Value;
                blauwmin = blauw - 1;
                trackBar6.Value = blauwmin;
            }
            lBlauw.Text = "Blauw. Van " + blauwmin.ToString() + " tot " + blauw.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            if (blauwmin < blauw)
            {
                blauwmin = trackBar6.Value;
            }
            else
            {
                blauwmin = trackBar6.Value;
                blauw = blauwmin + 1;
                trackBar5.Value = blauw;
            }
            lBlauw.Text = "Blauw. Van " + blauwmin.ToString() + " tot " + blauw.ToString();
        }

    }



}