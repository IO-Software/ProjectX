using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using AForge.Imaging;
using AForge;
using AForge.Math.Geometry;

namespace ProjectZ
{
    class BlobExtractor
    {
        private BlobCounter extractor;
        private const int blobMin = 10;
        private const int blobMax = 150;

        public BlobExtractor()
        {
            InitializeExtractor();
        }

        private void InitializeExtractor()
        {
            extractor = new BlobCounter();
            extractor.FilterBlobs = true;
            extractor.MinWidth = extractor.MinHeight = blobMin;
            extractor.MaxWidth = extractor.MaxHeight = blobMax;
        }

        public ArrayList extractBlob(Bitmap image)
        {
            ArrayList cornerPoints = new ArrayList();
            extractor.ProcessImage(image);
            foreach (Blob blob in extractor.GetObjectsInformation())
            {
                List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);
                Boolean boundaryCheck = true;
                if (corners.Count == 4)
                {
                    for (int i = 0; i < corners.Count; i++)
                    {
                        if (!withinBoundary(corners[i].X, corners[i].Y))
                        {
                            boundaryCheck = false;
                        }
                    }
                    if (boundaryCheck)
                    {
                        cornerPoints.Add(corners);
                    }
                }
            }
            return cornerPoints;
        }

        private Boolean withinBoundary(int x, int y)
        {
            if (y < -2.625 * x + 240 || y < 2.625 * x - 1440)
            {
                return false;
            }
            return true;
        }
    }
}
