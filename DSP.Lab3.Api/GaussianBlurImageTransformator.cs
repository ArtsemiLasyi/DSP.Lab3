using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace DSP.Lab3.Api
{
    public class GaussianBlurImageTransformator : ImageTransformator
    {
        public unsafe override Bitmap Transform(Bitmap bitmap, int windowSize)
        {
            Bitmap newBitmap = new Bitmap(bitmap);
            BitmapData bitmapData = newBitmap.LockBits(
                new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                ImageLockMode.ReadWrite,
                newBitmap.PixelFormat
            );

            int pixelSize = Image.GetPixelFormatSize(newBitmap.PixelFormat) / 8; 
            int width = newBitmap.Width * pixelSize;
            int height = newBitmap.Height;

            double acR, acG, acB;
            int radius = 300;
            int size = 2 * radius + 6;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j = j + pixelSize)
                {
                    byte* cursorPosition = (byte*)bitmapData.Scan0 + i * bitmapData.Stride;

                    int R = cursorPosition[j + 1];
                    int G = cursorPosition[j + 2];
                    int B = cursorPosition[j + 3];

                    acR = R * (Math.Pow((double)Math.E, -(Math.Pow((double)j - size / 2, 2) + Math.Pow((double)i - size / 2, 2)) / (2 * Math.Pow((double)radius, 2))));
                    acG = G * (Math.Pow((double)Math.E, -(Math.Pow((double)j - size / 2, 2) + Math.Pow((double)i - size / 2, 2)) / (2 * Math.Pow((double)radius, 2))));
                    acB = B * (Math.Pow((double)Math.E, -(Math.Pow((double)j - size / 2, 2) + Math.Pow((double)i - size / 2, 2)) / (2 * Math.Pow((double)radius, 2))));

                    cursorPosition[j + 1] = (byte)acR;
                    cursorPosition[j + 2] = (byte)acG;
                    cursorPosition[j + 3] = (byte)acB;
                }
            }
            newBitmap.UnlockBits(bitmapData);
            return newBitmap;
        }
    }
}
