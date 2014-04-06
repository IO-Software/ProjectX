using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    class ChangeOpacity
    {
        public ChangeOpacity()
        {

        }

        // http://www.codeproject.com/Tips/201129/Change-Opacity-of-Image-in-C
        public static Bitmap change(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }

        private void Filter(Bitmap bm)
        {
            Rectangle bounds = new Rectangle(0, 0, bm.Width, bm.Height);
            int numPixels = bm.Width * bm.Height;
            byte[] pixels = new byte[numPixels * 4]; // 4 bytes per pixel
            // Lock the bitmap in memory.
            BitmapData bmd = bm.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            // Copy bytes directly from the bitmap.
            // Scan0 is the address of the first byte of pixel data in the bitmap.
            Marshal.Copy(bmd.Scan0, pixels, 0, pixels.Length);
            // Run through each pixel and do something.
            for (int i = 0; i < pixels.Length; i += 4)
            {
                // Note the order - BGRA - because of the endianness used to store the int32.
                byte b = pixels[i];
                byte g = pixels[i + 1];
                byte r = pixels[i + 2];
                // byte a = pixels[i + 3];
                pixels[i + 3] = 128;
                pixels[i + 2] = g;
                pixels[i + 1] = b;
                pixels[i] = r;
            }
            // Copy the altered pixels back in.
            Marshal.Copy(pixels, 0, bmd.Scan0, pixels.Length);
            // Free the bitmap.
            bm.UnlockBits(bmd);
            return;
        }
      }
}
