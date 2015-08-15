using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapStudio.ImageUtil
{
    public static class BitmapUtil
    {
        public static Bitmap ToStrip(List<Bitmap> images, Size targetSize)
        {
            // Enforce the sizes
            int width = targetSize.Width * images.Count;
            int height = targetSize.Height;
            for (int i = 0; i < images.Count; ++i)
                images[i] = ScaleBitmap(images[i], targetSize);

            // Convert into a strip image
            Bitmap ret = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < images.Count; ++i)
            {
                for (int x = 0; x < targetSize.Width; ++x)
                {
                    for (int y = 0; y < targetSize.Height; ++y)
                        ret.SetPixel(x + (i * targetSize.Width), y, images[i].GetPixel(x, y));
                }
            }
            return ret;
        }

        public static Bitmap ScaleBitmap(Bitmap input, Size targetSize)
        {
            if (input.Width == targetSize.Width && input.Height == targetSize.Height)
                return input;
            return new Bitmap(input, targetSize);
        }
    }
}
