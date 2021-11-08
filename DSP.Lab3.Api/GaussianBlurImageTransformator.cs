using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace DSP.Lab3.Api
{
    public class GaussianBlurImageTransformator : ImageTransformator
    {
        public unsafe override Bitmap Transform(Bitmap bitmap)
        {
            Bitmap newBitmap = new Bitmap(bitmap);
            BitmapData bitmapData = newBitmap.LockBits(
                new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                ImageLockMode.ReadWrite,
                newBitmap.PixelFormat
            );

            int s = Image.GetPixelFormatSize(newBitmap.PixelFormat) / 8; // число бит на пиксель
            int width = newBitmap.Width * s;
            int height = newBitmap.Height;
            byte[,,] res = new byte[3, height, width];

            double acR, acG, acB;
            int radius = 30;
            int size = 2 * radius + 6;

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w = w + s)
                {
                    byte* cursorPosition = (byte*)bitmapData.Scan0 + h * bitmapData.Stride;

                    int R = cursorPosition[w];
                    int G = cursorPosition[w + 1];
                    int B = cursorPosition[w + 2];

                    acR = R * (Math.Pow((double)Math.E, -(Math.Pow((double)w - size / 2, 2) + Math.Pow((double)h - size / 2, 2)) / (2 * Math.Pow((double)radius, 2))));
                    acG = G * (Math.Pow((double)Math.E, -(Math.Pow((double)w - size / 2, 2) + Math.Pow((double)h - size / 2, 2)) / (2 * Math.Pow((double)radius, 2))));
                    acB = B * (Math.Pow((double)Math.E, -(Math.Pow((double)w - size / 2, 2) + Math.Pow((double)h - size / 2, 2)) / (2 * Math.Pow((double)radius, 2))));

                    cursorPosition[w] = (byte)acR;
                    cursorPosition[w + 1] = (byte)acG;
                    cursorPosition[w + 2] = (byte)acB;
                }
            }
            newBitmap.UnlockBits(bitmapData);
            return newBitmap;
        }
    }
}
