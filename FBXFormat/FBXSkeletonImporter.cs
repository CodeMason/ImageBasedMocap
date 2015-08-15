using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBXFormat
{
    /// <summary>
    /// Constructs a skeleton from FBX data.
    /// </summary>
    [MoCapPluginLib.AdvertiseSettings(Name = "FBX Model Skeleton")]
    public class FBXSkeletonImporter : MoCapPluginLib.ISkeletonImporter
    {
        public MoCapPluginLib.Skeleton ReadSkeleton(string fileName)
        {
            return null;
        }
    }
}
