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

        //TEST
        private PictureBox testBox;
        private Pen pen = new Pen(Color.Red, 2);

        public Webcam(PictureBox pboxStream)
        {
            this.pboxStream = pboxStream;
            Initialize();
        }

        private void Initialize()
        {
            filter = new Filter();
            blobExtractor = new BlobExtractor();
            videoSource = new VideoCaptureDevice();
            codeScanner = new CodeScanner();
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
                pboxStream.Image = stream;
                stopWatch.Stop();
                Console.WriteLine("Elapsed Milliseconds: " + stopWatch.ElapsedMilliseconds);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("FOUT OPGETREDEN: " + e.StackTrace);
            }
        }

        private void analyseImage(ArrayList cornerPoints, Bitmap stream)
        {
            try
            {
                ArrayList blobImages = new ArrayList();
                // Zorgt er voor dat het gedeelte van het plaatje dat wordt aangegeven in de blob uit de image wordt gesneden en kan worden geanalyseerd. Daarna wordt deze in een array gestopt van plaatjes
                if (cornerPoints.Count > 0)
                {
                    foreach (List<IntPoint> corners in cornerPoints)
                    {
                        quadTransformation = new QuadrilateralTransformation(corners, 150, 150);
                        blobImages.Add(quadTransformation.Apply(stream));
                    }

                    // TEST --------------------------------------------------
                    if (blobImages.Count > 0 && blobImages[0] != null)
                    {
                        testBox.Image = (Bitmap)blobImages[0];
                    }
                    else
                    {
                        testBox.Image = null;
                        testBox.Invalidate();
                    }
                    // --------------------------------------------------------

                    // Voor elke image in de image array van de blobs wordt een scanner overheen gegooid om te kijken of dit een code is die we kunnen gebruiken en om deze dan ook meteen te identificeren.
                    if (blobImages.Count > 0)
                    {
                        foreach (Bitmap imageAnalysis in blobImages)
                        {
                            string recognition = null;
                            if (imageAnalysis != null)
                            {
                                recognition = codeScanner.scan(imageAnalysis);
                                if (recognition != null)
                                {
                                    if (recognition.Equals("player1"))
                                    {
                                        Console.WriteLine("YAAAAAAAAAAAAAAAAAAY");
                                    }
                                }
                            }
                        }
                    }
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
    }
}
