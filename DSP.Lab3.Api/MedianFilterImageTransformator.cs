using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
namespace DSP.Lab3.Api
{
    public class MedianFilterImageTransformator : ImageTransformator
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

            for (int i = 0; i < newBitmap.Height; i++)
            {
                for (int j = 0; j < newBitmap.Width * pixelSize; j += pixelSize)
                {
                    byte* cursorPosition = (byte*)bitmapData.Scan0 + i * bitmapData.Stride;

                    int delta = windowSize / 2;

                    int counter = 0;

                    List<int> redValues = new List<int>();
                    List<int> blueValues = new List<int>();
                    List<int> greenValues = new List<int>();
                    List<int> alphaValues = new List<int>();

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

                            alphaValues.Add((int)(data[index + indexX + 3]));
                            redValues.Add((int)(data[index + indexX + 2]));
                            greenValues.Add((int)(data[index + indexX + 1]));
                            blueValues.Add((int)(data[index + indexX]));

                            counter++;
                        }
                    }

                    alphaValues.Sort();
                    redValues.Sort();
                    greenValues.Sort();
                    blueValues.Sort();

                    cursorPosition[j + 3] = (byte)(alphaValues[counter / 2 - 1]);
                    cursorPosition[j + 2] = (byte)(redValues[counter / 2 - 1]);
                    cursorPosition[j + 1] = (byte)(greenValues[counter / 2 - 1]);
                    cursorPosition[j] = (byte)(blueValues[counter / 2 - 1]);
                }
            }
            newBitmap.UnlockBits(bitmapData);

            return newBitmap;
        }
    }
}
