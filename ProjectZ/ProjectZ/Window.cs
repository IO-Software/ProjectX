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
        private Bitmap streamImage;
        private Bitmap drawArea;

        private PlayingField playingField;
        private Player player1;
        private Player player2;
        private Wall player1Wall;
        private Wall player2Wall;
        private Cannon player1Cannon;
        private Cannon player2Cannon;
        private Ball ball;

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
            InitializeCardRecognitionComponents();
            InitializeFieldComponents();
        }

        private void InitializeCardRecognitionComponents()
        {
            filter = new Filter();
            blobExtractor = new BlobExtractor();
            codeScanner = new CodeScanner();
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

        private void InitializeFieldComponents()
        {
            player1 = new Player(1);
            player2 = new Player(2);
            // Wall en Cannon worden (nog) niet gebruikt
            player1Wall = new Wall();
            player2Wall = new Wall();
            player1Cannon = new Cannon();
            player2Cannon = new Cannon();
            ball = new Ball(new IntPoint(100, 100), 45);

            playingField = new PlayingField();
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
                visibleObjects = new ArrayList();
                EdgeKeeper.emptyEdges();

                // Add ball to visibleobjectlist
                visibleObjects.Add(ball);
                visibleObjects.Add(playingField);

                // Add edges of playingfield to keeper
                playingField.addEdgesToKeeper();
                
                int widthCheck = webcam.getWidth();
                int heightCheck = webcam.getHeight();
                if (widthCheck != 0 && heightCheck != 0)
                {
                    drawArea = new Bitmap(webcam.getStreamImage(), widthCheck, heightCheck);
                    streamImage = webcam.getStreamImage();

                    //pboxStream.Image = drawArea;
                    //pboxTest.Image = streamImage;
                    //pboxTest2.Image = filter.applyFilter(streamImage);

                    //Stopwatch stopwatch = new Stopwatch();
                    //stopwatch.Start();

                    //if (streamImage != null)
                    //{
                    //    ArrayList cornerPoints = blobExtractor.extractBlob(filter.applyFilter(streamImage));
                    //    if (cornerPoints.Count > 0)
                    //    {
                    //        analyseImage(cornerPoints);
                    //    }
                    //}
                    //stopwatch.Stop();
                    //lblElapsedTime.Text = "Elapsed Time: " + stopwatch.ElapsedMilliseconds;

                    //// BALLETJE BEWEGEN
                    //ball.move();
                    //// TEKENEN
                    //if (visibleObjects.Count > 0)
                    //{
                    //    foreach (VisibleObject visObj in visibleObjects)
                    //    {
                    //        drawArea = visObj.draw(drawArea);
                    //    }
                    //}
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
            lblAmountVisObj.Text = "Amount of visibleobject = " + visibleObjects.Count;
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
                    visibleObjects.Add(player1);
                    player1.addEdgesToKeeper();
                    break;
                case PLAYER2:
                    player2.updatePosition(corners);
                    visibleObjects.Add(player2);
                    player2.addEdgesToKeeper();
                    break;

                case WALLPLAYER1:
                    player1Wall.updatePosition(corners);
                    visibleObjects.Add(player1Wall);
                    player1Wall.addEdgesToKeeper();
                    break;

                case WALLPLAYER2:
                    player2Wall.updatePosition(corners);
                    visibleObjects.Add(player2Wall);
                    player2Wall.addEdgesToKeeper();
                    break;

                case CANNONPLAYER1:
                    player1Cannon.updatePosition(corners);
                    visibleObjects.Add(player1Cannon);
                    player1Cannon.addEdgesToKeeper();
                    break;

                case CANNONPLAYER2:
                    player2Cannon.updatePosition(corners);
                    visibleObjects.Add(player2Cannon);
                    player2Cannon.addEdgesToKeeper();
                    break;

                default:
                    Console.WriteLine("Default option, no action taken");
                    break;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Punt2D (243,252) naar 3D: " + PointConverter.get3DPoint(new IntPoint(243, 252)));
            //Console.WriteLine("Punt3D (191, 91) naar 2D: " + PointConverter.get2DPoint(new IntPoint(191, 91)));
            //Console.WriteLine("Punt2D (243, 252) converTo3DMethod: " + PointConverter.convertTo3D(new IntPoint(243, 252)));
            //Console.WriteLine("Punt3D (158, 91) naar 2D: " + PointConverter.convertTo2D(new IntPoint(158, 91)));
            //Console.WriteLine("");
            //Console.WriteLine("Punt2D (358, 352) naar 3D: " + PointConverter.get3DPoint(new IntPoint(358, 352)));
            //Console.WriteLine("Punt3D (225, 136) naar 2D: " + PointConverter.get2DPoint(new IntPoint(225, 136)));
            //Console.WriteLine("");
            //Console.WriteLine("Punt2D (813, 705) naar 3D: " + PointConverter.get3DPoint(new IntPoint(813, 705)));
            //Console.WriteLine("Punt3D (596, 365) naar 2D: " + PointConverter.get2DPoint(new IntPoint(596, 365)));
            pboxStream.Image = webcam.getStreamImage();
            pboxTest.Image = filter.applyFilter(webcam.getStreamImage());
            pboxTest2.Image = filter.applyGrayFilter(webcam.getStreamImage());
        }
    }
}
