using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoCapStudio.Shared
{
    public class FrameEventArgs : EventArgs
    {
        public Bitmap Image { get; set; }
    }

    public delegate void FrameEventHandler(object sender, FrameEventArgs args);

    public interface IMocapRecorder
    {
        string Name { get; }
        int Width { get; }
        int Height { get; }
        int Framerate { get; }
        Calibration.CameraCalibrationData Calibration { get; set; }
        void Snapshot();
        void StartRecording();
        void StopRecording();
        void Read(XmlElement element);
        void Write(XmlElement parent);
        AForge.Video.IVideoSource GetSource();

        event FrameEventHandler OnFrame;
    }
}
