using MoCapPluginLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapStudio.Data
{
    public class ProcessingSettings
    {
        public ProcessingSettings()
        {
            RotationalDamping = 0.5f;
            RetargetAgainst = "";
            WorldOffset = new Vector3(1, 1, 1);
            WorldScale = new Vector3(1, 1, 1);
        }

        public float RotationalDamping { get; set; }

        public string RetargetAgainst { get; set; }

        public Vector3 WorldOffset { get; set; }

        public Vector3 WorldScale { get; set; }
    }
}
