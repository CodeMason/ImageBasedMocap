using MoCapStudio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoCapStudio.Data
{
    public class GlobalData
    {
        static GlobalData inst_;
        GlobalData()
        {
            Cameras = new CameraCollection();
        }

        public static GlobalData GetInst()
        {
            if (inst_ == null)
                inst_ = new GlobalData();
            return inst_;
        }

        public CameraCollection Cameras { get; private set; }

        public void Load(string file)
        {
            Cameras.ReadMetadata(file);
        }

        public void Save(string file)
        {
            Cameras.WriteMetadata(file);
        }
    }
}
