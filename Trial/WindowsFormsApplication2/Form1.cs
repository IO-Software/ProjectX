using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge;
using AForge.Imaging.Filters;
using AForge.Math;
using AForge.Math.Geometry;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        private List<IntPoint> corners = new List<IntPoint>();
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        //Maak de pen aan
        private Pen blackPen = new Pen(Color.Red, 2);


        public Form1()
        {
            InitializeComponent();
        }



        public Bitmap ApplyGreyScale(Bitmap sourceImage, Bitmap image)
        {
            FiltersSequence seq = new FiltersSequence();

            //Laad de Grayscale algoritmes
            seq.Add(Grayscale.CommonAlgorithms.BT709); 

            //Laad de filter
            seq.Add(new OtsuThreshold()); 


            if (cbGreyScale.Checked == true)
            {
                //Voer de Grayscale filter uit over het plaatje
                sourceImage = seq.Apply(sourceImage); 
            }

            if (cbRemoveBlobs.Checked == true)
            {

                BlobCounter extractor = new BlobCounter();
                extractor.FilterBlobs = true;
                extractor.MinWidth = extractor.MinHeight = 30;
                extractor.MaxWidth = extractor.MaxHeight = 300;
                extractor.ProcessImage(sourceImage);
                extractor.GetObjectsInformation();

                foreach (Blob blob in extractor.GetObjectsInformation())
                {
                    //Randpunten vinden per blob
                    List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                    //Hoekpunten vinden per blob
                    corners = PointsCloud.FindQuadrilateralCorners(edgePoints);

                    using (var graphics = Graphics.FromImage(image))
                    {

                        // Voer alleen uit als er meer dan 3 hoekpunten gevonden zijn.
                        if (corners.Count > 3)
                        {

                            // Teken de vier lijnen van het basisvierkant
                            graphics.DrawLine(blackPen, corners[0].X, corners[0].Y, corners[1].X, corners[1].Y);
                            graphics.DrawLine(blackPen, corners[1].X, corners[1].Y, corners[2].X, corners[2].Y);
                            graphics.DrawLine(blackPen, corners[2].X, corners[2].Y, corners[3].X, corners[3].Y);
                            graphics.DrawLine(blackPen, corners[3].X, corners[3].Y, corners[0].X, corners[0].Y);

                            //Als 3D effects aangevinkt is
                            if (cb3D.Checked == true)
                            {

                                //Reken de afstand tussen de eerste twee hoekpunten uit
                                double Distance = Math.Sqrt((corners[3].X - corners[0].X) * (corners[3].X - corners[0].X) + (corners[3].Y - corners[0].Y) * (corners[3].Y - corners[0].Y));

                                //Convert naar integer
                                int IDistance = Convert.ToInt32(Distance);                             

                                //Teken alle verticale lijnen van de kubus
                                graphics.DrawLine(blackPen, corners[0].X, corners[0].Y, corners[0].X, corners[0].Y - IDistance);
                                graphics.DrawLine(blackPen, corners[1].X, corners[1].Y, corners[1].X, corners[1].Y - IDistance);
                                graphics.DrawLine(blackPen, corners[2].X, corners[2].Y, corners[2].X, corners[2].Y - IDistance);
                                graphics.DrawLine(blackPen, corners[3].X, corners[3].Y, corners[3].X, corners[3].Y - IDistance);

                                //Teken het bovenste vierkant van de kubub
                                graphics.DrawLine(blackPen, corners[0].X, corners[0].Y - IDistance, corners[1].X, corners[1].Y - IDistance);
                                graphics.DrawLine(blackPen, corners[1].X, corners[1].Y - IDistance, corners[2].X, corners[2].Y - IDistance);
                                graphics.DrawLine(blackPen, corners[2].X, corners[2].Y - IDistance, corners[3].X, corners[3].Y - IDistance);
                                graphics.DrawLine(blackPen, corners[3].X, corners[3].Y - IDistance, corners[0].X, corners[0].Y - IDistance);

                            }
                        }
                    }


                }

                sourceImage = image;
            }

            return sourceImage;
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

                pictureBox2.Image = null; //Verwijderd het image uit het geheugen van picturebox
                pictureBox2.Invalidate();
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
            // Zet de webcam images in de picture boxes
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image2 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = image2;

            // Voer de greyscale uit over de image
            pictureBox1.Image = ApplyGreyScale(image, image2);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }



    }



}