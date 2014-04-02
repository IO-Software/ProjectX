using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

using AForge;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge.Imaging.Filters;
using System.Diagnostics;

namespace ProjectY
{
    class Webcam
    {
        private PictureBox pboxStream;
        private Filter filter;
        private BlobExtractor blobExtractor;
        private String videoSourceString;
        private VideoCaptureDevice videoSource;
        private QuadrilateralTransformation quadTransformation;
        private CodeScanner codeScanner;
        private Player player1;
        private Player player2;
        private ArrayList visibleObjects;

        private const int PLAYER1 = 1;
        private const int PLAYER2 = 2;
        private const int WALL = 3;

        //TEST
        private PictureBox testBox;

        public Webcam(PictureBox pboxStream)
        {
            this.pboxStream = pboxStream;
            Initialize();
            InitializeObjects();
        }

        private void Initialize()
        {
            filter = new Filter();
            blobExtractor = new BlobExtractor();
            videoSource = new VideoCaptureDevice();
            codeScanner = new CodeScanner();
            visibleObjects = new ArrayList();
        }

        private void InitializeObjects()
        {
            player1 = new Player(1);
            player2 = new Player(2);
            visibleObjects.Add(player1);
            visibleObjects.Add(player2);
        }

        public void setVideoSource(String source)
        {
            videoSourceString = source;
        }

        public Boolean isRunning()
        {
            return videoSource.IsRunning;
        }

        public void stop()
        {
            videoSource.Stop();
        }

        public void clearPictureBoxes()
        {
            pboxStream.Image = null;
            pboxStream.Invalidate();
        }

        public void turnOn()
        {
            videoSource = new VideoCaptureDevice(videoSourceString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                Bitmap stream = (Bitmap)eventArgs.Frame.Clone();
                Bitmap streamAnalysis = filter.applyFilter(stream);
                analyseImage(blobExtractor.extractBlob(streamAnalysis), stream);

                Bitmap drawnStream = draw(stream);
                pboxStream.Image = drawnStream;

                stopWatch.Stop();
                Console.WriteLine("Elapsed Milliseconds: " + stopWatch.ElapsedMilliseconds);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("FOUT OPGETREDEN: " + e.StackTrace);
            }
        }

        private Bitmap draw(Bitmap image)
        {
            Bitmap drawnImage = image;
            foreach (VisibleObject obj in visibleObjects)
            {
                drawnImage = obj.draw(drawnImage);
            }
            return drawnImage;
        }

        private void analyseImage(ArrayList cornerPoints, Bitmap stream)
        {
            try
            {
                ArrayList blobImages = new ArrayList();
                if (cornerPoints.Count > 0)
                {
                    foreach (List<IntPoint> corners in cornerPoints)
                    {
                        //Console.WriteLine(corners.Count);
                        //foreach (IntPoint point in corners)
                        //{
                        //    Console.WriteLine(point);
                        //}

                        quadTransformation = new QuadrilateralTransformation(corners, 150, 150);
                        Bitmap imageAnalysis = quadTransformation.Apply(stream);
                        int cardValue = -1;
                        if (imageAnalysis != null)
                        {
                            cardValue = codeScanner.scan(imageAnalysis);
                            if (cardValue != -1)
                            {
                                recognize(cardValue, corners);
                            }
                        }
                    }
                    Console.WriteLine("Blobcount: " + cornerPoints.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FOUT: " + e.StackTrace);
            }
        }

        public void testing(PictureBox testBox)
        {
            this.testBox = testBox;
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
