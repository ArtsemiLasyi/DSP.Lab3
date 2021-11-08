using System.Drawing;

namespace DSP.Lab3.Api
{
    public abstract class ImageTransformator
    {
        public abstract Bitmap Transform(Bitmap bitmap);
    }
}
