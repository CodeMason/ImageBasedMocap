using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoCapStudio.Shared.Recorders
{
    /// <summary>
    /// IPCamera based motion capture recorder
    /// </summary>
    public class IPMocapRecorder : IMocapRecorder
    {
        int width_;
        int height_;
        int frameRate_;
        AForge.Video.IVideoSource stream_;

        public bool IsMJPEG { get; set; }
        public string Uri { get; set; }

        IPMocapRecorder()
        {

        }

        public IPMocapRecorder(string uri, bool mjpeg)
        {
            Name = Uri = uri;
            IsMJPEG = mjpeg;
        }

        public override string ToString()
        {
            return "IP Cam: " + Name;
        }

        public string Name { get; private set; }

        void Create()
        {
            if (IsMJPEG)
                stream_ = new AForge.Video.MJPEGStream(Uri);
            else
                stream_ = new AForge.Video.JPEGStream(Uri);
            stream_.NewFrame += stream__NewFrame;
        }

        void stream__NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (OnFrame != null)
                OnFrame.Invoke(sender, new FrameEventArgs { Image = eventArgs.Frame });
        }

        public void Snapshot()
        {
            if (stream_ == null)
                Create();
        }

        public void StartRecording()
        {
            if (stream_ == null)
                Create();
            if (stream_ != null)
            {
                stream_.Start();
            }
        }

        public void StopRecording()
        {
            if (stream_ == null)
                Create();
            if (stream_ != null)
                stream_.Start();
        }

        public int Width {
            get { return width_; }
            set { width_ = value; }
        }

        public int Height {
            get { return height_; }
            set { height_ = value; }
        }

        public int Framerate
        {
            get { return frameRate_; }
            set { frameRate_ = value; }
        }


        public void Read(XmlElement element)
        {
            Uri = element.GetAttribute("address");
            IsMJPEG = element.GetAttribute("mjpeg").Equals("True");
            XmlNodeList calib = element.GetElementsByTagName("CameraCalibrationData");
            if (calib.Count > 0)
            {
                Calibration = new Calibration.CameraCalibrationData();
                Calibration.Read(calib[0] as XmlElement);
            }
        }

        public void Write(XmlElement parent)
        {
            XmlElement element = parent.OwnerDocument.CreateElement("ip-camera");
            element.SetAttribute("address", Uri);
            element.SetAttribute("mjpeg", IsMJPEG ? "True" : "False");
            parent.AppendChild(element);
            if (Calibration != null)
                Calibration.Write(element);
        }

        public static IPMocapRecorder Construct(XmlElement element)
        {
            IPMocapRecorder ret = new IPMocapRecorder();
            ret.Read(element);
            return ret;
        }


        public Calibration.CameraCalibrationData Calibration
        {
            get;
            set;
        }


        public event FrameEventHandler OnFrame;


        public AForge.Video.IVideoSource GetSource()
        {
            if (stream_ == null)
                Create();
            return stream_;
        }
    }
}
