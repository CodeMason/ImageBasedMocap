using AForge.Video.VFW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MoCapStudio.Recording.Writers
{
    public class AVIVideoWriter : IVideoWriter
    {
        AVIWriter writer_;

        public string FileName { get; set; }
        public Size OutputSize { get; set; }

        public void Start()
        {
            writer_ = new AVIWriter();
            writer_.Open(FileName, OutputSize.Width, OutputSize.Height);
        }

        public void PushFrame(System.Drawing.Bitmap frame)
        {
            writer_.AddFrame(frame);
        }

        public void Finish()
        {
            Dispose();
        }

        public void Cancel()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (writer_ != null)
            {
                writer_.Close();
                writer_.Dispose();
                writer_ = null;
            }
        }
    }
}
