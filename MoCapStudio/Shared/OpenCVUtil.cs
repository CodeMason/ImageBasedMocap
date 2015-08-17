using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoCapStudio.Shared
{
    public static class OpenCVUtil
    {
        public static IplImage IplImageFromBitmap(Bitmap bitmap)
        {
            IplImage ret = new IplImage(bitmap.Width, bitmap.Height, BitDepth.U8, 3);
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                    ret[y, x] = bitmap.GetPixel(x, y).ToCVColor();
            }
            return ret;
        }

        public static Bitmap BitmapFromIplImage(IplImage img)
        {
            return img.ToBitmap();
        }

        public static CvColor ToCVColor(this Color color)
        {
            return new CvColor(color.R, color.G, color.B);
        }

        public static Color ToColor(this CvColor color)
        {
            return Color.FromArgb(color.R, color.G, color.B);
        }

        public static CvScalar CVScalarFromColor(Color color, bool alpha = false)
        {
            if (alpha)
                return new CvScalar(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);
            else
                return new CvScalar(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
        }

        public static void Write(this CvMat matrix, XmlElement parent, string elemName)
        {
            XmlElement me = parent.OwnerDocument.CreateElement(elemName);
            me.SetAttribute("cols", matrix.Cols.ToString());
            me.SetAttribute("rows", matrix.Rows.ToString());
            me.SetAttribute("type", matrix.ElemType.ToString());
            StringBuilder sb = new StringBuilder();
            switch (matrix.ElemType)
            {
                case MatrixType.F32C1:
                    for (int x = 0; x < matrix.Cols; ++x)
                    {
                        for (int y = 0; y < matrix.Rows; ++y)
                        {
                            if (sb.Length > 0)
                                sb.Append(", ");
                            sb.Append(matrix.Get2D(x, y).Val0);
                        }
                    }
                    break;
                case MatrixType.F64C1:
                    for (int x = 0; x < matrix.Cols; ++x)
                    {
                        for (int y = 0; y < matrix.Rows; ++y)
                        {
                            if (sb.Length > 0)
                                sb.Append(", ");
                            sb.Append(matrix.Get2D(x, y).Val0);
                        }
                    }
                    break;
                default:
                    throw new Exception("Write unsupported MatrixType " + matrix.ElemType);
            }
            me.SetAttribute("values", sb.ToString());
        }

        public static void Read(out CvMat matrix, XmlElement element)
        {
            int cols = int.Parse(element.GetAttribute("cols"));
            int rows = int.Parse(element.GetAttribute("rows"));
            MatrixType matType = (MatrixType)Enum.Parse(typeof(MatrixType), element.GetAttribute("type"));
            string terms = element.GetAttribute("values");
            List<double> values = new List<double>();
            string[] words = terms.Split(',');
            foreach (string w in words)
                values.Add(double.Parse(w.Trim()));

            switch (matType)
            {
                case MatrixType.F32C1:
                    break;
                case MatrixType.F64C1:
                    break;
                default:
                    throw new Exception("Read unsupported MatrixType " + matType.ToString());
            }
            matrix = new CvMat(rows, cols, matType);

            // Fill the matrix popping values off
            for (int x = 0; x < cols; ++x)
            {
                for (int y = 0; y < rows; ++y)
                {
                    matrix.Set2D(x, y, new CvScalar(values[0]));
                    values.RemoveAt(0);
                }
            }
        }
    }
}
