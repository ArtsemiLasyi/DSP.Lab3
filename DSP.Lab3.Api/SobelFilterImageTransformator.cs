using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace DSP.Lab3.Api
{
    public class SobelFilterImageTransformator : ImageTransformator
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

            for (int i = 0; i < newBitmap.Height; i++)
            {
                for (int j = 0; j < newBitmap.Width * pixelSize; j += pixelSize)
                {
                    byte* cursorPosition = (byte*)bitmapData.Scan0 + i * bitmapData.Stride;

                    double rgb = (cursorPosition[j + 2] * 0.071) + (cursorPosition[j] * 0.21) + (cursorPosition[j + 1] * 0.71);

                    cursorPosition[j] = (byte)rgb;
                    cursorPosition[j + 1] = (byte)rgb;
                    cursorPosition[j + 2] = (byte)rgb;
                    cursorPosition[j + 3] = (byte)255;
                }
            }

            int bytes = bitmapData.Stride * bitmapData.Height;
            IntPtr scan = bitmapData.Scan0;
            byte[] data = new byte[bytes];
            Marshal.Copy(scan, data, 0, bytes);

            for (int i = 0; i < newBitmap.Height; i++)
            {
                for (int j = 0; j < newBitmap.Width * pixelSize; j += pixelSize)
                {
                    byte* cursorPosition = (byte*)bitmapData.Scan0 + i * bitmapData.Stride;

                    double redX = 0;
                    double greenX = 0;
                    double blueX = 0;
                    double redY = 0;
                    double greenY = 0;
                    double blueY = 0;

                    int delta = windowSize / 2;

                    int counter = 0;

                    int[,] kernelX = GetKernelX(windowSize);
                    int[,] kernelY = GetKernelY(windowSize);

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

                            redX += data[index + indexX + 2] * kernelX[k, s / pixelSize];
                            greenX += data[index + indexX + 1] * kernelX[k, s / pixelSize];
                            blueX += data[index + indexX] * kernelX[k, s / pixelSize];
                            redY += data[index + indexX + 2] * kernelY[k, s / pixelSize];
                            greenY += data[index + indexX + 1] * kernelY[k, s / pixelSize];
                            blueY += data[index + indexX] * kernelY[k, s / pixelSize];

                            counter++;
                        }
                    }

                    double red = Math.Sqrt(
                        Math.Pow(redX, 2)
                        + Math.Pow(redY, 2)
                    );
                    double green = Math.Sqrt(
                        Math.Pow(greenX, 2)
                        + Math.Pow(greenY, 2)
                    );
                    double blue = Math.Sqrt(
                        Math.Pow(blueX, 2)
                        + Math.Pow(blueY, 2)
                    );

                    if (red > 255)
                    {
                        red = 255;
                    }
                    if (green > 255)
                    {
                        green = 255;
                    }
                    if (blue > 255)
                    {
                        blue = 255;
                    }

                    cursorPosition[j] = (byte)blue;
                    cursorPosition[j + 1] = (byte)green;
                    cursorPosition[j + 2] = (byte)red;
                    cursorPosition[j + 3] = 255;
                }
            }
            newBitmap.UnlockBits(bitmapData);

            return newBitmap;
        }

        private int[,] GetKernelX(int windowSize)
        {
            int[,] matrix = new int[windowSize, windowSize];
            for (int i = 0; i < windowSize; i++)
            {
                for (int j = 0; j < windowSize; j++)
                {
                    if (j == 0 || j == windowSize - 1)
                    {
                        matrix[i, j] = Math.Min(i + 1, windowSize - i);

                        if (j == 0)
                        {
                            matrix[i, j] = - matrix[i, j];
                        }
                    }
                }
            }
            return matrix;
        }

        private int[,] GetKernelY(int windowSize)
        {
            int[,] matrix = new int[windowSize, windowSize];
            for (int i = 0; i < windowSize; i++)
            {
                for (int j = 0; j < windowSize; j++)
                {
                    if (i == 0 || i == windowSize - 1)
                    {
                        matrix[i, j] = Math.Min(j + 1, windowSize - j);

                        if (i == 0)
                        {
                            matrix[i, j] = -matrix[i, j];
                        }
                    }
                }
            }
            return matrix;
        }
    }
}
