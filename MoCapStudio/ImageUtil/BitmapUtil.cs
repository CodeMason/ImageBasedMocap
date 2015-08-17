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
                using (Graphics g = Graphics.FromImage(ret))
                {
                    g.DrawImage(images[i], i * targetSize.Width, 0);
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

        public static List<Bitmap> FromStrip(Bitmap input, int count)
        {
            List<Bitmap> ret = new List<Bitmap>();
            int widthEach = input.Width / count;
            int height = input.Height;

            for (int i = 0; i < count; ++i)
            {
                Bitmap bmp = new Bitmap(widthEach, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(input, 0, 0, new Rectangle(i * widthEach, 0, widthEach, height), GraphicsUnit.Pixel);
                }
                ret.Add(bmp);
            }
            return ret;
        }
    }
}
