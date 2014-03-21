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

namespace ProjectY
{
    class Webcam
    {
        private PictureBox pboxStream;
        private Filter Filter;
        private BlobExtractor blobExtractor;
        private String videoSourceString;
        private VideoCaptureDevice videoSource;
        private QuadrilateralTransformation quadTransformation;
        private CodeScanner codeScanner;
        private String recognition;
        private Bitmap testImage;

        public Webcam(PictureBox pboxStream)
        {
            this.pboxStream = pboxStream;
            Initialize();
            Console.WriteLine(Codes.getCode());
        }

        private void Initialize()
        {
            Filter = new Filter();
            blobExtractor = new BlobExtractor();
            videoSource = new VideoCaptureDevice();
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
                Bitmap stream = (Bitmap)eventArgs.Frame.Clone();
                Bitmap streamAnalysis = Filter.applyFilter(stream);
                analyseImage(blobExtractor.extractBlob(streamAnalysis), stream);
                pboxStream.Image = stream;
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
                        quadTransformation = new QuadrilateralTransformation(corners, 200, 200);
                        blobImages.Add(quadTransformation.Apply(stream));
                    }

                    // Toegevoegd om te testen
                    if (blobImages.Count != 0)
                    {
                        testImage = (Bitmap)blobImages[0];
                    }
                    // Voor elke image in de image array van de blobs wordt een scanner overheen gegooid om te kijken of dit een code is die we kunnen gebruiken en om deze dan ook meteen te identificeren.
                    foreach (Bitmap imageAnalysis in blobImages)
                    {
                        recognition = codeScanner.scan(imageAnalysis);
                        if (recognition != null)
                        {
                            // VOEG AL DE INFO BIJ ELKAAR
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FOUT: " + e.StackTrace);
            }
        }

        public void test(PictureBox test)
        {
            test.Image = testImage;
        }
    }
}
