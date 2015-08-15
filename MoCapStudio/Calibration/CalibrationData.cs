using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoCapStudio.Shared;

namespace MoCapStudio.Calibration
{
    /// <summary>
    /// Lens calibration for a camera
    /// </summary>
    public class CameraCalibrationData
    {
        public CvMat Rotation { get; set; }
        public CvMat Translation { get; set; }
        public CvMat Intrinsic { get; set; }
        public CvMat Distortion { get; set; }
        public bool IsValid { get; set; }

        public bool Valid()
        {
            if (Rotation == null || Translation == null || Intrinsic == null || Distortion == null)
                return false;
            return IsValid;
        }

        public void Write(XmlElement parent)
        {
            XmlElement me = parent.OwnerDocument.CreateElement("CameraCalibrationData");

            if (Rotation != null)
                Rotation.Write(me, "rotation");
            if (Translation != null)
                Translation.Write(me, "translation");
            if (Intrinsic != null)
                Intrinsic.Write(me, "intrinsic");
            if (Distortion != null)
                Distortion.Write(me, "distortion");

            parent.AppendChild(me);
        }

        public void Read(XmlElement me)
        {
            foreach (XmlNode node in me.ChildNodes)
            {
                if (node is XmlElement)
                {

                    if (node.Name == "rotation")
                    {
                        CvMat mat;
                        OpenCVUtil.Read(out mat, node as XmlElement);
                        Rotation = mat;
                    } 
                    else if (node.Name == "translation")
                    {
                        CvMat mat;
                        OpenCVUtil.Read(out mat, node as XmlElement);
                        Translation = mat;
                    }
                    else if (node.Name == "intrinsic")
                    {
                        CvMat mat;
                        OpenCVUtil.Read(out mat, node as XmlElement);
                        Intrinsic = mat;
                    }
                    else if (node.Name == "distortion")
                    {
                        CvMat mat;
                        OpenCVUtil.Read(out mat, node as XmlElement);
                        Distortion = mat;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Contains relational offset matrices of each camera from the first camera
    /// </summary>
    public class SpaceCalibrationData
    {
        static string[] CameraNames = {
        "one", 
        "two", 
        "three", 
        "four", 
        "five", 
        "six", 
        "seven", 
        "eight", 
        "nine", 
        "ten", 
        "eleven",
        "twelve",
        "thirteen",
        "fourteen",
        "fifteen",
        "sixteen",
        "seventeen",
        "eighteen",
        "nineteen",
        "twenty",
        "twenty-one",
        "twenty-two",
        "twenty-three",
        "twenty-four"
        };

        public SpaceCalibrationData()
        {
            OffsetMatrices = new List<CvMat>();
        }

        public List<CvMat> OffsetMatrices { get; private set; }

        public void Write(XmlElement parent)
        {
            XmlElement elem = parent.OwnerDocument.CreateElement("SpaceCalibration");

            for (int i = 0; i < OffsetMatrices.Count; ++i)
                OffsetMatrices[i].Write(elem, CameraNames[i]);

            parent.AppendChild(elem);
        }

        public void Read(XmlElement me)
        {
            foreach (XmlNode node in me.ChildNodes)
            {
                if (CameraNames.Contains(node.Name))
                {
                    CvMat mat;
                    OpenCVUtil.Read(out mat, node as XmlElement);
                    OffsetMatrices.Add(mat);
                }
            }
        }
    }
}
