using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace DSP.Lab3.Api
{
    public class SobelFilterImageTransformator : ImageTransformator
    {
        public override Bitmap Transform(Bitmap bitmap, int windowSize)
        {
            Bitmap newBitmap = new Bitmap(bitmap);

            int[,] kernelY = GetKernelY(windowSize);
            int[,] kernelX = GetKernelX(windowSize);

            BitmapData bitmapData = newBitmap.LockBits(
                new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                ImageLockMode.ReadWrite,
                newBitmap.PixelFormat
            );

            int pixelSize = Image.GetPixelFormatSize(newBitmap.PixelFormat) / 8; // число бит на пиксель

            for (int i = 1; i <= newBitmap.Height - 2; i++)
            {
                for (int j = 1; j <= newBitmap.Width - 2; j++)
                {

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
