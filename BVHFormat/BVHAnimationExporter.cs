using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVHFormat
{
    /// <summary>
    /// Exports the animation to BVH
    /// </summary>
    [MoCapPluginLib.AdvertiseSettings(Name = "BVH Animation")]
    public class BVHAnimationExporter : MoCapPluginLib.IAnimationExporter
    {
    }
}
