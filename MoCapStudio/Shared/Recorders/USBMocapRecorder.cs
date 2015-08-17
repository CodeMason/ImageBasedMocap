using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoCapStudio.Shared.Recorders
{
    /// <summary>
    /// USB/Directshow mocap recorder
    /// </summary>
    public class USBMocapRecorder : IMocapRecorder
    {
        bool created_ = false;
        AForge.Video.DirectShow.VideoCaptureDevice device_;

        private USBMocapRecorder() { }

        public USBMocapRecorder(AForge.Video.DirectShow.VideoCaptureDevice device, string name, string moniker)
        {
            device_ = device;
            Name = name;
            Moniker = moniker;
        }

        public string Name
        {
            get;
            set;
        }

        public string Moniker { get; set; }

        public override string ToString()
        {
            return Name != null ? Name : Moniker;
        }

        public void Snapshot()
        {
            throw new NotImplementedException();
        }

        void Create()
        {
            if (!created_)
            {
                device_.NewFrame += device__NewFrame;
                created_ = true;
            }
        }

        void device__NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (OnFrame != null)
                OnFrame.Invoke(this, new FrameEventArgs { Image = eventArgs.Frame });
        }

        public void StartRecording()
        {
            if (!created_)
                Create();
            if (device_ != null)
                device_.Start();
        }

        public void StopRecording()
        {
            if (device_ != null)
                device_.Stop();
        }

        public int Width
        {
            get
            {
                if (device_ != null)
                    return device_.VideoResolution.FrameSize.Width;
                return -1;
            }
        }

        public int Height
        {
            get
            {
                if (device_ != null)
                    return device_.VideoResolution.FrameSize.Height;
                return -1;
            }
        }

        public int Framerate
        {
            get
            {
                if (device_ != null)
                    return device_.VideoResolution.AverageFrameRate;
                return -1;
            }
        }

        public void Read(XmlElement element)
        {
            try
            {
                Name = element.GetAttribute("name");
                Moniker = element.GetElementsByTagName("moniker")[0].InnerText; ;
                device_ = new AForge.Video.DirectShow.VideoCaptureDevice(Moniker);
                XmlNodeList calib = element.GetElementsByTagName("CameraCalibrationData");
                if (calib.Count > 0)
                {
                    Calibration = new Calibration.CameraCalibrationData();
                    Calibration.Read(calib[0] as XmlElement);
                }
            } 
            catch (Exception ex)
            {
                ErrorHandler.GetInst().PushError(ex);
            }
        }
        public void Write(XmlElement parent)
        {
            XmlElement element = parent.OwnerDocument.CreateElement("usb-camera");
            element.SetAttribute("name", Name);
            parent.AppendChild(element);
            XmlElement moniker = element.OwnerDocument.CreateElement("moniker");
            moniker.InnerText = Moniker;
            element.AppendChild(moniker);

            if (Calibration != null)
                Calibration.Write(element);
        }

        public static USBMocapRecorder Construct(XmlElement element)
        {
            USBMocapRecorder rec = new USBMocapRecorder();
            rec.Read(element);
            return rec;
        }


        public Calibration.CameraCalibrationData Calibration
        {
            get;
            set;
        }


        public event FrameEventHandler OnFrame;


        public AForge.Video.IVideoSource GetSource()
        {
            return device_;
        }
    }
}
