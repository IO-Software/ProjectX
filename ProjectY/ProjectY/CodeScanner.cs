using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectY
{
    // BRON: http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

    class CodeScanner
    {
        public CodeScanner()
        {

        }

        public String scan(Bitmap image)
        {
            ArrayList croppedImages = convertToCroppedImages(image);
            lockBits(croppedImages);
            convertToQRCode();
            getCode();
            unlockBits();
            // AANPASSEN
            return null;
        }

        private ArrayList convertToCroppedImages(Bitmap source)
        {
            ArrayList croppedImages = new ArrayList();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    // Deelt de bitmap in negen (3x3)
                    Crop crop = new Crop(new Rectangle((source.Width/3)*i, (source.Height/3)*j, source.Width/3, source.Height/3));
                    croppedImages.Add(crop.Apply(source));
                }
            }
            return croppedImages;
        }

        private void lockBits(ArrayList croppedImages)
        {
            foreach (Bitmap crop in croppedImages)
            {
                // Lock the bitmap bits
                Rectangle rect = new Rectangle(0, 0, crop.Width, crop.Height);
                System.Drawing.Imaging.BitmapData cropData = crop.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, crop.PixelFormat);

                // Get the address of the first line
                IntPtr ptr = cropData.Scan0;

                // Declare an array to hold the bytes of the bitmap
                int bytes = Math.Abs(cropData.Stride) * crop.Height;
                byte[] rgbValues = new byte[bytes];

                // Copy the RGB values into the array
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                determineColor(rgbValues, bytes);
            }
            
        }

        private int determineColor(byte[] rgbValues, int rgbValueCount)
        {
            for (int i = 0; i < rgbValueCount; i++)
            {
                // Per pixel zijn er 3 int waardes die interesssant zijn. Deze int waardes kunnen worden gecheckt door i + (2*i) + 0, 1 of 2. De RGB waardes moeten nog worden getest.
            }
                // AANPASSEN
                return 0;
        }

        private void convertToQRCode()
        {

        }

        private String getCode()
        {

            return null;
        }

        private void unlockBits()
        {

        }
    }
}
