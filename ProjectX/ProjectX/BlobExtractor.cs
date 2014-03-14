using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AForge.Imaging;
using AForge;
using AForge.Math;
using AForge.Math.Geometry;
using System.Collections;


namespace ProjectX
{
    public class BlobExtractor
    {
        private BlobCounter extractor;
        private Boolean draw2D;
        private Boolean draw3D;
        private Pen pen = new Pen(Color.Red, 2);

        public BlobExtractor(int blobMin, int blobMax)
        {
            extractor = new BlobCounter();
            extractor.FilterBlobs = true;
            extractor.MinWidth = extractor.MinHeight = blobMin;
            extractor.MaxWidth = extractor.MaxHeight = blobMax; 
        }

        public void setMinimum(int minimum)
        {
            extractor.MinWidth = extractor.MinHeight = minimum;
        }

        public void setMaximum(int maximum)
        {
            extractor.MaxWidth = extractor.MaxHeight = maximum;
        }

        public void setDraw2D(Boolean status)
        {
            draw2D = status;
        }

        public void setDraw3D(Boolean status)
        {
            draw3D = status;
        }

        public Bitmap extractBlobs(Bitmap originalImage, Bitmap alteredImage)
        {
            extractor.ProcessImage(alteredImage);
            foreach (Blob blob in extractor.GetObjectsInformation())
            {
                List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);

                if (draw2D)
                {
                    using (var graphics = Graphics.FromImage(originalImage))
                    {
                        if (corners.Count == 4)
                        {
                            graphics.DrawLine(pen, corners[0].X, corners[0].Y, corners[1].X, corners[1].Y);
                            graphics.DrawLine(pen, corners[1].X, corners[1].Y, corners[2].X, corners[2].Y);
                            graphics.DrawLine(pen, corners[2].X, corners[2].Y, corners[3].X, corners[3].Y);
                            graphics.DrawLine(pen, corners[3].X, corners[3].Y, corners[0].X, corners[0].Y);
                            if (draw3D)
                            {
                                //Reken de afstand tussen de eerste twee hoekpunten uit
                                double Distance = Math.Sqrt((corners[3].X - corners[0].X) * (corners[3].X - corners[0].X) + (corners[3].Y - corners[0].Y) * (corners[3].Y - corners[0].Y));

                                //Convert naar integer
                                int IDistance = Convert.ToInt32(Distance);

                                //Teken alle verticale lijnen van de kubus
                                graphics.DrawLine(pen, corners[0].X, corners[0].Y, corners[0].X, corners[0].Y - IDistance);
                                graphics.DrawLine(pen, corners[1].X, corners[1].Y, corners[1].X, corners[1].Y - IDistance);
                                graphics.DrawLine(pen, corners[2].X, corners[2].Y, corners[2].X, corners[2].Y - IDistance);
                                graphics.DrawLine(pen, corners[3].X, corners[3].Y, corners[3].X, corners[3].Y - IDistance);

                                //Teken het bovenste vierkant van de kubub
                                graphics.DrawLine(pen, corners[0].X, corners[0].Y - IDistance, corners[1].X, corners[1].Y - IDistance);
                                graphics.DrawLine(pen, corners[1].X, corners[1].Y - IDistance, corners[2].X, corners[2].Y - IDistance);
                                graphics.DrawLine(pen, corners[2].X, corners[2].Y - IDistance, corners[3].X, corners[3].Y - IDistance);
                                graphics.DrawLine(pen, corners[3].X, corners[3].Y - IDistance, corners[0].X, corners[0].Y - IDistance);
                            }
                        }
                    }
                }
            }
            return originalImage;
        }
    }
}
