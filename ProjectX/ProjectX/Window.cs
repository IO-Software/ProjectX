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
        //public Webcam webcam;
        //public Filters camFilters;
        
        public Window()
        {
            maxScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            maxScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            
            InitializeComponent(maxScreenWidth, maxScreenHeight);
            // Initializes the filter for card recognition
            initializeFilters();
            // Initializes the webcam for card recognition
            initializeWebcams();
        }

        private void initializeFilters () {
            //camFilters = new Filters();
        }

        private void initializeWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cBoxCam.Items.Add(Device.Name);
            }
            cBoxCam.SelectedIndex = 0;
            //webcam = new Webcam();
        }

        private void btnOnOff_Click(object sender, EventArgs e) 
        {
            //webcam.setVideoSource(videoDevices[cBoxCam.SelectedIndex].MonikerString);
            if (true)
            {
                //webcam.stop();
                // Erase the last image from the memory of the picturebox
                pBoxUp.Image = null;
                pBoxDown.Image = null;
                // Refresh the picturebox
                pBoxUp.Invalidate();
                pBoxDown.Invalidate();
            }
            else 
            {
                //webcam.turnOn(pBoxUp, pBoxDown);
            }
        }

        private void btnQuit_Click (object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (webcam.isRunning())
            {
                //webcam.stop();
            }
        }

        public PictureBox getPictureBox (int i)
        {
            if (i == 0)
            {
                return pBoxUp;
            }
            else {
                return pBoxDown;
            }
        }
    }
}
