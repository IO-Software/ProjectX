using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge;
using AForge.Imaging.Filters;

namespace ProjectX
{
    public partial class Window : Form
    {
        private float maxScreenWidth;
        private float maxScreenHeight;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private int i = 0;
        private FiltersSequence otsu;
        private Webcam webcamOriginal;
        private Webcam webcamTrial;
        
        public Window()
        {
            maxScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            maxScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            
            InitializeComponent(maxScreenWidth, maxScreenHeight);
            // Initializes the filter for card recognition
            initializeFilters();
            loadWebcams();
        }

        private void initializeFilters () {
            otsu = new FiltersSequence();
            // Add a grayscale filter to get out all the colors
            otsu.Add(Grayscale.CommonAlgorithms.BT709);
            // Converts the image into a binary black and white image with the otsu algorithm
            otsu.Add(new OtsuThreshold());
        }

        private void loadWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cBoxCam.Items.Add(Device.Name);
            }
            cBoxCam.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
            // Wil eigenlijk apart webcam class invoegen. Zal er later naar kijken. Kan je nu negeren
            //webcamOriginal = new Webcam();
            //webcamTrial = new Webcam();
            
        }

        private void btnOnOff_Click(object sender, EventArgs e) 
        {
            if (videoSource.IsRunning) //Als camera aanstaan
            {
                videoSource.Stop(); //Stop streamen
                pBoxUp.Image = null; //Verwijderd het image uit het geheugen van picturebox
                pBoxUp.Invalidate(); //Refreshed de picturebox
                pBoxDown.Image = null;
                pBoxDown.Invalidate();
            }
            else //Als de camera nog niet aan staat
            {
                videoSource = new VideoCaptureDevice(videoDevices[cBoxCam.SelectedIndex].MonikerString);
                // De Videokaart
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }
        }

        private void btnQuit_Click (object sender, EventArgs e)
        {
            Application.Exit();
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap original = (Bitmap)eventArgs.Frame.Clone();
            Bitmap trial = (Bitmap)eventArgs.Frame.Clone();
            pBoxUp.Image = original; 
            trial = otsuConverter(trial);
            blobRecognition(trial);
            pBoxDown.Image = trial;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private Bitmap otsuConverter(Bitmap camImage)
        {
            camImage = otsu.Apply(camImage);
            return camImage;
        }

        private Bitmap blobRecognition(Bitmap camImage)
        {
            return null;
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
