using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBXFormat
{
    /// <summary>
    /// Exports the animation in the FBX format.
    /// </summary>
    [MoCapPluginLib.AdvertiseSettings(Name = "FBX Animation")]
    public class FBXAnimationExporter : MoCapPluginLib.IAnimationExporter
    {
    }
}
