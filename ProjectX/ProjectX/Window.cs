﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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
        private Webcam webcam;

        /// <summary>
        /// The class window provides the interface of the program. This class also initializes the webcam for the pictureboxes. 
        /// </summary>
        public Window()
        {
            // The maximal screensizes
            maxScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            maxScreenWidth = Screen.PrimaryScreen.Bounds.Width;

            InitializeComponent(maxScreenWidth, maxScreenHeight);
            // Initializes the webcam for card recognition
            initializeWebcams();
        }

        /// <summary>
        /// This method looks through all the available webcam options and adds them to the combobox. It also creates a new webcam and provides the 
        /// webcam with pictureboxes where it can show the image
        /// </summary>
        private void initializeWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cBoxCam.Items.Add(Device.Name);
            }
            cBoxCam.SelectedIndex = 0;
            webcam = new Webcam(pBoxUp, pBoxDown);
        }

        /// <summary>
        /// When the button on/off has been pushed it checks if the webcam is on or off. If the webcam is on it will stop the current feed of the webcam
        /// and clears both pictureboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnOff_Click(object sender, EventArgs e)
        {
            webcam.setVideoSource(videoDevices[cBoxCam.SelectedIndex].MonikerString);
            if (webcam.isRunning())
            {
                webcam.stop();
                webcam.clearPictureBoxes();
            }
            else
            {
                webcam.turnOn();
            }
        }

        /// <summary>
        /// When the button Quit has been pushed it checks if the webcam is running. If so, it will close the webcamfeed and shuts it down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// When the form is closed this method checks if the webcam is running. If so, it will close the webcamfeed and shuts it down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam.isRunning())
            {
                webcam.stop();
            }
        }
    }
}
