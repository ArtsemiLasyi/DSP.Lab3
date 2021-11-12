using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
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

            int bytes = bitmapData.Stride * bitmapData.Height;
            IntPtr scan = bitmapData.Scan0;
            byte[] data = new byte[bytes];
            Marshal.Copy(scan, data, 0, bytes);

            double[] coefs = GetCoefficients(windowSize);

            for (int i = 0; i < newBitmap.Height; i++)
            {
                for (int j = 0; j < newBitmap.Width * pixelSize; j += pixelSize)
                {
                    byte* cursorPosition = (byte*)bitmapData.Scan0 + i * bitmapData.Stride;

                    double red = 0;
                    double green = 0;
                    double blue = 0;

                    int delta = windowSize / 2;

                    int counter = 0;

                    for (int k = 0; k < windowSize; k++)
                    {
                        int indexY = k + i - delta;
                        if (indexY < 0 || indexY > newBitmap.Height - 1)
                        {
                            continue;
                        }

                        int index = indexY * bitmapData.Stride;
                        for (int s = 0; s < windowSize * pixelSize; s += pixelSize)
                        {
                            int indexX = s + j - delta * pixelSize;
                            if (indexX < 0 || indexX > (newBitmap.Width - 1) * pixelSize)
                            {
                                continue;
                            }

                            red += (data[index + indexX + 2] * coefs[counter]);
                            green += (data[index + indexX + 1] * coefs[counter]);
                            blue += (data[index + indexX] * coefs[counter]);

                            counter++;
                        }
                    }

                    cursorPosition[j + 2] = (byte)(red);
                    cursorPosition[j + 1] = (byte)(green);
                    cursorPosition[j] = (byte)(blue);
                }
            }
            newBitmap.UnlockBits(bitmapData);

            return newBitmap;
        }

        private double[] GetCoefficients(int windowSize)
        {
            double sigma = ((double)windowSize / 6);

            double[] coefs = new double[windowSize * windowSize];

            for (int i = 0; i < windowSize * windowSize; i++)
            {
                int row = i / windowSize + 1;
                int place = i % windowSize + 1;

                double xSquare = Math.Pow(row - (windowSize / 2 + 1), 2);
                double ySquare = Math.Pow(place - (windowSize / 2 + 1), 2);
                coefs[i] = 
                    (1 / (2 * Math.PI * Math.Pow(sigma, 2))) 
                    * Math.Pow(
                        Math.E, 
                        -(xSquare + ySquare) / (2 * Math.Pow(sigma, 2))
                    );
            }

            double sum = coefs.Sum();


            for (int i = 0; i < windowSize * windowSize; i++)
            {
                coefs[i] /= sum ;
            }

            double anotherSum = coefs.Sum();
            double max = coefs.Max();
            int index;
            for (int i = 0; i < coefs.Length; i++)
            {
                if (coefs[i] == max)
                {
                    index = i;
                }
            }


            return coefs;
        }
    }
}
