﻿using AForge;
using AForge.Imaging.Filters;
using AForge.Video.DirectShow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectZ
{
    public partial class Window : Form
    {
        private Webcam webcam;
        private FilterInfoCollection videoDevices;
        private Filter filter;
        private BlobExtractor blobExtractor;
        private CodeScanner codeScanner;
        private ArrayList visibleObjects;
        private Bitmap streamImage;
        private Bitmap drawArea;
        private Player player1;
        private Player player2;

        private const int PLAYER1 = 1;
        private const int PLAYER2 = 2;
        private const int WALL = 3;


        public Window()
        {
            InitializeComponent();
            InitializeWebcams();
            InitializeSecondaryComponents();
            InitializePlayers();
        }

        private void InitializeSecondaryComponents()
        {
            filter = new Filter();
            blobExtractor = new BlobExtractor();
            codeScanner = new CodeScanner();
            visibleObjects = new ArrayList();
        }

        private void InitializeWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cboxWebcams.Items.Add(Device.Name);
            }
            cboxWebcams.SelectedIndex = 0;
            webcam = new Webcam();
        }

        private void InitializePlayers()
        {
            player1 = new Player(1);
            visibleObjects.Add(player1);
            player2 = new Player(2);
            visibleObjects.Add(player2);
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam.isRunning())
            {
                webcam.stop();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            webcam.setVideoSource(videoDevices[cboxWebcams.SelectedIndex].MonikerString);
            if (webcam.isRunning())
            {
                webcam.stop();
                clearPictureBox(pboxStream);
                videoStreamTimer.Enabled = false;
            }
            else
            {
                webcam.turnOn();
                videoStreamTimer.Enabled = true;
            }
        }

        private void clearPictureBox(PictureBox pbox)
        {
            pbox.Image = null;
            pbox.Invalidate();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void videoStreamTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                drawArea = new Bitmap(webcam.getStreamImage(), webcam.getWidth(), webcam.getHeight());
                streamImage = webcam.getStreamImage();

                pboxStream.Image = drawArea;
                pboxTest.Image = streamImage;
                pboxTest2.Image = filter.applyFilter(streamImage);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                if (streamImage != null)
                {
                    ArrayList cornerPoints = blobExtractor.extractBlob(filter.applyFilter(streamImage));
                    if (cornerPoints.Count > 0)
                    {
                        analyseImage(cornerPoints);
                    }
                }
                stopwatch.Stop();
                lblElapsedTime.Text = "Elapsed Time: " + stopwatch.ElapsedMilliseconds;

                if (visibleObjects.Count > 0)
                {
                    foreach (VisibleObject obj in visibleObjects)
                    {
                        if (obj.canBeDrawn())
                        {
                            drawArea = obj.draw(drawArea);
                        }
                    }
                }
            }
            catch (Exception h)
            {
                Console.WriteLine(h.StackTrace);
            }
        }

        private void analyseImage(ArrayList cornerPoints)
        {
            lblAmountOfBlobs.Text = "Amount of blobs " + cornerPoints.Count;
            foreach (List<IntPoint> corners in cornerPoints)
            {
                QuadrilateralTransformation quadTransformation = new QuadrilateralTransformation(corners, 150, 150);
                Bitmap analysedImage = quadTransformation.Apply(streamImage);
                int cardValue = -1;
                if (analysedImage != null)
                {
                    cardValue = codeScanner.scan(analysedImage);
                    if (cardValue != -1)
                    {
                        recognize(cardValue, corners);
                    }
                }
            }
        }

        private void recognize(int cardValue, List<IntPoint> corners)
        {
            switch (cardValue)
            {
                case PLAYER1:
                    player1.updatePosition(corners);
                    break;
                case PLAYER2:
                    player2.updatePosition(corners);
                    break;

                case WALL:
                    // NOG NIETS
                    break;

                default:
                    Console.WriteLine("Default, no action taken");
                    break;

            }
        }
    }
}
