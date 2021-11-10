using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

                    int redX = 0;
                    int greenX = 0;
                    int blueX = 0;
                    int redY = 0;
                    int greenY = 0;
                    int blueY = 0;

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

                        byte* otherCursorPosition = (byte*)bitmapData.Scan0 + indexY * bitmapData.Stride;
                        for (int s = 0; s < windowSize * pixelSize; s += pixelSize)
                        {
                            int indexX = s + j - delta * pixelSize;
                            if (indexX < 0 || indexX > (newBitmap.Width - 1) * pixelSize)
                            {
                                continue;
                            }

                            redX += otherCursorPosition[indexX + 1] * kernelX[k, s / pixelSize];
                            greenX += otherCursorPosition[indexX + 2] * kernelX[k, s / pixelSize];
                            blueX += otherCursorPosition[indexX + 3] * kernelX[k, s / pixelSize];
                            redY += otherCursorPosition[indexX + 1] * kernelY[k, s / pixelSize];
                            greenY += otherCursorPosition[indexX + 2] * kernelY[k, s / pixelSize];
                            redY += otherCursorPosition[indexX + 3] * kernelY[k, s / pixelSize];

                            counter++;
                        }
                    }

                    int red = (byte)Math.Sqrt(
                        Math.Pow(redX, 2)
                        + Math.Pow(redY, 2)
                    );
                    int green = (byte)Math.Sqrt(
                        Math.Pow(greenX, 2)
                        + Math.Pow(greenY, 2)
                    );
                    int blue = (byte)Math.Sqrt(
                        Math.Pow(blueX, 2)
                        + Math.Pow(blueY, 2)
                    );

                    cursorPosition[j] = 255;
                    cursorPosition[j + 1] = (byte)(red / Math.Pow(windowSize, 2));
                    cursorPosition[j + 2] = (byte)(green / Math.Pow(windowSize, 2));
                    cursorPosition[j + 3] = (byte)(blue / Math.Pow(windowSize, 2));
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
