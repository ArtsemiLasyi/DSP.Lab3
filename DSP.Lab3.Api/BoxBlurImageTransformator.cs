using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace DSP.Lab3.Api
{
    public class BoxBlurImageTransformator : ImageTransformator
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

            for (int i = 0; i < newBitmap.Height; i++ )
            {
                for (int j = 0; j < newBitmap.Width * pixelSize; j += pixelSize)
                {
                    byte* cursorPosition = (byte*)bitmapData.Scan0 + i * bitmapData.Stride;

                    int red = 0;
                    int green = 0;
                    int blue = 0;

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

                            red += data[index + indexX + 2];
                            green += data[index + indexX + 1];
                            blue += data[index + indexX];

                            counter++;
                        }
                    }

                    cursorPosition[j + 2] = (byte)(red / counter);
                    cursorPosition[j + 1] = (byte)(green / counter);
                    cursorPosition[j] = (byte)(blue / counter);
                }
            }
            newBitmap.UnlockBits(bitmapData);

            return newBitmap;
        }
    }
}
