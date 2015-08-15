using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoCapStudio.Shared
{
    public class CameraCollection : ObservableCollection<IMocapRecorder>
    {
        public Calibration.SpaceCalibrationData SpacialCalibration { get; set; }

        /// <summary>
        /// Persists camera configuration into XML
        /// </summary>
        /// <param name="fileName"></param>
        public void WriteMetadata(String fileName)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("RecordingConfig");
            doc.AppendChild(root);
            Write(root);
            doc.Save(fileName);
        }

        public void Write(XmlElement parent)
        {
            foreach (IMocapRecorder camera in this)
                camera.Write(parent);
            if (SpacialCalibration != null)
                SpacialCalibration.Write(parent);
        }

        /// <summary>
        ///  Reconstruct from XML configuration
        /// </summary>
        /// <param name="filename">XML file to load</param>
        public void ReadMetadata(String filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            Read(doc.DocumentElement);
        }

        void Read(XmlElement me)
        {
            Clear();

            foreach (XmlNode node in me.ChildNodes)
            {
                if (node.Name.Equals("usb-camera"))
                    Add(Shared.Recorders.USBMocapRecorder.Construct(node as XmlElement));
                else if (node.Name.Equals("ip-camera"))
                    Add(Shared.Recorders.IPMocapRecorder.Construct(node as XmlElement));
                else if (node.Name.Equals("SpaceCalibrationData"))
                {
                    SpacialCalibration = new Calibration.SpaceCalibrationData();
                    SpacialCalibration.Read(node as XmlElement);
                }
            }
        }
    }
}
