using AForge;
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
        private ArrayList visibleObjectsCheck;
        private Bitmap streamImage;
        private Bitmap drawArea;

        private Player player1;
        private Player player2;
        private Wall player1Wall;
        private Wall player2Wall;
        private Cannon player1Cannon;
        private Cannon player2Cannon;

        private const int PLAYER1 = 1;
        private const int PLAYER2 = 2;
        private const int WALLPLAYER1 = 3;
        private const int WALLPLAYER2 = 4;
        private const int CANNONPLAYER1 = 5;
        private const int CANNONPLAYER2 = 6;


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
            player2 = new Player(2);
            player1Wall = new Wall();
            player2Wall = new Wall();
            player1Cannon = new Cannon();
            player2Cannon = new Cannon();
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
                        drawArea = obj.draw(drawArea);
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
            visibleObjectsCheck = new ArrayList();
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
            updateVisibleObjects();
            lblAmountVisObj.Text = "Amount of visibleobject = " + visibleObjects.Count;
            lblAmountVisObjCheck.Text = "Amount of visibleobjectscheck = " + visibleObjectsCheck.Count;
        }

        private void updateVisibleObjects()
        {
            for (int i = 0; i < visibleObjects.Count; i++)
            {
                if (!contains(visibleObjects[i], visibleObjectsCheck))
                {
                    visibleObjects.Remove(visibleObjects[i]);
                }
            }
            for (int j = 0; j < visibleObjectsCheck.Count; j++)
            {
                if (!contains(visibleObjectsCheck[j], visibleObjects))
                {
                    visibleObjects.Add(visibleObjectsCheck[j]);
                }
            }
            
        }

        private Boolean contains(Object obj, ArrayList objectList)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                if (objectList[i].Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }

        private void recognize(int cardValue, List<IntPoint> corners)
        {
            switch (cardValue)
            {
                case PLAYER1:
                    player1.updatePosition(corners);
                    visibleObjectsCheck.Add(player1);
                    break;
                case PLAYER2:
                    player2.updatePosition(corners);
                    visibleObjectsCheck.Add(player2);
                    break;

                case WALLPLAYER1:
                    player1Wall.updatePosition(corners);
                    visibleObjectsCheck.Add(player1Wall);
                    break;

                case WALLPLAYER2:
                    player2Wall.updatePosition(corners);
                    visibleObjectsCheck.Add(player2Wall);
                    break;

                case CANNONPLAYER1:
                    player1Cannon.updatePosition(corners);
                    visibleObjectsCheck.Add(player1Cannon);
                    break;

                case CANNONPLAYER2:
                    player2Cannon.updatePosition(corners);
                    visibleObjectsCheck.Add(player2Cannon);
                    break;

                default:
                    Console.WriteLine("Default option, no action taken");
                    break;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ArrayList testing = new ArrayList();
            testing.Add(player1);
            testing.Add(player2);
            testing.Add(player1Wall);
            testing.Add(player2Wall);

            for (int i = 0; i < testing.Count; i++)
            {
                if (testing[i].Equals(player2))
                {
                    Console.WriteLine("Player 2 gevonden in lijst");
                }
                else
                {
                    Console.WriteLine("Geen player 2 gevonden in lijst");
                }
            }
        }
    }
}
