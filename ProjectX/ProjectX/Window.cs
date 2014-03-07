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
        private FiltersSequence otsu;
        private Webcam webcam;
        
        public Window()
        {
            maxScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            maxScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            
            InitializeComponent(maxScreenWidth, maxScreenHeight);
            // Initializes the filter for card recognition
            initializeFilters();
            initializeWebcams();
        }

        private void initializeFilters () {
            otsu = new FiltersSequence();
            // Add a grayscale filter to get out all the colors
            otsu.Add(Grayscale.CommonAlgorithms.BT709);
            // Converts the image into a binary black and white image with the otsu algorithm
            otsu.Add(new OtsuThreshold());
        }

        private void initializeWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cBoxCam.Items.Add(Device.Name);
            }
            cBoxCam.SelectedIndex = 0;
            webcam = new Webcam();
        }

        private void btnOnOff_Click(object sender, EventArgs e) 
        {
            webcam.setVideoSource(videoDevices[cBoxCam.SelectedIndex].MonikerString);
            if (webcam.isRunning())
            {
                webcam.stop();
                // Erase the last image from the memory of the picturebox
                pBoxUp.Image = null;
                pBoxDown.Image = null;
                // Refresh the picturebox
                pBoxUp.Invalidate();
                pBoxDown.Invalidate();
            }
            else 
            {
                webcam.turnOn();
            }
        }

        private void btnQuit_Click (object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam.isRunning())
            {
                webcam.stop();
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
    }
}
